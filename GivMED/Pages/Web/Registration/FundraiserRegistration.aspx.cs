using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace GivMED.Pages.Web.Registration
{
    public partial class FundraiserRegistration : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            mvFundreg.ActiveViewIndex = 0;
        }

        protected void btnIndividual_Click(object sender, EventArgs e)
        {
            mvFundreg.ActiveViewIndex = 1;
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {

        }

        protected void btnOrganization_Click(object sender, EventArgs e)
        {
            mvFundreg.ActiveViewIndex = 2;
        }
    }
}