using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GivMED.Pages.Web
{
    public partial class validation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Get the value of the email input field
            string email = Request.Form["email"];

            // Create a new list to store email addresses
            List<string> emailList = new List<string>();

            // Add the email to the list
            emailList.Add(email);

            // Do something with the email list
            // ...
            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "validate", "$(function () { $('#mainform').validate({ rules: { email: { required: true, email: true }, password: { required: true, minlength: 6 }, terms: { required: true } }, messages: { email: { required: 'Please enter a email address', email: 'Please enter a vaild email address' }, password: { required: 'Please provide a password', minlength: 'Your password must be at least 5 characters long' }, terms: 'Please accept our terms' }, errorElement: 'span', errorPlacement: function (error, element) { error.addClass('invalid-feedback'); element.closest('.form-group').append(error); }, highlight: function (element, errorClass, validClass) { $(element).addClass('is-invalid'); }, unhighlight: function (element, errorClass, validClass) { $(element).removeClass('is-invalid'); } }); });", true);
        }
    }
}