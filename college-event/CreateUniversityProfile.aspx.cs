using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace college_event
{
    public partial class CreateUniversityProfile : System.Web.UI.Page
    {
        CollegeEventDataContext db = new CollegeEventDataContext();
        string strcon = ConfigurationManager.ConnectionStrings["college_eventConnectionString1"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void create_university_profile_Click(object sender, EventArgs e)
        {
            if (checkIfUniversityExists())
            {
                Response.Write("<script>alert('University Profile already exists.');</script>");
            }
            else
            {
                CreateNewUniversityProfile();
            }
        }

        protected bool checkIfUniversityExists()
        {
            try
            {
                // Check if University already exists
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT name FROM university_profile WHERE emailExtension = @email;", con);
                cmd.Parameters.AddWithValue("@email", emailExtension.Text);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Close();
                    con.Close();
                    return true;
                }
                else
                {
                    dr.Close();
                    con.Close();
                    return false;
                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

            return true;
        }

        protected void CreateNewUniversityProfile()
        {
            university_profile newUniversity = new university_profile();

            if(university_name.Text == string.Empty || emailExtension.Text == string.Empty || number_of_Students.Text == null)
            {
                Response.Write("<script>alert('All the fields are required to create university profile.');</script>");
            }

            if (FileUpload1.HasFile)
            {
                // Adding the img link to out db.
                string filepath = "~/University_Images/university.png";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("University_Images/" + filename));
                filepath = "~/University_Images/" + filename;
                newUniversity.university_img = filepath;
            }

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                // Insert University
                SqlCommand cmd = new SqlCommand("INSERT INTO university_profile(name, number_of_students, emailExtension, university_img) " +
                    "values(@name, @numStudents, @email, @img);", con);

                // Fill parameters with user entered data
                cmd.Parameters.AddWithValue("@name", university_name.Text.Trim());
                cmd.Parameters.AddWithValue("@numStudents", Convert.ToInt32(number_of_Students.Text));
                cmd.Parameters.AddWithValue("@email", emailExtension.Text.Trim());
                cmd.Parameters.AddWithValue("@img", newUniversity.university_img);
                cmd.ExecuteNonQuery();

                // Update user to admin
                cmd = new SqlCommand("UPDATE member_master_tbl SET status = 1 WHERE uid = @uid", con);
                cmd.Parameters.AddWithValue("@uid", Session["uid"].ToString());
                cmd.ExecuteNonQuery();
                Response.Redirect("SuperAdminHome.aspx");
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
    }
}