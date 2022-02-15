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
	public partial class CustomerDetails : System.Web.UI.Page
	{
		string _connStr = ConfigurationManager.ConnectionStrings["Project"].ConnectionString;

		Customer aCust = new Customer();
		Customer Cust = new Customer();
		protected void Page_Load(object sender, EventArgs e)
		{
			HttpContext context = HttpContext.Current;
			string CID = (string)(context.Session["CustID"]);

			Cust = aCust.getCustomer(CID);
			lbl_Address.Text = Cust.address.ToString();
			DateTime yes = Convert.ToDateTime(Cust.DOB);
			lbl_DOB.Text = yes.ToString("dd MMMM, yyyy");
			lbl_Email.Text = Cust.email.ToString();
			lbl_Gender.Text = Cust.gender.ToString();
			lbl_FirstName.Text = Cust.first_Name.ToString();
			lbl_LastName.Text = Cust.last_Name.ToString();
			lbl_PhoneNo.Text = Cust.phoneNo.ToString();
			lbl_Username.Text = Cust.username.ToString();
		}

        protected void btn_Edit_Click(object sender, EventArgs e)
        {
			Response.Redirect("CustomerEditDetails.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
			string CustID = (string)(Session["CustID"]);
			Customer cust = new Customer();
			Customer acust = new Customer();
			acust = cust.getCustomer(CustID);
			Response.Redirect("CustomerPoints.aspx?pointTierID=" + acust.pointTierID);
		}

        protected void btn_Delete_Click(object sender, EventArgs e)
        {
			string queryStr = "DELETE FROM Customer WHERE Cust_ID=@CID";
			SqlConnection conn = new SqlConnection(_connStr);
			SqlCommand cmd = new SqlCommand(queryStr, conn);
			string delqueryStr = "DELETE FROM orderdetails WHERE Cust_ID=@CID";
			SqlConnection delconn = new SqlConnection(_connStr);
			SqlCommand delcmd = new SqlCommand(delqueryStr, delconn);
			string CustID = (string)(Session["CustID"]);
			cmd.Parameters.AddWithValue("@CID", CustID);
			delcmd.Parameters.AddWithValue("@CID", CustID);

			conn.Open();
			delconn.Open();
			int nofRow = 0;
			int delnofRow = 0;
			delnofRow = delcmd.ExecuteNonQuery();
			nofRow = cmd.ExecuteNonQuery();
			//  Response.Write("<script>alert('Delete successful');</script>");
			conn.Close();
			Response.Redirect("Loginpage.aspx");
		}
    }
}
