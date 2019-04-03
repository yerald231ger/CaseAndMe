using CaseAndMeWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace CaseAndMeWeb.Utilities
{
    public class Mail
    {
        public string sendMail(MailModel email)
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "mail.caseandme.com";
            smtp.Port = 25;// 8889;
            smtp.EnableSsl = false;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("pagos@caseandme.com", "Abcd1234#");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            string output = "";
            try
            {
                MailMessage Msg = new MailMessage();
                MailAddress fromMail = new MailAddress("pagos@caseandme.com");
                Msg.From = fromMail;
                Msg.Subject = email.subject;
                Msg.Body = email.body;

                foreach (var adress in email.emailsTo)
                {
                    Msg.To.Add(new MailAddress(adress.email));
                }

                smtp.Send(Msg);
                output = "Corre electrónico fue enviado satisfactoriamente.";
            }
            catch (Exception ex)
            {
                output = "Error enviando correo electrónico: " + ex.Message;
            }

            return output;
        }
    }
}