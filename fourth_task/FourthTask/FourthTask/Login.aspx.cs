using System;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using FourthTask.Models;

namespace FourthTask
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                Response.Redirect("PersonList.aspx");
            }
            ((Button)PersonLogin.FindControl("LoginButton")).Click += new System.EventHandler(PersonLogin_ServerClick);
        }

        private void PersonLogin_ServerClick(object sender, System.EventArgs e)
        {
            if (ValidateUser(PersonLogin.UserName, PersonLogin.Password))
            {
                FormsAuthenticationTicket tkt;
                string cookiestr;
                HttpCookie ck;
                tkt = new FormsAuthenticationTicket(1, PersonLogin.UserName, DateTime.Now,
                DateTime.Now.AddMinutes(30), PersonLogin.RememberMeSet, "user ticket");
                cookiestr = FormsAuthentication.Encrypt(tkt);
                ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
                if (PersonLogin.RememberMeSet)
                    ck.Expires = tkt.Expiration;
                ck.Path = FormsAuthentication.FormsCookiePath;
                Response.Cookies.Add(ck);

                
                FormsAuthentication.RedirectFromLoginPage(PersonLogin.UserName, PersonLogin.RememberMeSet);
            }
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