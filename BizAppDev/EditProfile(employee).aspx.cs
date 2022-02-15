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
    public partial class EditProfile_employee_ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void DataList1_CancelCommand(object source, DataListCommandEventArgs e)
        {
            DataList1.EditItemIndex = -1;
            // Rebind the data to the DataList
            DataList1.DataBind();
        }



        protected void DataList1_EditCommand(object source, DataListCommandEventArgs e)
        {
            DataList1.EditItemIndex = e.Item.ItemIndex;
            // Rebind the data to the DataList
            DataList1.DataBind();
        }

        protected void DataList1_UpdateCommand(object source, DataListCommandEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Project"].ToString());
                Label employeeid = (Label)e.Item.FindControl("lbl_id");



                TextBox contactno = (TextBox)e.Item.FindControl("tb_contactno");
                TextBox email = (TextBox)e.Item.FindControl("tb_email");
                TextBox address = (TextBox)e.Item.FindControl("tb_address");
                TextBox date = (TextBox)e.Item.FindControl("tb_birthdate");
                TextBox password = (TextBox)e.Item.FindControl("tb_password");


                string queryStr = "UPDATE Employee SET" +
               //" Product_ID = @productID, " +
               " Contactno = @contactno, " +
               " Email = @email, " +
               " Birthdate = @birthdate, " +
               " Password = @password, " +
               " Address = @address " +
               " WHERE empID = @empID";
                SqlCommand cmd = new SqlCommand(queryStr, con);
                int nofRow = 0;

                cmd.Parameters.AddWithValue("@email", email.Text);
                cmd.Parameters.AddWithValue("@contactno", contactno.Text);
                cmd.Parameters.AddWithValue("@address", address.Text);
                cmd.Parameters.AddWithValue("@birthdate", date.Text);
                cmd.Parameters.AddWithValue("@password", password.Text);
                cmd.Parameters.AddWithValue("@empID", employeeid.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                nofRow = cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();
                if (nofRow > 0)
                {
                    Response.Write("<script type=\"text/javascript\">alert('Updated Successfully!!!');</script>");
                    DataList1.EditItemIndex = -1;
                    DataList1.DataBind();
                }
                else
                {
                    Response.Write("<script type=\"text/javascript\">alert('not updated Successfully!!!');</script>");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}