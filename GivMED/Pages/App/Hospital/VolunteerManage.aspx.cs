using GivMED.Common;
using GivMED.Dto;
using GivMED.Models;
using GivMED.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static GivMED.Common.Enums;

namespace GivMED.Pages.App.Hospital
{
    public partial class VolunteerManage : System.Web.UI.Page
    {
        VolunteerService oVolunteerService = new VolunteerService();
        CommonService oCommonService = new CommonService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                PageLoad();
            }
        }

        private void PageLoad()
        {
            LoadGridview();
            LoadCombo();
            ClearControl();
            EnableControls(true);
            pnlvehicle.Visible = false;
            mvVol.ActiveViewIndex = 0;
        }

        private void LoadCombo()
        {
            List<ComboDTO> oVehicleCat = oCommonService.GetEnumComboWithSelect<typeofvehicle>();

            ddlVehicleCat.DataSource = oVehicleCat;
            ddlVehicleCat.DataTextField = "DataTextField";
            ddlVehicleCat.DataValueField = "DataValueField";
            ddlVehicleCat.DataBind();

            List<ComboDTO> oSkill = oCommonService.GetEnumComboWithSelect<typeofskills>();

            ddlSkill.DataSource = oSkill;
            ddlSkill.DataTextField = "DataTextField";
            ddlSkill.DataValueField = "DataValueField";
            ddlSkill.DataBind();
        }

        private void ClearControl()
        {
            txtVoName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtTele.Text = string.Empty;
            txtNIC.Text = string.Empty;
            txtVehicleNo.Text = string.Empty;
            txtEmail.Text = string.Empty;
            ddlVehicleCat.SelectedIndex = 0;
            ddlStatus.SelectedIndex = 1;
            ddlSkill.SelectedIndex = -1;
        }

        private void LoadGridview()
        {
            LoggedUserDto loggedUser = (LoggedUserDto)Session["loggedUser"];

            List<VolunteerMaster> odata = new List<VolunteerMaster>();
            odata = oVolunteerService.GetVolunteerMaster(loggedUser.HospitalID);

            gvVol.DataSource = odata;
            gvVol.DataBind();
        }

        private VolunteerMaster UiToModelAddVolunteer()
        {
            LoggedUserDto loggedUser = (LoggedUserDto)Session["loggedUser"];

            VolunteerMaster odata = new VolunteerMaster();
            odata.VolCode = "VLT";
            odata.HospitalID = loggedUser.HospitalID;
            odata.VolName = txtVoName.Text.ToString();
            odata.VolNIC = txtNIC.Text.ToString();
            odata.Address = txtAddress.Text.ToString();
            odata.Telephone = txtTele.Text.ToString();
            odata.VolEmail = txtEmail.Text.ToString();
            odata.VolSkill = Convert.ToInt32(ddlSkill.SelectedValue);

            if (ddlSkill.SelectedValue != "1")
            {
                odata.VehicleCat = Convert.ToInt32(ddlVehicleCat.SelectedValue);
                odata.VehicleNo = txtVehicleNo.Text.ToString();
            }
            else
            {
                odata.VehicleCat = 0;
                odata.VehicleNo = "None";
            }
            odata.Status = Convert.ToInt32(ddlStatus.SelectedValue);
            odata.CreateUser = "admin";
            odata.CreateDateTime = DateTime.Now;
            odata.ModifiedUser = "admin";
            odata.ModifieDateTime = DateTime.Now;

            return odata;
        }
        private VolunteerMaster UiToModelUpdateVolunteer()
        {
            LoggedUserDto loggedUser = (LoggedUserDto)Session["loggedUser"];

            VolunteerMaster odata = new VolunteerMaster();
            odata.VolCode = Session["VolID"].ToString();
            odata.HospitalID = loggedUser.HospitalID;
            odata.VolName = txtVoName.Text.ToString();
            odata.VolNIC = txtNIC.Text.ToString();
            odata.Address = txtAddress.Text.ToString();
            odata.VolEmail = txtEmail.Text.ToString();
            odata.Telephone = txtTele.Text.ToString();
            odata.VolSkill = Convert.ToInt32(ddlSkill.SelectedValue);

            if (ddlSkill.SelectedValue != "1")
            {
                odata.VehicleCat = Convert.ToInt32(ddlVehicleCat.SelectedValue);
                odata.VehicleNo = txtVehicleNo.Text.ToString();
            }
            else
            {
                odata.VehicleCat = 0;
                odata.VehicleNo = "None";
            }

            odata.Status = Convert.ToInt32(ddlStatus.SelectedValue);
            odata.CreateUser = "admin";
            odata.CreateDateTime = Convert.ToDateTime(Session["JoinDate"]);
            odata.ModifiedUser = "admin";
            odata.ModifieDateTime = DateTime.Now;

            return odata;
        }

        private void View()
        {
            Session["JoinDate"] = null;
            GridViewRow oGridViewRow = gvVol.Rows[Convert.ToInt32(ViewState["index"])];
            Session["VolID"] = ((Label)oGridViewRow.FindControl("lblVolID")).Text.ToString();

            VolunteerMaster odata = oVolunteerService.GetVolunteerMasterbyID(Session["VolID"].ToString());
            txtVoName.Text = odata.VolName.ToString();
            txtAddress.Text = odata.Address.ToString();
            txtTele.Text = odata.Telephone;
            txtNIC.Text = odata.VolNIC;
            txtEmail.Text = odata.VolEmail;
            ddlStatus.SelectedValue = odata.Status.ToString();
            ddlSkill.SelectedValue = odata.VolSkill.ToString();
            Session["JoinDate"] = odata.CreateDateTime; 
            if(ddlSkill.SelectedValue != "1")
            {
                pnlvehicle.Visible = true;
                txtVehicleNo.Text = odata.VehicleNo;
                ddlVehicleCat.SelectedValue = odata.VehicleCat.ToString();
            }
            else
            {
                pnlvehicle.Visible = false;
                txtVehicleNo.Text = odata.VehicleNo;
                ddlVehicleCat.SelectedValue = odata.VehicleCat.ToString();
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

        private void EnableControls(bool result)
        {
            txtVoName.Enabled = result;
            txtAddress.Enabled = result;
            txtTele.Enabled = result;
            txtEmail.Enabled = result;
            txtNIC.Enabled = result;
            txtVehicleNo.Enabled = result;
            ddlVehicleCat.Enabled = result;
            ddlStatus.Enabled = result;
            ddlSkill.Enabled = result;
        }

        protected void gvVol_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                Session["VolID"] = null;

                switch (e.CommandName)
                {
                    case "View":
                        ViewState["index"] = e.CommandArgument.ToString();
                        View();
                        EnableControls(false);
                        btnAdd.Visible = false;
                        btnSave.Visible = false;
                        mvVol.ActiveViewIndex = 1;
                        break;

                    case "EditData":
                        ViewState["index"] = e.CommandArgument.ToString();
                        View();
                        EnableControls(true);
                        btnAdd.Visible = false;
                        btnSave.Visible = true;
                        mvVol.ActiveViewIndex = 1;
                        break;

                    case "DeleteData":
                        ViewState["index"] = e.CommandArgument.ToString();
                        GridViewRow oGridViewRow = gvVol.Rows[Convert.ToInt32(ViewState["index"])];
                        Session["VolID"] = ((Label)oGridViewRow.FindControl("lblVolID")).Text.ToString();
                        //ScriptManager.RegisterStartupScript(this, GetType(), "DeleteConfirmation", "ShowDeleteConfirmation();", true);
                        break;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            WebApiResponse response = new WebApiResponse();
            response = oVolunteerService.PostVolunteerMaster(UiToModelAddVolunteer());

            if (response.StatusCode == (int)StatusCode.Success)
            {
                ShowSuccessMessage(ResponseMessages.InsertSuccess);
                PageLoad();
            }
            else
            {
                ShowErrorMessage(ResponseMessages.Error);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            WebApiResponse response = new WebApiResponse();
            response = oVolunteerService.PutVolunteerMaster(UiToModelUpdateVolunteer());

            if (response.StatusCode == (int)StatusCode.Success)
            {
                ShowSuccessMessage(ResponseMessages.UpdateSuccess);
                PageLoad();
            }
            else
            {
                ShowErrorMessage(ResponseMessages.Error);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            PageLoad();
            mvVol.ActiveViewIndex = 0;
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            ClearControl();
            btnAdd.Visible = true;
            btnSave.Visible = false;
            mvVol.ActiveViewIndex = 1;
        }

        private void Delete()
        {
            GridViewRow oGridViewRow = gvVol.Rows[Convert.ToInt32(ViewState["index"])];
            Session["VolID"] = ((Label)oGridViewRow.FindControl("lblVolID")).Text.ToString();

            VolunteerMaster delete = new VolunteerMaster();
            delete.VolCode = Session["VolID"].ToString();

            WebApiResponse response = new WebApiResponse();
            response = oVolunteerService.DeleteVolunteerMasterbyID(delete);

            if (response.StatusCode == (int)StatusCode.Success)
            {
                ShowSuccessMessage(ResponseMessages.UpdateSuccess);
            }
            else
            {
                ShowErrorMessage(ResponseMessages.Error);
            }
        }

        protected void ddlSkill_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlSkill.SelectedValue == "2" || ddlSkill.SelectedValue == "3")
            {
                pnlvehicle.Visible = true;
            }
            else
            {
                pnlvehicle.Visible = false;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
            PageLoad();
        }
    }
}