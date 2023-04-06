using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GivMED.Models
{
    public class ProfileImages
    {
        public string UserName { get; set; }

        public string FileName { get; set; }

        public byte[] Image { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedDateTime { get; set; }
    }
}