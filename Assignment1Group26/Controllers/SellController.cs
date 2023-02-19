using Assignment1Group26.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

            var bids = _context.bids.Include(c => c.Category).Include(a => a.AssetCondition).Include(u => u.Client)
                .OrderBy(b => b.BidId).ToList();
            return View(bids);
        }
        public IActionResult Add()
        {
            return View();
        }
    }
}
