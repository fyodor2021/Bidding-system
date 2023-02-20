using System.Net;
using System.Net.Mail;

namespace Assignment1Group26.Service
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message) {

            var mail = "causeleea@gmail.com";
            var password = "Pass@@wod22veo";

            var client = new SmtpClient("smtp.mailgun.org", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(mail,password)
            };
            return client.SendMailAsync(new MailMessage(from: mail,
                to:email,subject,message));
        }
    }
}
