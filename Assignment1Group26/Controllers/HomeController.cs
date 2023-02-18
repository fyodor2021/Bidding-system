using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Assignment1Group26.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

   
    }
}