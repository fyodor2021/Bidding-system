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
        [HttpGet]
        public IActionResult Search(string Search)
        {
            if (!String.IsNullOrEmpty(Search))
            {
                var tables = new HomeViewModel
                {
                    
                    Bids = _context.bids.Where(b => b.BidName.Contains(Search)).ToList(),
                    Categories = _context.categories.ToList(),
                    AssetConditions = _context.assetConditions.ToList()

                };

                return View("../Home/Index",tables);
            }
            else
            {
                var tables = new HomeViewModel
                {
                    Bids = _context.bids.ToList(),
                    Categories = _context.categories.ToList(),
                    AssetConditions = _context.assetConditions.ToList()

                };

                return View("../Home/Index", tables);
            }

        }
    }
}
