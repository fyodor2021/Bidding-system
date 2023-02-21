using Assignment1Group26.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Assignment1Group26.Controllers
{
    [Authorize]
    public class SellController : Controller
    {
        private ApplicationDbContext _context;
        public SellController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            var clientUserName = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var client = _context.clients.FirstOrDefault(c => c.ClientUserName == clientUserName);
            if (client.EmailConfimed == true)
            {
                var bids = _context.bids.Include(c => c.Category).Include(a => a.AssetCondition).Include(u => u.Client)
                .OrderBy(b => b.BidId).ToList();
                return View(bids);
            }
            return View("../Email/EmailVerifyPage");
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Categories = _context.categories.OrderBy(c => c.CategoryName).ToList();
            ViewBag.AssetCondition = _context.AssetConditions.ToList();

            return View(new Bid());
        }
     

    }
}
