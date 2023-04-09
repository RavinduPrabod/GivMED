using GivMED.Common;
using GivMED.Dto;
using GivMED.Models;
using GivMED.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static GivMED.Common.Enums;

namespace GivMED.Pages.App.Profile
{
    public partial class Profile : System.Web.UI.Page 
    {
        private ProfileService oProfileService = new ProfileService();
        string filepath = @"C:\Users\prabod\Documents\Pictures";
        string fileSavepath = @"C:\Users\prabod\Documents\Pictures\";

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LoggedUserDto loggedUser = (LoggedUserDto)Session["loggedUser"];
                Session["DonorID"] = null;

                ClearAllTextBoxes(this);

                lblUsername.Text = loggedUser.UserName;
                lblPdName.Text = loggedUser.FirstName;
                txtSecEmail.Text = loggedUser.UserName;
                btnSave.Visible = false;
                btnSubmit.Visible = false;
                txtNewPwd.Enabled = false;
                txtReNewPwd.Enabled = false;

                if (!oProfileService.CheckDonorMaster(loggedUser.UserName))
                {
                    txtFirstName.Text = loggedUser.Type == 1 ? "" : loggedUser.FirstName;
                    txtLastName.Text = loggedUser.Type == 1 ? "" : loggedUser.LastName;
                    txtEmail.Text = loggedUser.UserName;
                    txtOrgName.Text = loggedUser.Type == 2 ? "" : loggedUser.FirstName;
                    btnSave.Visible = false;
                    btnSubmit.Visible = true;
                }
                else
                {
                    DonorMaster odata = oProfileService.GetDonorMaster(loggedUser.UserName);
                    Session["DonorID"] = odata.DonorID;
                    txtFirstName.Text = odata.DonorFirstName.ToString();
                    txtLastName.Text = odata.DonorLastName.ToString();
                    txtAddress.Text = odata.Address.ToString();
                    txtTelephone.Text = odata.Telephone.ToString();
                    txtCity.Text = odata.City.ToString();
                    ddlState.SelectedValue = odata.State.ToString();
                    ddlCountry.SelectedValue = odata.Country.ToString();
                    txtZipCode.Text = odata.ZipCode.ToString();
                    txtEmail.Text = odata.Email.ToString();
                    if (loggedUser.Type == 2)
                    {
                        txtOrgName.Text = odata.DonorFirstName.ToString();
                        txtContactPerson.Text = odata.ContactPerson.ToString();
                        txtDesignation.Text = odata.Designation.ToString();
                        ddlOrgType.SelectedValue = odata.OrgType.ToString();
                    }
                    txtDescription.Text = odata.Description.ToString();
                    btnSave.Visible = true;
                    btnSubmit.Visible = false;
                }

                //txtFirstName.Attributes["value"] = "ravindu";

                if (loggedUser.Type == 1)
                {
                    pnlOrg1.Visible = false;
                    pnlOrg2.Visible = false;
                    pnlInd1.Visible = true;
                }
                else
                {
                    pnlOrg1.Visible = true;
                    pnlOrg2.Visible = true;
                    pnlInd1.Visible = false;
                }
                txtCurPwd.Text = string.Empty;
                LoadProfileImage(loggedUser.UserName);
                ScriptManager.RegisterStartupScript(this, GetType(), "ActivateSettingsTab", "<script>$(function() { " + "$('.nav-tabs a[href=\"#settings\"]').tab('show');" + "$('.tab-pane#settings').addClass('active');" + "});</script>", false);
            }
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            Uploadfile();
            ScriptManager.RegisterStartupScript(this, GetType(), "ActivateSettingsTab", "<script>$(function() { " + "$('.nav-tabs a[href=\"#settings\"]').tab('show');" + "$('.tab-pane#settings').addClass('active');" + "});</script>", false);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            WebApiResponse response = new WebApiResponse();
            response = oProfileService.PostDonor(UiToModelCreaterDonor());

            if (response.StatusCode == (int)StatusCode.Success)
            {
                ShowSuccessMessage(ResponseMessages.InsertSuccess);
                btnSubmit.Visible = false;
                btnSave.Visible = true;
            }
            else
            {
                ShowErrorMessage(ResponseMessages.Error);
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "ActivateSettingsTab", "<script>$(function() { " + "$('.nav-tabs a[href=\"#settings\"]').tab('show');" + "$('.tab-pane#settings').addClass('active');" + "});</script>", false);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            WebApiResponse response = new WebApiResponse();
            response = oProfileService.PutDonor(UiToModelUpdateDonor());

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
                                ShowErrorMessage(ResponseMessages.NewPasswordNotMatch);
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

        #endregion Events

        #region Methods
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

        private DonorMaster UiToModelCreaterDonor()
        {
            LoggedUserDto loggedUser = (LoggedUserDto)Session["loggedUser"];

            DonorMaster oData = new DonorMaster();

            oData.DonorID = 0;
            oData.UserName = lblUsername.Text.Trim();
            if (loggedUser.Type == 1)
            {
                oData.DonorFirstName = txtFirstName.Text.Trim();
                oData.DonorLastName = txtLastName.Text.Trim();
                oData.ContactPerson = "IND";
                oData.Designation = "IND";
                oData.OrgType = 1;
                oData.DonorType = 1;
            }
            else
            {
                oData.DonorFirstName = txtOrgName.Text.Trim();
                oData.DonorLastName = txtOrgName.Text.Trim();
                oData.ContactPerson = txtContactPerson.Text.Trim();
                oData.Designation = txtDesignation.Text.Trim();
                oData.OrgType = Convert.ToInt32(ddlOrgType.SelectedItem.Value);
                oData.DonorType = 2;
            }
            oData.Address = txtAddress.Text.Trim().ToString();
            oData.Telephone = txtTelephone.Text.Trim().ToString();
            oData.City = txtCity.Text.Trim().ToString();
            oData.State = ddlState.SelectedItem.Text.Trim();
            oData.Country = ddlCountry.SelectedItem.Text.Trim();
            oData.ZipCode = txtZipCode.Text.Trim();
            oData.Email = txtEmail.Text.Trim();
            oData.Description = txtDescription.Text.Trim();
            oData.CreatedDateTime = DateTime.Now;
            oData.CreatedBy = "admin";
            oData.ModifiedDateTime = DateTime.Now;
            oData.ModifiedBy = "admin";
            return oData;
        }

