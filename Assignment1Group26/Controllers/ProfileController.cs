using Assignment1Group26.Models;
using Assignment1Group26.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Net.Mail;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace Assignment1Group26.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private ApplicationDbContext _context;
        private IEmailSender _emailSender;
        public ProfileController(ApplicationDbContext context, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }
        public IActionResult Profile()
        {
            if (TempData["clientUserName"] != null)
            {
                var client = _context.clients.FirstOrDefault(c => c.ClientUserName == TempData["clientUserName"]);
                if (client != null)
                {
                    return View(client);
                }
            }
            else
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
            }
            



            return RedirectToAction("Login", "Login");
        }
        
        public IActionResult Edit(int id)
        {
            var c = _context.clients.FirstOrDefault(c => c.ClientId == id);
            return View(c);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Client cc)
        {


            if (cc.ClientPassword == cc.ClientRetypePassword)
            {
                _context.clients.Update(cc);
                _context.SaveChanges();
                ViewData["confirmationMessage"] = "Your Profile was Updated";
                string receiver;
                if (cc.ClientUserName != null)
                {
                    receiver = cc.ClientUserName;
                }
                else
                {
                    receiver = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                }
                var subject = "please verify your email(josedore)";
                var message = "<h1>Hello Friend</h1>" +
                              "<h3>This is To Notify you that you Password was Recently Changed</h3>";
                await _emailSender.SendEmailAsync(receiver, subject, message);
                return View(cc);
            }
            var client = _context.clients.FirstOrDefault(c => c.ClientId == cc.ClientId);
                    ViewData["errorMessage"] = "passwords don't match";
            return View(client);


        }
        public IActionResult CommonProfile(int id) {
           var tables = new ProfileReviewModel
           {
               Reviews = _context.reviews.Where(r => r.ClientId == id), 
               Client = _context.clients.FirstOrDefault(c => c.ClientId == id)
           };
          
           
            return View(tables);
        }
        public IActionResult Block(int id)
        {
             Client clientToUpdate  =  _context.clients.FirstOrDefault(c => c.ClientId == id);
            clientToUpdate.Blocked = true;
                  _context.Update(clientToUpdate);
                  _context.SaveChanges();
            Client clientToDisplay = _context.clients.FirstOrDefault(c => c.ClientId == id);
            return View("../../Views/Profile/Profile", clientToDisplay);

        }
        public IActionResult Unblock(int id)
        {

            Client clientToUpdate = _context.clients.FirstOrDefault(c => c.ClientId == id);
            clientToUpdate.Blocked = false;
                _context.Update(clientToUpdate);
                _context.SaveChanges();
            Client clientToDisplay = _context.clients.FirstOrDefault(c => c.ClientId == id);
            return View("../../Views/Profile/Profile", clientToDisplay);

        }
    }
}
