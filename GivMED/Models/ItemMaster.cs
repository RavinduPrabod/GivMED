using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GivMED.Models
{
    public class ItemMaster
    {
        public int ItemID { get; set; }

        public int ItemCatID { get; set; }

        public string ItemName { get; set; }

        public string ItemDescription { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDateTime { get; set; }
    }
}