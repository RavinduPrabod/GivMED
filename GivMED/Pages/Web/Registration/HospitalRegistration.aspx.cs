using GivMED.Common;
using GivMED.Dto;
using GivMED.EmailService;
using GivMED.Models;
using GivMED.Service;
using MailKit.Net.Smtp;
using MimeKit;
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

namespace GivMED.Pages.Web.Registration
{
    public partial class HospitalRegistration : System.Web.UI.Page
    {
        private RegistrationService oRegistrationService = new RegistrationService();
        private EmailConfigurationService oEmailConfigurationService = new EmailConfigurationService();
        CommonService oCommonService = new CommonService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                PageLoad();
            }
        }
        private void EmailConfigurationLoad()
        {
            EmailConfiguration oEmailConfiguration = oCommonService.GetEmailConfiguration();
            GlobalData.Port = oEmailConfiguration.Port;
            GlobalData.SmtpAddress = oEmailConfiguration.SmtpAddress;
            GlobalData.NoreplyEmail = oEmailConfiguration.EmailAddress;
            GlobalData.NoreplyPassword = oEmailConfiguration.Password;
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
            EmailConfigurationLoad();
            txtPassword.Visible = false;
            btnNext.Visible = false;
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
            oData.MobileNo = txtContactPersonTele.Text.ToString();
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
                if(txtPassword.Text == Session["emailGenaratePassword"].ToString())
                {
                    Session["emailGenaratePassword"] = null;
                    WebApiResponse response = new WebApiResponse();
                    response = oRegistrationService.CreateUser(UiToModelCreate());
                    ValidateLogin();
                    if (response.StatusCode == (int)StatusCode.Success)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Swal.fire({icon: 'success', title: 'User Registration successful!', showConfirmButton: false, timer: 1500});", true);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "carouselSlide", "$('#carouselExampleIndicators').carousel('next');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Swal.fire({icon: 'error', title: 'An error occurred!', text: 'Please try again later.', confirmButtonText: 'Ok'});", true);
                    }
                }
            }
            catch (Exception ex) 
            {

                throw ex;
            }
            
        }

        private void ValidateLogin()
        {
            try
            {
                string UserName =txtHospitalEmail.Text.ToString();
                string Password = txtPassword.Text.ToString();
                UserForLoginDto loginDto = new UserForLoginDto
                {
                    UserName = UserName,
                    Password = Password
                };

                LoggedUserDto loggedUser = new LoggedUserDto();
                using (HttpClient client = new HttpClient())
                {
                    string path = "Authentication/HospitalRegistrationValidate";
                    client.BaseAddress = new Uri(GlobalData.BaseUri);

                    var json = JsonConvert.SerializeObject(loginDto);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = client.PostAsync(path, content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string jsnString = response.Content.ReadAsStringAsync().Result;
                        loggedUser = JsonConvert.DeserializeObject<LoggedUserDto>(jsnString);

                        Session["BaseUri"] = GlobalData.BaseUri;
                        Session["Token"] = loggedUser.TokenString;
                        GlobalData.Token = loggedUser.TokenString;

                        Session["loggedUser"] = loggedUser;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Swal.fire({icon: 'error', title: 'Login Fail!', text: 'Please try again later.', confirmButtonText: 'Ok'});", true);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnVerify_Click(object sender, EventArgs e)
        {
            if(!oCommonService.GetIsUserAvailability(txtHospitalEmail.Text))
            {
                EmailSender(txtNameofHospital.Text, txtHospitalEmail.Text);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Swal.fire({icon: 'success', title: 'A password has been sent!', text: 'Please check your email and enter the password below.', confirmButtonText: 'Ok'});", true);
                txtPassword.Visible = true;
                btnNext.Visible = true;
            }
            else
            {
                txtPassword.Visible = false;
                btnNext.Visible = false;
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Swal.fire({icon: 'error', title: 'Email Already Exists!', showConfirmButton: false, timer: 1500});", true);
            }
        }

        private void EmailSender(string name, string useremail)
        {
            try
            {
                var today = DateTime.Now.ToString("yyyyMMdd");

                // Concatenate the email, today's date, and name
                var passwordString = $"{name}{useremail}{today}";
                // Convert the string to a byte array
                var passwordBytes = Encoding.UTF8.GetBytes(passwordString);
                // Use a cryptographic hash function to generate a 128-bit hash of the password bytes
                var hasher = new System.Security.Cryptography.SHA256Managed();
                var hashBytes = hasher.ComputeHash(passwordBytes);
                // Convert the hash bytes to a base64-encoded string
                var passwordBase64 = Convert.ToBase64String(hashBytes);
                // Trim the password to 10 characters
                var password = passwordBase64.Substring(0, 10);

                Session["emailGenaratePassword"] = password;

                var email = new MimeMessage();

                email.From.Add(new MailboxAddress("GiveMED Security", GlobalData.NoreplyEmail));
                email.To.Add(new MailboxAddress("User", useremail));

                email.Subject = "GiveMED email verification - Check your email for instructions";
                email.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
                {
                    Text = $"Dear {name},A temporary password has been received for your account.\n " +
                    $"Your new password is:{password}\n\n" +
                    $"Please use this password to login to your account and reset your password. If you did not request this password reset, please contact our support team immediately.\n" +
                    $"Best regards,\n" +
                    $"The GiveMED team"
                };
                using (var smtp = new SmtpClient())
                {
                    smtp.Connect(GlobalData.SmtpAddress, GlobalData.Port);

                    smtp.Authenticate(GlobalData.NoreplyEmail, GlobalData.NoreplyPassword);

                    smtp.Send(email);
                    smtp.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
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

                    if (response.StatusCode == (int)StatusCode.Success)
                    {
                        ClearControls();
                        Response.Redirect("~/Pages/HLogin.aspx");
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
    }
}