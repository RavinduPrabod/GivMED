using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GivMED.Models
{
    public class EmailUsers
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public int Publicity { get; set; }

        public int EmailNotification { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDateTime { get; set; }
    }
}