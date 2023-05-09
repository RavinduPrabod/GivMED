using GivMED.Common;
using GivMED.Models;
using GivMED.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static GivMED.Common.Enums;

namespace GivMED.Pages.Web
{
    public partial class ComplaintForum : System.Web.UI.Page
    {
        HomeService oHomeService = new HomeService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                clearfields();
            }
        }

        private void clearfields()
        {
            txtName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtSubject.Text = string.Empty;
            txtNameofVict.Text = string.Empty;
            txtFullComplaint.Text = string.Empty;
        }

        private void PostComplaint()
        {
            Complaint result = new Complaint();
            result.ComplaintCode = "CLN0";
            result.ComplanerName = txtName.Text.ToString();
            result.ComplanerEmail = txtEmail.Text.ToString();
            result.NameofVictim = txtNameofVict.Text.ToString();
            result.Subject = txtSubject.Text.ToString();
            result.FullComplaint = txtFullComplaint.Text.ToString();
            result.CreatedBy = "Admin";
            result.CreatedDateTime = DateTime.Now;

            WebApiResponse response = new WebApiResponse();
            response = oHomeService.PostComplaint(result);
            if (response.StatusCode == (int)StatusCode.Success)
            {
                clearfields();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Swal.fire({icon: 'success', title: 'Complaint successfully submitted!', text: 'We will review your complaint and take appropriate action.', showConfirmButton: false, timer: 3000});", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Swal.fire({icon: 'error', title: 'Error!', showConfirmButton: false, timer: 1500});", true);

            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            PostComplaint();
        }
    }
}