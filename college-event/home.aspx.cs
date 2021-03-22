using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace college_event
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    if (Session["status"].Equals("1"))    // SuperAdmin
            //    { 

            //    }
            //    else if (Session["status"].Equals("2")) // User is Admin
            //    {

            //    }
            //}
            //catch (Exception ex)
            //{
            //    Response.Write("<script>alert('" + ex.Message + "');</script>");
            //}
        }

        //Create Event
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateEventPage.aspx");
        }

        // Create University Profile
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateUniversityProfile.aspx");
        }

        // Request To Create Rso
        protected void requestToCreateRso_Click(object sender, EventArgs e)
        {

        }
    }
}