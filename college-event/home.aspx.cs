using college_event.Classes;
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

            String todayURL = "https://events.ucf.edu/feed.xml";
            String upcomingURL = "https://events.ucf.edu/upcoming/feed.xml";
            EventStream es = new EventStream(todayURL);

            ListBox1.DataSource = es.list;
            ListBox1.DataBind();
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

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String todayURL = "https://events.ucf.edu/feed.xml";
            String upcomingURL = "https://events.ucf.edu/upcoming/feed.xml";
            EventStream es1 = new EventStream(todayURL);
            ListBox1.DataSource = es1.list;
            ListBox1.DataBind();
        }
    }
}