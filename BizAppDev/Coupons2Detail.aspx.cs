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
    public partial class Coupons2Detail : System.Web.UI.Page
    {
        Coupons2 coup = null;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DataList1_UpdateCommand(object source, DataListCommandEventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Project"].ToString());
            Label couponid = (Label)e.Item.FindControl("Label1");

            TextBox coupdesc = (TextBox)e.Item.FindControl("TextBox1");
            TextBox amount = (TextBox)e.Item.FindControl("TextBox2");
            TextBox cost = (TextBox)e.Item.FindControl("TextBox3");
            TextBox discount = (TextBox)e.Item.FindControl("TextBox4");
            TextBox days = (TextBox)e.Item.FindControl("TextBox5");
            TextBox months = (TextBox)e.Item.FindControl("TextBox6");
            TextBox years = (TextBox)e.Item.FindControl("TextBox7");
            DropDownList category = (DropDownList)e.Item.FindControl("ddl_category");

            string queryStr = "UPDATE Coupon SET" +
           //" Product_ID = @productID, " +

           " cDesc = @desc," +
           " amount = @amount," +
           " cost = @cost," +
           " discount = @discount," +
           " validDays = @days," +
           " Category = @category," +
           " validMonths = @months," +
           " validYears = @years " +

           " WHERE couponID = @id";
            SqlCommand cmd = new SqlCommand(queryStr, con);
            int nofRow = 0;

            cmd.Parameters.AddWithValue("@desc", coupdesc.Text);
            cmd.Parameters.AddWithValue("@amount", int.Parse(amount.Text));
            cmd.Parameters.AddWithValue("@cost", int.Parse(cost.Text));
            cmd.Parameters.AddWithValue("@discount", decimal.Parse(discount.Text));
            cmd.Parameters.AddWithValue("@days", int.Parse(days.Text));
            cmd.Parameters.AddWithValue("@months", int.Parse(months.Text));
            cmd.Parameters.AddWithValue("@years", int.Parse(years.Text));
            cmd.Parameters.AddWithValue("@category", category.SelectedItem.Text);

            cmd.Parameters.AddWithValue("@id", couponid.Text);

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

        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("CouponsValidity(lermin).aspx");
        }

    }
}