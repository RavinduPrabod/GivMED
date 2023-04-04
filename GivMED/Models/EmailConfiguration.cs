using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GivMED.Models
{
    public class EmailConfiguration
    {
        public int Port { get; set; }

        public string SmtpAddress { get; set; }

        public string EmailAddress { get; set; }

        public string Password { get; set; }
    }
}