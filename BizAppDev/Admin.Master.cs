using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace BizAppDev
{
    public partial class staff : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Project"].ToString());
            string employeename;
            employeename = "Daniel";


            string queryStr = "SELECT * FROM Admin WHERE AdmName = @empName";


            SqlCommand cmd = new SqlCommand(queryStr, con);
            cmd.Parameters.AddWithValue("@empName", employeename);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {

                lbl_position.Text = "Admin";

            }
            label_Name.Text = employeename;



            con.Close();
            dr.Close();
            dr.Dispose();

            string profile = "/EditProfile.aspx?AdmName=" + employeename;
            hrefString.Text = profile;
        }

    }
}
