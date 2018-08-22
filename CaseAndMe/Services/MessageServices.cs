using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace CaseAndMe.Services
{
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link https://go.microsoft.com/fwlink/?LinkID=532713
    public class AuthMessageSender : IEmailSender, ISmsSender
    {
        public IOptions<AuthMessageSenderOptions> _optionsAccessor { get; set; }

        public AuthMessageSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            _optionsAccessor = optionsAccessor;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            // Plug in your email service here to send an email.
            var _fromAddress = new MailAddress(_optionsAccessor.Value.EmailSender, "Case&Me Account Services");
            var _toAddress = new MailAddress(email);

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_fromAddress.Address, _optionsAccessor.Value.EmailSenderPassword)
            };

            var _mail = new MailMessage(_fromAddress, _toAddress);
            _mail.Body = message;
            _mail.Subject = subject;
            _mail.IsBodyHtml = true;

            return smtp.SendMailAsync(_mail);
        }

        public Task SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }
}
