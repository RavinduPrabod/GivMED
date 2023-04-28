using GivMED.Common;
using GivMED.Dto;
using GivMED.Models;
using GivMED.Service;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static GivMED.Common.Enums;

namespace GivMED.Pages.App.Hospital
{
    public partial class SupplyNeeds : System.Web.UI.Page
    {
        private SupplyService oSupplyService = new SupplyService();
        private CommonService oCommonService = new CommonService();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                SetFunctionName();
                PageLoad();
            }

        }
        private void SetFunctionName()
        {
            try
            {
                Label lblFunctionName = this.Master.FindControl("lblFuncationName") as Label;
                lblFunctionName.Text = "Supply Needs Publish";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void PageLoad()
        {
            mvSupply.ActiveViewIndex = 0;

            EmailConfigurationLoad();

            LoadGridView();

            ddlSupplyType.DataSource = oCommonService.GetItemCat();
            ddlSupplyType.DataValueField = "DataValueField";
            ddlSupplyType.DataTextField = "DataTextField";
            ddlSupplyType.DataBind();

            LoadTemplate();

            List<ItemMaster> Itembulk = oSupplyService.GetAllItem();
            Session["Itembulk"] = Itembulk;
            btnPublish.Visible = false;
            txtExpireDate.Visible = false;
            checboxcontrol(true);

            Session["SupplyList"] = null;
            Session["SeletedCatinBulk"] = null;
            Session["SearchList"] = null;
            btnRePublish.Visible = false;
        }
        private void EmailConfigurationLoad()
        {
            EmailConfiguration oEmailConfiguration = oCommonService.GetEmailConfiguration();
            GlobalData.Port = oEmailConfiguration.Port;
            GlobalData.SmtpAddress = oEmailConfiguration.SmtpAddress;
            GlobalData.NoreplyEmail = oEmailConfiguration.EmailAddress;
            GlobalData.NoreplyPassword = oEmailConfiguration.Password;
        }
        protected void ddlSupplyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlSupplyType.SelectedItem.Value != "")
            {
                Session["SearchList"] = null;
                
                List<ItemMaster> SeletedCatinBulk = ((List<ItemMaster>)Session["Itembulk"]).Where(x => x.ItemCatID == Convert.ToInt32(ddlSupplyType.SelectedItem.Value)).ToList();

                List<ComboDTO> lstItemList = new List<ComboDTO>();

                foreach (var item in SeletedCatinBulk)
                {
                    ComboDTO odata = new ComboDTO();
                    odata.DataValueField = item.ItemID.ToString() + "-" + item.ItemCatID.ToString();
                    odata.DataTextField = item.ItemName;
                    lstItemList.Add(odata);
                }

                lstItem.DataSource = lstItemList;
                lstItem.DataTextField = "DataTextField";
                lstItem.DataValueField = "DataValueField";
                lstItem.DataBind();
                Session["SeletedCatinBulk"] = lstItemList;
                Session["SearchList"] = lstItemList; 

            }
            else
            {
                lstItem.DataSource = null;
                lstItem.Items.Clear();
            }
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                List<ComboDTO> records = Session["SearchList"] != null ? (List<ComboDTO>)Session["SearchList"] : new List<ComboDTO>();
                if (!string.IsNullOrEmpty(txtSearch.Text))
                {
                    List<ComboDTO> filterList = records.Where(x => x.DataTextField.Replace(" ", "").ToUpper().Split('-').Contains(txtSearch.Text.Trim().Replace(" ", "").ToUpper())).ToList();
                    if (filterList.Count == 0)
                    {
                        filterList = records.Where(x => x.DataTextField.Replace(" ", "").ToUpper().Contains(txtSearch.Text.Trim().Replace(" ", "").ToUpper())).ToList();
                    }
                    lstItem.Items.Clear();
                    foreach (var item in filterList)
                    {
                        ListItem assigned = new ListItem();
                        assigned.Value = item.DataValueField.ToString();
                        assigned.Text = item.DataTextField.ToString();
                        lstItem.Items.Add(assigned);
                    }
                }
                else
                {
                    lstItem.Items.Clear();
                    foreach (var item in records)
                    {
                        ListItem assigned = new ListItem();
                        assigned.Value = item.DataValueField.ToString();
                        assigned.Text = item.DataTextField.ToString();
                        lstItem.Items.Add(assigned);
                    }
                    if (records.Count > 0)
                        Session["SearchList"] = records;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnMove_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstItem.Items.Count > 0)
                {
                    if (lstItem.SelectedIndex > -1)
                    {
                        ListItem oListItem = new ListItem();
                        oListItem.Value = lstItem.SelectedItem.Value.ToString();
                        oListItem.Text = lstItem.SelectedItem.Text.ToString();

                        lstItem.Items.Remove(oListItem);
                        lstSelection.Items.Add(oListItem);
                    }
                    else
                    {
                        ShowErrorMessage(ResponseMessages.SelectFirst);
                    }
                }
                else
                {
                    ShowErrorMessage(ResponseMessages.NoRecords);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnMoveAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstItem.Items.Count > 0)
                {
                    lstItem.Items.Clear();
                    lstSelection.Items.Clear();
                    List<ComboDTO> oProducts = (List<ComboDTO>)Session["SeletedCatinBulk"];

                    foreach (var item in oProducts)
                    {
                        ListItem assigned = new ListItem();
                        assigned.Value = item.DataValueField.ToString();
                        assigned.Text = item.DataTextField.ToString();
                        lstSelection.Items.Add(assigned);
                    }
                }
                else
                {
                    ShowErrorMessage(ResponseMessages.NoRecords);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstSelection.Items.Count > 0)
                {
                    if (lstSelection.SelectedIndex > -1)
                    {
                        ListItem oListItem = new ListItem();
                        oListItem.Value = lstSelection.SelectedItem.Value.ToString();
                        oListItem.Text = lstSelection.SelectedItem.Text.ToString();

                        lstSelection.Items.Remove(oListItem);
                        lstItem.Items.Add(oListItem);
                    }
                    else
                    {
                        ShowErrorMessage(ResponseMessages.SelectFirst);
                    }
                }
                else
                {
                    ShowErrorMessage(ResponseMessages.NoRecords);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnRemoveAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstSelection.Items.Count > 0)
                {
                    lstSelection.Items.Clear();
                    lstItem.Items.Clear();
                    List<ComboDTO> oProducts = (List<ComboDTO>)Session["SeletedCatinBulk"];

                    foreach (var item in oProducts)
                    {
                        ListItem assigned = new ListItem();
                        assigned.Value = item.DataValueField.ToString();
                        assigned.Text = item.DataTextField.ToString();
                        lstItem.Items.Add(assigned);
                    }
                }
                else
                {
                    ShowErrorMessage(ResponseMessages.NoRecords);
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

        protected void btnAddtoList_Click(object sender, EventArgs e)
        {
            List<SupplyRequestDetails> oSupplyRequestDetails = Session["SupplyList"] != null ? (List<SupplyRequestDetails>)Session["SupplyList"] : new List<SupplyRequestDetails>();

            if (lstSelection.Items.Count > 0)
            {
                for(int i=0; lstSelection.Items.Count> i; i++)
                {
                    SupplyRequestDetails odata = new SupplyRequestDetails();
                    if (oSupplyRequestDetails.Count > 0)
                    {
                        if(oSupplyRequestDetails.Where(x=>x.SupplyItemID == Convert.ToInt32(lstSelection.Items[i].Value.Split('-')[0]) && x.SupplyItemCat == Convert.ToInt32(lstSelection.Items[i].Value.Split('-')[1])).Any())
                        {
                            ShowErrorMessage(ResponseMessages.AlreadyExists);
                        }
                        else
                        {
                            odata.SupplyItemID = Convert.ToInt32(lstSelection.Items[i].Value.Split('-')[0]);
                            odata.SupplyItemCat = Convert.ToInt32(lstSelection.Items[i].Value.Split('-')[1]);
                            odata.SupplyItemName = lstSelection.Items[i].Text.ToString();
                            oSupplyRequestDetails.Add(odata);
                        }
                    }
                    else
                    {
                        odata.SupplyItemID = Convert.ToInt32(lstSelection.Items[i].Value.Split('-')[0]);
                        odata.SupplyItemCat = Convert.ToInt32(lstSelection.Items[i].Value.Split('-')[1]);
                        odata.SupplyItemName = lstSelection.Items[i].Text.ToString();
                        oSupplyRequestDetails.Add(odata);
                    }
                }

                gvSupplyList.DataSource = oSupplyRequestDetails;
                gvSupplyList.DataBind();

                Session["SupplyList"] = oSupplyRequestDetails;

                btnPublish.Visible = true;
                txtExpireDate.Visible = true;
                //checboxcontrol(false);

                lstSelection.Items.Clear();
            }
            else
            {
                btnPublish.Visible = false;
                txtExpireDate.Visible = false;
                ShowErrorMessage(ResponseMessages.NoRecords);
            }
        }

        protected void gvSupplyList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                switch (e.CommandName)
                {
                    case "DeleteData":
                        ViewState["index"] = e.CommandArgument.ToString();
                        Delete();
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadGridView()
        {
            Session["FilterSupplyNeedList"] = null;
            LoggedUserDto loggedUser = (LoggedUserDto)Session["loggedUser"];

            List<HospitalSupplyNeedsGridDto> olist = new List<HospitalSupplyNeedsGridDto>();
            olist = oSupplyService.GetSupplyNeedHeaderlist(loggedUser.HospitalID);

            List<HospitalSupplyNeedsGridDto> result = new List<HospitalSupplyNeedsGridDto>();

            foreach (var item in olist)
            {
                long requestedQty = 0;
                long donatedQty = 0;

                HospitalSupplyNeedsGridDto odata = new HospitalSupplyNeedsGridDto();

                odata.SupplyID = item.SupplyID;
                odata.SupplyCreateDate = item.SupplyCreateDate;
                odata.SupplyExpireDate = item.SupplyExpireDate;
                odata.SupplyPriorityLevel = item.SupplyPriorityLevel;
                odata.SupplyStatus = item.SupplyStatus;
                requestedQty = item.RequestQty;
                donatedQty = item.DonatedQty;

                // Calculate donated percentage
                double donatedPercentage = (double)donatedQty / requestedQty * 100;
                // Round to 2 decimal places
                donatedPercentage = Convert.ToInt32(donatedPercentage);

                odata.Proceprecent = Convert.ToInt32(donatedPercentage);

                result.Add(odata);
            }

            gvSupplyNeeds.DataSource = result;
            gvSupplyNeeds.DataBind();
            if (result.Count > 0)
                Session["FilterSupplyNeedList"] = result;

            //List<HospitalSupplyNeedsGridDto> grouplist = olist.GroupBy(s => s.SupplyID)
            //                                            .Select(group => group.First())
            //                                            .ToList();
            //foreach (var item in grouplist)
            //{
            //    int requestedQty = 0;
            //    int donatedQty = 0;

            //    HospitalSupplyNeedsGridDto odata = new HospitalSupplyNeedsGridDto();

            //    odata.SupplyID = item.SupplyID;
            //    odata.SupplyCreateDate = item.SupplyCreateDate;
            //    odata.SupplyExpireDate = item.SupplyExpireDate;
            //    odata.SupplyPriorityLevel = item.SupplyPriorityLevel;

            //    List<HospitalSupplyNeedsGridDto> forlist = new List<HospitalSupplyNeedsGridDto>();
            //    forlist = olist.Where(x => x.SupplyID == item.SupplyID && x.DonatedQty > 0).ToList();

            //    if (forlist.Count > 0)
            //    {
            //        for (int i = 0; forlist.Count > i; i++)
            //        {
            //            requestedQty = requestedQty + Convert.ToInt32(olist[i].RequestQty);
            //            donatedQty = donatedQty + Convert.ToInt32(olist[i].DonatedQty);
            //        }

            //        // Calculate donated percentage
            //        double donatedPercentage = (double)donatedQty / requestedQty * 100;
            //        // Round to 2 decimal places
            //        donatedPercentage = Convert.ToInt32(donatedPercentage);
            //        odata.Proceprecent = Convert.ToInt32(donatedPercentage);
            //    }
            //    else
            //    {
            //        odata.Proceprecent = 0;
            //    }
            //    result.Add(odata);
            //}

            //gvSupplyNeeds.DataSource = result;
            //gvSupplyNeeds.DataBind();
            //if (result.Count > 0)
            //    Session["FilterSupplyNeedList"] = result;

        }

        private void Delete()
        {
            List<SupplyRequestDetails> oSupplyRequestDetails = new List<SupplyRequestDetails>();

            foreach (GridViewRow row in gvSupplyList.Rows)
            {
                // Extract data from each row and create a new SupplyRequestDetails object
                SupplyRequestDetails oRequestDetails = new SupplyRequestDetails();
                oRequestDetails.SupplyItemCat = Convert.ToInt32((row.FindControl("lblSupplyItemCat") as Label).Text);
                oRequestDetails.SupplyItemID = Convert.ToInt32((row.FindControl("lblSupplyItemID") as Label).Text);
                oRequestDetails.SupplyItemName = (row.FindControl("lblSupplyItemName") as Label).Text.ToString();
                oRequestDetails.SupplyItemQty = Convert.ToInt64((row.FindControl("txtQty") as TextBox).Text);

                // Add the new SupplyRequestDetails object to the list
                oSupplyRequestDetails.Add(oRequestDetails);
            }

            GridViewRow oGridViewRow = gvSupplyList.Rows[Convert.ToInt32(ViewState["index"])];
            int SupplyItemCat = Convert.ToInt32(((Label)oGridViewRow.FindControl("lblSupplyItemCat")).Text);
            int SupplyItemID = Convert.ToInt32(((Label)oGridViewRow.FindControl("lblSupplyItemID")).Text);

            oSupplyRequestDetails.RemoveAll(x => x.SupplyItemCat == SupplyItemCat && x.SupplyItemID == SupplyItemID);

            if (oSupplyRequestDetails.Count > 0)
            {
                gvSupplyList.DataSource = oSupplyRequestDetails;
                gvSupplyList.DataBind();
                Session["SeletedCatinBulk"] = oSupplyRequestDetails;
            }
            else
            {
                gvSupplyList.DataSource = null;
                gvSupplyList.DataBind();
                btnPublish.Visible = false;
                txtExpireDate.Visible = false;
                checboxcontrol(true);
            }
        }

        protected void btnPublish_Click(object sender, EventArgs e)
        {
            Insert();
        }

        private void Insert()
        {
            WebApiResponse response = new WebApiResponse();
            response = oSupplyService.PostSupplyNeed(UiToModelCreateSupplyNeed());

            if (response.StatusCode == (int)StatusCode.Success)
            {
                ShowSupplyPublishID(response.Result);
                EmailSender(UiToModelCreateSupplyNeed());
            }
            else
            {
                ShowErrorMessage(ResponseMessages.Error);
            }

        }

        private void EmailSender(SupplyNeedsDto Supply)
        {
            try
            {
                LoggedUserDto loggedUser = (LoggedUserDto)Session["loggedUser"];

                var email = new MimeMessage();
                email.From.Add(new MailboxAddress("GiveMED Urgent Notice", GlobalData.NoreplyEmail));
                if (Supply.SupplyRequestHeader.SupplyPriorityLevel == 1)
                {
                    email.Subject = "Urgent Notice - Medical Supplies Shortage in '" + loggedUser.FirstName + "'";
                }
                else
                {
                    email.Subject = "Notice - Medical Supplies Shortage in '" + loggedUser.FirstName + "'";
                }

                StringBuilder suppliesText = new StringBuilder();
                foreach (var supply in Supply.SupplyRequestDetails)
                {
                    suppliesText.AppendLine($"Item Name: {supply.SupplyItemName}\n Quantity: {supply.SupplyItemQty}");
                }

                email.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
                {
                    Text = $"Dear Valued Donors,\n\n" +
                    $"We hope this email finds you well. As you know, our hospital has been facing a shortage of \n" +
                    $"medical supplies due to the ongoing pandemic. We are reaching out to our previous donors\n" +
                    $"to request your urgent support to help us overcome this critical situation.\n\n" +
                    $"We are facing a critical shortage of the following medical supplies:\n\n" +
                    $"Priority Level: {(Supply.SupplyRequestHeader.SupplyPriorityLevel == 1 ? "High" : (Supply.SupplyRequestHeader.SupplyPriorityLevel == 2 ? "Normal" : "Low"))}\n\n"+
                    $"{suppliesText.ToString()}\n\n" +
                    $"Thank you for your kind consideration and support.\n" +
                    $"Best regards,\n" +
                    $"{loggedUser.FirstName}"
                };

                List<EmailUsers> EmailUserList = oCommonService.GetAllActiveEmailUsers();

                foreach(var item in EmailUserList)
                {
                    email.To.Add(new MailboxAddress("Donor", item.Email));

                    using (var smtp = new SmtpClient())
                    {
                        smtp.Connect(GlobalData.SmtpAddress, GlobalData.Port);

                        smtp.Authenticate(GlobalData.NoreplyEmail, GlobalData.NoreplyPassword);

                        smtp.Send(email);
                        smtp.Disconnect(true);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ShowSupplyPublishID(string publishID)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowSupplyPublishID('" + publishID + "');", true);
        }
        private SupplyNeedsDto UiToModelCreateSupplyNeed()
        {
            SupplyNeedsDto result = new SupplyNeedsDto();
            SupplyRequestHeader oHeader = new SupplyRequestHeader();
            List<SupplyRequestDetails> oDetails = new List<SupplyRequestDetails>();

            oHeader.HospitalID = 0;
            oHeader.SupplyID = "SPN";
            oHeader.SupplyCreateDate = DateTime.Now;
            oHeader.SupplyExpireDate = Convert.ToDateTime(txtExpireDate.Text).Date;
            //oHeader.SupplyNarration = txtSupplyNarration.Text;
            oHeader.SupplyPriorityLevel = (chkHigh.Checked == true) ? 1 : (chkNormal.Checked == true) ? 2 : (chkLow.Checked == true) ? 3 : 0;
            oHeader.SupplyType = 1;
            oHeader.SupplyStatus = 1;
            oHeader.CreatedBy = "admin";
            oHeader.CreatedDateTime = DateTime.Now;
            oHeader.ModifiedBy = "admin";
            oHeader.ModifiedDateTime = DateTime.Now;


            foreach (GridViewRow row in gvSupplyList.Rows)
            {
                // Extract data from each row and create a new SupplyRequestDetails object
                SupplyRequestDetails oData = new SupplyRequestDetails();
                oData.SupplyID = "SPN";
                oData.SupplyItemID = Convert.ToInt32((row.FindControl("lblSupplyItemID") as Label).Text);
                oData.SupplyItemCat = Convert.ToInt32((row.FindControl("lblSupplyItemCat") as Label).Text);
                oData.SupplyItemName = (row.FindControl("lblSupplyItemName") as Label).Text.ToString();
                oData.SupplyItemQty = Convert.ToInt64((row.FindControl("txtQty") as TextBox).Text);
                oData.CreatedBy = "admin";
                oData.CreatedDateTime = DateTime.Now;
                oData.ModifiedBy = "admin";
                oData.ModifiedDateTime = DateTime.Now;

                // Add the new SupplyRequestDetails object to the list
                oDetails.Add(oData);
            }

            LoggedUserDto loggedUser = (LoggedUserDto)Session["loggedUser"];

            result.UserName = loggedUser.UserName.ToString();
            result.SupplyRequestHeader = oHeader;
            result.SupplyRequestDetails = oDetails;

            return result;
        }

        private void checboxcontrol(bool result)
        {
            chkHigh.Enabled = result;
            chkNormal.Enabled = result;
            chkLow.Enabled = result;
        }

        protected void gvSupplyNeeds_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblSupplyStatus = (Label)e.Row.FindControl("lblSupplyStatus");
                string supplyStatus = DataBinder.Eval(e.Row.DataItem, "SupplyStatus").ToString();
                switch (supplyStatus)
                {
                    case "1":
                        lblSupplyStatus.Text = "Processing";
                        lblSupplyStatus.CssClass = "badge badge-warning";
                        break;
                    case "2":
                        lblSupplyStatus.Text = "Complete";
                        lblSupplyStatus.CssClass = "badge badge-success";
                        break;
                }

                Label lblSupplyPriorityLevel = (Label)e.Row.FindControl("lblSupplyPriorityLevel");
                string SupplyPriorityLevel = DataBinder.Eval(e.Row.DataItem, "SupplyPriorityLevel").ToString();
                switch (SupplyPriorityLevel)
                {
                    case "1":
                        lblSupplyPriorityLevel.Text = "High";
                        lblSupplyPriorityLevel.CssClass = "badge badge-danger";
                        break;
                    case "2":
                        lblSupplyPriorityLevel.Text = "Normal";
                        lblSupplyPriorityLevel.CssClass = "badge badge-primary";
                        break;

                    case "3":
                        lblSupplyPriorityLevel.Text = "Low";
                        lblSupplyPriorityLevel.CssClass = "badge badge-dark";
                        break;
                }
            }
        }

        protected void gvSupplyNeeds_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                switch (e.CommandName)
                {
                    case "ViewData":
                        ViewState["index"] = e.CommandArgument.ToString();
                        //ViewRecord();
                        break;

                    case "EditData":
                        ViewState["index"] = e.CommandArgument.ToString();
                        ViewRecord();
                        btnPublish.Visible = false;
                        btnRePublish.Visible = true;
                        break;

                    case "DeleteData":
                        ViewState["index"] = e.CommandArgument.ToString();
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowDeleteConfirmation();", true);
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ViewRecord()
        {
            try
            {
                GridViewRow oGridViewRow = gvSupplyNeeds.Rows[Convert.ToInt32(ViewState["index"])];
                string SupplyID = ((Label)oGridViewRow.FindControl("lblSupplyID")).Text.ToString();

                SupplyNeedsDto record = oSupplyService.GetSupplyNeedsForID(SupplyID);

                if(record.SupplyRequestHeader.SupplyPriorityLevel == 1)
                {
                    chkHigh.Checked = true;
                }
                else if(record.SupplyRequestHeader.SupplyPriorityLevel == 2)
                {
                    chkNormal.Checked = true;
                }
                else if(record.SupplyRequestHeader.SupplyPriorityLevel == 3)
                {
                    chkLow.Checked = true;
                }

                txtExpireDate.Text = record.SupplyRequestHeader.SupplyExpireDate.ToString();

                gvSupplyList.DataSource = record.SupplyRequestDetails;
                gvSupplyList.DataBind();

                Session["SupplyList"] = record.SupplyRequestDetails;

                btnPublish.Visible = true;
                txtExpireDate.Visible = true;

                mvSupply.ActiveViewIndex = 1;
                //ddlType.SelectedValue = record.Type.ToString();
                //txtInstructionName.Text = record.InstructionName.ToString();
                //txtDescription.Text = record.Instruction.ToString();
                //mvInstructions.ActiveViewIndex = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvSupplyNeeds_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            mvSupply.ActiveViewIndex = 1;
        }

        protected void btnRePublish_Click(object sender, EventArgs e)
        {

        }
        protected void btnAddtemp_Click(object sender, EventArgs e)
        {
            LoggedUserDto loggedUser = (LoggedUserDto)Session["loggedUser"];

            ManageTemplate temp = new ManageTemplate();
            temp.HospitalID = loggedUser.HospitalID;
            temp.TemplateID = 0;
            temp.TemplateText = txtEditor.Text.ToString();
            temp.CreatedBy = "admin";
            temp.CreatedDateTime = DateTime.Now;
            temp.ModifiedBy = "admin";
            temp.ModifiedDateTime = DateTime.Now;

            WebApiResponse response = new WebApiResponse();
            response = oSupplyService.PostTemplate(temp);

            if (response.StatusCode == (int)StatusCode.Success)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Swal.fire({icon: 'success', title: 'Created!', text: 'Draft'"+ response.Result+ "'.', confirmButtonText: 'Ok'});", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "HideModalBackdrop", "$('.modal-backdrop').removeClass('show');", true);
                LoadTemplate();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "HideModalBackdrop", "$('.modal-backdrop').removeClass('show');", true);
            }
        }

        private void LoadTemplate()
        {
            LoggedUserDto loggedUser = (LoggedUserDto)Session["loggedUser"];

            ddlTemplates.DataSource = oCommonService.GetTemplate(loggedUser.HospitalID);
            ddlTemplates.DataValueField = "DataValueField";
            ddlTemplates.DataTextField = "DataTextField";
            ddlTemplates.DataBind();
        }

        protected void btnSaveTemp_Click(object sender, EventArgs e)
        {

        }

        protected void btnNewTemp_Click(object sender, EventArgs e)
        {
            btnSaveTemp.Visible = false;
            btnAddtemp.Visible = true;
            txtEditor.Text = string.Empty;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowDetails();", true);
        }

        protected void btnEditTemp_Click(object sender, EventArgs e)
        {
            btnSaveTemp.Visible = true;
            btnAddtemp.Visible = false;
            txtEditor.Text = string.Empty;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowDetails();", true);
        }

        protected void ddlTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlTemplates.SelectedValue.Count() == 5)
            {
                btnNewTemp.Enabled = false;
            }
            else
            {
                btnNewTemp.Enabled = true;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            try
            {
                Session["SupplyNeedFilterList"] = null;
                List<HospitalSupplyNeedsGridDto> records = Session["FilterSupplyNeedList"] != null ? (List<HospitalSupplyNeedsGridDto>)Session["FilterSupplyNeedList"] : new List<HospitalSupplyNeedsGridDto>();
                if (!string.IsNullOrEmpty(txtSearchList.Text))
                {
                    List<HospitalSupplyNeedsGridDto> filterList = records.Where(x => x.SearchIndex.Replace(" ", "").ToUpper().Split('-').Contains(txtSearchList.Text.Trim().Replace(" ", "").ToUpper())).ToList();
                    if (filterList.Count == 0)
                    {
                        filterList = records.Where(x => x.SearchIndex.Replace(" ", "").ToUpper().Contains(txtSearchList.Text.Trim().Replace(" ", "").ToUpper())).ToList();
                    }
                    gvSupplyNeeds.DataSource = filterList;
                    gvSupplyNeeds.DataBind();
                    if (filterList.Count > 0)
                    {
                        Session["SupplyNeedFilterList"] = filterList;
                    }

                }
                else
                {
                    gvSupplyNeeds.DataSource = records;
                    gvSupplyNeeds.DataBind();
                    if (records.Count > 0)
                    {
                        Session["SupplyNeedFilterList"] = records;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}