using Assignment1Group26.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
namespace Assignment1Group26.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
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
                        bid.expired = true;
                        bid.Status = false;
                        _context.bids.Update(bid);
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

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login","Login");
        }
    }
}

