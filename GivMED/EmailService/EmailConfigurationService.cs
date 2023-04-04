using GivMED.Common;
using GivMED.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace GivMED.EmailService
{
    public class EmailConfigurationService
    {
        private GiveMEDContext _dbContext = new GiveMEDContext();

        public void EmailSender(string Email)
        {
            try
            {
                using (MailMessage mm = new MailMessage())
                {
                    mm.From = new MailAddress("lucifer98moninstar@gmail.com"); // Email address of the sender
                    mm.To.Add(Email); // Email address of the recipient.
                    mm.Subject = "Test"; // Subject of email.
                    mm.Body = "For testing purpose"; // Content of email.
                    mm.IsBodyHtml = false; // To specify whether email body contains HTML tags or not.

                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com"; // SMTP Host Details.
                    smtp.EnableSsl = true; // Specify whether host accepts SSL Connections or not.
                    smtp.UseDefaultCredentials = false; // Use NetworkCredential for authentication.
                    NetworkCredential NetworkCred = new NetworkCredential("lucifer98moninstar@gmail.com", "Kudse181f004"); // Your Email and password
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 465; // SMTP Server port number. This varies from host to host.
                    smtp.Send(mm);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SendEmail(string recipient)
        {
            // Set up SMTP client
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;

            // Set up login credentials
            NetworkCredential credentials = new NetworkCredential("lucifer98moninstar@gmail.com", "Kudse181f004");
            client.Credentials = credentials;

            // Set up email message
            MailMessage message = new MailMessage();
            message.From = new MailAddress("lucifer98moninstar@gmail.com");
            message.To.Add(new MailAddress(recipient));
            message.Subject = "test";
            message.Body = "test";

            // Send email
            client.Send(message);
        }

        private void LoadEmailSettings()
        {
            try
            {
                EmailConfiguration oEmailConfiguration = _dbContext.GetEmailConfigurations;
                GlobalData.Port = oEmailConfiguration.Port;
                GlobalData.SmtpAddress = oEmailConfiguration.SmtpAddress;
                GlobalData.NoreplyEmail = oEmailConfiguration.EmailAddress;
                GlobalData.NoreplyPassword = oEmailConfiguration.Password;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SendUnsendEmails(string Email)
        {
            try
            {
                string emailusers = "";
                List<UnsendEmailLog> oUnsendEmailLogs = _dbContext.GetUnSendEmaiLogs.ToList();
                if (oUnsendEmailLogs.Count > 0)
                {
                    foreach (var item in oUnsendEmailLogs)
                    {
                        emailusers = _dbContext.GetEmailUsers(item.FunctionId);
                        if (!string.IsNullOrEmpty(emailusers))
                        {
                            if (SendMail(item.Subject, item.Message, Email))
                            {
                                _dbContext.DeleteCurrentLog(item.FunctionId, item.TransactionNo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool SendMail(string subject, string message, string emailusers)
        {
            bool result = false;
            try
            {
                using (MailMessage mm = new MailMessage(GlobalData.NoreplyEmail, emailusers))
                {
                    mm.Subject = subject;
                    mm.Body = message;
                    mm.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = GlobalData.SmtpAddress;
                    smtp.Port = GlobalData.Port;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.EnableSsl = false;
                    smtp.UseDefaultCredentials = false;
                    NetworkCredential NetworkCred = new NetworkCredential(GlobalData.NoreplyEmail, GlobalData.NoreplyPassword);
                    smtp.Credentials = NetworkCred;
                    smtp.Send(mm);
                    result = true;
                }
            }
            catch (Exception)
            {
            }
            return result;
        }
        private bool SendMailDirect(string emailusers)
        {
            bool result = false;
            try
            {
                using (MailMessage mm = new MailMessage(GlobalData.NoreplyEmail, emailusers))
                {
                    mm.Subject = "Test";
                    mm.Body = "Hello";
                    mm.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = GlobalData.SmtpAddress;
                    smtp.Port = GlobalData.Port;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.EnableSsl = false;
                    smtp.UseDefaultCredentials = false;
                    NetworkCredential NetworkCred = new NetworkCredential(GlobalData.NoreplyEmail, GlobalData.NoreplyPassword);
                    smtp.Credentials = NetworkCred;
                    smtp.Send(mm);
                    result = true;
                }
            }
            catch (Exception)
            {
            }
            return result;
        }

    }
}