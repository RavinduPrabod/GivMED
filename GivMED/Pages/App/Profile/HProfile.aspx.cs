using GivMED.Common;
using GivMED.Dto;
using GivMED.Models;
using GivMED.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static GivMED.Common.Enums;

namespace GivMED.Pages.App.Profile
{
    public partial class HProfile : System.Web.UI.Page
    {
        private ProfileService oProfileService = new ProfileService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LoggedUserDto loggedUser = (LoggedUserDto)Session["loggedUser"];
                Session["HospitalID"] = null;

                ClearAllTextBoxes(this);
                txtNewPwd.Enabled = false;
                txtReNewPwd.Enabled = false;
                txtCurPwd.Text = string.Empty;

                lblPdName.Text = loggedUser.FirstName.ToString();
                //lblPdSubName.Text = loggedUser.FirstName.ToString();
                txtSecEmail.Text = loggedUser.UserName.ToString();

                HospitalMaster odata = oProfileService.GetHospitalMaster(loggedUser.UserName);
                Session["HospitalID"] = odata.HospitalID;
                lblUsername.Text = loggedUser.UserName.ToString();
                txtHRegNo.Text = odata.RegistrationNo.ToString();
                txtYear.Text = odata.YearEstablish.ToString();
                ddltype.SelectedValue = odata.TypeofHosptal.ToString();
                txtNoofBeds.Text = odata.NoOfBeds.ToString();
                txtCity.Text = odata.City.ToString();
                ddlState.SelectedValue = odata.State.ToString();
                ddlCountry.SelectedValue = odata.Country.ToString();
                txtZipCode.Text = odata.ZipCode.ToString();
                txtAddress.Text = odata.Address.ToString();
                txtURL.Text = odata.WebURL.ToString();
                txtEmail.Text = odata.Email.ToString();
                txtTelephone.Text = odata.Telephone.ToString();
                txtAuthName.Text = odata.ContactPerson.ToString();
                txtDesignation.Text = odata.Designation.ToString();
                txtphoneNo.Text = odata.MobileNo.ToString();

                ScriptManager.RegisterStartupScript(this, GetType(), "ActivateSettingsTab", "<script>$(function() { " + "$('.nav-tabs a[href=\"#settings\"]').tab('show');" + "$('.tab-pane#settings').addClass('active');" + "});</script>", false);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            WebApiResponse response = new WebApiResponse();
            response = oProfileService.PutHospital(UiToModelUpdateHospital());

            if (response.StatusCode == (int)StatusCode.Success)
            {
                ShowSuccessMessage(ResponseMessages.UpdateSuccess);
            }
            else
            {
                ShowErrorMessage(ResponseMessages.Error);
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "ActivateSettingsTab", "<script>$(function() { " + "$('.nav-tabs a[href=\"#settings\"]').tab('show');" + "$('.tab-pane#settings').addClass('active');" + "});</script>", false);

        }

        protected void txtCurPwd_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string UserName = txtSecEmail.Text.ToString();
                string Password = txtCurPwd.Text.ToString();
                UserForLoginDto loginDto = new UserForLoginDto
                {
                    UserName = UserName,
                    Password = Password
                };

