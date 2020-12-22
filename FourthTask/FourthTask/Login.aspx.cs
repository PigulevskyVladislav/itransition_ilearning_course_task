using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Security;
using System.Data;
using FourthTask.Models;

namespace FourthTask
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/");
            }
            ((Button)PersonLogin.FindControl("LoginButton")).Click += new System.EventHandler(PersonLogin_ServerClick);
        }

        private void PersonLogin_ServerClick(object sender, System.EventArgs e)
        {
            if (ValidateUser(PersonLogin.UserName, PersonLogin.Password))
                FormsAuthentication.RedirectFromLoginPage(PersonLogin.UserName, PersonLogin.RememberMeSet);
            else
                Response.Redirect("Login.aspx", true);
        }

        private bool ValidateUser(string email, string passWord)
        {
            if ((null == email) || (0 == email.Length) || (email.Length > 60))
            {
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of email failed.");
                return false;
            }
            if ((null == passWord) || (1 > passWord.Length) || (passWord.Length > 60))
            {
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of passWord failed.");
                return false; 
            }
            try
            {
                using (var db = new PersonContext())
                {
                    Person user = db.Persons.SingleOrDefault(x => x.Email == email);
                    if (user == null || user.Password != passWord)
                    {
                        System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of passWord failed.");
                        return false;
                    }
                    user.LastLoginDate = DateTime.Now;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Exception " + ex.Message);
                return false;
            }
        }
    }
}