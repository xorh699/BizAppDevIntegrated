using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BizAppDev
{
    public partial class product_desc : System.Web.UI.Page
    {

        Product prod = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["addproduct"] = "false";
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            //     Label Stock_LevelLabel = (Label)(e.Item.FindControl("Stock_LevelLabel"));
            TextBox tb_quantity = (TextBox)(e.Item.FindControl("tb_quantity"));
            //     if(int.Parse(tb_quantity.ToString()) > int.Parse(Stock_LevelLabel.ToString()))
            //      {
            //          Response.Write("<alert>('Quantity Entered is more than available quantity');</alert>");
            //      }
            //     else

            Session["addproduct"] = "true";

            Response.Redirect("ViewCart.aspx?id=" + e.CommandArgument.ToString() + "&Quantity=" + tb_quantity.Text);




        }


    }
}