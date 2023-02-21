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
            ViewBag.AssetCondition = _context.assetConditions.ToList();

            return View(new Bid());
        }
        [HttpPost]
        public IActionResult Add(Bid b)
        {
            string action = (b.BidId == 0) ? "Add" : "Edit";


            if (ValidateDate(b))
            {
                if (b.ImageFile != null && b.ImageFile.ContentType.Contains("image"))
                {
                    string ImageUploadedFolder = Path.Combine(webHostEnvironment.WebRootPath, "Images");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + b.ImageFile.FileName;
                    string filepath = Path.Combine(ImageUploadedFolder, uniqueFileName);

                    using (var fs = new FileStream(filepath, FileMode.Create))
                    {
                        b.ImageFile.CopyTo(fs);
                    }

                    b.ImagePath = "~/Images/" + uniqueFileName;

					if (ModelState.IsValid)
					{
						if (action == "Add")
						{


							_context.bids.Add(b);

						}
						else
						{
							// Handle edit action
						}

						_context.SaveChanges();
						return RedirectToAction("Index", "Sell");
					}
				}
                return View(b);
            }
            
            else
            {
                // Validation failed
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                ViewBag.Action = action;
                ViewBag.Categories = _context.categories.OrderBy(c => c.CategoryName).ToList();
                ViewBag.AssetCondition = _context.assetConditions.ToList();
                return View(new Bid());
            }
        }


        public bool ValidateDate(Bid b)
        {
            var dt = b.BidEndDate;
            if (dt >= DateTime.Now)
            {
                return true;
            }
            return false;
        }



        [HttpGet]
        public IActionResult Delete(int id)
        {
            var bid = _context.bids.Include(c => c.Category).Include(a => a.AssetCondition).Include(u => u.Client)
             .FirstOrDefault(b => b.BidId == id);
            return View(bid);
        }

        [HttpPost]
        public IActionResult Delete(Bid b)
        {
           _context.bids.Remove(b);
            _context.SaveChanges();


            return RedirectToAction("Index", "Sell");
        }


    }
}
