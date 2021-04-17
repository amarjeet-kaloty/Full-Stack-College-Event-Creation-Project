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
    public partial class Register : System.Web.UI.Page
    {
        // Connecting to the Database 
        string strcon = ConfigurationManager.ConnectionStrings["college_eventConnectionString1"].ConnectionString;
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Check if User exists
        bool checkUserExist()
        {

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl " +
                    "Where uid='" + uid.Text.Trim() + "';", con);
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
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }


        public string EnryptString(string strEncrypted)
        {
            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(strEncrypted);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;
        }

        //Sign-up button on_click
        protected void signup_Click(object sender, EventArgs e)
        {
            if (checkUserExist())
            {
                Response.Write("<script>alert('User already exists.');</script>");
            }
            else
            {
                userSignUpNewUser();
                Response.Redirect("Login.aspx");
            }
        }

        void userSignUpNewUser()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO member_master_tbl(uid, name, password, status) values(" +
                    "@uid, @name, @password, @status)", con);

                int status = 3;
                string pwd = EnryptString(password.Text.Trim());

                cmd.Parameters.AddWithValue("@uid", uid.Text.Trim());
                cmd.Parameters.AddWithValue("@name", name.Text.Trim());
                cmd.Parameters.AddWithValue("@password", pwd);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Sign-up Successful. Go to Login Page.');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

    }
}