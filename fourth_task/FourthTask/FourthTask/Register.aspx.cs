using FourthTask.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FourthTask
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            if (ValidateUser(EmailTextBox.Text, PasswordTextBox.Text, RepeatPasswordTextBox.Text, NameTextBox.Text))
                Response.Redirect("Login.aspx", true);
            else
                Response.Redirect("Register.aspx", true);
        }

        private bool ValidateUser(string email, string passWord, string repeatPassWord, string name)
        {
            if ((null == email) || (0 == email.Length) || (email.Length > 60))
            {
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of email failed.");
                return false;
            }
            if ((null == passWord) || (1 > passWord.Length) || (passWord.Length > 60) || (!passWord.Equals(repeatPassWord)))
            {
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of passWord failed.");
                return false;
            }

            if ((null == name) || (0 == name.Length) || (name.Length > 50))
            {
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of name failed.");
                return false;
            }

            try
            {
                using (var db = new PersonContext())
                {
                    Person userCheck = db.Persons.SingleOrDefault(x => x.Email == email);
                    if (userCheck != null)
                    {
                        System.Diagnostics.Trace.WriteLine("[ValidateUser] User with this email already exists.");
                        return false;
                    }
                    Person newUser = new Person();
                    newUser.PersonName = name;
                    newUser.Password = passWord;
                    newUser.Email = email;
                    newUser.RegisterDate = newUser.LastLoginDate = DateTime.Now;
                    newUser.Blocked = false;
                    db.Persons.Add(newUser);
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