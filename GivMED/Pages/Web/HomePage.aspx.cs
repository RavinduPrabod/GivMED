using System;

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

namespace GivMED.Pages.Web
{
    public partial class HomePage : System.Web.UI.Page
    {
        HomeService oHomeService = new HomeService();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                List<TopTrendingDonorDto> result = new List<TopTrendingDonorDto>();
                List<TopTrendingDonorDto> lastresult = new List<TopTrendingDonorDto>();

                List<TopTrendingDonorDto> Toplist = new List<TopTrendingDonorDto>();
                List<TopTrendingDonorDto> grplist = new List<TopTrendingDonorDto>();

                Toplist = oHomeService.GetTopRateDonors();

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
                        donatedQty = Temp1list.Where(x=>x.SupplyID == Temp2list[i].SupplyID).Select(x=>x.DonatedQty).Sum();

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
            }




            //var email = new MimeMessage();

            //email.From.Add(new MailboxAddress("Sender Name", "joan8@ethereal.email"));
            //email.To.Add(new MailboxAddress("Receiver Name", "gilbert.runolfsdottir22@ethereal.email"));

            //email.Subject = "Testing out email sending";
            //email.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
            //{
            //    Text = "Hello all the way from the land of C#"
            //};
            //using (var smtp = new SmtpClient())
            //{
            //    smtp.Connect("smtp.ethereal.email", 587, false);

            //    // Note: only needed if the SMTP server requires authentication
            //    smtp.Authenticate("joan8@ethereal.email", "DSaAs5TKsp6X5pgyKc");

            //    smtp.Send(email);
            //    smtp.Disconnect(true);
            //}
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
            Response.Redirect("Registration/FundraiserRegistration.aspx");
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
                string PriorityD1 = DataBinder.Eval(e.Row.DataItem, "PriorityD1").ToString();

                switch (PriorityD1)
                {
                    case "1":
                        lblPriorityD1.Text = " URGENT";
                        lblPriorityD1.ForeColor = System.Drawing.Color.Red;
                        break;
                }

                Label lblPriorityD2 = (Label)e.Row.FindControl("lblPriorityD2");
                string PriorityD2 = DataBinder.Eval(e.Row.DataItem, "PriorityD2").ToString();

                switch (PriorityD2)
                {
                    case "1":
                        lblPriorityD2.Text = " URGENT";
                        lblPriorityD2.ForeColor = System.Drawing.Color.Red;
                        break;
                }

                Label lblPriorityD3 = (Label)e.Row.FindControl("lblPriorityD3");
                string PriorityD3 = DataBinder.Eval(e.Row.DataItem, "PriorityD3").ToString();

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
}