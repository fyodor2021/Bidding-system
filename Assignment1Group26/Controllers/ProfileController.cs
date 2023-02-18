using Microsoft.AspNetCore.Mvc;

namespace Assignment1Group26.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
