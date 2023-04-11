using Microsoft.AspNetCore.Mvc;

namespace Assignment1Group26.Controllers
{
    public class BidController : Controller
    {
        public IActionResult Index()
        {
            return View("../../Views/PlacingBid/PlacingBid");
        }
    }
}
