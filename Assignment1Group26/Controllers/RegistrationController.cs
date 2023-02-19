using Assignment1Group26.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Assignment1Group26.Controllers
{
    public class RegistrationController : Controller
    {

        private ApplicationDbContext _context;
        public RegistrationController(ApplicationDbContext context)
        {
            _context = context;
        }
        public ActionResult Register()
        {
            return View(new Client());
        }
        [HttpPost]
        public async Task<IActionResult> RegisterProcess(Client c)
        {
            
            if(ModelState.IsValid)
            {
                _context.clients.Add(c);
                _context.SaveChanges();
                List<Claim> claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier, c.ClientUserName)
                    };
                ClaimsIdentity ClaimsIdentity
                    = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IsPersistent = c.keepLoggedIn
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(ClaimsIdentity), properties);
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ViewData["validMessage"] = "Invalid credentials";
                return RedirectToAction("Register", "Registration");
            }
            
            
        }

    }
}
