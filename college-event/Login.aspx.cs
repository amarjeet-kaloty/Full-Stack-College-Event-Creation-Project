using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace college_event
{
    public partial class Login : System.Web.UI.Page
    {
        CollegeEventDataContext db = new CollegeEventDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Login
        protected void login_btn_Click(object sender, EventArgs e)
        {
            var qryUserLogin = (from user in db.member_master_tbls
                                where user.uid == uid.Text.Trim()
                                select user).ToList();

            foreach (member_master_tbl user in qryUserLogin)
            {
                string id = user.uid;
                string pwd = DecryptString(user.password);

                if (id == uid.Text.Trim() && pwd == password.Text.Trim())
                {
                    Response.Write("<script>alert('Login Successful.');</script>");
                    Session["uid"] = user.uid;
                    Session["name"] = user.name;
                    Session["status"] = user.status;
                    if(user.status == 1)
                    {
                        Response.Redirect("SuperAdminHome.aspx");
                    }
                    else if(user.status == 3)
                    {
                        Response.Redirect("Users/UserHome.aspx");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Login Credentials incorrect. Please try again.');</script>");
                }
            }
        }

        protected string DecryptString(string encrString)
        {
            byte[] b;
            string decrypted;
            try
            {
                b = Convert.FromBase64String(encrString);
                decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
            }
            catch (FormatException fe)
            {
                Response.Write("<script>alert('Unable to Decrypt the password.');</script>");
                decrypted = "";
            }
            return decrypted;
        }
    }
}