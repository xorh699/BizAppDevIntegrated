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
    public partial class Employeeinfo : System.Web.UI.Page
    {
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
            //DataList1.DataSource = employeeList;
            //DataList1.DataBind();
        }

        protected void myListEditHandler(object source, DataListCommandEventArgs e)
        {
            DataList1.EditItemIndex = e.Item.ItemIndex;
            DataList1.DataBind();
        }
    
        protected void myListCancelHandler(Object src, DataListCommandEventArgs e)
            {
                DataList1.EditItemIndex = -1;
                DataList1.DataBind();
                Response.Redirect("employeelist.aspx");
            }

        protected void myListUpdateHandler(Object src, DataListCommandEventArgs e)
        {
            
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Project"].ToString());
                Label EmpID = (Label)e.Item.FindControl("EmpIDLabel");
                TextBox EmpName = (TextBox)e.Item.FindControl("tb_EmpName");
                TextBox NRIC = (TextBox)e.Item.FindControl("tb_NRIC");
                Label Birthdate = (Label)e.Item.FindControl("BirthdateLabel");
                Label Gender = (Label)e.Item.FindControl("GenderLabel");
                TextBox Contactno = (TextBox)e.Item.FindControl("tb_Contactno");
                TextBox Email = (TextBox)e.Item.FindControl("tb_Email");
                TextBox Address = (TextBox)e.Item.FindControl("tb_Address");


                string queryStr = "UPDATE Employee SET" +
                       //" Product_ID = @productID, " +
                       " EmpName = @EmpName, " +
                       " NRIC = @NRIC, " +
                       " Contactno = @Contactno, " +
                       " Email = @Email, " +
                       " Address = @Address " +
                       " WHERE EmpID = @EmpID";


                
                int nofRow = 0;
                SqlCommand cmd = new SqlCommand(queryStr, con);
                cmd.Parameters.AddWithValue("@EmpID", EmpID.Text);
                cmd.Parameters.AddWithValue("@EmpName", EmpName.Text);
                cmd.Parameters.AddWithValue("@NRIC", NRIC.Text);
                cmd.Parameters.AddWithValue("@Contactno", Contactno.Text);
                cmd.Parameters.AddWithValue("@Email", Email.Text);
                cmd.Parameters.AddWithValue("@Address", Address.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                nofRow += cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();
               
                if (nofRow > 0)
                {
                    Response.Write("<script>alert('Employee Deleted successfully');</script>");
                 
                }
                else
                {
                    Response.Write("<script>alert('Employee NOT successfully Deleted');</script>");
                }
                DataList1.EditItemIndex = -1;
                DataList1.DataBind();
                Response.Redirect("employeelist.aspx");         
        }

        protected void DataList1_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            int result = 0;
            Employee emp = new Employee();
            string EmpID = DataList1.DataKeys[e.Item.ItemIndex].ToString();
            result = emp.EmployeeDelete(EmpID);

            if (result > 0)
            {
                Response.Write("<script>alert('Product Remove successfully');</script>");
            }
            else
            {
                Response.Write("<script>alert('Product Removal NOT successfully');</script>");
            }

            DataList1.EditItemIndex = -1;
            DataList1.DataBind();
        }
    }
}
    


