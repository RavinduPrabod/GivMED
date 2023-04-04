using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GivMED.Common
{
    public class GlobalData
    {
        #region ApiConfiguration

        public static string BaseUri { get; set; }

        #endregion ApiConfiguration

        public static string Token { get; set; }

        #region EmailConfiguration

        public static string CloudConString = "Data Source=LT-41-PE3;Initial Catalog=db_GiveMED;User ID=sa;Password=#compaq123";

        public static int Port { get; set; }

        public static string SmtpAddress { get; set; }

        public static string NoreplyEmail { get; set; }

        public static string NoreplyPassword { get; set; }

        #endregion EmailConfiguration
    }
}