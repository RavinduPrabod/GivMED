using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GivMED.Models
{
    public class Complaint
    {
        public string ComplaintCode { get; set; }

        public string ComplanerName { get; set; }

        public string ComplanerEmail { get; set; }

        public string Subject { get; set; }

        public string NameofVictim { get; set; }

        public string FullComplaint { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedDateTime { get; set; }
    }
}