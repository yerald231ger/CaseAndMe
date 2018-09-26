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
        public Task SendEmailAsync(string email, string subject, string message)
        {
            

            var fromAddress = new MailAddress("caseandme.gerardo@gmail.com", "Angar Account Services");
            
            var smtpClient = new SmtpClient
            {                
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Timeout = 300000,
                Credentials = new NetworkCredential(fromAddress.Address, "!@Ger231")
            };

            var mailMessage = new MailMessage
            {
                Body = message,
                Subject = subject,
                IsBodyHtml = true, 
                From = fromAddress
            };
            mailMessage.To.Add(email);

            return smtpClient.SendMailAsync(mailMessage);
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