        private DonorMaster UiToModelUpdateDonor()
        {
            LoggedUserDto loggedUser = (LoggedUserDto)Session["loggedUser"];

            DonorMaster oData = new DonorMaster();

            oData.DonorID = Convert.ToInt32(Session["DonorID"]);
            oData.UserName = lblUsername.Text.Trim();
            if (loggedUser.Type == 1)
            {
                oData.DonorFirstName = txtFirstName.Text.Trim();
                oData.DonorLastName = txtLastName.Text.Trim();
                oData.ContactPerson = "IND";
                oData.Designation = "IND";
                oData.OrgType = 1;
                oData.DonorType = 1;
            }
            else
            {
                oData.DonorFirstName = txtOrgName.Text.Trim();
                oData.DonorLastName = txtOrgName.Text.Trim();
                oData.ContactPerson = txtContactPerson.Text.Trim();
                oData.Designation = txtDesignation.Text.Trim();
                oData.OrgType = Convert.ToInt32(ddlOrgType.SelectedItem.Value);
                oData.DonorType = 2;
            }
            oData.Address = txtAddress.Text.Trim().ToString();
            oData.Telephone = txtTelephone.Text.Trim().ToString();
            oData.City = txtCity.Text.Trim().ToString();
            oData.State = ddlState.SelectedItem.Text.Trim();
            oData.Country = ddlCountry.SelectedItem.Text.Trim();
            oData.ZipCode = txtZipCode.Text.Trim();
            oData.Email = txtEmail.Text.Trim();
            oData.Description = txtDescription.Text.Trim();
            oData.ModifiedDateTime = DateTime.Now;
            oData.ModifiedBy = "admin";
            return oData;
        }

        protected void Uploadfile()
        {
            try
            {
                if (FileUpload1.HasFile)
                {
                    if (FileUpload1.FileBytes.Length < 5242880)
                    {
                        foreach (HttpPostedFile fuImg in FileUpload1.PostedFiles)
                        {
                            string filePath = fuImg.FileName;
                            string filename = Path.GetFileName(filePath);
                            string extension = Path.GetExtension(filename);

                            Stream fs = fuImg.InputStream;
                            BinaryReader br = new BinaryReader(fs);
                            byte[] bytes = br.ReadBytes((Int32)fs.Length);

                            if (extension == ".jpeg" || extension == ".png" || extension == ".svg" || extension == ".jpg")
                            {
                                switch (extension)
                                {
                                    case ".jpeg":
                                        AddImageType(bytes, filename);
                                        break;

                                    case ".png":
                                        AddImageType(bytes, filename);
                                        break;

                                    case ".svg":
                                        AddImageType(bytes, filename);
                                        break;

                                    case ".jpg":
                                        AddImageType(bytes, filename);
                                        break;
                                }
                            }
                            else
                            {
                                ShowErrorMessage("Invalid Format");
                            }
                        }
                    }
                    else
                    {
                        ShowErrorMessage("Image Size Exceeded 2MB");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AddImageType(byte[] bytes, string filename)
        {
            try
            {
                LoggedUserDto loggedUser = (LoggedUserDto)Session["loggedUser"];

                ProfileImages oimg = new ProfileImages();
                oimg.UserName = loggedUser.UserName.ToString();
                oimg.FileName = filename.ToString();
                oimg.CreatedBy = "admin";
                oimg.CreatedDateTime = DateTime.Now;
                WebApiResponse response = new WebApiResponse();
                response = oProfileService.UploadImages(oimg);

                //save physical path
                WriteImage(bytes, oimg.FileName);

                //save cache
                byte[] fileBytes = FileUpload1.FileBytes;
                HttpRuntime.Cache.Insert(oimg.FileName, fileBytes);
                LoadProfileImageCache(oimg.FileName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadProfileImageCache(string FileName)
        {
            byte[] showbyte = HttpRuntime.Cache.Get(FileName) as byte[];
            if (showbyte != null)
            {
                string base64String = "data:image/jpeg;base64," + Convert.ToBase64String(showbyte);
                imgPd.ImageUrl = base64String;
            }
        }

        private void LoadProfileImage(string UserName)
        {
            var image = oProfileService.GetImage(UserName);
            string fileName = image?.FileName?.ToString() ?? "user.png";

            string filePath = Path.Combine(@"C:\Users\prabod\Documents\Pictures\", fileName);
            if (File.Exists(filePath))
            {
                byte[] imgBytes = File.ReadAllBytes(filePath);
                string base64String = "data:image/jpeg;base64," + Convert.ToBase64String(imgBytes);
                imgPd.ImageUrl = base64String;
            }
        }
        private void WriteImage(byte[] img, string FileName)
        {
            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }

            FileUpload1.SaveAs(fileSavepath + FileName);
            fileSavepath = @"C:\Users\prabod\Documents\Pictures\";
        }

        private void ShowSuccessMessage(string msg)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowSuccessMessage('" + msg + "');", true);
        }

        private void ShowErrorMessage(string msg)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowErrorMessage('" + msg + "');", true);
        }
        #endregion Methods
    }
}