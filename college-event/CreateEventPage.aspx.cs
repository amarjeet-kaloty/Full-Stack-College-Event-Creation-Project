using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace college_event
{
    public partial class CreateEventPage : System.Web.UI.Page
    {
        string event_id = "";
        string loca = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Location"] != null)
            {
                string loc = Request.QueryString["Location"];
                string[] split_loc = loc.Split(new[] { ':' });
                event_id = split_loc[0];
                loca = split_loc[1];
                Location.Text = loca;
            }

            // InitializeCategory();
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
            createEvent.eDescription = description.Text.Trim();

            string s_time = start_time.Text.ToString();
            TimeSpan st = DateTime.Parse(s_time).TimeOfDay;
            createEvent.start = st;

            string e_time = end_time.Text.ToString();
            TimeSpan et = DateTime.Parse(e_time).TimeOfDay;
            createEvent.end = et;

            string dt = date.Text.ToString();
            DateTime y = Convert.ToDateTime(dt);
            createEvent.date = DateTime.Parse(y.Date.ToShortDateString());

            createEvent.contact = contact_number.Text.ToString();
            createEvent.email = contact_email.Text.ToString();
            createEvent.event_no = Convert.ToInt32(event_id);
            try
            {
                db.Events.InsertOnSubmit(createEvent);
                db.SubmitChanges();
                Response.Write("Event created successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());
            }
        }

        protected void InitializeCategory()
        {
            
        }
    }
}