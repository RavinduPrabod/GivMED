using GivMED.Common;
using GivMED.Dto;
using GivMED.Models;
using GivMED.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static GivMED.Common.Enums;

namespace GivMED.Pages.App.Hospital
{
    public partial class DonorContribution : System.Web.UI.Page
    {
        SupplyService oSupplyService = new SupplyService();
        private ProfileService oProfileService = new ProfileService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                PageLoad();
                mvDonorCont.ActiveViewIndex = 0;
                pnlContact.Visible = false;

            }
        }
        private void PageLoad()
        {
            LoadGridView();
        }

        private void LoadGridView()
        {
            Session["DonorContList"] = null;
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
                odata.pendingcount = item.pendingcount;

                requestedQty = item.RequestQty;
                donatedQty = item.DonatedQty;

                // Calculate donated percentage
                double donatedPercentage = (double)donatedQty / requestedQty * 100;
                // Round to 2 decimal places
                donatedPercentage = Convert.ToInt32(donatedPercentage);

                odata.Proceprecent = Convert.ToInt32(donatedPercentage);

                result.Add(odata);
            }

            gvDonorProgress.DataSource = result;
            gvDonorProgress.DataBind();
            if (result.Count > 0)
                Session["DonorContList"] = result;
        }

            protected void gvDonorProgress_RowDataBound(object sender, GridViewRowEventArgs e)
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

        private void LoadDonorsList()
        {       
            try
            {
                GridViewRow oGridViewRow = gvDonorProgress.Rows[Convert.ToInt32(ViewState["index"])];
                string SupplyID = ((Label)oGridViewRow.FindControl("lblSupplyID")).Text.ToString();
                lblSupplyCode.Text = SupplyID.ToString();
                List<DonationContributeGridDto> record = oSupplyService.GetDonorsForID(SupplyID);
                if (record.Count > 0)
                    Session["DonationContribute"] = record;
                List<DonationContributeGridDto> orecordbyName = new List<DonationContributeGridDto>();
                foreach (string name in record.Select(x => x.DonorName).Distinct())
                {
                    DonationContributeGridDto odata = new DonationContributeGridDto();
                    odata.DonorName = name;
                    odata.UserName = record.Where(x => x.DonorName == name).First().UserName;
                    orecordbyName.Add(odata);
                }
                gvDonorNamelist.DataSource = orecordbyName;
                gvDonorNamelist.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GetCashInflowByGroup(string DonName, GridView gvDonationIdList)
        {
            try
            {
                List<DonationContributeGridDto> oInflow = (List<DonationContributeGridDto>)Session["DonationContribute"];

                List<DonationContributeGridDto> oresult = new List<DonationContributeGridDto>();
                foreach (string DonationID in oInflow.Where(x => x.DonorName == DonName).Select(y => y.DonationID).Distinct())
                {
                    DonationContributeGridDto odata = new DonationContributeGridDto();
                    odata.DonationID = DonationID;
                    odata.DonorID = oInflow.Where(x => x.DonationID == DonationID).First().DonorID;
                    odata.Status = oInflow.Where(x => x.DonationID == DonationID).First().Status;
                    oresult.Add(odata);
                }
                gvDonationIdList.DataSource = oresult;
                gvDonationIdList.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void GetCashInflowByCustomer(string donationid, GridView gvDonorDetails)
        {
            try
            {
                List<DonationContributeGridDto> oInflow = (List<DonationContributeGridDto>)Session["DonationContribute"];

                List<DonationContributeGridDto> oresult = new List<DonationContributeGridDto>();
                foreach (string SupplyItemName in oInflow.Where(x => x.DonorName == Session["DonName"].ToString() && x.DonationID == donationid).Select(y => y.SupplyItemName).Distinct())
                {
                    DonationContributeGridDto odata = new DonationContributeGridDto();
                    odata.SupplyItemName = SupplyItemName;
                    odata.SupplyItemCat = oInflow.Where(x => x.SupplyItemName == SupplyItemName && x.DonationID == donationid).First().SupplyItemCat;
                    odata.DonatedQty = oInflow.Where(x => x.SupplyItemName == SupplyItemName && x.DonationID == donationid).First().DonatedQty;
                    oresult.Add(odata);
                }
                gvDonorDetails.DataSource = oresult;
                gvDonorDetails.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void gvDonorProgress_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                switch (e.CommandName)
                {
                    case "View":
                        ViewState["index"] = e.CommandArgument.ToString();
                        LoadDonorsList();
                        mvDonorCont.ActiveViewIndex = 1;
                        break;

                    //case "EditData":
                    //    ViewState["index"] = e.CommandArgument.ToString();
                    //    ViewRecord();
                    //    btnPublish.Visible = false;
                    //    btnRePublish.Visible = true;
                    //    break;

                    //case "DeleteData":
                    //    ViewState["index"] = e.CommandArgument.ToString();
                    //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowDeleteConfirmation();", true);
                    //    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvDonorlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Session["DonName"] = null;
                Session["DonName"] = gvDonorNamelist.DataKeys[e.Row.RowIndex].Value.ToString();
                GridView gvDonationIdList = e.Row.FindControl("gvDonationIdList") as GridView;
                GetCashInflowByGroup(Session["DonName"].ToString(), gvDonationIdList);
            }
        }

        protected void gvDonationIdList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Session["DtnID"] = null;
                GridView gvDonorNamelist = e.Row.NamingContainer as GridView;
                Session["DtnID"] = gvDonorNamelist.DataKeys[e.Row.RowIndex].Values[0].ToString();
                GridView gvDonorDetails = e.Row.FindControl("gvDonorDetails") as GridView;
                GetCashInflowByCustomer(Session["DtnID"].ToString(), gvDonorDetails);
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblStatus = (Label)e.Row.FindControl("lblHeader1Status");
                LinkButton btnConfirm = (LinkButton)e.Row.FindControl("btnConfirm");

                if (lblStatus.Text == "1")
                {
                    btnConfirm.Visible = false;
                }
                else
                {
                    btnConfirm.Visible = true;
                }
            }
        }

        private void ResizeGrid()
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Script", "ResizeGrid();", true);
        }

        protected void gvDonationIdList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "ShowConfirm")
                {
                    Session["DonationCode"] = null;
                    Session["DonorID"] = null;

                    int rowIndex = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
                    GridView gvDonationIdList = (GridView)row.FindControl("gvDonationIdList");
                    Session["DonationCode"] = ((Label)row.FindControl("lblHeader1Value")).Text;
                    Session["DonorID"] = ((Label)row.FindControl("lblHeader1DonorID")).Text;

                    ScriptManager.RegisterStartupScript(this, GetType(), "ShowRating", "ShowRating();", true);
                    // Use the donationId variable here as needed
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void btnSubmitFeedback_Click(object sender, EventArgs e)
        {
            string rating = Request.Form["rate"];

            if(rating != "" && rating != null)
            {
                LoggedUserDto loggedUser = (LoggedUserDto)Session["loggedUser"];

                DonationFeedback ofeed = new DonationFeedback();
                ofeed.SupplyCode = lblSupplyCode.Text.ToString();
                ofeed.DonationID = Session["DonationCode"].ToString();
                ofeed.DonorID = Convert.ToInt32(Session["DonorID"]);
                ofeed.HospitalID = loggedUser.HospitalID;
                ofeed.FeedbackText = txtFeedback.Text.ToString();
                ofeed.StartRatings = Convert.ToInt32(rating);
                ofeed.Status = 1;
                ofeed.CreatedBy = "admin";
                ofeed.CreatedDateTime = DateTime.Now;

                WebApiResponse response = new WebApiResponse();
                response = oSupplyService.PostFeedBack(ofeed);

                if (response.StatusCode == (int)StatusCode.Success)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "sweetAlert", "Swal.fire({title: 'Thank you for your feedback!', text: 'Your feedback has been successfully submitted.', icon: 'success'}).then(function() { $('#modal-Show').modal('hide'); $('.modal-backdrop').fadeOut('fast', function () { $(this).remove(); }); });", true);
                    txtFeedback.Text = string.Empty;
                    LoadDonorsList();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "ShowRating", "ShowRating();", true);
                    ShowErrorMessage(ResponseMessages.Error);
                }

               
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowRating", "ShowRating();", true);
                ShowErrorMessage("Please Rated using Stars");
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

        protected void gvDonorNamelist_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                switch (e.CommandName)
                {
                    case "ShowContact":
                        ViewState["index"] = e.CommandArgument.ToString();
                        LoadContact();
                        pnlContact.Visible = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadContact()
        {
            GridViewRow oGridViewRow = gvDonorNamelist.Rows[Convert.ToInt32(ViewState["index"])];
            string UserName = ((Label)oGridViewRow.FindControl("lblHeader1UserName")).Text.ToString();

            DonorMaster odata = oProfileService.GetDonorMaster(UserName);
            Session["DonorID"] = odata.DonorID;
            if (odata.DonorType == 2)
            {
                lblName.Text = odata.DonorFirstName.ToString();
                lblDtype.Text = Enum.GetName(typeof(typeofOrg), Convert.ToInt32(odata.OrgType)).ToString();
                lblContact.Text = odata.Designation + odata.ContactPerson;
            }
            else
            {
                lblName.Text = odata.DonorFirstName.ToString() + " " + odata.DonorLastName.ToString();
                lblDtype.Text = "Individual";
                lblContact.Text = odata.Email.ToString();
            }

            lblAddress.Text = odata.Address.ToString() + "\r\n\r\n"
                 + "City: " + odata.City + "\r\n\r\n"
                 + "State: " + odata.State.ToString() + "\r\n\r\n"
                 + "Country: " + odata.Country.ToString();
            lblTele.Text = odata.Telephone.ToString();
            lblPublicStatus.Text = "Donation Publicity: " + (odata.PublicStatus == 1 ? "Enable" : "Disable");

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
        private void UseOpenAI()
        {
            string query = "Write 100 word limit Feedback Message for donor of Medical supplies donation.";
            WebApiResponse response = new WebApiResponse();
            response = oSupplyService.UseChatGPTFeedBack(query);

            if (response.StatusCode == (int)StatusCode.Success)
            {
                txtFeedback.Text = string.Empty;
                string trimmedString = response.Result.Replace("\n\n", "").Trim();
                txtFeedback.Text = trimmedString.ToString();
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowRating", "ShowRating();", true);
            }
            else
            {
                ShowErrorMessage(ResponseMessages.Error);
            }
        }
        protected void btnfeedbackwriter_Click(object sender, EventArgs e)
        {
            UseOpenAI();
        }

        protected void btnBackPage_Click(object sender, EventArgs e)
        {
            mvDonorCont.ActiveViewIndex = 0;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            try
            {
                Session["donorcountFilterList"] = null;
                List<HospitalSupplyNeedsGridDto> records = Session["DonorContList"] != null ? (List<HospitalSupplyNeedsGridDto>)Session["DonorContList"] : new List<HospitalSupplyNeedsGridDto>();
                if (!string.IsNullOrEmpty(txtSearch.Text))
                {
                    List<HospitalSupplyNeedsGridDto> filterList = records.Where(x => x.SearchIndex.Replace(" ", "").ToUpper().Split('-').Contains(txtSearch.Text.Trim().Replace(" ", "").ToUpper())).ToList();
                    if (filterList.Count == 0)
                    {
                        filterList = records.Where(x => x.SearchIndex.Replace(" ", "").ToUpper().Contains(txtSearch.Text.Trim().Replace(" ", "").ToUpper())).ToList();
                    }
                    gvDonorProgress.DataSource = filterList;
                    gvDonorProgress.DataBind();
                    if (filterList.Count > 0)
                    {
                        Session["donorcountFilterList"] = filterList;
                    }

                }
                else
                {
                    gvDonorProgress.DataSource = records;
                    gvDonorProgress.DataBind();
                    if (records.Count > 0)
                    {
                        Session["donorcountFilterList"] = records;
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