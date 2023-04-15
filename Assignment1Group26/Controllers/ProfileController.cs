using Assignment1Group26.Models;
using Assignment1Group26.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace Assignment1Group26.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private ApplicationDbContext _context;
        private IEmailSender _emailSender;
        public ProfileController(ApplicationDbContext context, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }
        public IActionResult Profile()
        {
            if (TempData["clientUserName"] != null)
            {
                var client = _context.clients.FirstOrDefault(c => c.ClientUserName == TempData["clientUserName"]);
                if (client != null)
                {
                    return View(client);
                }
                else
                {
                    return View("../Login/Login");
                }
            }
            else
            {
                var clientUserName = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                var client = _context.clients.FirstOrDefault(c => c.ClientUserName == clientUserName);
                if (client != null)
                {
                    if (client.EmailConfirmed == true)
                    {
                        return View(client);
                    }
                    else
                    {
                        return View("../Email/EmailVerifyPage");
                    }
                }
            }
            



            return RedirectToAction("Login", "Login");
        }

		[HttpGet]
		public IActionResult Edit(int id)
        {
            var c = _context.clients.FirstOrDefault(c => c.ClientId == id);
            return View(c);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Client cc)
        {

			await cc.SaveImageAsync();

			if (cc.ClientPassword == cc.ClientRetypePassword)
            {
                _context.clients.Update(cc);
                _context.SaveChanges();
                ViewData["confirmationMessage"] = "Your Profile was Updated";
                string receiver;
                if (cc.ClientUserName != null)
                {
                    receiver = cc.ClientUserName;
                }
                else
                {
                    receiver = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                }
                var subject = "Profile Changes Were Made";
                var message = "<h1>Hello Friend</h1>" +
                              "<h3>This is To Notify you that you Password was Recently Changed</h3>";
                await _emailSender.SendEmailAsync(receiver, subject, message);
                return View(cc);
            }
            var client = _context.clients.FirstOrDefault(c => c.ClientId == cc.ClientId);
                    ViewData["errorMessage"] = "passwords don't match";
            return View(client);


        }
        public IActionResult CommonProfile(int id) {
           var tables = new ProfileReviewModel
           {
               clients = _context.clients.ToList(),
               purchases = _context.purchases.Where(p => p.SellerId == id),
               Reviews = _context.reviews.Where(r => r.ClientId == id), 
               Client = _context.clients.FirstOrDefault(c => c.ClientId == id)
           };

          
           
            return View(tables);
        }
        public IActionResult Block(int id)
        {
             Client clientToUpdate  =  _context.clients.FirstOrDefault(c => c.ClientId == id);
            clientToUpdate.Blocked = true;
                  _context.Update(clientToUpdate);
                  _context.SaveChanges();
            Client clientToDisplay = _context.clients.FirstOrDefault(c => c.ClientId == id);
            return View("../../Views/Profile/Profile", clientToDisplay);

        }
        public IActionResult Unblock(int id)
        {

            Client clientToUpdate = _context.clients.FirstOrDefault(c => c.ClientId == id);
            clientToUpdate.Blocked = false;
                _context.Update(clientToUpdate);
                _context.SaveChanges();
            Client clientToDisplay = _context.clients.FirstOrDefault(c => c.ClientId == id);
            return View("../../Views/Profile/Profile", clientToDisplay);

        }
		[HttpGet]
		public IActionResult LeadingBids(int id)
		{
			var tables = new LeadingBidsModel
			{
			    WinningBids = _context.bids.ToList(),
                LostBids= _context.bids.ToList(),
                Bids = _context.bids.ToList(),
				Client = _context.clients.FirstOrDefault(c => c.ClientId == id),
				BidsPlaced = _context.bidsPlaced.Where(c => c.ClientId == id).ToList()
			};
			var bidIds = tables.BidsPlaced.Select(bp => bp.BidId);
			var clientPlacedBids = _context.bids.Where(b => bidIds.Contains(b.BidId)).ToList();


			var bidHighestAmount = tables.BidsPlaced.Select(bp => bp.BidAmount).ToList();

			var leadingBids = _context.bids.Where(b => bidHighestAmount.Contains((double)b.HighestBid)).ToList();
			var lostBids = clientPlacedBids.Where(b => !leadingBids.Any(hb => hb.BidId == b.BidId)).ToList();







			tables.WinningBids = leadingBids;
            tables.LostBids= lostBids;


			return View("../../Views/PlacedBids/PlacedBids", tables);

		}
	}
}
