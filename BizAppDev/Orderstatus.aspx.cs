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
    public partial class Orderstatus : System.Web.UI.Page
    {
        Orderdetails adetails = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            DataList2.RepeatColumns = 3;
            DataList2.RepeatDirection = RepeatDirection.Horizontal;
        }

        protected void DataList2_ItemCommand(object source, DataListCommandEventArgs e)
        {
            Label lbl = (Label)e.Item.FindControl("OrderIDLabel");
            Response.Redirect("Orderinfo.aspx?OrderID=" + lbl.Text);
        }

        protected void DataList2_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            int result = 0;
            Orderdetails details = new Orderdetails();
            string OrderID = DataList2.DataKeys[e.Item.ItemIndex].ToString();
            result = details.OrderdetailsDelete(OrderID);

            if (result > 0)
            {
                Response.Write("<script>alert('This order has been removed successfully');</script>");
            }
            else
            {
                Response.Write("<script>alert(This order has not been successfully');</script>");
            }

            DataList2.EditItemIndex = -1;
            DataList2.DataBind();
        }



        protected void DataList2_EditCommand(object source, DataListCommandEventArgs e)
        {
            Label lbl = (Label)e.Item.FindControl("OrderIDLabel");
            Response.Redirect("Orderinfo.aspx?OrderID=" + lbl.Text);
        }

       
    }
}
   