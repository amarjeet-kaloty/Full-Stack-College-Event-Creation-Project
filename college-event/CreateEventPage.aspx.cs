using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace college_event
{
    public partial class CreateEventPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Set Location
        protected void set_location_Click(object sender, EventArgs e)
        {
            Response.Redirect("SetLocation.aspx");
        }

        // Create Event 
        protected void create_event_Click(object sender, EventArgs e)
        {
            CollegeEventDataContext db = new CollegeEventDataContext();
            var createEvent = new Event();
            createEvent.eType = event_type.Text.Trim();
            createEvent.eCategory = category.SelectedValue.ToString();
        }
    }
}