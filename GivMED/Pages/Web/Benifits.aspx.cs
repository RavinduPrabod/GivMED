using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GivMED.Pages.Web
{
    public partial class Benifits : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnjoinFundraiser_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration/DonorRegistration.aspx");
        }

        protected void btnjoinRecipient_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration/HospitalRegistration.aspx");
        }
    }
}