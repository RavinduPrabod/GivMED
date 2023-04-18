using GivMED.Dto;
using GivMED.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GivMED.Pages.App.Hospital
{
    public partial class DonorContribution : System.Web.UI.Page
    {
        SupplyService oSupplyService = new SupplyService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                PageLoad();
                mvDonorCont.ActiveViewIndex = 0;

            }
        }
        private void PageLoad()
        {
            LoggedUserDto loggedUser = (LoggedUserDto)Session["loggedUser"];

            List<HospitalSupplyNeedsGridDto> olist = new List<HospitalSupplyNeedsGridDto>();
            List<HospitalSupplyNeedsGridDto> result = new List<HospitalSupplyNeedsGridDto>();

            olist = oSupplyService.GetDonationContributeGridData(loggedUser.HospitalID);

            //List<HospitalSupplyNeedsGridDto> grouplist = olist.GroupBy(s => s.SupplyID)
            //                                        .Select(group => group.First())
            //                                        .ToList();
            foreach (var item in olist)
            {
                long requestedQty = 0;
                long donatedQty = 0;

                HospitalSupplyNeedsGridDto odata = new HospitalSupplyNeedsGridDto();

                odata.SupplyID = item.SupplyID;
                odata.SupplyCreateDate = item.SupplyCreateDate;
                odata.SupplyExpireDate = item.SupplyExpireDate;
                odata.SupplyPriorityLevel = item.SupplyPriorityLevel;
                odata.DonorCount = item.DonorCount;
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

                List<DonationContributeGridDto> record = oSupplyService.GetDonorsForID(SupplyID);
                if (record.Count > 0)
                    Session["DonationContribute"] = record;
                List<DonationContributeGridDto> orecordbyName = new List<DonationContributeGridDto>();
                foreach (string name in record.Select(x => x.DonorName).Distinct())
                {
                    DonationContributeGridDto odata = new DonationContributeGridDto();
                    odata.DonorName = name;
                    //odata.DonationID = record.Where(x => x.DonorName == name).First().DonationID;
                    //odata.SupplyItemCat = record.Where(x => x.DonorName == name).First().SupplyItemCat;
                    //odata.SupplyItemID = record.Where(x => x.DonorName == name).First().SupplyItemID;
                    //odata.DonatedQty = record.Where(x => x.DonorName == name).First().DonatedQty;
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
                foreach (string itemid in oInflow.Where(x => x.DonorName == Session["DonName"].ToString() && x.DonationID == donationid).Select(y => y.SupplyItemName).Distinct())
                {
                    DonationContributeGridDto odata = new DonationContributeGridDto();
                    odata.SupplyItemCat = oInflow.Where(x => x.SupplyItemName == itemid).First().SupplyItemCat;
                    odata.SupplyItemID = itemid;
                    odata.DonatedQty = oInflow.Where(x => x.SupplyItemName == itemid).First().DonatedQty;
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
        }

        private void ResizeGrid()
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Script", "ResizeGrid();", true);
        }

    }
}