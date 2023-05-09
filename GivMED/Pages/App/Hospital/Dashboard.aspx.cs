using GivMED.Dto;
using GivMED.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GivMED.Pages.App.Hospital
{
    public partial class Dashboard : System.Web.UI.Page
    {
        HomeService oHomeService = new HomeService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LoggedUserDto loggedUser = (LoggedUserDto)Session["loggedUser"];

                HospitalDashboardDto result = oHomeService.GetHospitalDashboardData(loggedUser.HospitalID);

                lblregisteredVolunteers.Text = result.registeredVolunteers.ToString();
                lblCountofTotalDonation.Text = result.CountofTotalDonation.ToString();
                lblContributeOrganization.Text = result.ContributeOrganization.ToString();
                lblNewDonors.Text = result.NewDonors.ToString();

                int regularLevel = result.RegularLevel;
                int urgentLevel =result.UrgentLevel;
                int monthlyProgress = 50;

                // Create the progress bar HTML for each value
                string regularLevelHtml = CreateProgressBarHtml("Regular Level", regularLevel, "bg-success");
                string urgentLevelHtml = CreateProgressBarHtml("Urgent Level", urgentLevel, "bg-danger");
                //string monthlyProgressHtml = CreateProgressBarHtml("Monthly Progress", monthlyProgress, "bg-primary progress-bar-striped");

                // Add the progress bar HTML to the placeholder control
                progressBarsPlaceholder.Controls.Add(new LiteralControl(regularLevelHtml));
                progressBarsPlaceholder.Controls.Add(new LiteralControl(urgentLevelHtml));
                //progressBarsPlaceholder.Controls.Add(new LiteralControl(monthlyProgressHtml));

                SetFunctionName();
                //ScriptManager.RegisterStartupScript(this, GetType(), "BindChart", "BindBarChart();", true);s

                List<ChartData> chartData = new List<ChartData>();
                chartData.Add(new ChartData() { Label = "Urgent", Value = result.Urgent });
                chartData.Add(new ChartData() { Label = "Normal", Value = result.Normal });
                chartData.Add(new ChartData() { Label = "Low", Value = result.Low });

                // Convert List object to JSON
                string jsonData = JsonConvert.SerializeObject(chartData);

                // Generate script to create chart with JSON data
                string script = "<script>var data = " + jsonData + "; var ctx = document.getElementById('donutChart').getContext('2d'); var myChart = new Chart(ctx, {type: 'doughnut',data: {labels: data.map(function(d) { return d.Label; }),datasets: [{data: data.map(function(d) { return d.Value; }),backgroundColor: ['#ff6384','#36a2eb','#ffce56','#4bc0c0','#ff9f40']}]}});</script>";
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "chartScript", script, false);

            }
        }
        private string CreateProgressBarHtml(string label, int value, string colorClass)
        {
            int width = value; // Set the progress bar width to the database value
            return $@"
        <div class='progress-group'>
            {label}
            <span class='float-right'><b>{value}</b>%</span>
            <div class='progress progress-sm'>
                <div class='progress-bar {colorClass}' style='width: {width}%'></div>
            </div>
        </div>
    ";
        }

        private void SetFunctionName()
        {
            try
            {
                Label lblFunctionName = this.Master.FindControl("lblFuncationName") as Label;
                lblFunctionName.Text = "Dashboard";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public class ChartData
        {
            public string Label { get; set; }
            public int Value { get; set; }
        }

        [WebMethod]
        public static List<int> GetChartData()
        {
            List<int> data = new List<int>() { 20, 30, 40, 50, 60, 70 };
            return data;
        }
        public class MyDataClass
        {
            public int Date { get; set; }
            public int Value { get; set; }
        }
    }
}