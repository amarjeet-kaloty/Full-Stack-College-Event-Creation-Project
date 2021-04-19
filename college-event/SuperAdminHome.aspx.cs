using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace college_event
{
    public partial class SuperAdminHome : System.Web.UI.Page
    {
        CollegeEventDataContext db = new CollegeEventDataContext();
        string strcon = ConfigurationManager.ConnectionStrings["college_eventConnectionString1"].ConnectionString;
        string[] parts;
        string username;
        string domain;

        protected void Page_Load(object sender, EventArgs e)
        {
            int status = Convert.ToInt32(Session["status"]);
            string email = Convert.ToString(Session["uid"]);

            parts = email.Split(new[] { '@' });
            username = parts[0];
            domain = parts[1];
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

            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("SELECT * FROM [Events] WHERE status = 1 AND email = @email;", con);
            cmd.Parameters.AddWithValue("@email", Session["uid"].ToString().Split('@')[1]);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    DataRow row = table_view_events.NewRow();
                    string x = "";
                    string y = "";
                    var qry_event_no = (from eNum in db.set_event_locations
                                        where eNum.event_no == Int32.Parse(dr.GetValue(9).ToString())
                                        select eNum).ToList();

                    foreach (var v in qry_event_no)
                    {
                        x = v.location;
                        y = v.address;
                    }
                    row[0] = dr.GetValue(1).ToString();
                    row[1] = dr.GetValue(2).ToString();
                    Session["edesc"] = dr.GetValue(3).ToString();
                    row[2] = dr.GetValue(3).ToString();
                    row[3] = TimeSpan.Parse(dr.GetValue(4).ToString());
                    row[4] = TimeSpan.Parse(dr.GetValue(5).ToString());
                    row[5] = dr.GetValue(6).ToString();
                    row[6] = dr.GetValue(7).ToString();
                    row[7] = dr.GetValue(8).ToString();
                    row[8] = x;
                    row[9] = y;

                    table_view_events.Rows.Add(row);
                }
            }

            GridView_ApproveEvent.DataSource = table_view_events;
            GridView_ApproveEvent.DataBind();
            dr.Close();
            con.Close();
        }

        // Update Status of the event from pending to approved.
        protected void btn_click_approve(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("UPDATE [Events] SET [status] = 0 WHERE eDescription = @edesc;", con);
            String sdfa = Session["edesc"].ToString();
            cmd.Parameters.AddWithValue("@edesc", Session["edesc"].ToString());
            cmd.ExecuteNonQuery();
            con.Close();



            //GridViewRow clickedRow = (((Button)sender).NamingContainer) as GridViewRow;
            //int x = clickedRow.RowIndex;
            ////String edesc =  GridView_ApproveEvent.Rows[x].Cells[2].ToString();
            //string u = x.ToString();
            //int event_no = Convert.ToInt32(ViewState[u]);
            //Event evt = db.Events.Single(a => a.event_no == event_no);
            //evt.status = false;
            //db.SubmitChanges();
            LoadGridView();
        }

        protected void GridView_ApproveEvent_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}