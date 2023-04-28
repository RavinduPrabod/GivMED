using GivMED.Common;
using GivMED.Dto;
using GivMED.Models;
using GivMED.Service;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        VolunteerService oVolunteerService = new VolunteerService();
        CommonService oCommonService = new CommonService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                SetFunctionName();
                PageLoad();
                pnlNotFound.Visible = false;
            }
        }

        private void PageLoad()
        {
            LoggedUserDto loggedUser = (LoggedUserDto)Session["loggedUser"];
            EmailConfigurationLoad();
            LoadGridView();
            btnConfirm.Visible = true;
            btnDonate.Visible = false;
            btnCancel.Visible = false;
            mvpublishNeeds.ActiveViewIndex = 0;
        }
        private void EmailConfigurationLoad()
        {
            EmailConfiguration oEmailConfiguration = oCommonService.GetEmailConfiguration();
            GlobalData.Port = oEmailConfiguration.Port;
            GlobalData.SmtpAddress = oEmailConfiguration.SmtpAddress;
            GlobalData.NoreplyEmail = oEmailConfiguration.EmailAddress;
            GlobalData.NoreplyPassword = oEmailConfiguration.Password;
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
                string itemscat = string.Empty;
                forlist = oHeaderWithDetailsList.Where(x => x.SupplyID == item.SupplyID).ToList();

                for (int i=0; forlist.Count > i; i++)
                {
                    itemsname = itemsname + forlist[i].SupplyItemName + ", ";
                    itemscat = itemscat + item.SupplyItemCat.ToString() + "-";

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
                odata.SupplyItemCatIDText = itemscat;
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

                        if(Convert.ToBoolean(Session["donorisvalid"]) == true)
                        {
                            ViewRecord();
                            btnConfirm.Visible = true;
                            btnDonate.Visible = false;
                            btnCancel.Visible = false;
                            mvpublishNeeds.ActiveViewIndex = 1;
                        }
                        else
                        {
                            Response.Redirect("/Pages/App/Profile/Profile.aspx");
                            ShowErrorMessage("Complete your profile first");
                        }
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

        private void CheckDonorMaster()
        {
            LoggedUserDto loggedUser = (LoggedUserDto)Session["loggedUser"];

            Session["donorisvalid"] = null;
            Session["donorisvalid"] = oCommonService.GetIsDonorAvailability(loggedUser.UserName);
        }

        private void ViewRecord()
        {
            Session["lblSupplyPriorityLevel"] = null;
            Session["lblHospitalName"] = null;
            GridViewRow oGridViewRow = gvNeedsList.Rows[Convert.ToInt32(ViewState["index"])];
            string SupplyID = ((Label)oGridViewRow.FindControl("lblSupplyID")).Text.ToString();
            string HospitalID = ((Label)oGridViewRow.FindControl("lblHospitalID")).Text.ToString();
            string HospitalName = ((Label)oGridViewRow.FindControl("lblHospitalName")).Text.ToString();
            Session["lblHospitalName"] = HospitalName.ToString();
            Session["lblSupplyPriorityLevel"] = ((Label)oGridViewRow.FindControl("lblSupplyPriorityLevel")).Text.ToString();

            List <SupplyNeedGridDto> record = oSupplyService.GetSupplyNeedGridForID(SupplyID);

            record.GroupBy(x => x.SupplyItemCat).Where(g => g.Count() > 1).SelectMany(g => g.Skip(1)).ToList().ForEach(x => x.ItemCatName = "");

            gvSupplyList.DataSource = record.OrderByDescending(x=>x.SupplyItemCat);
            gvSupplyList.DataBind();

            SupplyNeedsDto PrimaryRecords = oSupplyService.GetSupplyNeedsForID(SupplyID);

            HospitalMaster oHospitalMaster = oSupplyService.GetHospitalMasterForID(Convert.ToInt32(HospitalID));

            lblSupplyIDin.Text = SupplyID.ToString();
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
            LoadVolunteerGridview();
            ScriptManager.RegisterStartupScript(this, GetType(), "ShowDonateConfirm", "ShowDonateConfirm();", true);
        }

        private void LoadVolunteerGridview()
        {
            List<VolunteerMaster> odata = new List<VolunteerMaster>();
            odata = oVolunteerService.GetAllActiveVolunteerMaster();

            gvVolunteer.DataSource = odata;
            gvVolunteer.DataBind();
            if (odata.Count > 0)
                Session["AllActiveVolunteerMaster"] = odata;
        }

        private void Post()
        {
            try
            {
                List<DonationDetails> oDonationDetails = new List<DonationDetails>();
                DonationHeader oDonationHeader = new DonationHeader();
                LoggedUserDto loggedUser = (LoggedUserDto)Session["loggedUser"];

                foreach (GridViewRow row in gvSupplyList.Rows)
                {
                    DonationDetails odata = new DonationDetails();

                    TextBox txtRemainigQty = (TextBox)row.FindControl("txtRemainingQty");
                    if (string.IsNullOrEmpty(txtRemainigQty.Text) || txtRemainigQty.Text != "0")
                    {
                        odata.DonationID = "DTN";
                        odata.SupplyID = lblSupplyIDin.Text.ToString();
                        odata.ItemID = Convert.ToInt32(((Label)row.FindControl("lblSupplyItemID")).Text); // corrected
                        odata.ItemCategory = Convert.ToInt32(((Label)row.FindControl("lblSupplyItemCat")).Text); // corrected
                        odata.ItemName = ((Label)row.FindControl("lblSupplyItemName")).Text; // corrected
                        odata.RequestQty = Convert.ToInt64(((Label)row.FindControl("lblRequestQty")).Text); // corrected
                        odata.DonatedQty = Convert.ToInt64(txtRemainigQty.Text); // corrected
                        odata.DonatedQty = Convert.ToInt64(txtRemainigQty.Text);
                        odata.DonationStatus = 1;
                        odata.CreatedBy = "admin";
                        odata.CreatedDateTime = DateTime.Now;
                        odata.ModifiedBy = "admin";
                        odata.ModifiedDateTime = DateTime.Now;
                        oDonationDetails.Add(odata);
                    }
                }

                oDonationHeader.DonationID = "DTN";
                oDonationHeader.DonorID = oProfileService.GetDonorMaster(loggedUser.UserName.ToString()).DonorID;
                oDonationHeader.UserName = loggedUser.UserName.ToString();
                oDonationHeader.HospitalID = 0;
                oDonationHeader.SupplyID = lblSupplyIDin.Text.ToString();
                oDonationHeader.DonationStatus = 1;
                oDonationHeader.DonationCreateDate = DateTime.Now;
                oDonationHeader.DonationDealDate = Convert.ToDateTime(txtDealDate.Text);
                oDonationHeader.CreatedBy = "admin";
                oDonationHeader.CreatedDateTime = DateTime.Now;
                oDonationHeader.ModifiedBy = "admin";
                oDonationHeader.ModifiedDateTime = DateTime.Now;

                List<DonationVolunteer> oDonationVolunteer = new List<DonationVolunteer>();

                foreach (GridViewRow row in gvVolunteer.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        bool isChecked = row.Cells[0].Controls.OfType<CheckBox>().FirstOrDefault().Checked;
                        if (isChecked)
                        {
                            string VolCode = row.Cells[1].Controls.OfType<Label>().FirstOrDefault().Text;

                            DonationVolunteer odata = new DonationVolunteer();

                            odata.DonationCode = "DTN";
                            odata.SupplyCode = lblSupplyIDin.Text.ToString();
                            odata.HospitalID = 0;
                            odata.DonorID = oProfileService.GetDonorMaster(loggedUser.UserName.ToString()).DonorID;
                            odata.VolunteerCode = VolCode.ToString();
                            odata.CreatedBy = "admin";
                            odata.CreatedDateTime = DateTime.Now;
                            odata.ModifiedBy = "admin";
                            odata.ModifiedDateTime = DateTime.Now;
                            oDonationVolunteer.Add(odata);
                        }
                    }
                }

                PublishedNeedsPostDto oPostData = new PublishedNeedsPostDto();
                oPostData.DonationHeader = oDonationHeader;
                oPostData.DonationDetails = oDonationDetails;
                if(oDonationVolunteer.Count > 0)
                {
                    oPostData.DonationVolunteer = oDonationVolunteer;
                }
                oPostData.UserName = loggedUser.UserName.ToString();

                WebApiResponse response = new WebApiResponse();
                response = oSupplyService.PostDonation(oPostData);

                if (response.StatusCode == (int)StatusCode.Success)
                {
                    PageLoad();
                    oPostData.DonationHeader.DonationID = response.Result.ToString();
                    oPostData.DonorMaster = oProfileService.GetDonorMaster(loggedUser.UserName);
                    EmailSender(oPostData);
                    if(oDonationVolunteer.Count != 0)
                    {
                        EmailSenderToVolunteers(oPostData);
                    }
                    ShowDonationConfirm(response.Result);
                }
                else
                {
                    ShowErrorMessage(ResponseMessages.Error);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void SetFunctionName()
        {
            try
            {
                Label lblFunctionName = this.Master.FindControl("lblFuncationName") as Label;
                lblFunctionName.Text = "Medical Supply Shortages (Live)";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void EmailSender(PublishedNeedsPostDto odata)
        {
            try
            {
                var email = new MimeMessage();

                email.From.Add(new MailboxAddress("Donation Confirmation Notice", GlobalData.NoreplyEmail));
                email.To.Add(new MailboxAddress("User", "givemed.donation@gmail.com"));

                email.Subject = "We are pleased to inform you that the donation for the '" + odata.DonationHeader.SupplyID.ToString() + "' has been confirmed by the donor.";
                email.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
                {
                    Text = $"Below are the details of the donation:\n\nDonation ID: {odata.DonationHeader.DonationID}\n" +
                    $"Donor Name: { (odata.DonorMaster.DonorType == 1 ? odata.DonorMaster.DonorFirstName + " " + odata.DonorMaster.DonorLastName : odata.DonorMaster.DonorFirstName)}\n" +
                    $"Donor Email: {odata.UserName}\nSupply ID: {odata.DonationHeader.SupplyID}\n" +
                    $"Deal Date: {odata.DonationHeader.DonationDealDate}\n\nWe hope that this donation will be helpful for the patients in need and contribute to the\n" +
                    $"improvement of healthcare services in your hospital.\n\nBest regards,\n{odata.DonorMaster.DonorFirstName}"
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

        private void EmailSenderToVolunteers(PublishedNeedsPostDto Supply)
        {
            try
            {
                LoggedUserDto loggedUser = (LoggedUserDto)Session["loggedUser"];

                var email = new MimeMessage();
                email.From.Add(new MailboxAddress("GiveMED Notice", GlobalData.NoreplyEmail));
                email.Subject = "Urgent request for Medical Supply Donations";

                StringBuilder suppliesText = new StringBuilder();
                foreach (var supply in Supply.DonationDetails)
                {
                    suppliesText.AppendLine($"Supply Name: {supply.ItemName}\n Quantity: {supply.DonatedQty}");
                }

                email.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
                {
                    Text = $"Dear Volunteer,\n\n" +
                       $"We hope this email finds you well. As you know, our hospital is currently facing a critical shortage of essential medical supplies. We are reaching out to our valued donors and supporters to request their urgent assistance in helping us overcome this critical situation.\n\n" +
                       $"We are pleased to inform you that {Supply.DonorMaster.DonorFirstName}, located at {Supply.DonorMaster.Address}, has generously agreed to donate medical supplies to our hospital. The deal was finalized on {Supply.DonationHeader.DonationDealDate} and we are now in possession of the following supplies:\n\n" +
                       $"Priority Level: {Session["lblSupplyPriorityLevel"].ToString()}\n\n" +
                       $"{suppliesText.ToString()}\n\n" +
                       $"We would also like to take this opportunity to thank {lblHospitalName.Text} for their ongoing support in our mission to provide quality healthcare services to the community. Their\n" +
                       $"continued assistance is greatly appreciated.\n" +
                       $"For any queries or further information, please do not hesitate to contact us at {lblPhone.Text}.\n" +
                       $"We thank you for your continued support and look forward to working with you in the future.\n\n" +
                       $"Best regards,\n\n" +
                       $"{lblHospitalName.Text}\n" +
                       $"{lblPhone.Text}\n"
                };

                List<VolunteerMaster> VolunteerMaster = (List<VolunteerMaster>)Session["AllActiveVolunteerMaster"];

                foreach (var item in Supply.DonationVolunteer)
                {
                    email.To.Add(new MailboxAddress("Volunteer", VolunteerMaster.Where(x=>x.VolCode == item.VolunteerCode).First().VolEmail));

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


        private void ShowDonationConfirm(string DonationID)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowDonationID('" + DonationID + "');", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "HideModalBackdrop", "$('.modal-backdrop').removeClass('show');", true);
            //ScriptManager.RegisterStartupScript(this, GetType(), "ShowDonateConfirm", "$('.modal-backdrop').addClass('show'); $('#modal-DonateConfirm').modal('show');", true);
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

        protected void gvSupplyList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                switch (e.CommandName)
                {
                    case "viewforhelp":
                        ViewState["index"] = e.CommandArgument.ToString();
                        UseOpenAI();
                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowHelp", "ShowHelp();", true);
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void UseOpenAI()
        {
            GridViewRow oGridViewRow = gvSupplyList.Rows[Convert.ToInt32(ViewState["index"])];
            string ItemName = ((Label)oGridViewRow.FindControl("lblSupplyItemName")).Text.ToString();

            WebApiResponse response = new WebApiResponse();
            response = oSupplyService.UseChatGPT(ItemName);

            if (response.StatusCode == (int)StatusCode.Success)
            {
                lblhelp.Text = response.Result.ToString();
                //ShowOpenAIResult(response.Result);
            }
            else
            {
                ShowErrorMessage(ResponseMessages.Error);
            }
        }

        private void ShowOpenAIResult(string result)
        {
            string script = "ShowOpenAIResult('" + result + "');";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "script", script, true);
        }

        protected void gvPopSuppliesShow_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                switch (e.CommandName)
                {
                    case "viewforhelp":
                        ViewState["index"] = e.CommandArgument.ToString();
                        UseOpenAI();
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Post();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            try
            {
                Session["NeedFilterList"] = null;
                List<PublishedNeedsGridDto> records = Session["FilterList"] != null ? (List<PublishedNeedsGridDto>)Session["FilterList"] : new List<PublishedNeedsGridDto>();
                if (!string.IsNullOrEmpty(txtSearch.Text))
                {
                    List<PublishedNeedsGridDto> filterList = records.Where(x => x.SearchIndex.Replace(" ", "").ToUpper().Split('-').Contains(txtSearch.Text.Trim().Replace(" ", "").ToUpper())).ToList();
                    if (filterList.Count == 0)
                    {
                        filterList = records.Where(x => x.SearchIndex.Replace(" ", "").ToUpper().Contains(txtSearch.Text.Trim().Replace(" ", "").ToUpper())).ToList();
                        pnlNotFound.Visible = true;
                        lblShowCount.Visible = false;
                    }
                    gvNeedsList.DataSource = filterList;
                    gvNeedsList.DataBind();
                    if (filterList.Count > 0)
                    {
                        Session["NeedFilterList"] = filterList;
                        pnlNotFound.Visible = false;
                        lblShowCount.Visible = true;
                    }
                        
                }
                else
                {
                    gvNeedsList.DataSource = records;
                    gvNeedsList.DataBind();
                    if (records.Count > 0)
                    {
                        Session["NeedFilterList"] = records;
                        pnlNotFound.Visible = false;
                        lblShowCount.Visible = true;
                    }  
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SearchforItemCat(int ItemCat)
        {
            try
            {
                Session["NeedFilterList"] = null;
                List<PublishedNeedsGridDto> records = Session["FilterList"] != null ? (List<PublishedNeedsGridDto>)Session["FilterList"] : new List<PublishedNeedsGridDto>();
                if (!string.IsNullOrEmpty(ItemCat.ToString()))
                {
                    List<PublishedNeedsGridDto> filterList = records.Where(x => x.SupplyItemCatIDText.Replace(" ", "").ToUpper().Split('-').Contains(ItemCat.ToString().Trim().Replace(" ", "").ToUpper())).ToList();
                    if (filterList.Count == 0)
                    {
                        filterList = records.Where(x => x.SupplyItemCatIDText.Replace(" ", "").ToUpper().Contains(ItemCat.ToString().Trim().Replace(" ", "").ToUpper())).ToList();
                        pnlNotFound.Visible = true;
                        lblShowCount.Visible = false;
                    }
                    gvNeedsList.DataSource = filterList;
                    gvNeedsList.DataBind();
                    if (filterList.Count > 0)
                    {
                        Session["NeedFilterList"] = filterList;
                        pnlNotFound.Visible = false;
                        lblShowCount.Visible = true;
                    }
                        
                }
                else
                {
                    gvNeedsList.DataSource = records;
                    gvNeedsList.DataBind();
                    if (records.Count > 0)
                    {
                        Session["NeedFilterList"] = records;
                        pnlNotFound.Visible = false;
                        lblShowCount.Visible = true;
                    }
                        
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnItemCat1_Click(object sender, EventArgs e)
        {
            SearchforItemCat(1);
        }

        protected void btnItemCat2_Click(object sender, EventArgs e)
        {
            SearchforItemCat(2);
        }

        protected void btnItemCat3_Click(object sender, EventArgs e)
        {
            SearchforItemCat(3);
        }

        protected void btnItemCat4_Click(object sender, EventArgs e)
        {
            SearchforItemCat(4);
        }

        protected void btnItemCat5_Click(object sender, EventArgs e)
        {
            SearchforItemCat(5);
        }

        protected void btnItemCat6_Click(object sender, EventArgs e)
        {
            SearchforItemCat(6);
        }

        protected void btnItemCat7_Click(object sender, EventArgs e)
        {
            SearchforItemCat(7);
        }

        protected void btnItemCat8_Click(object sender, EventArgs e)
        {
            SearchforItemCat(8);
        }
    }
}