using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Data.Entity;
using FourthTask.Models;
using System.Data.SqlClient;
using System.Data;
using Npgsql;

namespace FourthTask
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                string email = HttpContext.Current.User.Identity.Name;
                bool blocked = true;
                try
                {
                    NpgsqlConnection conn = new NpgsqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["FourthTask"].ConnectionString);
                    conn.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand("Select \"Blocked\" from persons where \"Email\"=@email", conn);
                    cmd.Parameters.AddWithValue("@email", email);
                    var result = cmd.ExecuteScalar();
                    blocked = result != null ? (bool)result : true;
                    cmd.Dispose();
                    conn.Dispose();
                }
                catch (SqlException ex) { Console.WriteLine(ex.Message); }
                if (blocked)
                {
                    FormsAuthentication.SignOut();
                    Response.Redirect("Login.aspx", true);
                }
            }
        }
    }
}