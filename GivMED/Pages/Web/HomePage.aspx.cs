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

                List<TopTrendingDonorDto> olist = new List<TopTrendingDonorDto>();
                List<TopTrendingDonorDto> grplist = new List<TopTrendingDonorDto>();

                olist = oHomeService.GetTopRateDonors();
                grplist = olist.GroupBy(s => s.DonorID)
                                                    .Select(group => group.First())
                                                    .ToList();

                foreach (var item in grplist)
                {
                    TopTrendingDonorDto otemp = new TopTrendingDonorDto();
                    otemp.DonorName = item.DonorName.ToString();
                    otemp.ImgURL = GetimageURL(item.ImgURL);
                    otemp.DonationCredit = (5 * olist.Where(x => x.DonorID == item.DonorID).Count());
                    otemp.DonorID = item.DonorID;
                    otemp.LastActivityDate = olist.Where(x => x.DonorID == item.DonorID).LastOrDefault().CreatedDateTime;
                    otemp.Lastprogram1 = olist.Where(x => x.DonorID == item.DonorID).LastOrDefault().HospitalName + " " + olist.Where(x => x.DonorID == item.DonorID).LastOrDefault().SupplyID;
                    otemp.Lastprogram2 = olist.Where(x => x.DonorID == item.DonorID).LastOrDefault().HospitalName + " " + olist.Where(x => x.DonorID == item.DonorID).LastOrDefault().SupplyID;
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

                    if (i == 0)
                    {
                        odata.DonorNameT1 = result[i].DonorName;
                        odata.ImgURLT1 = result[i].ImgURL;
                        odata.DonationCreditT1 = result[i].DonationCredit;
                        odata.LastActivityDateT1 = result[i].LastActivityDate;
                        odata.Lastprogram1T1 = result[i].Lastprogram1;
                        odata.Lastprogram2T1 = result[i].Lastprogram2;
                    }
                    else if (i == 1)
                    {
                        odata.DonorNameT2 = result[i].DonorName;
                        odata.ImgURLT2 = result[i].ImgURL;
                        odata.DonationCreditT2 = result[i].DonationCredit;
                        odata.LastActivityDateT2 = result[i].LastActivityDate;
                        odata.Lastprogram1T2 = result[i].Lastprogram1;
                        odata.Lastprogram2T2 = result[i].Lastprogram2;
                    }
                    else
                    {
                        odata.DonorNameT3 = result[i].DonorName;
                        odata.ImgURLT3 = result[i].ImgURL;
                        odata.DonationCreditT3 = result[i].DonationCredit;
                        odata.LastActivityDateT3 = result[i].LastActivityDate;
                        odata.Lastprogram1T3 = result[i].Lastprogram1;
                        odata.Lastprogram2T3 = result[i].Lastprogram2;
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
    }
}