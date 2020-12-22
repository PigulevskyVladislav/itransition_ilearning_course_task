using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FourthTask
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cmdSignOut.ServerClick += new System.EventHandler(cmdSignOut_ServerClick);
        }

        private void cmdSignOut_ServerClick(object sender, System.EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("Login.aspx", true);
        }
    }
}