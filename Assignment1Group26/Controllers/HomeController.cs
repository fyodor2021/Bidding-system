using Assignment1Group26.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Assignment1Group26.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _Homecontext;
        public HomeController(ApplicationDbContext ctx)
        {
            _Homecontext = ctx;
        }
        public IActionResult Index()

        { 

            return View();
        }

   
    }
}