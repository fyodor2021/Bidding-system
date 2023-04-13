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
        public SellController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            
            var clientUserName = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var client = _context.clients.FirstOrDefault(c => c.ClientUserName == clientUserName);
            if( client.ClientRole != "Admin")
            {
                if (client.EmailConfirmed == true)
                {
                    var sellTables = new SellViewModel
                    {
                        Bids = _context.bids.Where(b => b.ClientId == client.ClientId).ToList(),
                        Clients = _context.clients.Where(c => c.ClientId == client.ClientId).ToList()
                    };
                    foreach (var bid in sellTables.Bids)
                    {
                            if (bid.BidStartDate < DateTime.Now)
                            {
                                if (bid.BidEndDate < DateTime.Now)
                                {
                                    bid.expired = true;
                                    bid.Status = false;
                                    _context.bids.Update(bid);
                                }
                                else
                                {
                                    bid.expired = false;
                                    bid.Status = true;
                                    _context.bids.Update(bid);
                                }
                            }
                            else
                            {
                                bid.expired = false;
                                bid.Status = false;
                                _context.bids.Update(bid);
                            }
                    }
                    _context.SaveChanges();


                    return View(sellTables);
                }
            }
            else
            {
                var sellTables = new SellViewModel
                {
                    Bids = _context.bids.OrderBy(b => b.ClientId).ToList(),
                    Clients = _context.clients.ToList(),
                };
                return View(sellTables);
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
            
            DateTime newStartDate = b.BidStartDate.AddHours(b.BidStartTime.Hour).AddMinutes(b.BidStartTime.Minute).AddSeconds(b.BidStartTime.Second);
            DateTime newEndDate = b.BidEndDate.AddHours(b.BidEndTime.Hour).AddMinutes(b.BidEndTime.Minute).AddSeconds(b.BidEndTime.Second);
            b.BidStartDate = newStartDate;
            b.BidEndDate = newEndDate;
            string action = (b.BidId == 0) ? "Add" : "Edit";
            
            await b.SaveImageAsync();
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
                ViewBag.Image = "data:image/*;base64," + Convert.ToBase64String(b.ImageData); ;

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
            
            ViewBag.Image = "data:image/*;base64," + Convert.ToBase64String(b.ImageData);
            
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
