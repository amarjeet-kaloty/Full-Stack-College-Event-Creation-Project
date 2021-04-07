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
            try
            {
                if (string.IsNullOrEmpty((string)Session["name"]))
                {
                    login.Visible = true;     // User Login button
                    register.Visible = true;     // User Sign-up button

                    logout.Visible = false;       // Logout button
                    greetings.Visible = false;      // Hello User button     

                }
                else  // User
                {
                    login.Visible = false;     // User Login button
                    register.Visible = false;     // User Sign-up button

                    logout.Visible = true;       // Logout button
                    greetings.Text = "Hello " + Session["name"].ToString() + "!";      // Hello User button 
                    
                }
                
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

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

        protected void logout_Click(object sender, EventArgs e)
        {
            Session["uid"] = "";
            Session["name"] = "";
            Session["status"] = "";
            login.Visible = true;     // User Login button
            register.Visible = true;     // User Sign-up button

            logout.Visible = false;       // Logout button
            greetings.Visible = false;      // Hello User button     
            Response.Redirect("Login.aspx");
        }
    }
}