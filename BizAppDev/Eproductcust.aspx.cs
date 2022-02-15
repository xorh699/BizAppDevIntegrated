using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BizAppDev
{
    public partial class Eproductcust : System.Web.UI.Page
    {
        ProductCust acust = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            DataList8.RepeatColumns = 3;
            DataList8.RepeatDirection = RepeatDirection.Horizontal;
        }

        protected void DataList8_ItemCommand(object source, DataListCommandEventArgs e)
        {
            Label lbl = (Label)e.Item.FindControl("CustIDLabel");
            Response.Redirect("Orderinfo.aspx?OrderID=" + lbl.Text);
        }

        protected void DataList8_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            int result = 0;
            ProductCust details = new ProductCust();
            string custID = DataList8.DataKeys[e.Item.ItemIndex].ToString();
            result = details.ProdCustDelete(custID);

            if (result > 0)
            {
                Response.Write("<script>alert('his order has been removed successfully');</script>");
            }
            else
            {
                Response.Write("<script>alert(his order has not been successfully');</script>");
            }

            DataList8.EditItemIndex = -1;
            DataList8.DataBind();
        }

        protected void DataList8_EditCommand(object source, DataListCommandEventArgs e)
        {
            Label lbl = (Label)e.Item.FindControl("CustIDLabel");
            Response.Redirect("Eprodcustdetails.aspx?custID=" + lbl.Text);
        }


    }
}
