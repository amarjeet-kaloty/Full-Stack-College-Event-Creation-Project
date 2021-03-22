using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace college_event.Users
{
    public partial class UserHomePage : System.Web.UI.Page
    {
        CollegeEventDataContext db = new CollegeEventDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            Load_GridView();
        }

        protected void Load_GridView()
        {
            int status = Convert.ToInt32(Session["status"]);
            string email = Convert.ToString(Session["uid"]);

            string[] parts = email.Split(new[] { '@' });
            string username = parts[0];
            string domain = "knights.ucf.edu";                      // parts[1];

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

            var qry_Events = (from temp in db.Events
                              select temp).Where(x => x.email.Contains(domain)).ToList();

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
            GridView_UniversityEvents.DataSource = table_view_events;
            GridView_UniversityEvents.DataBind();

            // RSO GridView
            DataTable table_joinRSO = new DataTable();

            table_joinRSO.Columns.Add(new DataColumn("RSO Name", typeof(string)));
            table_joinRSO.Columns.Add(new DataColumn("Member", typeof(string)));
            table_joinRSO.Columns.Add(new DataColumn("College ID", typeof(int)));
            table_joinRSO.Columns.Add(new DataColumn("Email", typeof(string)));
            table_joinRSO.Columns.Add(new DataColumn("Number of Members", typeof(int)));

            var qry_RSO = (from temp in db.RSOs
                           select temp).GroupBy(x => x.organisation_name).Select(y => y.FirstOrDefault()).Where(x => x.email.Contains(domain)).ToList();

            foreach (var value in qry_RSO)
            {
                var qry_count = (from temp1 in db.RSOs
                                 where value.organisation_name == temp1.organisation_name
                                 select temp1).Count();

                DataRow row = table_joinRSO.NewRow();
                row[0] = value.organisation_name;
                row[1] = value.group_member;
                row[2] = value.college_id;
                row[3] = value.email;
                row[4] = qry_count;
                table_joinRSO.Rows.Add(row);
            }
            GridView_JoinRSO.DataSource = table_joinRSO;
            GridView_JoinRSO.DataBind();
        }

        //
        protected void create_RSO_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateEventPage.aspx");
        }
    }
}