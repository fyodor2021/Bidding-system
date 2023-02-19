using Assignment1Group26.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

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
        public IActionResult Login()
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            if (claimUser.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Client c)
        {
            var clients = _context.clients;
            foreach(Client Cl in clients) 
            {
                if(Cl.ClientUserName == c.ClientUserName && Cl.ClientPassword == c.ClientPassword)
                {
                    List<Claim> claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier, c.ClientUserName)
                    };
                    ClaimsIdentity ClaimsIdentity
                        = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    AuthenticationProperties properties = new AuthenticationProperties()
                    {
                        AllowRefresh= true,
                        IsPersistent = c.keepLoggedIn
                    };
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(ClaimsIdentity), properties); 

                    return RedirectToAction("Index","Home");
                }
            }
            ViewData["ValidationMessage"] = "user not found";
            return View();
        }
        
    }

    
}

