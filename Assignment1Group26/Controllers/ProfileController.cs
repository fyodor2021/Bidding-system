using Assignment1Group26.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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
        public IActionResult Profile()
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

        public IActionResult Edit(int id)
        {
            var c = _context.clients.FirstOrDefault(c => c.ClientId == id);
            return View(c);
        }
        [HttpPost]
        public IActionResult Edit(Client cc)
        {


            if (cc.ClientPassword == cc.ClientRetypePassword)
            {
                _context.clients.Update(cc);
                _context.SaveChanges();
                ViewData["confirmationMessage"] = "Your Profile was Updated";
                return View(cc);
            }
            var client = _context.clients.FirstOrDefault(c => c.ClientId == cc.ClientId);
                    ViewData["errorMessage"] = "passwords don't match";
            return View(client);


        }

    }
}
