using Assignment1Group26.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1Group26.Controllers
{
    public class LoginController : Controller
    {
        private ApplicationDbContext _context;
        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login(Client c)
        {
            var clients = _context.clients;
            foreach(Client Cl in clients)
            {
                if(Cl.ClientUserName == c.ClientUserName && Cl.ClientPassword == c.ClientPassword)
                {
                    ViewBag.ClientUserName = Cl.ClientUserName;
                    return RedirectToAction("Index","Home");
                }
            }

            return RedirectToAction("Index", "Home");
        }

    }
}

