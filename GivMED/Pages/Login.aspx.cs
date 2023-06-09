﻿using GivMED.Common;
using GivMED.Dto;
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

namespace GivMED.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        CommonService oCommonService = new CommonService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Session["loggedUser"] = null;
                Session["donorisvalid"] = null;
            }
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            ValidateLogin();
        }

        private void ValidateLogin()
        {
            try
            {
                string UserName = Request.Form["email"];
                string Password = Request.Form["password"];
                UserForLoginDto loginDto = new UserForLoginDto
                {
                    UserName = Request.Form["email"],
                    Password = Request.Form["password"]
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
                        string jsnString = response.Content.ReadAsStringAsync().Result;
                        loggedUser = JsonConvert.DeserializeObject<LoggedUserDto>(jsnString);

                        Session["BaseUri"] = GlobalData.BaseUri;
                        Session["Token"] = loggedUser.TokenString;
                        GlobalData.Token = loggedUser.TokenString;

                        Session["loggedUser"] = loggedUser;
                        if(loggedUser.Type != 3)
                        {
                            ShowSuccessMessage(ResponseMessages.LoginSuccess);
                            CheckDonorMaster(loggedUser.UserName);
                            if (Convert.ToBoolean(Session["donorisvalid"]) == true)
                            {
                                Response.Redirect("~/Pages/App/Donor/Published_Needs.aspx");
                            }
                            else
                            {
                                Response.Redirect("~/Pages/App/Profile/Profile.aspx");
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Swal.fire({icon: 'error', title: 'Invalid Email Address!', text: 'Please try again later.', confirmButtonText: 'Ok'});", true);
                        }

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

        private void CheckDonorMaster(string UserName)
        {
            Session["donorisvalid"] = null;
            Session["donorisvalid"] = oCommonService.GetIsDonorAvailability(UserName);
        }

        private void ShowSuccessMessage(string msg)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowSuccessMessage", "ShowSuccessMessage('" + msg + "');", true);
        }

        private void ShowErrorMessage(string msg)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowErrorMessage", "ShowErrorMessage('" + msg + "');", true);
        }
    }
}