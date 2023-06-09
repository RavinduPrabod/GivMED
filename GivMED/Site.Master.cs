﻿using GivMED.Dto;
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

            //panel Donor
            pnlHSidebar.Visible = false;
            pnlHProf.Visible = false;

            //panel Hospital
            pnlDSidebar.Visible = false;
            pnlDProf.Visible = false;

            if (loggedUser.Type == 1)
            {
                string dpname = loggedUser.FirstName.ToString() + " " + loggedUser.LastName.ToString();
                if(dpname.Length > 27)
                {
                    lblDProfileName.Text = dpname.Substring(0, 27);
                    pnlDSidebar.Visible = true;
                    pnlDProf.Visible = true;
                }
                else
                {
                    lblDProfileName.Text = dpname;
                    pnlDSidebar.Visible = true;
                    pnlDProf.Visible = true;
                }
                
            }
            if (loggedUser.Type == 2)
            {
                string dpname = loggedUser.FirstName.ToString();
                if (dpname.Length > 27)
                {
                    dpname = loggedUser.FirstName.ToString();
                    lblDProfileName.Text = dpname.Substring(0, 27);
                    pnlDSidebar.Visible = true;
                    pnlDProf.Visible = true;
                }
                else
                {
                    lblDProfileName.Text = dpname;
                    pnlDSidebar.Visible = true;
                    pnlDProf.Visible = true;
                }
                    
            }
            if (loggedUser.Type == 3)
            {
                lblHProfileName.Text = loggedUser.FirstName.ToString();
                pnlHSidebar.Visible = true;
                pnlHProf.Visible = true;
            }
        }
    }
}