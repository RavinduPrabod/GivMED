using GivMED.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace GivMED
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            GlobalData.BaseUri = ConfigurationManager.AppSettings["BaseUri"].ToString();
        }
    }
}