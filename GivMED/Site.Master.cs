using GivMED.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GivMED
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedUserDto loggedUser = (LoggedUserDto)Session["loggedUser"];

            if (loggedUser.Type == 1)
            {
                lblProfileName.Text = loggedUser.FirstName.ToString() + " " + loggedUser.LastName.ToString();
            }
            if (loggedUser.Type == 2)
            {
                lblProfileName.Text = loggedUser.FirstName.ToString();
            }
            if (loggedUser.Type == 3)
            {
                lblProfileName.Text = loggedUser.FirstName.ToString();
            }
        }
    }
}