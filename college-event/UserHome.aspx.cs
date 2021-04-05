using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace college_event
{
    public partial class UserHome : System.Web.UI.Page
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
            domain = "knights.ucf.edu";                        // parts[1];
            if (!IsPostBack)
            {
                Load_GridView();
            }
        }

        protected void Load_GridView()
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

            var qry_Events = (from temp in db.Events
                              select temp).Where(x => x.email.Contains(domain) && (x.eCategory == "Public" || x.eCategory == "Private")).ToList();

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

            table_joinRSO.Columns.Add(new DataColumn("RSO", typeof(string)));
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
                row[1] = qry_count;
                table_joinRSO.Rows.Add(row);
            }
            GridView_RSO.DataSource = table_joinRSO;
            GridView_RSO.DataBind();


        }

        //
        protected void create_RSO_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateNewRSO.aspx");
        }

        // Adding new member to RSO
        protected void Join_Click(object sender, EventArgs e)
        {
            GridViewRow clickedRow = ((Button)sender).NamingContainer as GridViewRow;
            var organisation_name = clickedRow.Cells[1].Text;
            int num_of_members = Convert.ToInt32(clickedRow.Cells[2].Text);

            var qry_members = (from rso in db.RSOs
                               where rso.organisation_name == organisation_name
                               select rso);

            var add_member = new RSO();
            var rand = new Random();
            int college_id = rand.Next(100100, 200100);
            add_member.college_id = college_id;
            add_member.organisation_name = organisation_name;
            add_member.group_member = Session["name"].ToString();
            add_member.email = Session["uid"].ToString();
            add_member.group_administrator = false;
            add_member.creator = false;
            num_of_members++;
            try
            {
                db.RSOs.InsertOnSubmit(add_member);
                db.SubmitChanges();
                Response.Write("<script>alert('Member successfully joined the RSO.');</script>");
            }
            catch (Exception)
            {
                Response.Write("<script>alert('An Error Occured. Please try again.');</script>");
            }


            if (num_of_members == 5) 
            {
                AssignAdmin(organisation_name);
            }
        }

        protected void AssignAdmin(string org_name)
        {
            List<string> members = new List<string>();

            var qry_RSO = (from rso in db.RSOs
                             where rso.organisation_name == org_name
                             select rso).ToList();

            foreach(var member in qry_RSO)
            {
                members.Add(member.college_id.ToString());
            }

            var rand = new Random();
            int random_member = rand.Next(members.Count);
            string choosen_college_id = members[random_member];

            RSO qry_assignAdmin = db.RSOs.Single(x => x.college_id == Convert.ToInt32(choosen_college_id));
            qry_assignAdmin.group_administrator = true;
            db.SubmitChanges();
            

        }

        protected void view_events_by_rso_Click(object sender, EventArgs e)
        {
            GridView_UniversityEvents.Visible = false;
            GridView_RSO.Visible = false;
            label_join_rso.Visible = false;

            // Events if user is a member of the RSO
            DataTable RSO_member_of = new DataTable();

            RSO_member_of.Columns.Add(new DataColumn("Event", typeof(string)));
            RSO_member_of.Columns.Add(new DataColumn("Category", typeof(string)));
            RSO_member_of.Columns.Add(new DataColumn("Description", typeof(string)));
            RSO_member_of.Columns.Add(new DataColumn("Start", typeof(TimeSpan)));
            RSO_member_of.Columns.Add(new DataColumn("End", typeof(TimeSpan)));
            RSO_member_of.Columns.Add(new DataColumn("Date", typeof(string)));
            RSO_member_of.Columns.Add(new DataColumn("Contact", typeof(string)));
            RSO_member_of.Columns.Add(new DataColumn("Email", typeof(string)));
            RSO_member_of.Columns.Add(new DataColumn("Location", typeof(string)));
            RSO_member_of.Columns.Add(new DataColumn("Address", typeof(string)));


            var qry_RSO_user_follows = (from temp in db.RSOs
                                        where temp.email == Session["uid"].ToString() && temp.creator == false
                                        select temp.organisation_name).ToList();

            foreach (var value in qry_RSO_user_follows)
            {
                var qry_RSO_for_creator = (from temp in db.RSOs
                                           where value == temp.organisation_name && temp.creator == true
                                           select temp.email).ToList();

                foreach (var value2 in qry_RSO_for_creator)
                {
                    var qry_Event = (from temp in db.Events
                                     where value2 == temp.email && temp.eCategory == "RSO"
                                     select temp).ToList();
                    foreach (var value3 in qry_Event)
                    {
                        string x = "";
                        string y = "";
                        var qry_event_no = (from eNum in db.set_event_locations
                                            where eNum.event_no == value3.event_no
                                            select eNum).ToList();
                        foreach (var v in qry_event_no)
                        {
                            x = v.location;
                            y = v.address;
                        }
                        DataRow row = RSO_member_of.NewRow();
                        row[0] = value3.eType;
                        row[1] = value3.eCategory;
                        row[2] = value3.eDescription;
                        row[3] = value3.start;
                        row[4] = value3.end;
                        string dt = value3.date.ToString();
                        string[] split_date = dt.Split(' ');
                        row[5] = split_date[0];
                        row[6] = value3.contact;
                        row[7] = value3.email;
                        row[8] = x;
                        row[9] = y;
                        RSO_member_of.Rows.Add(row);
                    }
                }
            }
            GridView_RSO_user_follows.DataSource = RSO_member_of;
            GridView_RSO_user_follows.DataBind();
        }
    }
}