using Assignment1Group26.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment1Group26.Controllers
{
    public class DetailsController : Controller
    {
        private ApplicationDbContext _context;
        public DetailsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Details(int id)
        {

            var b = _context.bids.Include(c => c.AssetCondition).Include(c => c.Category).Include(c => c.Client).FirstOrDefault(b => b.BidId == id);
            return View(b);
        }
    }
}
