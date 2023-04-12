using GivMED.Common;
using GivMED.Dto;
using GivMED.Models;
using GivMED.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
                mvSupply.ActiveViewIndex = 0;

                //DataTable dt = new DataTable();
                //dt.Columns.Add("#", typeof(int));
                //dt.Columns.Add("User", typeof(string));
                //dt.Columns.Add("Date", typeof(DateTime));
                //dt.Columns.Add("Status", typeof(string));
                //dt.Columns.Add("Reason", typeof(string));

                //// Add some sample data to the table
                //dt.Rows.Add(183, "John Doe", new DateTime(2014, 11, 7), "Approved", "Bacon ipsum dolor sit amet salami venison chicken flank fatback doner.");
                //dt.Rows.Add(219, "Alexander Pierce", new DateTime(2014, 11, 7), "Pending", "Bacon ipsum dolor sit amet salami venison chicken flank fatback doner.");
                //dt.Rows.Add(657, "Alexander Pierce", new DateTime(2014, 11, 7), "Approved", "Bacon ipsum dolor sit amet salami venison chicken flank fatback doner.");
                //dt.Rows.Add(175, "Mike Doe", new DateTime(2014, 11, 7), "Denied", "Bacon ipsum dolor sit amet salami venison chicken flank fatback doner.");
                //dt.Rows.Add(134, "Jim Doe", new DateTime(2014, 11, 7), "Approved", "Bacon ipsum dolor sit amet salami venison chicken flank fatback doner.");

                //// Bind the GridView to the data source
                //GridView1.DataSource = dt;
                //GridView1.DataBind();

                LoadGridView();

                ddlSupplyType.DataSource = oCommonService.GetItemCat();
                ddlSupplyType.DataValueField = "DataValueField";
                ddlSupplyType.DataTextField = "DataTextField";
                ddlSupplyType.DataBind();

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
                        if(oSupplyRequestDetails.Where(x=>x.SupplyItemID == Convert.ToInt32(lstSelection.Items[i].Value.Split('-')[0])).Any())
                        {
                            odata.SupplyItemID = Convert.ToInt32(lstSelection.Items[i].Value.Split('-')[0]);
                            odata.SupplyItemCat = Convert.ToInt32(lstSelection.Items[i].Value.Split('-')[1]);
                            odata.SupplyItemName = lstSelection.Items[i].Text.ToString();
                            oSupplyRequestDetails.Add(odata);
                        }
                        else
                        {
                            ShowErrorMessage(ResponseMessages.AlreadyExists);
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
            List<SupplyRequestHeader> olist = new List<SupplyRequestHeader>();
            olist = oSupplyService.GetSupplyNeedHeaderlist();

            //olist.ForEach(x => x.SupplyStatus = 50);

            gvSupplyNeeds.DataSource = olist;
            gvSupplyNeeds.DataBind();

            //progressBar.Style["width"] = $"{dataValue}%";
            //progressBar.Text = $"<span class='sr-only'>{dataValue}% Complete</span>";
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
                ShowSuccessMessage(ResponseMessages.SuccessfullyPulished);
                // need pop
            }
            else
            {
                ShowErrorMessage(ResponseMessages.Error);
            }

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
                        ViewRecord();
                        break;

                    case "EditData":
                        ViewState["index"] = e.CommandArgument.ToString();
                        ViewRecord();
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

        protected void btnCancelTemp_Click(object sender, EventArgs e)
        {

        }

        protected void btnSaveTemp_Click(object sender, EventArgs e)
        {

        }

        protected void btnCreateNew_Click(object sender, EventArgs e)
        {
            txtTemplateName.Text = string.Empty;
            txtEditor.Text = string.Empty;

        }

        protected void btnNew_Click(object sender, EventArgs e)
        {

        }

        protected void btnedit_Click(object sender, EventArgs e)
        {

        }
    }
}