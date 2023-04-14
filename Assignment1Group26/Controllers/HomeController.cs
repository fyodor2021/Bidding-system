using Assignment1Group26.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Assignment1Group26.Service;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using System.Linq;

namespace Assignment1Group26.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        private IEmailSender _emailSender;
        public HomeController(ApplicationDbContext context,IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }
        

        public IActionResult Index()
        {
            var tables = new HomeViewModel
            {
                Bids = _context.bids.ToList(),
                Categories = _context.categories.ToList(),
                AssetConditions= _context.assetConditions.ToList()

            };
            foreach (var bid in tables.Bids)
            {
                if(bid.BidStartDate < DateTime.Now)
                {
                    if (bid.BidEndDate < DateTime.Now)
                    {
                        
                       
                        if (bid.expired == false)
                        {
                            var distinctBids = _context.bidsPlaced
                          .Select(bid => new { ClientId = bid.ClientId })
                          .Distinct()
                          .ToList();
                            bid.expired = true;
                            bid.Status = false;
                            _context.bids.Update(bid);
                            
                            
                          foreach (var bidPlaced in distinctBids)
                            {
                                var client = _context.clients.FirstOrDefault(c=>c.ClientId == bidPlaced.ClientId);
                               ExpiredEmail(client, bid);
                            }
                        }
                        
                    }
                    else
                    {
                        bid.expired = false;
                        bid.Status = true;
                        _context.bids.Update(bid);
                    }
                }
                else
                {
                    bid.expired = false;
                    bid.Status = false;
                    _context.bids.Update(bid);
                }
                
                
            }
            _context.SaveChanges();

            return View(tables);
        }
        public async Task ExpiredEmail(Client cl, Bid bid)
        {
            string receiver = cl.ClientUserName;
            var subject = "Bidding Notification";
            var message = "<h1>Hello " + cl.ClientFirstName + "</h1>" +
                          "<h2>This Email is to Notify you That the " + bid.BidName + " Has Ended </h2>"+
                            "<h2>We Would Like to Thank you For Participating In the Bidding Process </h2>";

            await _emailSender.SendEmailAsync(receiver, subject, message);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login","Login");
        }

    }
}

