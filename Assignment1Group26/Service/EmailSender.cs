using Assignment1Group26.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

namespace Assignment1Group26.Service
{
    public class EmailSender : IEmailSender
    {
        private ApplicationDbContext _context;
        public EmailSender(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task SendEmailAsync(string email, string subject, string message) {

            var mail = "causeleea@gmail.com";
            var password = "xajvgnbdjfmhkovd";

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                UseDefaultCredentials = false,
                 EnableSsl= true,
                Credentials = new NetworkCredential(mail,password)
            };
            MailMessage mailMessage = new MailMessage();
            {
                mailMessage.To.Add(email);

                mailMessage.From = new MailAddress(mail,"JoseDore");

                mailMessage.Subject = subject;

                mailMessage.Body = message;
                
                mailMessage.IsBodyHtml = true;

            }
            

            
            return client.SendMailAsync(mailMessage);
        }
    }
}
