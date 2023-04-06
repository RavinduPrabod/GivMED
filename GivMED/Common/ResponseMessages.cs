using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GivMED.Common
{
    public class ResponseMessages
    {
        public static string InsertSuccess { get { return "Record Successfully Inserted."; } }

        public static string UpdateSuccess { get { return "Record Successfully Updated."; } }

        public static string DeleteSuccess { get { return "Record Successfully Deleted."; } }

        public static string CheckSuccess { get { return "Record Successfully Checked."; } }

        public static string NoData { get { return "No Record(s) Available."; } }

        public static string PasswordResetSuccess { get { return "Password Successfully Resetted."; } }

        public static string AlreadyExists { get { return "Record Already Exists, Please Add Another Record"; } }

        public static string Error { get { return "Error Occured..Please Try Again"; } }

        public static string PasswordNotMatch { get { return "Password Not Match"; } }

        public static string NewUser { get { return "New User Added.."; } }

        public static string AlreadyAssign { get { return "Already Assign"; } }

        public static string CampDeleteExist { get { return "Cannot Delete, Already Camp Have Donors"; } }

        public static string EmailAlreadyExists { get { return "Email Already Exists"; } }

        public static string Registerd { get { return "Successfully Registered"; } }

        public static string LoginSuccess { get { return "Login Successfull"; } }

        public static string LoginFail { get { return "Login Fail"; } }
    }
}