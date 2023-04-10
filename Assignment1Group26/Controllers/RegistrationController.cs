using Assignment1Group26.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Assignment1Group26.Service;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Html;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http.Extensions;
using System.Net;

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
            if (c.ClientPassword == c.ClientRetypePassword)
            {
                var client = _context.clients.FirstOrDefault(u => u.ClientUserName == c.ClientUserName);
                if (ModelState.IsValid)
                {
                    if (client == null)
                    {
                        //adding the contact to the database
                        c.EmailConfirmed = false;
                        c.VerficationToken = getToken();
                        c.keepLoggedIn = false;
                        c.ClientRole = "Client";
                        _context.clients.Add(c);
                        _context.SaveChanges();
                        List<Claim> claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier, c.ClientUserName),
                        new Claim(ClaimTypes.Name, c.ClientRole)
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

                        await SendEmail(c);

                    }
                    else
                    {
                        ViewData["errorMessage"] = "user already exists";
                        return View("Register");
                    }

                }
                else
                {
                    ViewData["errorMessage"] = "Invalid Credentials";
                    return View("Register");
                }
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ViewData["errorMessage"] = "Passwords don't match";
                return View("Register");
            }
        }
        [HttpPost]
        public async Task<IActionResult> SendEmail(Client c)
        {
            string receiver;
            if (c.ClientUserName != null)
            {
                receiver = c.ClientUserName;
            }
            else
            {
                receiver = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            }

            var hostName = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/";
            var subject = "please verify your email(josedore)";
            var message = "<h1>please confirm your email</h1>" +
                          "<a href=\"" + hostName + "Registration/ValidateToken?token=" + c.VerficationToken + "\">verify your email</a>";

            await _emailSender.SendEmailAsync(receiver, subject, message);

            return View("../Email/EmailVerifyPage");
        }
        [HttpGet]
        public async Task<IActionResult> ValidateToken(String token)
        {


            if (token != null)
            {

                var client = _context.clients.FirstOrDefault(c => c.VerficationToken == token);
                if (client != null)
                {
                    client.EmailConfirmed = true;
                    _context.SaveChanges();

                }
            }
            else
            {
                var clientUserName = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                var client = _context.clients.FirstOrDefault(c => c.ClientUserName == clientUserName);
                if (client != null)
                {
                    client.EmailConfirmed = true;
                    _context.SaveChanges();
                }

            }

            return RedirectToAction("Index", "Home");
        }
        public string getToken()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
        }
        public IActionResult Email(Client cl)
        {
            var Clients = _context.clients.ToList();
            foreach (var c in Clients)
            {
                if (cl.ClientUserName == c.ClientUserName)
                {
                    return View(c);
                }
            }
            return View();
        }
    }
}
