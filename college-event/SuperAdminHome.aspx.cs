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
            domain = parts[1];              // "knights.ucf.edu";
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


            var qry_RSO = (from temp in db.RSOs
                           where temp.email == Session["uid"].ToString()
                           select temp).ToList();

            if(qry_RSO.Count == 0)
            {
                var qry_Events = (from temp in db.Events
                                  select temp).Where(x => x.email.Contains(domain) && (x.eCategory == "Public")).ToList();

                foreach (var value in qry_Events)
                {
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
                    table_view_events.Rows.Add(row);
                }
                GridView_ApproveEvent.DataSource = table_view_events;
                GridView_ApproveEvent.DataBind();
            }

            
        }
    }
}