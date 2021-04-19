using college_event.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
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
        string strcon = ConfigurationManager.ConnectionStrings["college_eventConnectionString1"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            int status = Convert.ToInt32(Session["status"]);
            string email = Convert.ToString(Session["uid"]);

            parts = email.Split(new[] { '@' });
            username = parts[0];
            domain = parts[1];                                                //  "knights.ucf.edu";  // parts[1];
            if (!IsPostBack)
            {
                public_button_onClick();
            }
            else
            {
                
            }
        }

        protected void public_button_onClick()
        {

            // View Events in the University
            DataTable table_view_events = new DataTable();
            DataTable eventsUCF = new DataTable();
            int i = 0;

            // Create tables
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

            eventsUCF.Columns.Add(new DataColumn("Event", typeof(string)));
            eventsUCF.Columns.Add(new DataColumn("Category", typeof(string)));
            eventsUCF.Columns.Add(new DataColumn("Description", typeof(string)));
            eventsUCF.Columns.Add(new DataColumn("Start", typeof(TimeSpan)));
            eventsUCF.Columns.Add(new DataColumn("End", typeof(TimeSpan)));
            eventsUCF.Columns.Add(new DataColumn("Date", typeof(string)));
            eventsUCF.Columns.Add(new DataColumn("Location", typeof(string)));
            eventsUCF.Columns.Add(new DataColumn("URL", typeof(string)));

            // SOMETHING ABOUT PUBLIC EVENT FILTER
            var qry_Events = (from temp in db.Events
                              select temp).Where(x => x.email.Contains(domain) && (x.eCategory == "Public" && x.status == false)).ToList();

            // Create event stream objects for 2 webpages
            EventStream todayES = new EventStream("https://events.ucf.edu/feed.xml");
            EventStream upcomingES = new EventStream("https://events.ucf.edu/upcoming/feed.xml");
            String[] email = Session["uid"].ToString().Split('@');

            // Check if student belongs to UCF
            if (email[1].Equals("knights.ucf.edu"))
            {
                // Invoke getEvents()
                List<EventXML> todayList = todayES.getEvents();
                List<EventXML> upcomingList = upcomingES.getEvents();

                foreach (EventXML temp in todayList)
                {
                    // Parse every event and add row into the table
                    DataRow row = eventsUCF.NewRow();

                    row[0] = temp.title;
                    row[1] = "Public";
                    row[2] = temp.description;
                    row[3] = temp.startTime;
                    row[4] = temp.endTime;
                    row[5] = temp.startDate;
                    row[6] = temp.location;
                    row[7] = temp.url;

                    eventsUCF.Rows.Add(row);
                }

                foreach (EventXML temp in upcomingList)
                {
                    // Parse every event and add row into the table
                    DataRow row = eventsUCF.NewRow();

                    row[0] = temp.title;
                    row[1] = "Public";
                    row[2] = temp.description;
                    row[3] = temp.startTime;
                    row[4] = temp.endTime;
                    row[5] = temp.startDate;
                    row[6] = temp.location;
                    row[7] = temp.url;

                    eventsUCF.Rows.Add(row);
                }

                GridView_UniversityEvents0.DataSource = eventsUCF;
                GridView_UniversityEvents0.DataBind();
            }

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
                ViewState[i.ToString()] = value.event_no;
                i++;
                table_view_events.Rows.Add(row);
            }
            GridView_UniversityEvents.DataSource = table_view_events;
            GridView_UniversityEvents.DataBind();
            Load_RSO();
        }

        protected void private_button_onClick()
        {

            // View Events in the University
            DataTable table_view_events_private = new DataTable();
            DataTable eventsUCF = new DataTable();

            table_view_events_private.Columns.Add(new DataColumn("Event", typeof(string)));
            table_view_events_private.Columns.Add(new DataColumn("Category", typeof(string)));
            table_view_events_private.Columns.Add(new DataColumn("Description", typeof(string)));
            table_view_events_private.Columns.Add(new DataColumn("Start", typeof(TimeSpan)));
            table_view_events_private.Columns.Add(new DataColumn("End", typeof(TimeSpan)));
            table_view_events_private.Columns.Add(new DataColumn("Date", typeof(string)));
            table_view_events_private.Columns.Add(new DataColumn("Contact", typeof(string)));
            table_view_events_private.Columns.Add(new DataColumn("Email", typeof(string)));
            table_view_events_private.Columns.Add(new DataColumn("Location", typeof(string)));
            table_view_events_private.Columns.Add(new DataColumn("Address", typeof(string)));

            eventsUCF.Columns.Add(new DataColumn("Event", typeof(string)));
            eventsUCF.Columns.Add(new DataColumn("Category", typeof(string)));
            eventsUCF.Columns.Add(new DataColumn("Description", typeof(string)));
            eventsUCF.Columns.Add(new DataColumn("Start", typeof(TimeSpan)));
            eventsUCF.Columns.Add(new DataColumn("End", typeof(TimeSpan)));
            eventsUCF.Columns.Add(new DataColumn("Date", typeof(string)));
            eventsUCF.Columns.Add(new DataColumn("Location", typeof(string)));
            eventsUCF.Columns.Add(new DataColumn("URL", typeof(string)));

            var qry_Events = (from temp in db.Events
                              select temp).Where(x => x.email.Contains(domain) && (x.eCategory == "Private" && x.status == false)).ToList();

            // Create event stream objects for 2 webpages
            EventStream todayES = new EventStream("https://events.ucf.edu/feed.xml");
            EventStream upcomingES = new EventStream("https://events.ucf.edu/upcoming/feed.xml");
            String[] email = Session["uid"].ToString().Split('@');

            // Check if student belongs to UCF
            if (email[1].Equals("knights.ucf.edu"))
            {
                // Invoke getEvents()
                List<EventXML> todayList = todayES.getEvents();
                List<EventXML> upcomingList = upcomingES.getEvents();

                foreach (EventXML temp in todayList)
                {
                    // Parse every event and add row into the table
                    DataRow row = eventsUCF.NewRow();

                    row[0] = temp.title;
                    row[1] = "Public";
                    row[2] = temp.description;
                    row[3] = temp.startTime;
                    row[4] = temp.endTime;
                    row[5] = temp.startDate;
                    row[6] = temp.location;
                    row[7] = temp.url;

                    eventsUCF.Rows.Add(row);
                }

                foreach (EventXML temp in upcomingList)
                {
                    // Parse every event and add row into the table
                    DataRow row = eventsUCF.NewRow();

                    row[0] = temp.title;
                    row[1] = "Public";
                    row[2] = temp.description;
                    row[3] = temp.startTime;
                    row[4] = temp.endTime;
                    row[5] = temp.startDate;
                    row[6] = temp.location;
                    row[7] = temp.url;

                    eventsUCF.Rows.Add(row);
                }

                GridView_UniversityEvents0.DataSource = eventsUCF;
                GridView_UniversityEvents0.DataBind();
            }

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

                DataRow row = table_view_events_private.NewRow();
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
                table_view_events_private.Rows.Add(row);
            }
            GridView_UniversityEvents.DataSource = table_view_events_private;
            GridView_UniversityEvents.DataBind();
            Load_RSO();
        }

        protected void Load_RSO()
        {

            // RSO GridView
            DataTable table_joinRSO = new DataTable();
            SqlConnection con;
            SqlCommand cmd;

            // Create table
            table_joinRSO.Columns.Add(new DataColumn("RSO", typeof(string)));
            table_joinRSO.Columns.Add(new DataColumn("Number of Members", typeof(int)));

            try
            {
                con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                // Get all RSOs for university
                cmd = new SqlCommand("SELECT * FROM RSO LEFT JOIN university_profile up ON RSO.Uni_ID = up.Uni_ID;", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                SqlDataReader dr = cmd.ExecuteReader();

                // Add all RSOs to the table
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        DataRow row = table_joinRSO.NewRow();
                        row[0] = dr.GetValue(1).ToString();
                        row[1] = dr.GetValue(3).ToString();
                        table_joinRSO.Rows.Add(row);

                    }
                }
                else
                {
                    Response.Write("<script>alert('Couldnt load RSOs');</script>");
                }

                dr.Close();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

            GridView_RSO.DataSource = table_joinRSO;
            GridView_RSO.DataBind();
        }

        //
        protected void create_RSO_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateNewRSO.aspx");
        }

        protected bool CheckInRSO(int rso_id)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                
                // Check if user is already in RSO
                SqlCommand cmd = new SqlCommand("SELECT * FROM RSOMemberList WHERE RSO_ID = @rso_id AND uid = @email;", con);

                cmd.Parameters.AddWithValue("@rso_id", rso_id);
                cmd.Parameters.AddWithValue("@email", Session["uid"].ToString());

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }

            return false;
        }
        
        // Adding new member to RSO
        protected void Join_Click(object sender, EventArgs e)
        {
            // Get organization name
            GridViewRow clickedRow = ((Button)sender).NamingContainer as GridViewRow;
            String org_name = clickedRow.Cells[2].Text;

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                SqlCommand cmd;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                // Get the RSO_ID
                cmd = new SqlCommand("SELECT RSO_ID FROM RSO WHERE organisation_name = @org_name;", con);
                cmd.Parameters.AddWithValue("@org_name", org_name);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                SqlDataReader dr = cmd.ExecuteReader();
                int rso_id = -1;

                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        rso_id = Int32.Parse(dr.GetValue(0).ToString());
                    }
                }
                dr.Close();

                if (CheckInRSO(rso_id))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('User already in RSO!')", true);
                    return;
                }

                // Insert into table
                cmd = new SqlCommand("INSERT INTO RSOMemberList(RSO_ID, name, uid, admin) values(@rso_id, '" + Session["name"].ToString() + "', '" +
                    Session["uid"].ToString() + "', 0"+ ");", con);
                cmd.Parameters.AddWithValue("@rso_id", rso_id);
                cmd.ExecuteNonQuery();
                con.Close();
                Load_RSO();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        // Adding new member to RSO
        protected void Exit_Click(object sender, EventArgs e)
        {
            // Get organization name
            GridViewRow clickedRow = ((Button)sender).NamingContainer as GridViewRow;
            String org_name = clickedRow.Cells[2].Text;

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                SqlCommand cmd;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                // Get the RSO_ID
                cmd = new SqlCommand("SELECT RSO_ID FROM RSO WHERE organisation_name = @org_name;", con);
                cmd.Parameters.AddWithValue("@org_name", org_name);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                SqlDataReader dr = cmd.ExecuteReader();
                int rso_id = -1;

                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        rso_id = Int32.Parse(dr.GetValue(0).ToString());
                    }
                }
                dr.Close();

                if (!CheckInRSO(rso_id))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('User is not in RSO!')", true);
                    return;
                }

                // Delete from table
                cmd = new SqlCommand("DELETE FROM RSOMemberList WHERE uid = @email AND RSO_ID = @rso_id;", con);
                cmd.Parameters.AddWithValue("@email", Session["uid"].ToString());
                cmd.Parameters.AddWithValue("@rso_id", rso_id);
                cmd.ExecuteNonQuery();
                con.Close();
                Load_RSO();

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        // View Events from RSO
        protected void view_events_by_rso_Click(object sender, EventArgs e)
        {
            GridView_UniversityEvents.Visible = false;
            GridView_RSO.Visible = false;
            //label_join_rso.Visible = false;

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

        // Create Event
        protected void creat_event_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateEventPage.aspx");
        }

        // Comments from event
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            GridViewRow clickedRow = ((Button)sender).NamingContainer as GridViewRow;
            var x = clickedRow.RowIndex;
            string u = x.ToString();
            int event_no = Convert.ToInt32(ViewState[u]);
            var comments = new Comment();
            comments.event_id = event_no;
            comments.timestamp = DateTime.Now;
            // comments.text = user_comments.Text;
            comments.uid = Session["uid"].ToString();
            try
            {
                db.Comments.InsertOnSubmit(comments);
                db.SubmitChanges();
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Unable to add comments. Please try again');</script>");
            }
        }

        protected void GridView_UniversityEvents0_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateUniversityProfile.aspx");
        }

        protected void Create_Event_Button_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateEventPage.aspx");
        }

        protected void public_button_Click(object sender, EventArgs e)
        {
            public_button_onClick();
        }

        protected void private_button_Click(object sender, EventArgs e)
        {
            private_button_onClick();
            GridView_UniversityEvents0.DataSource = null;
            GridView_UniversityEvents0.DataBind();
        }

        // Star rating implementation
        //[WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //protected void insert_rating(int score) 
        //{
        //    var add_score = new test_score();
        //    add_score.score = score;
        //    try
        //    {
        //        db.test_scores.InsertOnSubmit(add_score);
        //        db.SubmitChanges();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //    }
        //}

    }
}