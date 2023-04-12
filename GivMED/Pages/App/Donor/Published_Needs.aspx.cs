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

namespace GivMED.Pages.App.Donor
{
    public partial class Published_Needs : System.Web.UI.Page
    {
        SupplyService oSupplyService = new SupplyService();
        ProfileService oProfileService = new ProfileService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LoadGridView();
                btnConfirm.Visible = true;
                btnDonate.Visible = false;
                btnCancel.Visible = false;
                mvpublishNeeds.ActiveViewIndex = 0;
            }
        }

        private void LoadGridView()
        {
            List<PublishedNeedsGridDto> oBindList = new List<PublishedNeedsGridDto>();
            List<PublishedNeedsGridDto> oHeaderWithDetailsList = new List<PublishedNeedsGridDto>();

            oHeaderWithDetailsList = oSupplyService.GetSupplyNeedHeaderWithDetails();

            List<PublishedNeedsGridDto> SupplyIDList = oHeaderWithDetailsList.GroupBy(x => x.SupplyID).Select(group => group.First()).ToList();

            foreach (var item in SupplyIDList)
            {
                int requestedQty = 0;
                int donatedQty = 0;

                PublishedNeedsGridDto odata = new PublishedNeedsGridDto();
                List<PublishedNeedsGridDto> forlist = new List<PublishedNeedsGridDto>();
                odata.SupplyID = item.SupplyID;
                string itemsname = string.Empty;
                forlist = oHeaderWithDetailsList.Where(x => x.SupplyID == item.SupplyID).ToList();

                for (int i=0; forlist.Count > i; i++)
                {
                    itemsname = itemsname + forlist[i].SupplyItemName + ", ";

                    requestedQty = requestedQty + Convert.ToInt32(forlist[i].SupplyItemQty);
                    donatedQty = donatedQty + Convert.ToInt32(forlist[i].DonatedQty);
                }

                if (itemsname.Length > 60)
                {
                    itemsname = itemsname.Substring(0, 60) + "...";
                }
                else
                {
                    itemsname = itemsname.TrimEnd(',', ' ');
                }

                // Calculate donated percentage
                double donatedPercentage = (double)donatedQty / requestedQty * 100;

                // Round to 2 decimal places
                donatedPercentage = Convert.ToInt32(donatedPercentage);

                odata.ProcessPrecentage = Convert.ToInt32(donatedPercentage);
                odata.SupplyItemName = itemsname.ToString();
                odata.HospitalID = item.HospitalID;
                odata.HospitalName = item.HospitalName;
                odata.State = item.State;
                odata.SupplyCreateDate = item.SupplyCreateDate;
                odata.SupplyExpireDate = item.SupplyExpireDate;
                odata.SupplyPriorityLevel = item.SupplyPriorityLevel;
                oBindList.Add(odata);
            }

            int pagecount = oBindList.Count() / 10;
            lblShowCount.Text = "Showing " + Convert.ToInt32(pagecount).ToString() + " of " + Convert.ToInt32(oBindList.Count()).ToString();

            Session["MainList"] = oBindList;
            Session["FilterList"] = oBindList;

            gvNeedsList.DataSource = oBindList.OrderByDescending(x => x.SupplyCreateDate).ToList();
            gvNeedsList.DataBind();

            LoadStateList(oBindList);
        }

        private void LoadStateList(List<PublishedNeedsGridDto> oBindList)
        {
            List<PublishedNeedsGridDto> oMainList = new List<PublishedNeedsGridDto>();
            oMainList = oBindList;

            List<ComboDTO> items = new List<ComboDTO>();
            List<ComboDTO> newitems = new List<ComboDTO>();

            items.Add(new ComboDTO { DataTextField = "Ampara", DataValueField = "Ampara" });
            items.Add(new ComboDTO { DataTextField = "Anuradhapura", DataValueField = "Anuradhapura" });
            items.Add(new ComboDTO { DataTextField = "Badulla", DataValueField = "Badulla" });
            items.Add(new ComboDTO { DataTextField = "Batticaloa", DataValueField = "Batticaloa" });
            items.Add(new ComboDTO { DataTextField = "Colombo", DataValueField = "Colombo" });
            items.Add(new ComboDTO { DataTextField = "Galle", DataValueField = "Galle" });
            items.Add(new ComboDTO { DataTextField = "Gampaha", DataValueField = "Gampaha" });
            items.Add(new ComboDTO { DataTextField = "Hambantota", DataValueField = "Hambantota" });
            items.Add(new ComboDTO { DataTextField = "Jaffna", DataValueField = "Jaffna" });
            items.Add(new ComboDTO { DataTextField = "Kalutara", DataValueField = "Kalutara" });
            items.Add(new ComboDTO { DataTextField = "Kandy", DataValueField = "Kandy" });
            items.Add(new ComboDTO { DataTextField = "Kegalle", DataValueField = "Kegalle" });
            items.Add(new ComboDTO { DataTextField = "Kilinochchi", DataValueField = "Kilinochchi" });
            items.Add(new ComboDTO { DataTextField = "Kurunegala", DataValueField = "Kurunegala" });
            items.Add(new ComboDTO { DataTextField = "Mannar", DataValueField = "Mannar" });
            items.Add(new ComboDTO { DataTextField = "Matale", DataValueField = "Matale" });
            items.Add(new ComboDTO { DataTextField = "Matara", DataValueField = "Matara" });
            items.Add(new ComboDTO { DataTextField = "Monaragala", DataValueField = "Monaragala" });
            items.Add(new ComboDTO { DataTextField = "Mullaitivu", DataValueField = "Mullaitivu" });
            items.Add(new ComboDTO { DataTextField = "Nuwara Eliya", DataValueField = "Nuwara Eliya" });
            items.Add(new ComboDTO { DataTextField = "Polonnaruwa", DataValueField = "Polonnaruwa" });
            items.Add(new ComboDTO { DataTextField = "Puttalam", DataValueField = "Puttalam" });
            items.Add(new ComboDTO { DataTextField = "Ratnapura", DataValueField = "Ratnapura" });
            items.Add(new ComboDTO { DataTextField = "Trincomalee", DataValueField = "Trincomalee" });
            items.Add(new ComboDTO { DataTextField = "Vavuniya", DataValueField = "Vavuniya" });

            foreach(var i in items)
            {
                ComboDTO odata = new ComboDTO();
                if(oMainList.Where(x=>x.State == i.DataTextField).Any())
                {
                    odata.DataTextField = i.DataTextField + " (" + Convert.ToInt32(oMainList.Where(x => x.State == i.DataTextField).Count()).ToString() + ")";
                    odata.DataValueField = i.DataValueField;
                    newitems.Add(odata);
                }
            }

            lstStates.DataSource = newitems;
            lstStates.DataTextField = "DataTextField";
            lstStates.DataValueField = "DataValueField";
            lstStates.DataBind();

        }

        protected void gvNeedsList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblSupplyPriorityLevel = (Label)e.Row.FindControl("lblSupplyPriorityLevel");
                string SupplyPriorityLevel = DataBinder.Eval(e.Row.DataItem, "SupplyPriorityLevel").ToString();
                switch (SupplyPriorityLevel)
                {
                    case "1":
                        lblSupplyPriorityLevel.Text = "URGENT";
                        lblSupplyPriorityLevel.CssClass = "badge badge-danger";
                        break;
                    case "2":
                        lblSupplyPriorityLevel.Text = "NORMAL";
                        lblSupplyPriorityLevel.CssClass = "badge badge-primary";
                        break;

                    case "3":
                        lblSupplyPriorityLevel.Text = "LOW";
                        lblSupplyPriorityLevel.CssClass = "badge badge-dark";
                        break;
                }
            }
        }

        protected void ddlSortResullt_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<PublishedNeedsGridDto> oFilterList = (List<PublishedNeedsGridDto>)Session["FilterList"];
            if (ddlSortResullt.SelectedValue == "1")
            {
                oFilterList = oFilterList.OrderByDescending(x => x.SupplyCreateDate).ToList(); 
            }
            else if (ddlSortResullt.SelectedValue == "2")
            {
                oFilterList = oFilterList.OrderBy(x => x.SupplyCreateDate).ToList();
            }
            else if (ddlSortResullt.SelectedValue == "3")
            {
                oFilterList = oFilterList.OrderBy(x => x.SupplyPriorityLevel).ToList();
            }
            else if (ddlSortResullt.SelectedValue == "4")
            {
                oFilterList = oFilterList.OrderByDescending(x => x.SupplyPriorityLevel).ToList();
            }

            Session["FilterList"] = oFilterList;

            gvNeedsList.DataSource = oFilterList;
            gvNeedsList.DataBind();
        }

        protected void chkHigh_CheckedChanged(object sender, EventArgs e)
        {
            List<PublishedNeedsGridDto> oFilterList = (List<PublishedNeedsGridDto>)Session["FilterList"];

            if (chkHigh.Checked == true)
            {
                oFilterList = oFilterList.Where(x => x.SupplyPriorityLevel == 1).ToList();

                Session["FilterList"] = oFilterList;

                gvNeedsList.DataSource = oFilterList;
                gvNeedsList.DataBind();

                LoadStateList(oFilterList);
            }
            else
            {
                List<PublishedNeedsGridDto> oBeforeFilter = (List<PublishedNeedsGridDto>)Session["MainList"];

                Session["FilterList"] = oBeforeFilter;

                gvNeedsList.DataSource = oBeforeFilter;
                gvNeedsList.DataBind();

                LoadStateList(oBeforeFilter);
            }
        }

        protected void chkNormal_CheckedChanged(object sender, EventArgs e)
        {
            List<PublishedNeedsGridDto> oFilterList = (List<PublishedNeedsGridDto>)Session["FilterList"];

            if (chkNormal.Checked == true)
            {
                oFilterList = oFilterList.Where(x => x.SupplyPriorityLevel == 2 || x.SupplyPriorityLevel == 3).ToList();

                Session["FilterList"] = oFilterList;

                gvNeedsList.DataSource = oFilterList;
                gvNeedsList.DataBind();

                LoadStateList(oFilterList);
            }
            else
            {
                List<PublishedNeedsGridDto> oBeforeFilter = (List<PublishedNeedsGridDto>)Session["MainList"];

                Session["FilterList"] = oBeforeFilter;

                gvNeedsList.DataSource = oBeforeFilter;
                gvNeedsList.DataBind();

                LoadStateList(oBeforeFilter);
            }
        }

        protected void lstStates_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<PublishedNeedsGridDto> oFilterList = (List<PublishedNeedsGridDto>)Session["FilterList"];

            gvNeedsList.DataSource = oFilterList.Where(x => x.State == lstStates.SelectedItem.Value.ToString()).ToList();
            gvNeedsList.DataBind();
        }

        protected void gvNeedsList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                switch (e.CommandName)
                {
                    case "ViewData":
                        ViewState["index"] = e.CommandArgument.ToString();
                        ViewRecord();
                        btnConfirm.Visible = true;
                        btnDonate.Visible = false;
                        btnCancel.Visible = false;
                        mvpublishNeeds.ActiveViewIndex = 1;
                        break;

                    case "ShowDetails":
                        ViewState["index"] = e.CommandArgument.ToString();
                        ViewRecordForDetails();
                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowDetails", "ShowDetails();", true);
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
            GridViewRow oGridViewRow = gvNeedsList.Rows[Convert.ToInt32(ViewState["index"])];
            string SupplyID = ((Label)oGridViewRow.FindControl("lblSupplyID")).Text.ToString();
            string HospitalID = ((Label)oGridViewRow.FindControl("lblHospitalID")).Text.ToString();
            string HospitalName = ((Label)oGridViewRow.FindControl("lblHospitalName")).Text.ToString();

            Session["vSupplyID"] = null;
            Session["vHospitalID"] = null;
            Session["vHospitalName"] = null;

            Session["vSupplyID"] = SupplyID;
            Session["vHospitalID"] = HospitalID;
            Session["vHospitalName"] = HospitalName;

            List <SupplyNeedGridDto> record = oSupplyService.GetSupplyNeedGridForID(SupplyID);

            record.GroupBy(x => x.SupplyItemCat).Where(g => g.Count() > 1).SelectMany(g => g.Skip(1)).ToList().ForEach(x => x.ItemCatName = "");

            gvSupplyList.DataSource = record.OrderByDescending(x=>x.SupplyItemCat);
            gvSupplyList.DataBind();

            SupplyNeedsDto PrimaryRecords = oSupplyService.GetSupplyNeedsForID(SupplyID);

            HospitalMaster oHospitalMaster = oSupplyService.GetHospitalMasterForID(Convert.ToInt32(HospitalID));

            lblHospitalName.Text = oHospitalMaster.HospitalName.ToString();
            lblRegNo.Text = " " + oHospitalMaster.RegistrationNo.ToString(); 
            lbltype.Text = " " + Enum.GetName(typeof(typeofhospital), Convert.ToInt32(oHospitalMaster.TypeofHosptal)).ToString();
            lblYear.Text = " " + oHospitalMaster.YearEstablish.ToString();
            lblNoofBeds.Text = " " + oHospitalMaster.NoOfBeds.ToString();
            lblWeb.Text = " " + oHospitalMaster.WebURL.ToString();
            lblAddress.Text = " " + oHospitalMaster.Address.ToUpper().ToString() + "<br />" +
                              oHospitalMaster.State + " ZipCode( " + oHospitalMaster.ZipCode.ToString() + " )";
            lblPhone.Text = " " + oHospitalMaster.Telephone.ToString();
            lblEmail.Text = " " + oHospitalMaster.Email.ToString();
            txtDescription.Text = PrimaryRecords.ManageTemplate.TemplateText.ToString();
        }

        private void ViewRecordForDetails()
        {
            GridViewRow oGridViewRow = gvNeedsList.Rows[Convert.ToInt32(ViewState["index"])];
            string SupplyID = ((Label)oGridViewRow.FindControl("lblSupplyID")).Text.ToString();

            List<SupplyNeedGridDto> record = oSupplyService.GetSupplyNeedGridForID(SupplyID);

            record.GroupBy(x => x.SupplyItemCat).Where(g => g.Count() > 1).SelectMany(g => g.Skip(1)).ToList().ForEach(x => x.ItemCatName = "");

            gvPopSuppliesShow.DataSource = record.OrderByDescending(x => x.SupplyItemCat);
            gvPopSuppliesShow.DataBind();
        }

        protected void gvNeedsList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void btnBackPage_Click(object sender, EventArgs e)
        {
            mvpublishNeeds.ActiveViewIndex = 0;
        }

        protected void gvSupplyList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox txtRemainigQty = (TextBox)e.Row.FindControl("txtRemainingQty"); // Find the TextBox control in the GridView row

                // Check if the TextBox value is empty
                if (string.IsNullOrEmpty(txtRemainigQty.Text) || txtRemainigQty.Text == "0")
                {
                    txtRemainigQty.Enabled = false; // Disable the TextBox if its value is empty
                }
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            int gridcount = 0;
            int notfillcount = 0;

            foreach (GridViewRow row in gvSupplyList.Rows)
            {
                TextBox txtRemainingQty = (TextBox)row.FindControl("txtRemainingQty");

                // Check if any of the TextBoxes are filled
                if (string.IsNullOrEmpty(txtRemainingQty.Text) || txtRemainingQty.Text == "0")
                {
                    notfillcount = notfillcount+1;
                }
                gridcount = gridcount +1;
            }

            // If at least one TextBox is filled, show an error message
            if (notfillcount == gridcount)
            {
                ShowErrorMessage(ResponseMessages.pleasefill);
            }
            else
            {
                btnDonate.Visible = true;
                btnCancel.Visible = true;
                btnConfirm.Visible = false;
                foreach (GridViewRow row in gvSupplyList.Rows)
                {
                    TextBox txtRemainigQty = (TextBox)row.FindControl("txtRemainingQty"); // Find the TextBox control in the GridView row
                    txtRemainigQty.Enabled = false; // Disable the TextBox
                }
            }
        }

        protected void btnDonate_Click(object sender, EventArgs e)
        {

            List<DonationDetails> oDonationDetails = new List<DonationDetails>();
            DonationHeader oDonationHeader = new DonationHeader();
            LoggedUserDto loggedUser = (LoggedUserDto)Session["loggedUser"];

            foreach (GridViewRow row in gvSupplyList.Rows)
            {
                DonationDetails odata = new DonationDetails();

                TextBox txtRemainigQty = (TextBox)row.FindControl("txtRemainingQty");
                if (!string.IsNullOrEmpty(txtRemainigQty.Text) || txtRemainigQty.Text == "0")
                {
                    odata.DonationID = "DTN";
                    odata.SupplyID = lblSupplyIDin.Text.ToString();
                    odata.ItemID = Convert.ToInt32((Label)row.FindControl("lblSupplyItemID"));
                    odata.ItemCategory = Convert.ToInt32((Label)row.FindControl("lblSupplyItemCat"));
                    odata.ItemName = ((Label)row.FindControl("lblSupplyItemName")).ToString();
                    odata.RequestQty = Convert.ToInt64((Label)row.FindControl("lblRequestQty"));
                    odata.DonatedQty = Convert.ToInt64(txtRemainigQty);
                    odata.DonationStatus = 1;
                    odata.CreatedBy = "admin";
                    odata.CreatedDateTime = DateTime.Now;
                    odata.ModifiedBy = "admin";
                    odata.ModifiedDateTime = DateTime.Now;
                    oDonationDetails.Add(odata);
                }
            }
            //Session["vSupplyID"] = SupplyID;
            //Session["vHospitalID"] = HospitalID;
            //Session["vHospitalName"] = HospitalName;

            //oDonationHeader.DonationID = "DTN";
            //oDonationHeader.DonorID = oProfileService.GetDonorMaster(loggedUser.UserName.ToString()).DonorID;
            //oDonationHeader.UserName = loggedUser.UserName.ToString();
            //oDonationHeader.HospitalID = 
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowCancelConfirmation();", true); 
        }

        protected void btnCancelOK_Click(object sender, EventArgs e)
        {
            btnCancel.Visible = false;
            btnDonate.Visible = false;
            btnConfirm.Visible = true;
            foreach (GridViewRow row in gvSupplyList.Rows)
            {
                TextBox txtRemainigQty = (TextBox)row.FindControl("txtRemainingQty"); // Find the TextBox control in the GridView row

                if (string.IsNullOrEmpty(txtRemainigQty.Text) || txtRemainigQty.Text == "0")
                {
                    txtRemainigQty.Enabled = false; // Enable the TextBox 
                }
                else
                {
                    txtRemainigQty.Enabled = true;
                }
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