using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace college_event
{
    public partial class SuperAdminHome : System.Web.UI.Page
    {
        CollegeEventDataContext db = new CollegeEventDataContext();
        string[] parts;
        string username;
        string domain;

        protected void Page_Load(object sender, EventArgs e)
        {
            int status = Convert.ToInt32(Session["status"]);
            string email = Convert.ToString(Session["uid"]);

            parts = email.Split(new[] { '@' });
            username = parts[0];
            domain = "knights.ucf.edu";              // parts[1];
            if (!IsPostBack)
            {
                LoadGridView();
            }
        }

        protected void LoadGridView()
        {
            // View Events in the University
            DataTable table_view_events = new DataTable();

            
            table_view_events.Columns.Add(new DataColumn("Event", typeof(string)));
            table_view_events.Columns.Add(new DataColumn("Category", typeof(string)));
            table_view_events.Columns.Add(new DataColumn("Description", typeof(string)));
            table_view_events.Columns.Add(new DataColumn("Start", typeof(TimeSpan)));
            table_view_events.Columns.Add(new DataColumn("End", typeof(TimeSpan)));
            table_view_events.Columns.Add(new DataColumn("Date", typeof(string)));
            table_view_events.Columns.Add(new DataColumn("Contact", typeof(string)));
            table_view_events.Columns.Add(new DataColumn("Email", typeof(string)));
            table_view_events.Columns.Add(new DataColumn("Location", typeof(string)));
            table_view_events.Columns.Add(new DataColumn("Address", typeof(string)));
            //table_view_events.Columns.Add(new DataColumn("Event No.", typeof(string)));

            var qry_Events = (from temp in db.Events
                              where temp.status == true 
                              select temp).ToList();
            var i = 0;
            foreach (var value in qry_Events)
            {
                //event_N = value.event_no;
                string x = "";
                string y = "";
                var qry_event_no = (from eNum in db.set_event_locations
                                    where eNum.event_no == value.event_no
                                    select eNum).ToList();

                foreach (var v in qry_event_no)
                {
                    x = v.location;
                    y = v.address;
                }
                
                DataRow row = table_view_events.NewRow();
                row[0] = value.eType;
                row[1] = value.eCategory;
                row[2] = value.eDescription;
                row[3] = value.start;
                row[4] = value.end;
                string dt = value.date.ToString();
                string[] split_date = dt.Split(' ');
                row[5] = split_date[0];
                row[6] = value.contact;
                row[7] = value.email;
                row[8] = x;
                row[9] = y;
                ViewState[i.ToString()] = value.event_no;
                i++;
                table_view_events.Rows.Add(row);
            }
            GridView_ApproveEvent.DataSource = table_view_events;
            GridView_ApproveEvent.DataBind();
        }

        // Update Status of the event from pending to approved.
        protected void btn_click_approve(object sender, EventArgs e)
        {
            GridViewRow clickedRow = ((Button)sender).NamingContainer as GridViewRow;
            var x = clickedRow.RowIndex;
            string u = x.ToString();
            int event_no = Convert.ToInt32(ViewState[u]);
            Event evt = db.Events.Single(a => a.event_no == event_no);
            evt.status = false;
            db.SubmitChanges();
            LoadGridView();
        }
    }
}