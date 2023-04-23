using System;

using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using GivMED.Common;
using GivMED.Dto;
using GivMED.Models;
using GivMED.Service;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static GivMED.Common.Enums;

namespace GivMED.Pages.Web.Registration
{
    public partial class DonorRegistration : System.Web.UI.Page
    {
        private RegistrationService oRegistrationService = new RegistrationService();
        CommonService oCommonService = new CommonService();

        protected void Page_Load(object sender, EventArgs e)
        {
            EmailConfigurationLoad();
            mvFundreg.ActiveViewIndex = 0;
        }

        private void EmailConfigurationLoad()
        {
            EmailConfiguration oEmailConfiguration = oCommonService.GetEmailConfiguration();
            GlobalData.Port = oEmailConfiguration.Port;
            GlobalData.SmtpAddress = oEmailConfiguration.SmtpAddress;
            GlobalData.NoreplyEmail = oEmailConfiguration.EmailAddress;
            GlobalData.NoreplyPassword = oEmailConfiguration.Password;
        }
        protected void btnRegisterOrg_Click(object sender, EventArgs e)
        {
            if (txtPwdOrg.Text.Length >= 6)
            {
                if (!oCommonService.GetIsUserAvailability(txtEmailOrg.Text))
                {
                    EmailSender(txtEmailOrg.Text);
                    lblEmailOrg.Text = txtEmailOrg.Text.ToString();
                    ScriptManager.RegisterStartupScript(this, GetType(), "showemailverify", "showemailverifyorg();", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "carouselSlide", "$('#carouselExampleIndicators').carousel('next');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "carouselSlide", "$('#carouselExampleIndicators').carousel('next');", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Swal.fire({icon: 'error', title: 'Email Already Exists!', showConfirmButton: false, timer: 1500});", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "carouselSlide", "$('#carouselExampleIndicators').carousel('next');", true);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Swal.fire({icon: 'error', title: 'Password minimum 6 characters required!', showConfirmButton: false, timer: 1500});", true);
            }

        }

        protected void btnRegisterInd_Click(object sender, EventArgs e)
        {
            if (txtPwdInd.Text.Length >= 6)
            {
                if (!oCommonService.GetIsUserAvailability(txtEmailInd.Text))
                {
                    EmailSender(txtEmailInd.Text);
                    lblEmail.Text = txtEmailInd.Text.ToString();
                    ScriptManager.RegisterStartupScript(this, GetType(), "showemailverify", "showemailverify();", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "carouselSlide", "$('#carouselExampleIndicators').carousel('prev');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "carouselSlide", "$('#carouselExampleIndicators').carousel('prev');", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Swal.fire({icon: 'error', title: 'Email Already Exists!', showConfirmButton: false, timer: 1500});", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "carouselSlide", "$('#carouselExampleIndicators').carousel('prev');", true);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Swal.fire({icon: 'error', title: 'Password minimum 6 characters required!', showConfirmButton: false, timer: 1500});", true);
            }

        }

        private void EmailSender(string emailuser)
        {
            try
            {
                var random = new Random();
                var code = random.Next(100000, 999999); // Generate a 6-digit code

                Session["emailGenarateCode"] = code;

                var email = new MimeMessage();

                email.From.Add(new MailboxAddress("GiveMED email verification", GlobalData.NoreplyEmail));
                email.To.Add(new MailboxAddress("User", emailuser));

                email.Subject = "Your verification code";
                email.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
                {
                    Text = $"Your verification code is {code}"
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

        protected void btnVerify_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            if(txtCode.Text == Session["emailGenarateCode"].ToString())
            {
                RegisteredInd();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showemailverify", "showemailverify();", true);
                lblError.Text = "Wrong Code. Try again";
            }
        }

        protected void btnVerifyOrg_Click(object sender, EventArgs e)
        {
            lblErrorOrg.Text = string.Empty;
            if (txtCodeOrg.Text == Session["emailGenarateCode"].ToString())
            {
                RegisterdOrg();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showemailverifyorg", "showemailverifyorg();", true);
                lblErrorOrg.Text = "Wrong Code. Try again";
            }
        }

        private void RegisteredInd()
        {
            Session["UserName"] = null;
            WebApiResponse response = new WebApiResponse();
            response = oRegistrationService.CreateUser(UiToModelCreateInd());

            if (response.StatusCode == (int)StatusCode.Success)
            {
                txtCode.Text = string.Empty;
                lblError.Text = string.Empty;
                Session["emailGenarateCode"] = null;
                UserDto getuser = UiToModelCreateInd();
                Session["UserName"] = getuser.UserName.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "HideModalBackdrop", "$('.modal-backdrop').removeClass('show');", true);
                Response.Redirect("/Pages/Login.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Swal.fire({icon: 'error', title: 'An error occurred!', text: 'Please try again later.', confirmButtonText: 'Ok'});", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "HideModalBackdrop", "$('.modal-backdrop').removeClass('show');", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "carouselSlide", "$('#carouselExampleIndicators').carousel('prev');", true);
                txtEmailInd.Focus();
            }
        }

        private void RegisterdOrg()
        {
            Session["UserName"] = null;
            WebApiResponse response = new WebApiResponse();
            response = oRegistrationService.CreateUser(UiToModelCreaterOrg());

            if (response.StatusCode == (int)StatusCode.Success)
            {
                txtCodeOrg.Text = string.Empty;
                lblErrorOrg.Text = string.Empty;
                Session["emailGenarateCode"] = null;
                UserDto getuser = UiToModelCreaterOrg();
                Session["UserName"] = getuser.UserName.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "HideModalBackdrop", "$('.modal-backdrop').removeClass('show');", true);
                Response.Redirect("/Pages/Login.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Swal.fire({icon: 'error', title: 'An error occurred!', text: 'Please try again later.', confirmButtonText: 'Ok'});", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "HideModalBackdrop", "$('.modal-backdrop').removeClass('show');", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "carouselSlide", "$('#carouselExampleIndicators').carousel('next');", true);
                txtEmailOrg.Focus();
            }

        }
    }
}