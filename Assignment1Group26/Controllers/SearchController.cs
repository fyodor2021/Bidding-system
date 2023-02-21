using Assignment1Group26.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1Group26.Controllers
{
    public class SearchController : Controller
    {
        private ApplicationDbContext _context;
        public SearchController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Search(string Search)
        {
            if (!String.IsNullOrEmpty(Search))
            {
                var items = _context.bids.Where(b => b.BidName.Contains(Search)).ToList();
                return View("../Home/Index",items);
            }
            else
            {
                var items = _context.bids.ToList();
                return View("../Home/Index", items);
            }

        }
    }
}
