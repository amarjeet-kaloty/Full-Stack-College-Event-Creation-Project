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
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO RSO(college_id, organisation_name, group_member, email, group_administrator, creator) values(" +
                    "@college_id, @organisation_name, @group_member, @email, @group_administrator, @creator)", con);

                cmd.Parameters.AddWithValue("@college_id", college_id.Text.Trim());
                cmd.Parameters.AddWithValue("@organisation_name", org_name.Text.Trim());
                cmd.Parameters.AddWithValue("@group_member", name.Text.Trim());
                cmd.Parameters.AddWithValue("@email", email.Text.Trim());
                cmd.Parameters.AddWithValue("@group_administrator", false);
                cmd.Parameters.AddWithValue("@creator", true);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('RSO created successfully.');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}