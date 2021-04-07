using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace college_event
{
    public partial class Register : System.Web.UI.Page
    {
        // Connecting to the Database using Linq
        CollegeEventDataContext db = new CollegeEventDataContext();
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void signup_Click(object sender, EventArgs e)
        {
            if (checkUserExist())
            {
                Response.Write("<script>alert('User-id already exists.');</script>");
            }
            else
            {
                RegisterNewUser();
            }
        }

        bool checkUserExist()
        {
            var qryUserExists = (from user in db.member_master_tbls
                                 where user.uid.Trim() == uid.Text.ToString().Trim()
                                 select user).ToList();
     
            if (qryUserExists.Count > 0)
            {
                return true;
            }
            return false;
        }

        protected void RegisterNewUser()
        {
            var newUser = new member_master_tbl();

            if(uid.Text == string.Empty || name.Text == string.Empty || password.Text == string.Empty)
            {
                Response.Write("<script>alert('All the fields are required to register.');</script>");
            }

            newUser.uid = uid.Text.Trim();
            newUser.name = name.Text.Trim();
            newUser.password = EnryptString(password.Text.Trim());
            newUser.status = 3;
            try
            {
                db.member_master_tbls.InsertOnSubmit(newUser);
                db.SubmitChanges();
                Response.Write("<script>alert('User successfully registered.');</script>");
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('Error occured while creating the user');</script>");
            }
            Response.Redirect("Login.aspx");
        }

        public string EnryptString(string strEncrypted)
        {
            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(strEncrypted);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;
        }
    }
}