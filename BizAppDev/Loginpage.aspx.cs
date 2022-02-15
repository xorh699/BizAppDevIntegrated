using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BizAppDev
{
    public partial class Loginpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Btn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Project"].ToString());
            Employee emp = new Employee();
            string queryStr = "SELECT * FROM Employee WHERE EmpID = @EmpID AND Password = @Password";        
            SqlCommand cmd = new SqlCommand(queryStr, con);
            cmd.Parameters.AddWithValue("@EmpID", tb_Username.Text);
            cmd.Parameters.AddWithValue("@Password", tb_Password.Text);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
               Response.Write("<script>alert('Log in successful');</script>");
               Response.Redirect("Ependingorder.aspx");
            }
            else
            {
                Response.Write("<script>alert('Invalid Username or password! Please try again.');</script>");
            }
            con.Close();

            string qrstr = "SELECT * FROM Admin WHERE AdmID = @AdmID AND Password = @Password";
            Admin adm = new Admin();
            SqlCommand cmde = new SqlCommand(qrstr, con);
            cmde.Parameters.AddWithValue("@AdmID", tb_Username.Text);
            cmde.Parameters.AddWithValue("@Password", tb_Password.Text);
            con.Open();
            SqlDataReader da = cmde.ExecuteReader();

            if (da.Read())
            {
                Response.Write("<script>alert('Log in successful');</script>");
                Response.Redirect("Adminlist.aspx");
            }
            else
            {
                Response.Write("<script>alert('Invalid Username or password! Please try again.');</script>");
            }
            con.Close();

            Customer cust = new Customer();
            string queryString = "SELECT * FROM Customer WHERE Cust_ID = @CustID AND Password = @Password";
            SqlCommand cmdp = new SqlCommand(queryString, con);
            cmdp.Parameters.AddWithValue("@CustID", tb_Username.Text);
            cmdp.Parameters.AddWithValue("@Password", tb_Password.Text);
            con.Open();
            SqlDataReader dp = cmdp.ExecuteReader();

            if (dp.Read())
            {
                Session["CustID"] = tb_Username.Text;
                Response.Write("<script>alert('Log in successful');</script>");
                Response.Redirect("home.aspx");
            }
            else
            {
                Response.Write("<script>alert('Invalid Username or password! Please try again.');</script>");
            }
            con.Close();

        }

    }
    }

