using Assignment1Group26.Models;
using Assignment1Group26.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Assignment1Group26.Controllers
{
    public class DetailsController : Controller
    {
        private ApplicationDbContext _context;
        private IEmailSender _emailSender;
        public DetailsController(ApplicationDbContext context, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }
        public IActionResult Details(int id)
        {
            Bid bid = _context.bids.FirstOrDefault(b => b.BidId == id);
            var tableBid = _context.bids.Include(c => c.AssetCondition).Include(c => c.Category).Include(c => c.Client).FirstOrDefault(b => b.BidId == id);
            var tables = new DetailsVeiwModel
            {
                BidPlaced = _context.bidsPlaced.Where(b => b.ClientId == bid.ClientId).OrderByDescending(b => b.BidId).LastOrDefault(),
                Bid = tableBid
            };
            return View(tables);
        }
        public IActionResult Add(DetailsVeiwModel dvm)
        {
            var clientUserName = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var bid = _context.bids.FirstOrDefault(b => b.BidId == dvm.Bid.BidId);
            var client = _context.clients.FirstOrDefault(c => c.ClientUserName == clientUserName);
            if (dvm.BidPlaced.BidDate <= bid.BidEndDate)
            {

                if (clientUserName != null)
                {
                    if (client.ClientId != bid.ClientId)
                    {

                        if (dvm.BidPlaced.BidAmount < bid.HighestBid)
                        {
                            var tableBid = _context.bids.Include(c => c.AssetCondition).Include(c => c.Category).Include(c => c.Client).FirstOrDefault(b => b.BidId == bid.BidId);
                            var tables = new DetailsVeiwModel
                            {
                                BidPlaced = _context.bidsPlaced.Where(b => b.ClientId == bid.ClientId).OrderByDescending(b => b.BidId).LastOrDefault(),
                                Bid = tableBid
                            };
                            ViewData["errorMessage"] = "Your Bid is Lower than the Leading Bid";
                            return View("../../Views/Details/Details", tables);
                        }
                        else
                        {
                            var bidLost = _context.bidsPlaced.Where(b => b.BidId == bid.BidId).OrderByDescending(b => b.BidAmount).FirstOrDefault();
                            bid.HighestBid = dvm.BidPlaced.BidAmount;
                            _context.bids.Update(bid);
                            dvm.BidPlaced.ClientId = client.ClientId;
                            dvm.BidPlaced.BidId = bid.BidId;
                            _context.bidsPlaced.Add(dvm.BidPlaced);
                            _context.SaveChanges();
                            sendAcceptanceEmail(client.ClientId, dvm.BidPlaced);
                            if (bidLost != null)
                            {
                               sendOutBittedEmail(bidLost.ClientId, dvm.BidPlaced);

                            }
                        }

                        return RedirectToAction("Details", "Details", new { id = dvm.Bid.BidId });

                    }
                    else
                    {
                        var tableBid = _context.bids.Include(c => c.AssetCondition).Include(c => c.Category).Include(c => c.Client).FirstOrDefault(b => b.BidId == bid.BidId);
                        var tables = new DetailsVeiwModel
                        {
                            BidPlaced = _context.bidsPlaced.Where(b => b.ClientId == bid.ClientId).OrderByDescending(b => b.BidId).LastOrDefault(),
                            Bid = tableBid
                        };
                        ViewData["errorMessage"] = "Sellers Aren't Premited to Bid On Their Products";
                        return View("../../Views/Details/Details", tables);
                    }
                }
                else
                {
                    return RedirectToAction("Login", "Login");
                }
            }
            else
            {
                var tableBid = _context.bids.Include(c => c.AssetCondition).Include(c => c.Category).Include(c => c.Client).FirstOrDefault(b => b.BidId == bid.BidId);
                var tables = new DetailsVeiwModel
                {
                    BidPlaced = _context.bidsPlaced.Where(b => b.ClientId == bid.ClientId).OrderByDescending(b => b.BidId).LastOrDefault(),
                    Bid = tableBid
                };
                ViewData["errorMessage"] = "The Bidding Period Ended";
                return View("../../Views/Details/Details", tables);
            }


        }
        public async Task sendAcceptanceEmail(int id, BidsPlaced bsp)
        {
            Client client = _context.clients.FirstOrDefault(c => c.ClientId == id);
            Bid bid = _context.bids.FirstOrDefault(b => b.BidId == bsp.BidId);
            string receiver = client.ClientUserName;
            var subject = "Bidding Notification";
            var message = "<h1>Hello " + client.ClientFirstName +"</h1>" +
                          "<h2>Your bid of " + bsp.BidAmount + " for "+ bid.BidName +" Has Been Place</h2>";

            await _emailSender.SendEmailAsync(receiver, subject, message);
        }
        public async Task sendOutBittedEmail(int id, BidsPlaced bsp)
        {
            Client client = _context.clients.FirstOrDefault(c => c.ClientId == id);
            Bid bid = _context.bids.FirstOrDefault(b => b.BidId == bsp.BidId);
            string receiver = client.ClientUserName;
            var subject = "Bidding Notification";
            var message = "<h1>Hello " + client.ClientFirstName +"</h1>" +
                "<h2>This is a notificatio to Inform you that someone out Bid you bid of " + bsp.BidAmount + " For " + bid.BidName + " </h2>";

            await _emailSender.SendEmailAsync(receiver, subject, message);
        }
       
    }
}
