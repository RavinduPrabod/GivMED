using GivMED.Dto;
using GivMED.Models;
using GivMED.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GivMED.Pages.Web.Review
{
    public partial class DonationReview : System.Web.UI.Page
    {
        SupplyService oSupplyService = new SupplyService();
        ProfileService oProfileService = new ProfileService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                PageLoad();
            }
        }

        private void PageLoad()
        {
            LoadGridView();
            mvpublishNeeds.ActiveViewIndex = 0;
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

                for (int i = 0; forlist.Count > i; i++)
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

            foreach (var i in items)
            {
                ComboDTO odata = new ComboDTO();
                if (oMainList.Where(x => x.State == i.DataTextField).Any())
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
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowDonate();", true);
                        mvpublishNeeds.ActiveViewIndex = 0;
                        break;

                    case "ViewReview":
                        ViewState["index"] = e.CommandArgument.ToString();
                        LoadFeedbacks();
                        mvpublishNeeds.ActiveViewIndex = 0;
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

        private void ViewRecordForDetails()
        {
            GridViewRow oGridViewRow = gvNeedsList.Rows[Convert.ToInt32(ViewState["index"])];
            string SupplyID = ((Label)oGridViewRow.FindControl("lblSupplyID")).Text.ToString();

            List<SupplyNeedGridDto> record = oSupplyService.GetSupplyNeedGridForID(SupplyID);

            record.GroupBy(x => x.SupplyItemCat).Where(g => g.Count() > 1).SelectMany(g => g.Skip(1)).ToList().ForEach(x => x.ItemCatName = "");

            gvPopSuppliesShow.DataSource = record.OrderByDescending(x => x.SupplyItemCat);
            gvPopSuppliesShow.DataBind();
        }

        private void LoadFeedbacks()
        {
            GridViewRow oGridViewRow = gvNeedsList.Rows[Convert.ToInt32(ViewState["index"])];
            string SupplyID = ((Label)oGridViewRow.FindControl("lblSupplyID")).Text.ToString();

            List<DonationReviewFeedbackDto> result = new List<DonationReviewFeedbackDto>();
            List<DonationReviewFeedbackDto> olist = oSupplyService.GetFeedBackForSupplyID(SupplyID);

            if(olist.Count > 0)
            {
                for (int i = 0; olist.Count > i; i++)
                {
                    DonationReviewFeedbackDto odata = new DonationReviewFeedbackDto();
                    odata.HospitalName = olist[i].HospitalName;
                    odata.DonorName = olist[i].DonorName;
                    odata.FeedText = olist[i].FeedbackText;
                    DateTime now = DateTime.Now;
                    DateTime tomorrow = now.AddDays(1);

                    string formattedDateTime;

                    if (now.Date == olist[i].CreateDateTime)
                    {
                        // If the date is today, format the time as "h:mm tt" and add "today" at the end
                        formattedDateTime = now.ToString("h:mm tt") + " today";
                    }
                    else if (tomorrow.Date == olist[i].CreateDateTime)
                    {
                        // If the date is tomorrow, format the time as "h:mm tt" and add "tomorrow" at the end
                        formattedDateTime = now.ToString("h:mm tt") + " tomorrow";
                    }
                    else
                    {
                        // If the date is not today or tomorrow, format the date and time as "M/d/yyyy h:mm tt"
                        formattedDateTime = now.ToString("M/d/yyyy h:mm tt");
                    }

                    odata.FeedDate = "Shared publicly - " + formattedDateTime;


                    string fileName = (olist[i].ImageUrl == "" ? "user.png" : olist[i].ImageUrl.ToString());

                    string filePath = Path.Combine(@"C:\Users\prabod\Documents\Pictures\", fileName);
                    if (File.Exists(filePath))
                    {
                        byte[] imgBytes = File.ReadAllBytes(filePath);
                        string base64String = "data:image/jpeg;base64," + Convert.ToBase64String(imgBytes);
                        odata.ImageUrl = base64String;
                    }

                    odata.DonationID = olist[i].StartRatings.ToString() + " " + "Stars";

                    result.Add(odata);
                }

                gvFeedbacks.DataSource = result;
                gvFeedbacks.DataBind();

                ScriptManager.RegisterStartupScript(this, GetType(), "ShowFeedback", "ShowFeedback();", true);
            }
            else
            {
                ShowErrorMessage("Feedbacks are not available");
            }
        }

        private void ShowErrorMessage(string msg)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowErrorMessage('" + msg + "');", true);
        }

    }
}