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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                SetFunctionName();
                ScriptManager.RegisterStartupScript(this, GetType(), "BindChart", "BindBarChart();", true);

                List<ChartData> chartData = new List<ChartData>();
                chartData.Add(new ChartData() { Label = "Urgent", Value = 20 });
                chartData.Add(new ChartData() { Label = "Normal", Value = 19 });
                chartData.Add(new ChartData() { Label = "Low", Value = 6 });

                // Convert List object to JSON
                string jsonData = JsonConvert.SerializeObject(chartData);

                // Generate script to create chart with JSON data
                string script = "<script>var data = " + jsonData + "; var ctx = document.getElementById('donutChart').getContext('2d'); var myChart = new Chart(ctx, {type: 'doughnut',data: {labels: data.map(function(d) { return d.Label; }),datasets: [{data: data.map(function(d) { return d.Value; }),backgroundColor: ['#ff6384','#36a2eb','#ffce56','#4bc0c0','#ff9f40']}]}});</script>";
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "chartScript", script, false);

            }
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