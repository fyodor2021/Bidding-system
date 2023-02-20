using Assignment1Group26.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Assignment1Group26.Service;

namespace Assignment1Group26.Controllers
{
    public class RegistrationController : Controller
    {

        private ApplicationDbContext _context;
        private readonly IEmailSender _emailSender;
        public RegistrationController(ApplicationDbContext context, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
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
                //adding the contact to the database

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

                //email verification
                var receiver = c.ClientUserName;
                var subject = "please verify your email(josedore)";
                var message = "Hello World";

                await _emailSender.SendEmailAsync(receiver, subject, message);
                return RedirectToAction("Index", "Home");

            }
            ViewData["errorMessage"] = "Invalid Credentials";
            return View("Register");


        }

    }
}
