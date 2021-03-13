using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace college_event
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Register Page
        protected void register_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        // Login Page
        protected void login_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}