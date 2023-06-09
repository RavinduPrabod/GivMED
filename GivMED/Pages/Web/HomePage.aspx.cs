﻿using System;

using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using GivMED.Common;
using GivMED.Dto;
using GivMED.Models;
using GivMED.Service;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static GivMED.Common.Enums;
using Microsoft.Reporting.WebForms;

namespace GivMED.Pages.Web
{
    public partial class HomePage : System.Web.UI.Page
    {
        HomeService oHomeService = new HomeService();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                Session["loggedUser"] = null;
                Session["donorisvalid"] = null;
                PageLoad();
            }
        }
        //private void EmailSender()
        //{
        //    try
        //    {
        //        var random = new Random();
        //        var code = random.Next(100000, 999999); // Generate a 6-digit code

        //        var email = new MimeMessage();

        //        email.From.Add(new MailboxAddress("GiveMED", "lucifer98moninstar@gmail.com"));
        //        email.To.Add(new MailboxAddress("User", "givemed.donation@gmail.com"));

        //        email.Subject = "Your verification code";
        //        email.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
        //        {
        //            Text = $"Your verification code is {code}"
        //        };

        //        using (var smtp = new SmtpClient())
        //        {
        //            smtp.Connect("smtp.elasticemail.com", 2525);

        //            smtp.Authenticate("lucifer98moninstar@gmail.com", "AFEF5C9832C1703859A338C87629F8A83BEA");

        //            smtp.Send(email);
        //            smtp.Disconnect(true);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        private void PageLoad()
        {
            List<TopTrendingDonorDto> result = new List<TopTrendingDonorDto>();
            List<TopTrendingDonorDto> lastresult = new List<TopTrendingDonorDto>();

            List<TopTrendingDonorDto> Toplist = new List<TopTrendingDonorDto>();
            List<TopTrendingDonorDto> grplist = new List<TopTrendingDonorDto>();

            Toplist = oHomeService.GetTopRateDonors();

            if (Toplist.Count > 0)
            {
                grplist = Toplist.GroupBy(s => s.DonorID)
                                                .Select(group => group.First())
                                                .ToList();

                foreach (var item in grplist)
                {
                    TopTrendingDonorDto otemp = new TopTrendingDonorDto();
                    otemp.DonorName = item.DonorName.ToString();
                    otemp.ImgURL = GetimageURL(item.ImgURL);
                    otemp.DonationCredit = (5 * Toplist.Where(x => x.DonorID == item.DonorID).Count());
                    otemp.DonorID = item.DonorID;
                    otemp.LastActivityDate = Toplist.Where(x => x.DonorID == item.DonorID).LastOrDefault().CreatedDateTime;
                    otemp.Lastprogram1 = Toplist.Where(x => x.DonorID == item.DonorID).LastOrDefault().HospitalName + " " + Toplist.Where(x => x.DonorID == item.DonorID).LastOrDefault().SupplyID;
                    otemp.Lastprogram2 = Toplist.Where(x => x.DonorID == item.DonorID).LastOrDefault().HospitalName + " " + Toplist.Where(x => x.DonorID == item.DonorID).LastOrDefault().SupplyID;
                    result.Add(otemp);
                }

                result = result.OrderByDescending(x => x.DonationCredit).Take(3).ToList();

                TopTrendingDonorDto odata = new TopTrendingDonorDto();

                for (int i = 0; result.Count > i; i++)
                {
                    if (result[i].DonorName.Length > 25)
                    {
                        result[i].DonorName = result[i].DonorName.Substring(0, 25) + "...";
                    }

                    DateTime? dateOnly = Toplist.Where(x => x.DonorID == result[i].DonorID).OrderByDescending(x => x.CreatedDateTime).First().CreatedDateTime;

                    DateTime paraddate = dateOnly?.Date ?? DateTime.MinValue;

                    DateTime now = DateTime.Now;
                    DateTime tomorrow = now.AddDays(1);
                    string formattedDateTime;

                    if (now.Date == paraddate)
                    {
                        // If the date is today, format the time as "h:mm tt" and add "today" at the end
                        formattedDateTime = now.ToString("h:mm tt") + " today";
                    }
                    else if (tomorrow.Date == paraddate)
                    {
                        // If the date is tomorrow, format the time as "h:mm tt" and add "tomorrow" at the end
                        formattedDateTime = now.ToString("h:mm tt") + " tomorrow";
                    }
                    else
                    {
                        // If the date is not today or tomorrow, format the date and time as "M/d/yyyy h:mm tt"
                        formattedDateTime = paraddate.ToString("M/d/yyyy h:mm tt");
                    }

                    if (i == 0)
                    {
                        odata.DonorNameT1 = result[i].DonorName;
                        odata.ImgURLT1 = result[i].ImgURL;
                        odata.DonationCreditT1 = result[i].DonationCredit;
                        odata.LastActivityDateT1 = formattedDateTime;
                        odata.Lastprogram1T1 = result[i].Lastprogram1;
                        odata.Lastprogram2T1 = result[i].Lastprogram2;
                    }
                    else if (i == 1)
                    {
                        odata.DonorNameT2 = result[i].DonorName;
                        odata.ImgURLT2 = result[i].ImgURL;
                        odata.DonationCreditT2 = result[i].DonationCredit;
                        odata.LastActivityDateT2 = formattedDateTime;
                        odata.Lastprogram1T2 = result[i].Lastprogram1;
                        odata.Lastprogram2T2 = result[i].Lastprogram2;
                    }
                    else
                    {
                        odata.DonorNameT3 = result[i].DonorName;
                        odata.ImgURLT3 = result[i].ImgURL;
                        odata.DonationCreditT3 = result[i].DonationCredit;
                        odata.LastActivityDateT3 = formattedDateTime;
                        odata.Lastprogram1T3 = result[i].Lastprogram1;
                        odata.Lastprogram2T3 = result[i].Lastprogram2;
                    }
                }


                List<TopTrendingDonorDto> Temp1list = new List<TopTrendingDonorDto>();
                List<TopTrendingDonorDto> Temp2list = new List<TopTrendingDonorDto>();

                Temp1list = oHomeService.GetTopTrendingDonations();

                grplist = Temp1list.GroupBy(s => s.SupplyID)
                                                    .Select(group => group.First())
                                                    .ToList();
                Temp2list = grplist.OrderByDescending(x => x.DonorCount).Take(3).ToList();

                for (int i = 0; Temp2list.Count > i; i++)
                {
                    long requestedQty = 0;
                    long donatedQty = 0;

                    if (i == 0)
                    {
                        odata.DonationIDD1 = Temp2list[i].SupplyID;
                        odata.PriorityD1 = Temp2list[i].SupplyPriorityLevel.ToString();

                        requestedQty = Temp2list[i].RequestQty;
                        donatedQty = Temp1list.Where(x => x.SupplyID == Temp2list[i].SupplyID).Select(x => x.DonatedQty).Sum();

                        // Calculate donated percentage
                        double donatedPercentage = (double)donatedQty / requestedQty * 100;
                        // Round to 2 decimal places
                        donatedPercentage = Convert.ToInt32(donatedPercentage);

                        odata.DonationPrecentatgeD1 = Convert.ToInt32(donatedPercentage);

                        odata.DonorCountD1 = Temp2list[i].DonorCount.ToString();
                        odata.HospitalNameD1 = Temp2list[i].HospitalName;
                        odata.HLocationD1 = Temp2list[i].City;
                    }
                    else if (i == 1)
                    {
                        odata.DonationIDD2 = Temp2list[i].SupplyID;
                        odata.PriorityD2 = Temp2list[i].SupplyPriorityLevel.ToString();

                        requestedQty = Temp2list[i].RequestQty;
                        donatedQty = Temp1list.Where(x => x.SupplyID == Temp2list[i].SupplyID).Select(x => x.DonatedQty).Sum();

                        // Calculate donated percentage
                        double donatedPercentage = (double)donatedQty / requestedQty * 100;
                        // Round to 2 decimal places
                        donatedPercentage = Convert.ToInt32(donatedPercentage);

                        odata.DonationPrecentatgeD2 = Convert.ToInt32(donatedPercentage);

                        odata.DonorCountD2 = Temp2list[i].DonorCount.ToString();
                        odata.HospitalNameD2 = Temp2list[i].HospitalName;
                        odata.HLocationD2 = Temp2list[i].City;
                    }
                    else
                    {
                        odata.DonationIDD3 = Temp2list[i].SupplyID;
                        odata.PriorityD3 = Temp2list[i].SupplyPriorityLevel.ToString();

                        requestedQty = Temp2list[i].RequestQty;
                        donatedQty = Temp1list.Where(x => x.SupplyID == Temp2list[i].SupplyID).Select(x => x.DonatedQty).Sum();

                        // Calculate donated percentage
                        double donatedPercentage = (double)donatedQty / requestedQty * 100;
                        // Round to 2 decimal places
                        donatedPercentage = Convert.ToInt32(donatedPercentage);

                        odata.DonationPrecentatgeD3 = Convert.ToInt32(donatedPercentage);

                        odata.DonorCountD3 = Temp2list[i].DonorCount.ToString();
                        odata.HospitalNameD3 = Temp2list[i].HospitalName;
                        odata.HLocationD3 = Temp2list[i].City;
                    }

                }


                lastresult.Add(odata);
                gvDonorProgress.DataSource = lastresult;
                gvDonorProgress.DataBind();

                HomeDashLineDto dashdata = oHomeService.GetHomeDashTopLineData();
                lblDonorCount.Text = dashdata.DonorsCount.ToString();
                lblHospitalCount.Text = dashdata.HospitalCount.ToString();
                lblNeedCount.Text = dashdata.DonationCount.ToString();
            }
        }

        private string GetimageURL(string fileName)
        {
            string imgurl = string.Empty;
            string filePath = Path.Combine(@"C:\Users\prabod\Documents\Pictures\", fileName);
            if (File.Exists(filePath))
            {
                byte[] imgBytes = File.ReadAllBytes(filePath);
                string base64String = "data:image/jpeg;base64," + Convert.ToBase64String(imgBytes);
                imgurl = base64String;
            }
            return imgurl;
        }

        protected void btnjoinFundraiser_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration/DonorRegistration.aspx");
        }

        protected void btnjoinRecipient_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration/HospitalRegistration.aspx");
        }

        protected void gvDonorProgress_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblPriorityD1 = (Label)e.Row.FindControl("lblPriorityD1");
                string PriorityD1 = DataBinder.Eval(e.Row.DataItem, "PriorityD1")?.ToString();

                if (!string.IsNullOrEmpty(PriorityD1))
                {
                    switch (PriorityD1)
                    {
                        case "1":
                            lblPriorityD1.Text = " URGENT";
                            lblPriorityD1.ForeColor = System.Drawing.Color.Red;
                            break;
                    }
                }

                Label lblPriorityD2 = (Label)e.Row.FindControl("lblPriorityD2");
                string PriorityD2 = DataBinder.Eval(e.Row.DataItem, "PriorityD2")?.ToString();

                if (!string.IsNullOrEmpty(PriorityD2))
                {
                    switch (PriorityD2)
                    {
                        case "1":
                            lblPriorityD2.Text = " URGENT";
                            lblPriorityD2.ForeColor = System.Drawing.Color.Red;
                            break;
                    }
                }

                Label lblPriorityD3 = (Label)e.Row.FindControl("lblPriorityD3");
                string PriorityD3 = DataBinder.Eval(e.Row.DataItem, "PriorityD3")?.ToString();

                if (!string.IsNullOrEmpty(PriorityD3))
                {
                    switch (PriorityD3)
                    {
                        case "1":
                            lblPriorityD3.Text = " URGENT";
                            lblPriorityD3.ForeColor = System.Drawing.Color.Red;
                            break;
                    }
                }
            }
        }

        private void LoadDonorReport()
        {
            List<DonorMaster> odonors = oHomeService.GetAllDonors();

            DataSet dsReprtData2 = new DataSet();
            dsReprtData2.Merge(CommonService.ToDataTable(odonors));

            ReportViewer2.ProcessingMode = ProcessingMode.Local;
            ReportViewer2.LocalReport.ReportPath = Server.MapPath("~/Report/RegisteredDonors.rdlc");

            ReportDataSource datasource2 = new ReportDataSource("dsDonor", dsReprtData2.Tables[0]);

            ReportViewer2.LocalReport.DataSources.Clear();
            ReportViewer2.LocalReport.DataSources.Add(datasource2);

            Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string fileNameExtension = string.Empty;
            string deviceInfo =
                "<DeviceInfo>" +
                "  <OutputFormat>PDF</OutputFormat>" +
                "  <PageWidth>8.27in</PageWidth>" +
                "  <PageHeight>6.0in</PageHeight>" +
                "  <MarginTop>0in</MarginTop>" +
                "  <MarginLeft>0in</MarginLeft>" +
                "  <MarginRight>0in</MarginRight>" +
                "  <MarginBottom>0in</MarginBottom>" +
                "</DeviceInfo>";

            byte[] bytes1 = ReportViewer2.LocalReport.Render("PDF", deviceInfo, out mimeType, out encoding, out fileNameExtension, out streamIds, out warnings);
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = mimeType;
            HttpContext.Current.Response.AddHeader("content-disposition", "inline; filename=GiveMEDRegisteredDonors.pdf");
            HttpContext.Current.Response.AddHeader("content-length", bytes1.Length.ToString());
            HttpContext.Current.Response.AppendHeader("Pragma", "no-cache");
            HttpContext.Current.Response.CacheControl = "no-cache";
            HttpContext.Current.Response.Expires = -1;
            HttpContext.Current.Response.Buffer = true;

            // Open the PDF in a new tab
            HttpContext.Current.Response.AddHeader("target", "_blank");

            HttpContext.Current.Response.BinaryWrite(bytes1);
            HttpContext.Current.Response.End();
        }

        private void LoadHospitalReport()
        {
            List<HospitalMaster> ohospitals = oHomeService.GetAllHospitals();

            DataSet dsReprtData3 = new DataSet();
            dsReprtData3.Merge(CommonService.ToDataTable(ohospitals));

            ReportDataSource datasource3 = new ReportDataSource("dsHospital", dsReprtData3.Tables[0]);


            ReportViewer3.ProcessingMode = ProcessingMode.Local;
            ReportViewer3.LocalReport.ReportPath = Server.MapPath("~/Report/RegisteredHospitals.rdlc");

            ReportViewer3.LocalReport.DataSources.Add(datasource3);

            ReportViewer3.LocalReport.DataSources.Clear();

            Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string fileNameExtension = string.Empty;
            string deviceInfo =
                "<DeviceInfo>" +
                "  <OutputFormat>PDF</OutputFormat>" +
                "  <PageWidth>8.27in</PageWidth>" +
                "  <PageHeight>6.0in</PageHeight>" +
                "  <MarginTop>0in</MarginTop>" +
                "  <MarginLeft>0in</MarginLeft>" +
                "  <MarginRight>0in</MarginRight>" +
                "  <MarginBottom>0in</MarginBottom>" +
                "</DeviceInfo>";

            byte[] bytes1 = ReportViewer3.LocalReport.Render("PDF", deviceInfo, out mimeType, out encoding, out fileNameExtension, out streamIds, out warnings);
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = mimeType;
            HttpContext.Current.Response.AddHeader("content-disposition", "inline; filename=GiveMEDRegisteredHospitals.pdf");
            HttpContext.Current.Response.AddHeader("content-length", bytes1.Length.ToString());
            HttpContext.Current.Response.AppendHeader("Pragma", "no-cache");
            HttpContext.Current.Response.CacheControl = "no-cache";
            HttpContext.Current.Response.Expires = -1;
            HttpContext.Current.Response.Buffer = true;

            // Open the PDF in a new tab
            HttpContext.Current.Response.AddHeader("target", "_blank");

            HttpContext.Current.Response.BinaryWrite(bytes1);
            HttpContext.Current.Response.End();
        }

        private void LoadAnnualReport()
        {
            List<VwAnnualreport> oRequestHeader = oHomeService.GetAllRequestHeader();

            DataSet dsReprtData1 = new DataSet();
            dsReprtData1.Merge(CommonService.ToDataTable(oRequestHeader));

            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/AnnualDonationReport.rdlc");

            ReportDataSource datasource1 = new ReportDataSource("VwAnnualreport", dsReprtData1.Tables[0]);

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource1);

            Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string fileNameExtension = string.Empty;
            string deviceInfo =
                "<DeviceInfo>" +
                "  <OutputFormat>PDF</OutputFormat>" +
                "  <PageWidth>8.27in</PageWidth>" +
                "  <PageHeight>6.0in</PageHeight>" +
                "  <MarginTop>0in</MarginTop>" +
                "  <MarginLeft>0in</MarginLeft>" +
                "  <MarginRight>0in</MarginRight>" +
                "  <MarginBottom>0in</MarginBottom>" +
                "</DeviceInfo>";

            byte[] bytes1 = ReportViewer1.LocalReport.Render("PDF", deviceInfo, out mimeType, out encoding, out fileNameExtension, out streamIds, out warnings);
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = mimeType;
            HttpContext.Current.Response.AddHeader("content-disposition", "inline; filename=GiveMEDAnnualDonationReport.pdf");
            HttpContext.Current.Response.AddHeader("content-length", bytes1.Length.ToString());
            HttpContext.Current.Response.AppendHeader("Pragma", "no-cache");
            HttpContext.Current.Response.CacheControl = "no-cache";
            HttpContext.Current.Response.Expires = -1;
            HttpContext.Current.Response.Buffer = true;

            // Open the PDF in a new tab
            HttpContext.Current.Response.AddHeader("target", "_blank");

            HttpContext.Current.Response.BinaryWrite(bytes1);
            HttpContext.Current.Response.End();
        }


        protected void btnReport_Click(object sender, EventArgs e)
        {
            LoadAnnualReport();
        }

        protected void btnhospital_Click(object sender, EventArgs e)
        {
            LoadHospitalReport();
        }

        protected void btndonor_Click(object sender, EventArgs e)
        {
            LoadDonorReport();
        }
    }
}