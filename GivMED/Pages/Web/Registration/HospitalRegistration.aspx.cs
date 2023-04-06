using GivMED.Common;
using GivMED.Dto;
using GivMED.EmailService;
using GivMED.Models;
using GivMED.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static GivMED.Common.Enums;

namespace GivMED.Pages.Web.Registration
{
    public partial class HospitalRegistration : System.Web.UI.Page
    {
        private RegistrationService oRegistrationService = new RegistrationService();
        private EmailConfigurationService oEmailConfigurationService = new EmailConfigurationService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                PageLoad();
            }
        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (chkTerms.Checked)
            {
                try
                {
                    WebApiResponse response = new WebApiResponse();
                    response = oRegistrationService.PostHospital(Submit());

                    if (response.StatusCode == (int)StatusCode.NoContent)
                    {
                        ClearControls();
                        ShowSuccessMessage(ResponseMessages.InsertSuccess);
                    }
                    else
                    {
                        ShowErrorMessage(ResponseMessages.Error);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "carouselSlide", "$('#carouselExampleIndicators').carousel('next');", true);
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

            else
            {
                chkTerms.ForeColor = System.Drawing.Color.Red;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "carouselSlide", "$('#carouselExampleIndicators').carousel('next');", true);
            }
            

        }

        private void ShowSuccessMessage(string msg)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowSuccessMessage('" + msg + "');", true);
        }

        private void ShowErrorMessage(string msg)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowErrorMessage('" + msg + "');", true);
        }

        #region Methdos
        private void PageLoad()
        {
            //LoggedUserDto loggedUser = (LoggedUserDto)Session["loggedUser"];
            if (Session["loggedUser"] != null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "carouselSlide", "window.onload = function() { $('#carouselExampleIndicators').carousel('next'); }", true);
            }
        }

        private UserDto UiToModelCreate()
        {
            UserDto oData = new UserDto();
            oData.UserName = txtHospitalEmail.Text.Trim();
            oData.FirstName = txtNameofHospital.Text.Trim();
            oData.LastName = txtNameofHospital.Text.Trim();
            oData.Type = 3;
            oData.Status = 1;
            oData.Password = txtPassword.Text.Trim();
            oData.Email = txtHospitalEmail.Text.ToString();
            oData.NoOfAttempts = 1;
            oData.LastLoginDate = DateTime.Now;
            oData.CreatedBy = "admin";
            oData.CreatedDateTime = DateTime.Now;
            oData.CreatedWorkStation = "laptop";
            oData.ModifiedBy = "admin";
            oData.ModifiedDateTime = DateTime.Now;
            oData.ModifiedWorkStation = "laptop";
            Session["loggedUser"] = oData;
            return oData;

        }
        private HospitalMaster Submit()
        {
            LoggedUserDto loggedUser = (LoggedUserDto)Session["loggedUser"];

            HospitalMaster oData = new HospitalMaster();
            oData.HospitalID = 0;
            oData.UserName = loggedUser.UserName;
            oData.HospitalName = loggedUser.FirstName.ToString();
            oData.Address = txtAddress.Text.ToString();
            oData.Telephone = txtPhoneNumber.Text.ToString();
            oData.City = txtcity.Text.ToString();
            oData.Country = ddlCountry.SelectedItem.Text.ToString();
            oData.State = ddlState.SelectedItem.Text.ToString();
            oData.ZipCode = txtzip.Text.ToString();
            oData.Email = loggedUser.UserName.ToString();
            oData.ContactPerson = txtContactPerson.Text.ToString();
            oData.Designation = txtDesignation.Text.ToString();
            oData.TypeofHosptal = Convert.ToInt32(ddltype.SelectedItem.Value);
            oData.RegistrationNo = txtRegistrationNumber.Text.ToString();
            var year = txtYearsofEs.Text.ToString();
            oData.YearEstablish = Convert.ToInt32(txtYearsofEs.Text);
            oData.NoOfBeds = Convert.ToInt32(txtNoofbeds.Text);
            oData.WebURL = txtWebURL.Text.ToString();
            oData.CreateUser = "admin";
            oData.CreateDateTime = DateTime.Now;
            oData.ModifiedUser = "admin";
            oData.ModifieDateTime = DateTime.Now;
            return oData;
        }

        private void ClearControls()
        {
            txtNameofHospital.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            txtcity.Text = string.Empty;
            ddlState.SelectedIndex = 0;
            txtzip.Text = string.Empty;
            txtHospitalEmail.Text = string.Empty;
            txtContactPerson.Text = string.Empty;
            txtDesignation.Text = string.Empty;
            ddltype.SelectedIndex = 0;
            ddlCountry.SelectedIndex = 0;
            txtRegistrationNumber.Text = string.Empty;
            txtYearsofEs.Text = string.Empty;
            txtNoofbeds.Text = string.Empty;
            txtWebURL.Text = string.Empty;
        }


        #endregion Methdos

        protected void regnext_Click(object sender, EventArgs e)
        {

        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPassword.Text.Trim().Equals(txtConfirmPassword.Text.Trim()))
                {
                    WebApiResponse response = new WebApiResponse();
                    response = oRegistrationService.CreateUser(UiToModelCreate());

                    if (response.StatusCode == (int)StatusCode.Created)
                    {
                        ShowSuccessMessage(ResponseMessages.Registerd);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "carouselSlide", "$('#carouselExampleIndicators').carousel('next');", true);
                    }
                    else if (response.StatusCode == (int)StatusCode.BadRequest)
                    {
                        ShowErrorMessage(ResponseMessages.EmailAlreadyExists);
                        txtHospitalEmail.Focus();
                    }
                    else
                    {
                        ShowSuccessMessage(ResponseMessages.Registerd);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "carouselSlide", "$('#carouselExampleIndicators').carousel('next');", true);
                    }

                    //oEmailConfigurationService.SendEmail(txtHospitalEmail.Text.ToString());

                }
                else
                {
                    ShowErrorMessage(ResponseMessages.PasswordNotMatch);
                    txtConfirmPassword.Focus();
                }
            }
            catch (Exception ex) 
            {

                throw ex;
            }
            
        }
    }
}