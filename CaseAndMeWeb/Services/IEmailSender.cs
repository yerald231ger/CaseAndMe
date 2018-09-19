using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace CaseAndMeWeb.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }

    public class EmailSender : IEmailSender
    {
        public EmailSender()
        {

        }

        public Task SendEmailAsync(string email, string subject, string message)
        {

            var _fromAddress = new MailAddress("caseandme.gerardo@gmail.com", "Angar Account Services");
            var _toAddress = new MailAddress(email);

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_fromAddress.Address, "!@Ger231")
            };

            var _mail = new MailMessage(_fromAddress, _toAddress);
            _mail.Body = message;
            _mail.Subject = subject;
            _mail.IsBodyHtml = true;

            return smtp.SendMailAsync(_mail);

        }

        //public Task SendEmailAsync(string email, string subject, string message)
        //{
        //    // Plug in your email service here to send an email.
        //    var _fromAddress = new MailAddress("caseandme.gerardo@gmail.com", "Case&Me Account Services");
        //    var _toAddress = new MailAddress(email);

        //    var smtp = new SmtpClient
        //    {
        //        Host = "smtp.gmail.com",
        //        Port = 587,
        //        EnableSsl = true,
        //        DeliveryMethod = SmtpDeliveryMethod.Network,
        //        UseDefaultCredentials = false,
        //        Credentials = new NetworkCredential(_fromAddress.Address, "!@Ger231")
        //    };

        //    var _mail = new MailMessage(_fromAddress, _toAddress);
        //    _mail.Body = message;
        //    _mail.Subject = subject;
        //    _mail.IsBodyHtml = true;

        //    return smtp.SendMailAsync(_mail);
        //}
    }
    //    {
    //  "EmailSender": "caseandme.gerardo@gmail.com",
    //  "EmailSenderPassword": "!@Ger231"
    //}

}

