using Assignment1Group26.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
        [HttpPost]
        public IActionResult Sort(int selectedCategories, int selectedAsset, int selectedPriceRange) {

            var tables = new HomeViewModel
            {
                Bids = _context.bids.ToList(),
                Categories = _context.categories.ToList(),
                AssetConditions = _context.assetConditions.ToList()

            };



            if (selectedCategories != 0)
            {
                tables.Bids = tables.Bids.Where(c => c.CategoryId == selectedCategories).ToList();
            }
            if (selectedAsset != 0)
            {
                tables.Bids = tables.Bids.Where(a => a.AssetConditionId == selectedAsset).ToList();
            }
            if (selectedPriceRange != 0)
            {
                 if (selectedPriceRange == 1) {
                    tables.Bids = tables.Bids.OrderByDescending(b => b.BidCost).ToList();
                 }
                else {
                    tables.Bids = tables.Bids.OrderBy(b => b.BidCost).ToList(); 
                }
                   
                    
            }



            return View("../Home/Index", tables);
        }









    }
}
