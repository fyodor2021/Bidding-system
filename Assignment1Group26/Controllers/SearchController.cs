using Assignment1Group26.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult Sort(string Search, int selectedCategories, int selectedAsset, int selectedPriceRange) {
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
                    tables.Bids = tables.Bids.OrderByDescending(b => b.BidStartPrice).ToList();
                 }
                else {
                    tables.Bids = tables.Bids.OrderBy(b => b.BidStartPrice).ToList(); 
                }
                   
                    
            }
            if (!String.IsNullOrEmpty(Search))
            {
               tables.Bids = tables.Bids.Where(b => b.BidName.Contains(Search, StringComparison.OrdinalIgnoreCase)).ToList();


            }


            return View("../Home/Index", tables);
        }









    }
}
