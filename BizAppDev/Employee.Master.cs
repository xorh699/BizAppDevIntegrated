using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace BizAppDev
{
    public partial class Employee1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Project"].ToString());
            string employeename;
            employeename = "Louis";


            string queryStr = "SELECT * FROM Employee WHERE EmpName = @empName";


            SqlCommand cmd = new SqlCommand(queryStr, con);
            cmd.Parameters.AddWithValue("@empName", employeename);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {

                lbl_position.Text = "Employee";

            }
            label_Name.Text = employeename;



            con.Close();
            dr.Close();
            dr.Dispose();

            string profile = "/EditProfile(employee).aspx?AdmName=" + employeename;
            hrefString.Text = profile;
        }

    }
}
