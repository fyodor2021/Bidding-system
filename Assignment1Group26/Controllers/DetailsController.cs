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
            Bid bid = _context.bids.FirstOrDefault(b => b.BidId == id);
            var tables = new DetailsVeiwModel
            {
                BidsPlaced = _context.bidsPlaced.Where(c => c.ClientId == bid.ClientId).ToList(),
                Bid = _context.bids.Include(c => c.AssetCondition).Include(c => c.Category).Include(c => c.Client).FirstOrDefault(b => b.BidId == id)
            };
            return View(tables);
        }
    }
}
