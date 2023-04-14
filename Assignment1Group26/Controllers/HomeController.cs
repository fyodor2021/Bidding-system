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
using System.Security.Cryptography;
using System.IO.IsolatedStorage;

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
            bool winCheck = false;
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
                                 var theBidsPlacedByThisClient = _context.bidsPlaced.Where(bsp => bsp.ClientId == client.ClientId);
                            var thebidsPlacedByThisClientForThisItem = theBidsPlacedByThisClient.Where(c => c.BidId == bid.BidId);
                                foreach (var bidPlacedByClient in thebidsPlacedByThisClientForThisItem)
                                {
                                    if(bidPlacedByClient.BidAmount == bid.HighestBid)
                                    {

                                        sendWinningEmail(client, bid);
                                        bidPlacedByClient.WinOrLostEmailSent = true;
                                        winCheck = true;
                                    }
                                }
                                if(winCheck == false)
                                {
                                    sendLosingEmail(client, bid);
                                }
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
            _context.SaveChanges(true);

            return View(tables);
        }
        public async Task ExpiredEmail(Client cl, Bid bid)
        {
            string receiver = cl.ClientUserName;
            var subject = "Bidding Notification";
            var message = "<h1>Hello " + cl.ClientFirstName + "</h1>" +
                          "<h2>This Email is to Notify you That the Biding Period for " + bid.BidName + " Has Ended </h2>"+
                            "<h2>We Would Like to Thank you For Participating In the Bidding Process </h2>";

            await _emailSender.SendEmailAsync(receiver, subject, message);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login","Login");
        }
        public async Task sendWinningEmail(Client cl, Bid bid)
        {
            string receiver = cl.ClientUserName;
            var subject = "Bidding Notification";
            var message = "<h1>Hello " + cl.ClientFirstName + "</h1>" +
                          "<h2>This Email is to Notify you That You've Won! the Bid " + bid.BidName + "</h2>" +
                            "<h2>we Congratulate You, and Would Like to Thank you For Participating In the Bidding Process</h2>";

            await _emailSender.SendEmailAsync(receiver, subject, message);
        }
        public async Task sendLosingEmail(Client cl, Bid bid)
        {
            string receiver = cl.ClientUserName;
            var subject = "Bidding Notification";
            var message = "<h1>Hello " + cl.ClientFirstName + "</h1>" +
                          "<h2>We're Sorry to Infrom you that You've Lost the Bid " + bid.BidName + "</h2>" +
                            "<h2>We Would Like to Thank you For Participating In the Bidding Process</h2>";

            await _emailSender.SendEmailAsync(receiver, subject, message);
        }
    }
}

