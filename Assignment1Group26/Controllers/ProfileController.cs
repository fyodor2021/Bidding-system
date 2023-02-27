using Assignment1Group26.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace Assignment1Group26.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private ApplicationDbContext _context;
        public ProfileController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
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



            return RedirectToAction("Login", "Login");
        }
        
    }
}
