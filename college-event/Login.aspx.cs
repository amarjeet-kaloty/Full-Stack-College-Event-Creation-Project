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
    public partial class Login : System.Web.UI.Page
    {
        // Connecting to the Database 
        string strcon = ConfigurationManager.ConnectionStrings["college_eventConnectionString1"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // User Login
        protected void login_btn_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string pwd = DecryptString(password.Text.Trim());

                // Get the user from table
                SqlCommand cmd = new SqlCommand("Select * From member_master_tbl Where uid='" + uid.Text.Trim() + "' AND password='" + pwd + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        // Create cookie stuff for user
                        Response.Write("<script>alert('Login Successful!');</script>");
                        Session["uid"] = dr.GetValue(0).ToString();
                        Session["name"] = dr.GetValue(1).ToString();
                        Session["status"] = dr.GetValue(3).ToString();
                    }
                    if (Int32.Parse(Session["status"].ToString()) == 1)
                        Response.Redirect("SuperAdminHome.aspx");
                    else if (Int32.Parse(Session["status"].ToString()) == 3)
                        Response.Redirect("UserHome.aspx", false);
                    else
                        Response.Redirect("UserHome.aspx", false);
                }
                else
                {
                    Response.Write("<script>alert('Invalid credentials');</script>");
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        public string DecryptString(string strEncrypted)
        {
            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(strEncrypted);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;
        }

    }
}