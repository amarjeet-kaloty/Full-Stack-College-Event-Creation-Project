using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace college_event
{
    public partial class CreateUniversityProfile : System.Web.UI.Page
    {
        CollegeEventDataContext db = new CollegeEventDataContext();

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
            var qryUniversityExists = (from univ in db.university_profiles
                                       where univ.name == university_name.Text.Trim()
                                       select univ).ToList();

            if(qryUniversityExists.Count > 0)
            {
                return true;
            }

            return false;
        }

        protected void CreateNewUniversityProfile()
        {
            university_profile newUniversity = new university_profile();

            if(university_name.Text == string.Empty || location.Text == string.Empty || description.Text == string.Empty
                || number_of_Students.Text == null)
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

                newUniversity.name = university_name.Text.Trim();
                newUniversity.location = location.Text.Trim();
                newUniversity.description = description.Text.Trim();
                newUniversity.number_of_students = Convert.ToInt32(number_of_Students.Text);
                newUniversity.university_img = filepath;
            }
            try 
            {
                db.university_profiles.InsertOnSubmit(newUniversity);
                db.SubmitChanges();
                Response.Write("<script>alert('University Profile created successfully.');</script>");
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Error creating university profile. Please try again.');</script>");
            }
        }
    }
}