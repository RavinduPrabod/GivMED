using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GivMED.Models
{
    public class UnsendEmailLog
    {
        public long UserID { get; set; }

        public string UserName { get; set; }

        public long FunctionId { get; set; }

        public string TransactionNo { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }
    }
}