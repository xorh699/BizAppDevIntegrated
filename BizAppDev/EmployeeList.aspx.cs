using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace BizAppDev
{
    public partial class EmployeeList : System.Web.UI.Page
    {
        Employee aemployee = new Employee();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }
        }
        protected void bind()
        {
            List<Employee> employeeList = new List<Employee>();

            DataList1.RepeatColumns = 3;
            DataList1.RepeatDirection = RepeatDirection.Horizontal;
            //DataList1.DataSource = tierList;
            //DataList1.DataBind();
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "More")
            {
                Label lbl = (Label)e.Item.FindControl("lbl_ID");
                Response.Redirect("EmployeeListMoreInfo.aspx?employeeID=" + lbl.Text);
            }
        }

        protected void DataList1_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Project"].ToString());
            Label employeeid = (Label)e.Item.FindControl("lbl_ID");

            string queryStr = "DELETE FROM Employee WHERE EmpID=@ID";
            SqlCommand cmd = new SqlCommand(queryStr, con);
            int nofRow = 0;


            cmd.Parameters.AddWithValue("@ID", employeeid.Text);
            con.Open();
            nofRow += cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            if (nofRow > 0)
            {
                Response.Write("<script type=\"text/javascript\">alert('Delete Successfully!!!');</script>");
                DataList1.EditItemIndex = -1;
                DataList1.DataBind();
            }
            else
            {
                Response.Write("<script type=\"text/javascript\">alert('not deleted Successfully!!!');</script>");
            }

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "1")
            {
                int result = 0;
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Project"].ToString());
                string querystring = "SELECT * FROM Employee;";
                SqlCommand cmd = new SqlCommand(querystring, con);

                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds, "EmpName");
                DataList1.DataSource = ds;
                DataList1.DataSourceID = string.Empty;

                DataList1.DataBind();
                result = ds.Tables[0].Rows.Count;
                lbl_noofstaff.Text = result.ToString();
                con.Close();
            }
            else if (DropDownList1.SelectedValue == "2")
            {
                int result = 0;
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Project"].ToString());
                string querystring = "SELECT * FROM Employee WHERE(Position = 'Advisor');";
                SqlCommand cmd = new SqlCommand(querystring, con);

                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds, "EmpName");
                DataList1.DataSource = ds;
                DataList1.DataSourceID = string.Empty;

                DataList1.DataBind();
                result = ds.Tables[0].Rows.Count;
                lbl_noofstaff.Text = result.ToString();
                con.Close();
            }
            else if (DropDownList1.SelectedValue == "3")
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Project"].ToString());
                string querystring = "SELECT * FROM Employee WHERE(Position = 'Priest');";
                SqlCommand cmd = new SqlCommand(querystring, con);

                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds, "EmpName");
                DataList1.DataSource = ds;
                DataList1.DataSourceID = string.Empty;

                DataList1.DataBind();
                int result = 0;
                result = ds.Tables[0].Rows.Count;
                lbl_noofstaff.Text = result.ToString();
                con.Close();
            }
            else if (DropDownList1.SelectedValue == "4")
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Project"].ToString());
                string querystring = "SELECT * FROM Employee WHERE(Position = 'Packer');";
                SqlCommand cmd = new SqlCommand(querystring, con);

                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds, "EmpName");
                DataList1.DataSource = ds;
                DataList1.DataSourceID = string.Empty;

                int result = 0;
                result = ds.Tables[0].Rows.Count;
                lbl_noofstaff.Text = result.ToString();
                DataList1.DataBind();
                con.Close();
            }
            else
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Project"].ToString());
                string querystring = "SELECT * FROM Employee WHERE(Position = 'Customer Support');";
                SqlCommand cmd = new SqlCommand(querystring, con);

                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds, "EmpName");
                DataList1.DataSource = ds;
                DataList1.DataSourceID = string.Empty;

                int result = 0;
                result = ds.Tables[0].Rows.Count;
                lbl_noofstaff.Text = result.ToString();
                DataList1.DataBind();
                con.Close();
            }
        }

    }
}