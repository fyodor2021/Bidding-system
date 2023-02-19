using Assignment1Group26.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1Group26.Controllers
{
    public class RegistrationController : Controller
    {

        private ApplicationDbContext _context;
        public RegistrationController(ApplicationDbContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            return View(new Client());
        }
        [HttpPost]
        public IActionResult Register(Client c)
        {
            
            if(ModelState.IsValid)
            {
                _context.clients.Add(c);
            }
            
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

    }
}
