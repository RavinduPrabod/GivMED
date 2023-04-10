using GivMED.Dto;
using GivMED.Models;
using GivMED.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GivMED.Pages.App.Donor
{
    public partial class Published_Needs : System.Web.UI.Page
    {
        SupplyService oSupplyService = new SupplyService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LoadGridView();
                mvpublishNeeds.ActiveViewIndex = 0;
            }
        }

        private void LoadGridView()
        {
            SupplyNeedsDto olist = new SupplyNeedsDto();
            olist = oSupplyService.GetSupplyNeedHeaderWithDetails();

            List<PublishedNeedsGridDto> onewlist = new List<PublishedNeedsGridDto>();
            
            //foreach(var item in olist.SupplyRequestHeaderList)
            //{
            //    PublishedNeedsGridDto odata = new PublishedNeedsGridDto();
            //    odata.SupplyItemName = item.
            //}

            gvNeedsList.DataSource = olist;
            gvNeedsList.DataBind();


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
    }
}