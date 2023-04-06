using GivMED.Common;
using GivMED.Dto;
using GivMED.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using static GivMED.Common.Enums;

namespace GivMED.Pages.Web.Registration
{
    public partial class FundraiserRegistration : System.Web.UI.Page
    {
        private RegistrationService oRegistrationService = new RegistrationService();

        protected void Page_Load(object sender, EventArgs e)
        {
            mvFundreg.ActiveViewIndex = 0;
        }
        protected void btnRegisterOrg_Click(object sender, EventArgs e)
        {
            Session["UserName"] = null;
            WebApiResponse response = new WebApiResponse();
            response = oRegistrationService.CreateUser(UiToModelCreaterOrg());

            if (response.StatusCode == (int)StatusCode.Created)
            {
                ShowSuccessMessage(ResponseMessages.InsertSuccess);
                //PageLoad();
            }
            else if (response.StatusCode == (int)StatusCode.BadRequest)
            {
                ShowErrorMessage(ResponseMessages.EmailAlreadyExists);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "carouselSlide", "$('#carouselExampleIndicators').carousel('next');", true);
                txtEmailOrg.Focus();
            }
            else
            {
                ShowSuccessMessage(ResponseMessages.Registerd);
                UserDto getuser = UiToModelCreateInd();
                Session["UserName"] = getuser.UserName.ToString();
            }
        }

        protected void btnRegisterInd_Click(object sender, EventArgs e)
        {
            Session["UserName"] = null;
            WebApiResponse response = new WebApiResponse();
            response = oRegistrationService.CreateUser(UiToModelCreateInd());

            if (response.StatusCode == (int)StatusCode.Created)
            {
                ShowSuccessMessage(ResponseMessages.InsertSuccess);
                //PageLoad();
            }
            else if (response.StatusCode == (int)StatusCode.BadRequest)
            {
                ShowErrorMessage(ResponseMessages.EmailAlreadyExists);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "carouselSlide", "$('#carouselExampleIndicators').carousel('prev');", true);
                txtEmailInd.Focus();
            }
            else
            {
                ShowSuccessMessage(ResponseMessages.Registerd);
                UserDto getuser  = UiToModelCreateInd();
                Session["UserName"] = getuser.UserName.ToString();
            }
        }
        private UserDto UiToModelCreateInd()
        {
            UserDto oData = new UserDto();
            oData.UserName = txtEmailInd.Text.Trim();
            oData.FirstName = txtNameInd.Text.Split(' ')[0].ToString();
            oData.LastName = txtNameInd.Text.Split(' ')[1].ToString();
            oData.Type = 1;
            oData.Status = 1;
            oData.Password = txtPwdInd.Text.Trim();
            oData.Email = txtEmailInd.Text.ToString();
            oData.NoOfAttempts = 1;
            oData.LastLoginDate = DateTime.Now;
            oData.CreatedBy = "admin";
            oData.CreatedDateTime = DateTime.Now;
            oData.CreatedWorkStation = "laptop";
            oData.ModifiedBy = "admin";
            oData.ModifiedDateTime = DateTime.Now;
            oData.ModifiedWorkStation = "laptop";
            return oData;
        }

        private UserDto UiToModelCreaterOrg()
        {
            UserDto oData = new UserDto();
            oData.UserName = txtEmailOrg.Text.Trim();
            oData.FirstName = txtNameOrg.Text.Trim();
            oData.LastName = txtNameOrg.Text.Trim();
            oData.Type = 2;
            oData.Status = 1;
            oData.Password = txtPwdOrg.Text.Trim();
            oData.Email = txtEmailOrg.Text.ToString();
            oData.NoOfAttempts = 1;
            oData.LastLoginDate = DateTime.Now;
            oData.CreatedBy = "admin";
            oData.CreatedDateTime = DateTime.Now;
            oData.CreatedWorkStation = "laptop";
            oData.ModifiedBy = "admin";
            oData.ModifiedDateTime = DateTime.Now;
            oData.ModifiedWorkStation = "laptop";
            return oData;
        }

        private void ShowSuccessMessage(string msg)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowSuccessMessage('" + msg + "');", true);
        }

        private void ShowErrorMessage(string msg)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowErrorMessage('" + msg + "');", true);
        }
    }
}