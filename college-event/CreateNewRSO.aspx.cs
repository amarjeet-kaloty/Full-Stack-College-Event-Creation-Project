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
    public partial class CreateNewRSO : System.Web.UI.Page
    {
        // Connecting to the Database 
        string strcon = ConfigurationManager.ConnectionStrings["college_eventConnectionString1"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Request to Create a New RSO
        protected void create_RSO_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                SqlCommand cmd;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                // Get university's ID
                cmd = new SqlCommand("SELECT (Uni_ID) FROM university_profile WHERE university_profile.emailExtension = @email", con);

                // Get the email extension for query
                String [] extension = Session["uid"].ToString().Split('@');
                cmd.Parameters.AddWithValue("@email",extension[1]);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                SqlDataReader dr = cmd.ExecuteReader();

                int Uni_ID = 0;

                // Parse ID into local variable
                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        Uni_ID = Int32.Parse(dr.GetValue(0).ToString());
                    }
                }

                dr.Close();

                cmd = new SqlCommand("INSERT INTO RSO(organisation_name, Uni_ID) values(@organisation_name, @Uni_ID)", con);

                String useremail = email.Text.Trim();
                cmd.Parameters.AddWithValue("@organisation_name", org_name.Text.Trim());
                cmd.Parameters.AddWithValue("@Uni_ID", Uni_ID);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('RSO created successfully.');</script>");


                // Get the RSO_ID
                cmd = new SqlCommand("SELECT RSO_ID FROM RSO WHERE organisation_name = @org_name;", con);
                cmd.Parameters.AddWithValue("@org_name", org_name.Text.Trim());
                da = new SqlDataAdapter(cmd);
                dr = cmd.ExecuteReader();
                int rso_id = -1;

                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        rso_id = Int32.Parse(dr.GetValue(0).ToString());
                    }
                }
                dr.Close();

                // Insert user as Admin into table
                cmd = new SqlCommand("INSERT INTO RSOMemberList(RSO_ID, name, uid, admin) values(@rso_id, '" + Session["name"].ToString() + "', '" +
                    Session["uid"].ToString() + "', 1" + ");", con);
                cmd.Parameters.AddWithValue("@rso_id", rso_id);
                cmd.ExecuteNonQuery();

                // Update status in master user table
                cmd = new SqlCommand("UPDATE member_master_tbl SET status = 2 WHERE uid = @email", con);
                cmd.Parameters.AddWithValue("@email", Session["uid"].ToString());
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("UserHome.aspx", false);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}