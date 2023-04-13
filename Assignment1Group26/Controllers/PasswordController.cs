using Assignment1Group26.Models;
using Assignment1Group26.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment1Group26.Controllers
{
    public class PasswordController : Controller
    {
        private IEmailSender _emailSender;
        private ApplicationDbContext _context;
        public PasswordController(IEmailSender emailSender, ApplicationDbContext context)
        {
            _emailSender = emailSender;
            _context = context;
        }
        [HttpGet]
        public IActionResult Index(String time ,String email)
        {
            Client client = _context.clients.FirstOrDefault( c =>c.ClientUserName == email);
           DateTime dt = Convert.ToDateTime(time);
           if (dt.Minute + 3 > DateTime.Now.Minute) 
            {

                return View(client);

            }
            else
            {
                ViewData["errorMessage"] = "Your Link expired";
                return RedirectToAction("Login", "Login");
            }
        }
        public IActionResult PassReset(Client Cl)
        {

            if(Cl.ClientPassword == Cl.ClientRetypePassword)
            {
                Client client = _context.clients.FirstOrDefault(c => c.ClientUserName == Cl.ClientUserName);
                client.ClientPassword = Cl.ClientPassword;
                _context.clients.Update(client);
                _context.SaveChanges();
                return RedirectToAction("ConfirmationEmail", "Password", client);
            }
            else
            {
                ViewData["errorMessage"] = "Passwords Don't Match";
                return View("../../Views/Password/Index");
            }

        }
        
        public async Task<IActionResult> PassResetEmail(Client Cl)
        {
            Client client = _context.clients.FirstOrDefault(c => c.ClientUserName == Cl.ClientUserName);
            if (client != null)
            {
                string receiver = client.ClientUserName;
                string dt = DateTime.Now.ToString();

                var hostName = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/";
                var subject = "Password Reset";
                var message = "<h1>To Reset your Password please Click on </h1>" +
                              "<a href=\"" + hostName + "Password/Index?time=" + dt + "&email="+ client.ClientUserName  +"\">verify your email</a>";
                await _emailSender.SendEmailAsync(receiver, subject, message);
                ViewData["ValidationMessage"] = "Check Your Email";
                return View("../../Views/Login/Login", client);

            }
            else
            {
                ViewData["ValidationMessage"] = "Account Doesn't Exist";
                return View("../../Views/Login/Login");
            }

        }
        public async Task<IActionResult> ConfirmationEmail(Client Cl)
        {
                Client client = _context.clients.FirstOrDefault(c => c.ClientUserName == Cl.ClientUserName);
                string receiver = client.ClientUserName;
                var hostName = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/";
                var subject = "Password Reset";
                var message = "<h1>Password is Successfully Reset</h1>";
                await _emailSender.SendEmailAsync(receiver, subject, message);
                ViewData["ValidationMessage"] = "Password Updated Successfully";
                return View("../../Views/Login/Login", client);
        }
    }
}
