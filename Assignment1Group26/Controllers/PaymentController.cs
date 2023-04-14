using Assignment1Group26.Models;
using Assignment1Group26.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe;
using System.Linq;
using System.Threading.Tasks;






namespace Assignment1Group26.Controllers
{
    public class PaymentController : Controller
    {
        private ApplicationDbContext _context;
        public PaymentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Payment(int id)
        {
            var tables = new PaymentModel
            {
                Total = 0,
                Bids = _context.bids.ToList(),
                Client = _context.clients.FirstOrDefault(c => c.ClientId == id),
                BidsPlaced = _context.bidsPlaced.Where(c => c.ClientId == id).ToList(),
                WinningBids = _context.bids.Where(b => b.expired == true).ToList()
            };
            var bidIds = tables.BidsPlaced.Select(bp => bp.BidId);
            var clientPlacedBids = _context.bids.Where(b => bidIds.Contains(b.BidId)).ToList();
            var bidHighestAmount = tables.BidsPlaced.Select(bp => bp.BidAmount).ToList();
            var leadingBids = _context.bids.Where(b => b.expired == true && bidHighestAmount.Contains((double)b.HighestBid)).ToList();


            


            tables.Bids = leadingBids;


            return View("../../Views/Payment/Payment", tables);




        }
        public IActionResult Charge(string stripeEmail, string stripeToken)
        {
            var customers = new CustomerService();
            var charges = new ChargeService();

            StripeConfiguration.SetApiKey("sk_test_51MvUuvAO8tl6rEU1lp3ovhM4Uyn2xYv0OhkNF1tKcEa2DbDcI8645lhMTp5PCMD7FVjxCRvDbcrKHIbkVgu8dOKq00AJkGl7Ld");


            var customer = customers.Create(new CustomerCreateOptions
            {
                Email= stripeEmail,
                Source =stripeToken,
            });

            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = 500,
                Description="Test Payment",
                Currency = "usd",
                Customer = customer.Id,


            });

            if (charge.Status == "succeeded" ) { 
                string BalanceTransactionId = charge.BalanceTransactionId;
                return View();


            }
          


            return View();
        }


    }
}