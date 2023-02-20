using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Assignment1Group26.Service
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email,string subject,string message);
    }
}
