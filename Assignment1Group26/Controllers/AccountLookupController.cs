using Assignment1Group26.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1Group26.Controllers
{
    public class AccountLookupController : Controller
    {
        private ApplicationDbContext _context;
        public AccountLookupController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AccountLookup(Client client)
        {   
            Client clientFound = _context.clients.FirstOrDefault(c => c.ClientUserName == client.ClientUserName && c.ClientFirstName == client.ClientFirstName && c.ClientLastName == client.ClientLastName);
            if(clientFound == null){
                ViewData["errorMessage"] = "Client Not Found";
                return View("Index");
            }
            else
            {
                TempData["clientUserName"] = clientFound.ClientUserName;
                
                return RedirectToAction("Profile","Profile");
            }
        }
    }
}
