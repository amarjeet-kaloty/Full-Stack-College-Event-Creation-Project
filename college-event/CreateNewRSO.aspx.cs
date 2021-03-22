using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace college_event
{
    public partial class CreateNewRSO : System.Web.UI.Page
    {
        CollegeEventDataContext db = new CollegeEventDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Request to Create a New RSO
        protected void create_RSO_Click(object sender, EventArgs e)
        {
            var createRSO = new RSO();
            createRSO.college_id = Convert.ToInt32(college_id.Text.ToString());
            createRSO.organisation_name = org_name.Text.ToString();
            createRSO.group_member = name.Text.ToString();
            createRSO.email = email.Text.ToString();
            createRSO.group_administrator = false;
            try
            {
                db.RSOs.InsertOnSubmit(createRSO);
                db.SubmitChanges();
                Response.Write("<script>alert('New RSO group created successfully');</script>");
            }
            catch (Exception)
            {
                Response.Write("<script>alert('An Error Occured. Please try again.');</script>");
            }
        }
    }
}