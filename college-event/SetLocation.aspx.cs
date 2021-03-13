using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace college_event
{
    public partial class SetLocation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Confirm Button: Stored the data to the database
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            CollegeEventDataContext db = new CollegeEventDataContext();
            var newEvent = new set_event_location();
            newEvent.location = txt_location.Text.Trim();
            newEvent.latitude = latitude.Text.ToString();
            newEvent.longitude = longitude.Text.ToString();
            newEvent.address = Address.Text.Trim();
            try
            {
                db.set_event_locations.InsertOnSubmit(newEvent);
                db.SubmitChanges();
                Response.Redirect("CreateEventPage.aspx");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());
            }
        }
    }
}