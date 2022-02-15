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
    public partial class MembershipMoreInfo_employee_ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void DataList1_EditCommand1(object source, DataListCommandEventArgs e)
        {
            DataList1.EditItemIndex = e.Item.ItemIndex;
            // Rebind the data to the DataList
            DataList1.DataBind();
        }

        protected void DataList1_CancelCommand(object source, DataListCommandEventArgs e)
        {
            DataList1.EditItemIndex = -1;
            // Rebind the data to the DataList
            DataList1.DataBind();
        }
        protected void DataList1_UpdateCommand(object source, DataListCommandEventArgs e)
        {
          
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Project"].ToString());
                Label label1 = (Label)e.Item.FindControl("lbl_tierID");
                string membershipid = label1.Text;
                TextBox membernameship = (TextBox)e.Item.FindControl("tb_Name");
                TextBox membershipdesc = (TextBox)e.Item.FindControl("tb_Desc");
                TextBox membershipbenefits = (TextBox)e.Item.FindControl("tb_Benefits");
                TextBox membershipprice = (TextBox)e.Item.FindControl("tb_Price");
                TextBox membershiplength = (TextBox)e.Item.FindControl("tb_length");

                string queryStr = "UPDATE Membership SET" +
               //" Product_ID = @productID, " +
               " membership_name = @membername, " +
               " membership_desc = @memberdesc, " +
               "membership_benefits = @memberbenefits, " +
               "membership_length = @length, " +
               "membership_price = @membershipprice" +
               " WHERE membership_id = @memberid";
                SqlCommand cmd = new SqlCommand(queryStr, con);
                int nofRow = 0;

                cmd.Parameters.AddWithValue("@memberid", label1.Text);
                cmd.Parameters.AddWithValue("@membername", membernameship.Text);
                cmd.Parameters.AddWithValue("@memberdesc", membershipdesc.Text);
                cmd.Parameters.AddWithValue("@memberbenefits", membershipbenefits.Text);
                cmd.Parameters.AddWithValue("@length", membershiplength.Text);
                cmd.Parameters.AddWithValue("@membershipprice", Convert.ToDecimal(membershipprice.Text));
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

        protected void btn_back_Click1(object sender, EventArgs e)
        {
            Response.Redirect("MembershipTierList(employee).aspx");
        }

        protected void DataList1_BackCommand(object sender, DataListCommandEventArgs e)
        {
            Response.Redirect("MembershipTierList(employee).aspx");
        }


    }
}