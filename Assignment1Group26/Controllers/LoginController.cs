using Assignment1Group26.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using System.Security.Cryptography;
using Assignment1Group26.Service;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.IO;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Assignment1Group26.Controllers
{
    public class LoginController : Controller
    {
        private ApplicationDbContext _context;
        private readonly IEmailSender _emailSender;
        private IServiceProvider _serviceProvider;
        public LoginController(ApplicationDbContext context, IEmailSender emailSender, IServiceProvider serviceProvider)
        {
            _context = context;
            _emailSender = emailSender;
            _serviceProvider = serviceProvider;
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

        public async Task<IActionResult> LoggingIn(Client cl)
        {
            string assembledPin = cl.FirstNumber.ToString() + cl.SecondNumber.ToString() + cl.ThirdNumber.ToString() + cl.FourthNumber.ToString() + cl.FifthNumber.ToString() + cl.SixthNumber.ToString();
            Client client = _context.clients.FirstOrDefault(c => c.ClientId == cl.ClientId);
            string multiPin = client.MultiPin.ToString();
            if(assembledPin != "")
            {
                if (client.MultiPin == int.Parse(assembledPin) || client.ClientRole == "Admin")
                {
                    List<Claim> claims;
                    if (client.ClientRole == "Admin")
                    {
                        claims = new List<Claim>()
                        {
                            new Claim(ClaimTypes.NameIdentifier, client.ClientUserName),
                            new Claim(ClaimTypes.Name, client.ClientRole)
                        };
                    }
                    else
                    {
                        claims = new List<Claim>()
                        {
                            new Claim(ClaimTypes.NameIdentifier, client.ClientUserName),
                            new Claim(ClaimTypes.Name, client.ClientUserName)
                        };

                    }
                    ClaimsIdentity ClaimsIdentity
                    = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    AuthenticationProperties properties = new AuthenticationProperties()
                    {
                        AllowRefresh = true,
                        IsPersistent = client.keepLoggedIn
                    };
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(ClaimsIdentity), properties);

                    return RedirectToAction("Profile", "Profile");
                }
                ViewData["ValidationMessage"] = "The PIN you Entered is InCorrect";
                return View("../../Views/Email/EmailVerifyPage", client);
            }
            else
            {
                if (client.ClientRole != "Admin")
                {
                    ViewData["ValidationMessage"] = "The PIN you Entered is InCorrect";
                    return View("../../Views/Email/EmailVerifyPage", client);
                }
                else
                {
                    if(client.MultiPin == 11111111)
                    {
                        List<Claim> claims;
                        claims = new List<Claim>()
                        {
                            new Claim(ClaimTypes.NameIdentifier, client.ClientUserName),
                            new Claim(ClaimTypes.Name, client.ClientRole)
                        };
                        ClaimsIdentity ClaimsIdentity
                       = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        AuthenticationProperties properties = new AuthenticationProperties()
                        {
                            AllowRefresh = true,
                            IsPersistent = client.keepLoggedIn
                        };
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(ClaimsIdentity), properties);

                        return RedirectToAction("Profile", "Profile");
                    }
                    ViewData["ValidationMessage"] = "The PIN you Entered is InCorrect";
                    return View("../../Views/Email/EmailVerifyPage", client);
                }

            }

        }

        public async Task<IActionResult> MultiFactor(Client c)
        {
            Client client = findClient(c.ClientUserName);
            if (client != null)
            {
                if (client.ClientRole != "Admin")
                {
                    if (client != null && client.ClientPassword == c.ClientPassword)
                    {
                        if (client.Blocked == false)
                        {
                            Random rn = new Random();
                            int x = rn.Next(100000, 999999);

                            string receiver;
                            if (c.ClientUserName != null)
                            {
                                receiver = c.ClientUserName;
                            }
                            else
                            {
                                receiver = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                            }

                            var subject = "Verification PIN";
                            var message = "<h1>Welcome Again to JoseDore</h1>" +
                                          "<h4>Your PIN for this session is: </h4>" + "<h2>" + x + "</h2>";

                            updatePin(client.ClientId, x);

                            await _emailSender.SendEmailAsync(receiver, subject, message);

                            return View("../Email/EmailVerifyPage", client);
                        }
                        else
                        {
                            ViewData["ValidationMessage"] = "You're Blocked";
                            return View("../../Views/Login/Login");
                        }
                    }

                    ViewData["ValidationMessage"] = "user not found";
                    return View("../../Views/Login/Login");
                }
                {
                    return RedirectToAction("LoggingIn", "Login", client);
                }
            }
            ViewData["ValidationMessage"] = "user not found";
            return View("../../Views/Login/Login");

        }
        [HttpPost]
       
        public void updatePin(int id,int pin)
        {
            Client client = _context.clients.FirstOrDefault(c => c.ClientId == id);
            client.MultiPin = pin;
            _context.clients.Update(client);
            _context.SaveChanges();

        }

        public string RenderPartialViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.ActionDescriptor.DisplayName;

            ViewData.Model = model;

            using (StringWriter sw = new StringWriter())
            {
                var engine = _serviceProvider.GetService(typeof(ICompositeViewEngine)) as ICompositeViewEngine; // Resolver.GetService(typeof(ICompositeViewEngine)) as ICompositeViewEngine;
                ViewEngineResult viewResult = engine.FindView(ControllerContext, viewName, false);

                ViewContext viewContext = new ViewContext(
                    ControllerContext,
                    viewResult.View,
                    ViewData,
                    TempData,
                    sw,
                    new HtmlHelperOptions() //Added this parameter in
                );

                //Everything is async now!
                var t = viewResult.View.RenderAsync(viewContext);
                t.Wait();

                return sw.GetStringBuilder().ToString();
            }
        }

        public async Task<IActionResult> ResendEmail(int id)
        {
            Client client = _context.clients.FirstOrDefault(c => c.ClientId == id);
            string receiver = client.ClientUserName;
            var subject = "Verification PIN";
            var message = "<h1>Welcome Again to JoseDore</h1>" +
                          "<h2>Your PIN for this session is " + client.MultiPin;

            await _emailSender.SendEmailAsync(receiver, subject, message);
            return View("../../Views/Email/EmailVerifyPage",client);
        }
        public Client findClient(string userName)
        {
           var client =  _context.clients.FirstOrDefault(c => c.ClientUserName == userName);
            if(client != null)
            {
                return  client;
            }
            return null;
        }

    }
    

}

    


