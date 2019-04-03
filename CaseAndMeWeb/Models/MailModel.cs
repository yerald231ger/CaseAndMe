using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaseAndMeWeb.Models
{
    public class MailModel
    {
        public string subject { get; set; }

        public string body { get; set; }

        
        public List<MailAdress> emailsTo { get; set; }
    }
}