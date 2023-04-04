using GivMED.Common;
using GivMED.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GivMED.EmailService
{
    public class GiveMEDContext
    {
        private readonly string ConString;

        public GiveMEDContext()
        {
            ConString = GlobalData.CloudConString;
        }

        public EmailConfiguration GetEmailConfigurations
        {
            get
            {
                EmailConfiguration oEmailConfiguration = new EmailConfiguration();
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    string Stock = "SELECT * FROM [dbo].[EmailConfiguration]";
                    SqlCommand cmd = new SqlCommand(Stock, con);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        oEmailConfiguration.Port = Convert.ToInt32(dr["Port"]);
                        oEmailConfiguration.SmtpAddress = dr["SmtpAddress"].ToString();
                        oEmailConfiguration.EmailAddress = dr["EmailAddress"].ToString();
                        oEmailConfiguration.Password = dr["Password"].ToString();
                    }
                }
                return oEmailConfiguration;
            }
        }

        public IEnumerable<UnsendEmailLog> GetUnSendEmaiLogs
        {
            get
            {
                List<UnsendEmailLog> oUnsendEmailLogs = new List<UnsendEmailLog>();
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    string Stock = "SELECT * FROM [dbo].[UnsendEmailLog]";
                    SqlCommand cmd = new SqlCommand(Stock, con);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        UnsendEmailLog oUnsendEmailLog = new UnsendEmailLog();
                        oUnsendEmailLog.FunctionId = Convert.ToInt64(dr["FunctionId"]);
                        oUnsendEmailLog.TransactionNo = dr["InvoiceNo"].ToString();
                        oUnsendEmailLog.Subject = dr["Subject"].ToString();
                        oUnsendEmailLog.Message = dr["Message"].ToString();
                        oUnsendEmailLogs.Add(oUnsendEmailLog);
                    }
                }
                return oUnsendEmailLogs;
            }
        }

        public string GetEmailUsers(long functionid)
        {
            ArrayList emailusersarray = new ArrayList();
            string emailusers = "";
            try
            {
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    string Stock = "SELECT UserEmail FROM [User] A INNER JOIN [dbo].[EmailUsers] B ON A.UserName=B.UserName WHERE B.FunctionId=@FunctionId";
                    SqlCommand cmd = new SqlCommand(Stock, con);
                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("FunctionId", functionid);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        emailusersarray.Add(dr["UserEmail"].ToString());
                    }
                }
                emailusers = string.Join(" ", emailusersarray.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return emailusers;
        }

        public void DeleteCurrentLog(long functionid, string invoiceno)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    String query = "DELETE FROM [dbo].[UnsendEmailLog] WHERE FunctionId=@FunctionId AND InvoiceNo=@InvoiceNo";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("FunctionId", functionid);
                    cmd.Parameters.AddWithValue("InvoiceNo", invoiceno);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}