using GivMED.Common;
using GivMED.Dto;
using GivMED.Models;
using GivMED.Service;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static GivMED.Common.Enums;

namespace GivMED.Pages.App.Donor
{
    public partial class DonationActivities : System.Web.UI.Page
    {
        SupplyService oSupplyService = new SupplyService();
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
                lblFunctionName.Text = "Donor Activities";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void PageLoad()
        {
            EmailConfigurationLoad();
            int count = LoaGridView();
            GetInfoBoxCssClass(count);
        }
        private void EmailConfigurationLoad()
        {
            EmailConfiguration oEmailConfiguration = oCommonService.GetEmailConfiguration();
            GlobalData.Port = oEmailConfiguration.Port;
            GlobalData.SmtpAddress = oEmailConfiguration.SmtpAddress;
            GlobalData.NoreplyEmail = oEmailConfiguration.EmailAddress;
            GlobalData.NoreplyPassword = oEmailConfiguration.Password;
        }
        private int LoaGridView()
        {
            Session["DonationActList"] = null;
            LoggedUserDto loggedUser = (LoggedUserDto)Session["loggedUser"];

            List<DonationActivityDto> oBindList = new List<DonationActivityDto>();

            oBindList = oSupplyService.GetDonationHeaderDetails(loggedUser.UserName);

            if (oBindList.Count > 0)
                Session["DonationActList"] = oBindList;

            oBindList = oBindList.Where(x => x.Status == 0).ToList();
            gvDonationList.DataSource = oBindList.OrderByDescending(x=>x.DonationCreateDate).ToList();
            gvDonationList.DataBind();

            int donationcount = oBindList.Count();

            return donationcount;
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            try
            {
                Session["DonationActFilterList"] = null;
                List<DonationActivityDto> records = Session["DonationActList"] != null ? (List<DonationActivityDto>)Session["DonationActList"] : new List<DonationActivityDto>();
                if (!string.IsNullOrEmpty(txtSearch.Text))
                {
                    List<DonationActivityDto> filterList = records.Where(x => x.SearchIndex.Replace(" ", "").ToUpper().Split('-').Contains(txtSearch.Text.Trim().Replace(" ", "").ToUpper())).ToList();
                    if (filterList.Count == 0)
                    {
                        filterList = records.Where(x => x.SearchIndex.Replace(" ", "").ToUpper().Contains(txtSearch.Text.Trim().Replace(" ", "").ToUpper())).ToList();
                    }
                    gvDonationList.DataSource = filterList;
                    gvDonationList.DataBind();
                    if (filterList.Count > 0)
                    {
                        Session["DonationActFilterList"] = filterList;
                    }

                }
                else
                {
                    gvDonationList.DataSource = records;
                    gvDonationList.DataBind();
                    if (records.Count > 0)
                    {
                        Session["DonationActFilterList"] = records;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void GetInfoBoxCssClass(int count)
        {
            int score = count * 5;

            lblTotdonation.Text = count.ToString();

            lblScore.Text = score.ToString() + " Points";
            //lblprogresbar.Text = score.ToString();

           // lblprogresbar.Attributes["style"] = "width: 100%";

            if (score < 200)
            {
                double donatedPercentage = (double)score / 200 * 100;
                lblScorePrecentatge.Text = donatedPercentage.ToString() + "% Complete";

                lblprogresbar.Attributes["style"] = "width: " + donatedPercentage + "%;";

                lblMedal.Text = "Bronze";
                infoBox.Attributes["class"] = "info-box bg-info";
            }
            else if (score > 200 && score < 400)
            {
                double donatedPercentage = (double)score / 400 * 100;
                lblScorePrecentatge.Text = donatedPercentage.ToString() + "% Complete";

                lblprogresbar.Attributes["style"] = "width: " + donatedPercentage + "%;";


                lblMedal.Text = "Silver";
                infoBox.Attributes["class"] = "info-box bg-secondary";
            }
            else
            {

                lblMedal.Text = "Gold";
                infoBox.Attributes["class"] = "info-box bg-warning";
            }
        }

        private void ViewRecordForDetails()
        {
            GridViewRow oGridViewRow = gvDonationList.Rows[Convert.ToInt32(ViewState["index"])];
            string DonationID = ((Label)oGridViewRow.FindControl("lblDonationID")).Text.ToString();

            List<SupplyNeedGridDto> record = oSupplyService.GetDonationNeedGridForID(DonationID);

            record.GroupBy(x => x.SupplyItemCat).Where(g => g.Count() > 1).SelectMany(g => g.Skip(1)).ToList().ForEach(x => x.ItemCatName = "");

            gvPopSuppliesShow.DataSource = record.OrderByDescending(x => x.SupplyItemCat);
            gvPopSuppliesShow.DataBind();
        }
        protected void btnviewarchdetails_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showarch", "showarch();", true);
        }

        protected void gvDonationList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                switch (e.CommandName)
                {
                    case "ViewData":
                        ViewState["index"] = e.CommandArgument.ToString();
                        ViewRecordForDetails();
                        ViewContactDetails();
                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowDetails", "ShowDetails();", true);
                        break;

                    case "Cancel":
                        ViewState["index"] = e.CommandArgument.ToString();
                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowCancel", "ShowCancel();", true);
                        break;

                    case "Contact":
                        ViewState["index"] = e.CommandArgument.ToString();
                        ViewFeedback();
                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowContactDetails", "ShowContactDetails();", true);
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ViewContactDetails()
        {
            GridViewRow oGridViewRow = gvDonationList.Rows[Convert.ToInt32(ViewState["index"])];
            string HospitalID = ((Label)oGridViewRow.FindControl("lblHospitalID")).Text.ToString();

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
        }

        private void ViewFeedback()
        {
            GridViewRow oGridViewRow = gvDonationList.Rows[Convert.ToInt32(ViewState["index"])];
            string DonationID = ((Label)oGridViewRow.FindControl("lblDonationID")).Text.ToString();
            string HospitalName = ((Label)oGridViewRow.FindControl("lblHospitalName")).Text.ToString();

            DonationFeedback oresullt = oSupplyService.GetFeedBackForID(DonationID);

            lblFeedHlName.Text = HospitalName.ToString();

            DateTime now = DateTime.Now;
            DateTime tomorrow = now.AddDays(1);
            string formattedDateTime;

            DateTime feeddate = oresullt.CreatedDateTime?.Date ?? DateTime.MinValue;

            if (now.Date == oresullt.CreatedDateTime)
            {
                // If the date is today, format the time as "h:mm tt" and add "today" at the end
                formattedDateTime = now.ToString("h:mm tt") + " today";
            }
            else if (tomorrow.Date == oresullt.CreatedDateTime)
            {
                // If the date is tomorrow, format the time as "h:mm tt" and add "tomorrow" at the end
                formattedDateTime = now.ToString("h:mm tt") + " tomorrow";
            }
            else
            {
                // If the date is not today or tomorrow, format the date and time as "M/d/yyyy h:mm tt"
                formattedDateTime = feeddate.ToString("M/d/yyyy h:mm tt");
            }

            lblFeedDate.Text = "Shared publicly - " + formattedDateTime;

            lblFeedbackText.Text = oresullt.FeedbackText.ToString();
        }

        private void EmailSender(DonationActivityDto odata)
        {
            try
            {
                LoggedUserDto loggedUser = (LoggedUserDto)Session["loggedUser"];

                var donationID = odata.DonationID;
                var supplyID = odata.SupplyID;
                var donorName = loggedUser.Type == 1 ? loggedUser.FirstName + " " + loggedUser.LastName : loggedUser.FirstName;

                var email = new MimeMessage();

                email.From.Add(new MailboxAddress("Donation Cancellation Notice", GlobalData.NoreplyEmail));
                email.To.Add(new MailboxAddress("User", odata.Email));

                email.Subject = $"Donation Cancellation - Donation ID: {donationID}, Supply ID: {supplyID}";
                email.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
                {
                    Text = $"Dear Hospital,\n\nWe regret to inform you that the donor '{donorName}' has canceled their donation.\n\nBelow are the details of the canceled donation:\n\nDonation ID: {donationID}\nSupply ID: {supplyID}\n\nPlease let us know if you have any questions or concerns.\n\nBest regards,\nGiveMed Donation Team"
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
        protected void gvDonationList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvDonationList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblStatus = (Label)e.Row.FindControl("lblStatus");
                string Status = DataBinder.Eval(e.Row.DataItem, "Status").ToString();
                switch (Status)
                {
                    case "1":
                        lblStatus.Text = "Confirmed";
                        lblStatus.CssClass = "badge badge-success";
                        break;
                    case "0":
                        lblStatus.Text = "Pending";
                        lblStatus.CssClass = "badge badge-warning";
                        break;
                }
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblStatus = (Label)e.Row.FindControl("lblStatus");
                LinkButton btnFeedback = (LinkButton)e.Row.FindControl("btnFeedback");
                LinkButton btnCancel = (LinkButton)e.Row.FindControl("btnCancel");

                if (lblStatus.Text == "Pending")
                {
                    btnFeedback.Visible = false;
                    btnCancel.Visible = true;
                }
                else
                {
                    btnFeedback.Visible = true;
                    btnCancel.Visible = false;
                }
            }
        }

        protected void btnCanceltrue_Click(object sender, EventArgs e)
        {
            GridViewRow oGridViewRow = gvDonationList.Rows[Convert.ToInt32(ViewState["index"])];
            Session["lblDonationID"] = ((Label)oGridViewRow.FindControl("lblDonationID")).Text.ToString();

            DonationActivityDto odata = new DonationActivityDto();
            odata.DonationID = Session["lblDonationID"].ToString();
            odata.SupplyID = ((Label)oGridViewRow.FindControl("lblSupplyID")).Text.ToString();
            odata.Email = ((Label)oGridViewRow.FindControl("lblEmail")).Text.ToString();

            WebApiResponse response = new WebApiResponse();
            response = oSupplyService.Delete(odata);

            if (response.StatusCode == (int)StatusCode.Success)
            {
                PageLoad();
                EmailSender(odata);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Swal.fire({icon: 'error', title: 'Donation ID:'"+ odata.DonationID .ToString()+ "' is Canceled ', text: 'Canceled', confirmButtonText: 'Ok'});", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "HideModalBackdrop", "$('.modal-backdrop').removeClass('show');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Swal.fire({icon: 'error', title: 'Error!', text: 'Please try again later.', confirmButtonText: 'Ok'});", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "HideModalBackdrop", "$('.modal-backdrop').removeClass('show');", true);
            }
        }

        protected void ddlSortResullt_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<DonationActivityDto> oBindList = (List<DonationActivityDto>)Session["DonationActList"];
            if (ddlStatus.SelectedValue == "1")
            {
                oBindList = oBindList.Where(x => x.Status == 0).ToList();
                gvDonationList.DataSource = oBindList.OrderByDescending(x => x.DonationCreateDate).ToList();
                gvDonationList.DataBind();
                //if (oBindList.Count > 0)
                //    Session["DonationActList"] = oBindList;
            }
            else
            {
                oBindList = oBindList.Where(x => x.Status == 1).ToList();
                gvDonationList.DataSource = oBindList.OrderByDescending(x => x.DonationCreateDate).ToList();
                gvDonationList.DataBind();
                //if (oBindList.Count > 0)
                //    Session["DonationActList"] = oBindList;
            }
        }
    }
}