using Microsoft.AspNetCore.Mvc;
using Stripe;
using System.Threading.Tasks;






namespace Assignment1Group26.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Payment()
        {
            return View();
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