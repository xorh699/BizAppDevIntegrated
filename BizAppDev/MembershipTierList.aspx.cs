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
    public partial class MembershipTierList : System.Web.UI.Page
    {
        MembershipTier amember = new MembershipTier();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }
        }

        protected void bind()
        {
            List<MembershipTier> tierList = new List<MembershipTier>();
            tierList = amember.getTierAll();
            DataList1.RepeatColumns = 3;
            DataList1.RepeatDirection = RepeatDirection.Horizontal;
            //DataList1.DataSource = tierList;
            //DataList1.DataBind();
        }

        protected void DataList1_EditCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            Label lbl = (Label)e.Item.FindControl("Label1");
            Response.Redirect("MembershipMoreInfo.aspx?memberID=" + lbl.Text);
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

        protected void cancel(object sender, CommandEventArgs e)
        {

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

            string queryStr = "UPDATE Membership SET" +
           //" Product_ID = @productID, " +
           " membership_name = @membername, " +
           " membership_desc = @memberdesc, " +
           "membership_benefits = @memberbenefits, " +
           "membership_price = @membershipprice" +
           " WHERE membership_id = @memberid";
            SqlCommand cmd = new SqlCommand(queryStr, con);
            int nofRow = 0;

            cmd.Parameters.AddWithValue("@memberid", label1.Text);
            cmd.Parameters.AddWithValue("@membername", membernameship.Text);
            cmd.Parameters.AddWithValue("@memberdesc", membershipdesc.Text);
            cmd.Parameters.AddWithValue("@memberbenefits", membershipbenefits.Text);
            cmd.Parameters.AddWithValue("@membershipprice", membershipprice.Text);
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
            Response.Redirect("MembershipTierList.aspx");
        }

        protected void back(object sender, CommandEventArgs e)
        {
            Response.Redirect("MembershipTierList.aspx");
        }

        protected void tb_Price_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btn_more_Click(object sender, EventArgs e)
        {

        }
    }
}