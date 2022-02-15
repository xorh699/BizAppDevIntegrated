using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BizAppDev
{
    public partial class ProductCustomization : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Calendar1.Visible = false;
            }
        }
        protected void calImg_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar1.Visible)
            {
                Calendar1.Visible = false;
            }
            else
            {
                Calendar1.Visible = true;
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            tb_date.Text = Calendar1.SelectedDate.ToString("dd/MM/yyyy");
            Calendar1.Visible = false;
        }

        protected void confirmBtn_Click(object sender, EventArgs e)
        {
            Session["CID"] = TextBox1.Text;
             
            int result = 0;

            if (ddl_prodcat.SelectedValue != "0")
            {
                if ((ddl_prodcol.SelectedValue == "0") && (ddl_scent.SelectedValue == "0"))
                {
                    Response.Write("<script>alert('Select at least 1 customization');</script>");
                }
                else
                {
                    ProductCust prodCust = new ProductCust(TextBox1.Text, ddl_prodcat.SelectedItem.Text,
                        ddl_prodcol.SelectedItem.Text, ddl_scent.SelectedItem.Text, tb_name.Text, tb_email.Text, tb_contact.Text, tb_date.Text);
                    
                    result = prodCust.ProdCustInsert();

                    if (result > 0)
                    {
                        Response.Redirect("ProductCustView.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Customization not Submitted');</script>");
                    }
                    TextBox1.Text = "";
                    ddl_prodcat.SelectedItem.Text = "Select a Category";
                    ddl_prodcol.SelectedItem.Text = "Default";
                    ddl_scent.SelectedItem.Text = "Default";
                    tb_name.Text = "";
                    tb_email.Text = "";
                    tb_contact.Text = "";
                    tb_date.Text = "";
                }
            }
            else
            {
                Response.Write("<script>alert('Select a product category');</script>");
            }
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date < DateTime.Now.Date)
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Red;
                e.Cell.Font.Strikeout = true;
            }
        }
    }
}