                LoggedUserDto loggedUser = new LoggedUserDto();
                using (HttpClient client = new HttpClient())
                {
                    string path = "Authentication/Login";
                    client.BaseAddress = new Uri(GlobalData.BaseUri);

                    var json = JsonConvert.SerializeObject(loginDto);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = client.PostAsync(path, content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        txtNewPwd.Enabled = true;
                        txtReNewPwd.Enabled = true;
                        ShowSuccessMessage(ResponseMessages.PasswordIsCorrect);
                        ScriptManager.RegisterStartupScript(this, GetType(), "HideSettingsTab", "<script>$(function() { " + "$('.nav-tabs a[href=\"#settings\"]').hide();" + "$('.tab-pane#settings').removeClass('active');" + "});</script>", false);
                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowChangePwdTab", "<script>$(function() { " + "$('.nav-tabs a[href=\"#changepwd\"]').tab('show');" + "$('.tab-pane#changepwd').addClass('active');" + "});</script>", false);
                    }
                    else
                    {
                        txtCurPwd.Text = string.Empty;
                        txtNewPwd.Enabled = false;
                        txtReNewPwd.Enabled = false;
                        ShowErrorMessage(ResponseMessages.PasswordNotMatch);
                        ScriptManager.RegisterStartupScript(this, GetType(), "HideSettingsTab", "<script>$(function() { " + "$('.nav-tabs a[href=\"#settings\"]').hide();" + "$('.tab-pane#settings').removeClass('active');" + "});</script>", false);
                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowChangePwdTab", "<script>$(function() { " + "$('.nav-tabs a[href=\"#changepwd\"]').tab('show');" + "$('.tab-pane#changepwd').addClass('active');" + "});</script>", false);

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ClearAllTextBoxes(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Text = string.Empty;
                }
                else if (control.Controls.Count > 0)
                {
                    ClearAllTextBoxes(control);
                }
            }
            lblUsername.Text = string.Empty;
            ddlState.SelectedIndex = -1;
            ddlCountry.SelectedIndex = -1;
        }
        private HospitalMaster UiToModelUpdateHospital()
        {
            LoggedUserDto loggedUser = (LoggedUserDto)Session["loggedUser"];

            HospitalMaster oData = new HospitalMaster();

            oData.HospitalID = Convert.ToInt32(Session["HospitalID"]);
            oData.UserName = loggedUser.UserName.ToString();
            oData.RegistrationNo = txtHRegNo.Text.ToString();
            oData.HospitalName = lblPdName.Text.Trim();
            oData.City = txtCity.Text.ToString();
            oData.Address = txtAddress.Text.Trim().ToString();
            oData.Telephone = txtTelephone.Text.Trim().ToString();
            oData.City = txtCity.Text.Trim().ToString();
            oData.State = ddlState.SelectedItem.Text.Trim();
            oData.Country = ddlCountry.SelectedItem.Text.Trim();
            oData.ZipCode = txtZipCode.Text.Trim();
            oData.YearEstablish = Convert.ToInt32(txtYear.Text);
            oData.TypeofHosptal = Convert.ToInt32(ddltype.SelectedItem.Value);
            oData.NoOfBeds = Convert.ToInt32(txtNoofBeds.Text);
            oData.WebURL = txtURL.Text.ToString();
            oData.Email = txtEmail.Text.ToString();
            oData.ContactPerson = txtAuthName.Text.ToString();
            oData.Designation = txtDesignation.Text.ToString();
            oData.MobileNo = txtphoneNo.Text.ToString();
            oData.ModifieDateTime = DateTime.Now;
            oData.ModifiedUser = "admin";
            return oData;
        }
        protected void btnUpdateSec_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSecEmail.Text))
            {
                txtSecEmail.Focus();
            }
            else
            {
                if (string.IsNullOrEmpty(txtCurPwd.Text))
                {
                    txtCurPwd.Focus();
                }
                else
                {
                    if (string.IsNullOrEmpty(txtNewPwd.Text))
                    {
                        txtNewPwd.Focus();
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(txtReNewPwd.Text))
                        {
                            txtReNewPwd.Focus();
                        }
                        else
                        {
                            if (txtNewPwd.Text.Trim().Equals(txtReNewPwd.Text.Trim()))
                            {
                                ValidateLogin();
                            }
                            else
                            {
                                ////txtNewPwd.Text = string.Empty;
                                ////txtReNewPwd.Text = string.Empty;
                                //ShowErrorMessage(ResponseMessages.NewPasswordNotMatch);
                            }
                            
                        }
                    }

                }
            }
        }

        private void ValidateLogin()
        {
            try
            {
                ChangePwdDto oChangePwdDto = new ChangePwdDto
                {
                    UserName = txtSecEmail.Text.Trim(),
                    Password = txtCurPwd.Text.Trim(),
                    NewPassword = txtNewPwd.Text.Trim()
                };
                LoggedUserDto loggedUser = new LoggedUserDto();
                using (HttpClient client = new HttpClient())
                {
                    string path = "Authentication/PasswordReset";
                    client.BaseAddress = new Uri(GlobalData.BaseUri);

                    var json = JsonConvert.SerializeObject(oChangePwdDto);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = client.PostAsync(path, content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        ShowSuccessMessage(ResponseMessages.PasswordResetSuccess);
                        txtCurPwd.Text = string.Empty;
                        txtNewPwd.Text = string.Empty;
                        txtReNewPwd.Text = string.Empty;
                    }
                    else
                    {
                        ShowErrorMessage(ResponseMessages.LoginFail);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
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
    }
}