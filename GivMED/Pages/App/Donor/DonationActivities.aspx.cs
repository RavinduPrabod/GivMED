using GivMED.Dto;
using GivMED.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GivMED.Pages.App.Donor
{
    public partial class DonationActivities : System.Web.UI.Page
    {
        SupplyService oSupplyService = new SupplyService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                int count =  LoaGridView();
                GetInfoBoxCssClass(count);
            }
        }

        private int LoaGridView()
        {
            LoggedUserDto loggedUser = (LoggedUserDto)Session["loggedUser"];

            List<DonationActivityDto> oBindList = new List<DonationActivityDto>();

            oBindList = oSupplyService.GetDonationHeaderDetails(loggedUser.UserName);

            gvDonationList.DataSource = oBindList.OrderByDescending(x=>x.DonationCreateDate).ToList();
            gvDonationList.DataBind();

            int donationcount = oBindList.Count();

            return donationcount;
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
                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowDetails", "ShowDetails();", true);
                        break;

                    case "ShowDetails":
                        ViewState["index"] = e.CommandArgument.ToString();
                        break;
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
    }
}