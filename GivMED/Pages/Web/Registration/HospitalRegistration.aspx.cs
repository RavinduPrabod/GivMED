using GivMED.Common;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                PageLoad();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
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

        }

        private HospitalMaster Submit()
        {
            HospitalMaster oData = new HospitalMaster();
            oData.HospitalID = "H01";
            oData.HospitalName = txtNameofHospital.Text.ToString();
            oData.Address = txtAddress.Text.ToString();
            oData.Telephone = txtPhoneNumber.Text.ToString();
            oData.City = txtcity.Text.ToString();
            oData.State = ddlState.SelectedItem.Text.ToString();
            oData.ZipCode = txtzip.Text.ToString();
            oData.Email = txtEmailAddress.Text.ToString();
            oData.ContactPerson = txtContactPerson.Text.ToString();
            oData.Designation = txtDesignation.Text.ToString();
            oData.TypeofHosptal = Convert.ToInt32(ddltype.SelectedItem.Value);
            oData.RegistrationNo = txtRegistrationNumber.Text.ToString();
            oData.YearEstablish = Convert.ToInt32(txtYear.Text);
            oData.NoOfBeds = Convert.ToInt32(txtNoofbeds.Text);
            oData.WebURL = txtWebURL.Text.ToString();
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
            txtEmailAddress.Text = string.Empty;
            txtContactPerson.Text = string.Empty;
            txtDesignation.Text = string.Empty;
            ddltype.SelectedIndex = 0;
            txtRegistrationNumber.Text = string.Empty;
            txtYear.Text = string.Empty;
            txtNoofbeds.Text = string.Empty;
            txtWebURL.Text = string.Empty;
        }

        #endregion Methdos
    }
}