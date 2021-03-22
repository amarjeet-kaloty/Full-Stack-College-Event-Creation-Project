using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace college_event.Users
{
    public partial class SuperAdminHomePage : System.Web.UI.Page
    {
        CollegeEventDataContext db = new CollegeEventDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGridView();
            }
        }

        protected void LoadGridView()
        {
            DataTable table_RSO = new DataTable();

            table_RSO.Columns.Add(new DataColumn("RSO Name", typeof(string)));
            table_RSO.Columns.Add(new DataColumn("Member", typeof(string)));
            table_RSO.Columns.Add(new DataColumn("College ID", typeof(int)));
            table_RSO.Columns.Add(new DataColumn("Email", typeof(string)));
            table_RSO.Columns.Add(new DataColumn("Number of Members", typeof(int)));

            var qry_RSO = (from temp in db.RSOs
                           select temp).GroupBy(x => x.organisation_name).Select(y => y.FirstOrDefault()).ToList();

            foreach (var value in qry_RSO)
            {
                var qry_count = (from temp1 in db.RSOs
                                where value.organisation_name == temp1.organisation_name
                                select temp1).Count();

                DataRow row = table_RSO.NewRow();
                row[0] = value.organisation_name;
                row[1] = value.group_member;
                row[2] = value.college_id;
                row[3] = value.email;
                row[4] = qry_count;
                table_RSO.Rows.Add(row);
            }
            GridView_RSO.DataSource = table_RSO;
            GridView_RSO.DataBind();

        }

        //protected void GridView_RSO_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    GridViewRow row = GridView_RSO.SelectedRow;
        //    // var x = row.Cells[4].Text;
        //    var y = row.Cells[2].Text;

        //    var qry_count_members = (from mem in db.RSOs
        //                             where mem.organisation_name == y
        //                             select mem).Count();

        //    if (qry_count_members == 5)
        //    {
        //        Console.WriteLine("Members are full");
        //    }
        //}

    }
}