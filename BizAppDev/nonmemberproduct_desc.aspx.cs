using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BizAppDev
{
    public partial class nonmemberproduct_desc : System.Web.UI.Page
    {
        Product prod = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["addproduct"] = "false";
        }
        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            //     Label Stock_LevelLabel = (Label)(e.Item.FindControl("Stock_LevelLabel"));
            Label Stock_LevelLabel = (Label)(e.Item.FindControl("Stock_LevelLabel"));
            TextBox tb_quantity = (TextBox)(e.Item.FindControl("tb_quantity"));
            if ( tb_quantity.Text == "0" || int.Parse(tb_quantity.Text)>int.Parse(Stock_LevelLabel.Text))
            {
                try { 
                if (int.Parse(tb_quantity.Text) > int.Parse(Stock_LevelLabel.Text))
                {
                    Response.Write("<script type=\"text/javascript\">alert('Quantity is more than available Quantity!!!');</script>");
                }
               
               if (tb_quantity.Text == "0")
                {
                    Response.Write("<script type=\"text/javascript\">alert('Quantity must be at least one!!!');</script>");
                }
                }
                catch
                {

                }
            }
            else { 
            //    
            Session["addproduct"] = "true";

            Response.Redirect("nonmemberViewCart.aspx?id=" + e.CommandArgument.ToString() + "&Quantity=" + tb_quantity.Text);
            }
         
        }
    }
}