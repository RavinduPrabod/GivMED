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
    public partial class SupplyNeeds : System.Web.UI.Page
    {
        private SupplyService oSupplyService = new SupplyService();
        private CommonService oCommonService = new CommonService();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                mvSupply.ActiveViewIndex = 1;

                ddlSupplyType.DataSource = oCommonService.GetItemCat();
                ddlSupplyType.DataValueField = "DataValueField";
                ddlSupplyType.DataTextField = "DataTextField";
                ddlSupplyType.DataBind();

                List<ItemMaster> Itembulk = oSupplyService.GetAllItem();
                Session["Itembulk"] = Itembulk;
                btnPublish.Visible = false;
                txtExpireDate.Visible = false;
            }

        }

        protected void ddlSupplyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlSupplyType.SelectedItem.Value != "")
            {
                Session["SearchList"] = null;
                Session["SeletedCatinBulk"] = null;
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
            Session["SupplyList"] = null;
            List<SupplyRequestDetails> oSupplyRequestDetails = new List<SupplyRequestDetails>();

            if (lstSelection.Items.Count > 0)
            {
                for(int i=0; lstSelection.Items.Count> i; i++)
                {
                    SupplyRequestDetails odata = new SupplyRequestDetails();
                    odata.SupplyItemID = Convert.ToInt32(lstSelection.Items[i].Value.Split('-')[0]);
                    odata.SupplyItemCat = Convert.ToInt32(lstSelection.Items[i].Value.Split('-')[1]);
                    odata.SupplyItemName = lstSelection.Items[i].Text.ToString();
                    oSupplyRequestDetails.Add(odata);
                }

                gvSupplyList.DataSource = oSupplyRequestDetails;
                gvSupplyList.DataBind();
                Session["SupplyList"] = oSupplyRequestDetails;
                btnPublish.Visible = true;
                txtExpireDate.Visible = true;
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
            }
            else
            {
                gvSupplyList.DataSource = null;
                gvSupplyList.DataBind();
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
                ShowSuccessMessage(ResponseMessages.UpdateSuccess);
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
            oHeader.SupplyNarration = txtSupplyNarration.Text;
            oHeader.SupplyPriorityLevel = (chkHigh.Checked == true) ? 1 : (chkNormal.Checked == true) ? 2 : (chkLow.Checked == true) ? 3 : 0;
            oHeader.SupplyType = 1;

            return result;
        }
    }
}