using Assignment1Group26.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Assignment1Group26.Controllers
{
    [Authorize]
    public class SellController : Controller
    {
        private ApplicationDbContext _context;
        private IWebHostEnvironment webHostEnvironment;
        public SellController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var clientUserName = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var client = _context.clients.FirstOrDefault(c => c.ClientUserName == clientUserName);
            if (client.EmailConfimed == true)
            {
                int clientId = client.ClientId;
                var bids = _context.bids.Where(b => b.ClientId == clientId).ToList();
               
                return View(bids);
            }
            return View("../Email/EmailVerifyPage");
        }
        [HttpGet]
        public IActionResult Add()
        {
            
            ViewBag.Action = "Add";
            ViewBag.Categories = _context.categories.OrderBy(c => c.CategoryName).ToList();
            ViewBag.AssetCondition = _context.assetConditions.ToList();

            return View(new Bid());
        }
        [HttpPost]
        public async Task<IActionResult> Add(Bid b)
        {
            var userName = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var user = _context.clients.FirstOrDefault(c => c.ClientUserName == userName);
            b.ClientId = user.ClientId;
            string action = (b.BidId == 0) ? "Add" : "Edit";
            await b.SaveImageAsync(webHostEnvironment);
            if (ModelState.IsValid)
            {
                if (action == "Add")
                {
                    _context.bids.Add(b);

                } else{

                    _context.bids.Update(b);
                }

            }

            else
            {
                // Validation failed
                ViewBag.Action = action;
                ViewBag.Categories = _context.categories.OrderBy(c => c.CategoryName).ToList();
                ViewBag.AssetCondition = _context.assetConditions.ToList();
                ViewBag.Image = b.ImagePath;

                return View(new Bid());
            }

                _context.SaveChanges();
                return RedirectToAction("Index", "Sell");
        }
       
     
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";

            ViewBag.Categories = _context.categories.OrderBy(c => c.CategoryName).ToList();
            ViewBag.AssetCondition = _context.assetConditions.ToList();
            var b = _context.bids
                .Include(c => c.Category).Include(a => a.AssetCondition).FirstOrDefault(b => b.BidId == id);
            ViewBag.Image = b.ImagePath;
            var bb = b.BidId;

            return View("Add",b);

        }




        [HttpGet]
        public IActionResult Delete(int id)
        {
            var bid = _context.bids.FirstOrDefault(b => b.BidId == id);
            return View(bid);
        }

        [HttpPost]
        public IActionResult Deleting(int id)
        {
            var b = _context.bids.FirstOrDefault(b => b.BidId == id);
           _context.bids.Remove(b);
            _context.SaveChanges();

            var lastId = _context.bids.Max(b => b.BidId);


        

            return RedirectToAction("Index", "Sell");
        }


        public IActionResult Details(int id)
        {
            var b = _context.bids.Include(c=>c.AssetCondition).Include(c => c.Category).FirstOrDefault(b => b.BidId == id);
            return View(b);
        }


     

    }
}
