using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace college_event
{
    public partial class CreateEventPage : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["college_eventConnectionString1"].ConnectionString;
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

            Dictionary<String, int> dict = new Dictionary<string, int>();
            ArrayList al = new ArrayList();


            if (DropDownList1.Items.Count == 0)
            {
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM RSO", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        // Add RSOs to dictionary
                        dict.Add(dr.GetValue(1).ToString(), Int32.Parse(dr.GetValue(0).ToString()));
                        al.Add(dr.GetValue(1).ToString());
                    }
                }

                DropDownList1.Items.Insert(0, new ListItem("None", "-1"));
                for (int i = 0; i < al.Count; i++)
                {
                    DropDownList1.Items.Insert(i + 1, new ListItem(al[i].ToString(), dict[al[i].ToString()].ToString()));
                }

                con.Close();
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

            try
            {
                int RSO_ID = -1;
                SqlConnection con = new SqlConnection(strcon);
                SqlCommand cmd;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                // Check if user is in RSO or not. If so, get RSO_ID
                if (!DropDownList1.SelectedValue.ToString().Equals("-1"))
                {
                    cmd = new SqlCommand("SELECT * FROM RSOMemberList WHERE uid = @email AND admin = 1 AND RSO_ID = @rso_id;", con);
                    cmd.Parameters.AddWithValue("@email", Session["uid"].ToString());
                    cmd.Parameters.AddWithValue("@rso_id", DropDownList1.SelectedValue);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    SqlDataReader dr = cmd.ExecuteReader();

                    // If user is not admin for selected RSO, Don't let them create an event
                    if (!dr.HasRows)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('User is not an admin for selected RSO!')", true);
                        dr.Close();
                        con.Close();
                        return;
                    }

                    dr.Close();
                }





                // Let admins and Events being created without RSO insert into Events table
                cmd = new SqlCommand("INSERT INTO Events([eType], [eCategory], [eDescription], [start], [end], [date], [contact], [email], [event_no], [status], [RSO_ID])" + 
                    " values(@type, @cat, @desc, @start, @end, @date, @contact, @email, @event_no, @status, @rso_id);", con);

                // Parse user inputs
                cmd.Parameters.AddWithValue("@type", event_type.Text.Trim());
                cmd.Parameters.AddWithValue("@cat", category.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@desc", description.Text.Trim());

                string s_time = start_time.Text.ToString();
                TimeSpan st = DateTime.Parse(s_time).TimeOfDay;
                cmd.Parameters.AddWithValue("@start", st);

                string e_time = end_time.Text.ToString();
                TimeSpan et = DateTime.Parse(e_time).TimeOfDay;
                cmd.Parameters.AddWithValue("@end", et);

                string dt = date.Text.ToString();
                DateTime y = Convert.ToDateTime(dt);
                cmd.Parameters.AddWithValue("@date", DateTime.Parse(y.Date.ToShortDateString()));

                cmd.Parameters.AddWithValue("@contact", contact_number.Text.ToString());
                cmd.Parameters.AddWithValue("@email", contact_email.Text.ToString());
                cmd.Parameters.AddWithValue("@event_no", Convert.ToInt32(event_id));

                // Check if user selected a specific RSO
                if (!DropDownList1.SelectedValue.Equals("-1"))
                {
                    cmd.Parameters.AddWithValue("@status", 0);
                    cmd.Parameters.AddWithValue("@rso_id", DropDownList1.SelectedValue.ToString());
                }
                else
                {
                    cmd.Parameters.AddWithValue("@status", 1);
                    cmd.Parameters.AddWithValue("@rso_id", -1);
                }

                cmd.ExecuteNonQuery();


                con.Close();

                Response.Redirect("UserHome.aspx", false);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        protected void InitializeCategory()
        {
            
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void contact_email_TextChanged(object sender, EventArgs e)
        {

        }
    }
}