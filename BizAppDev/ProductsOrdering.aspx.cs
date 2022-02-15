using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BizAppDev
{
    public partial class ProductsOrdering : System.Web.UI.Page
    {
        Product prod = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductOrdering aordering = new ProductOrdering();
            Product aprod = new Product();
            string supplname = Request.QueryString["supplierName"].ToString();
            prod = aprod.getProd(supplname);

            lbl_id.Text = prod.Product_ID;
            lbl_product.Text = prod.Product_Name;
            lbl_supplemail.Text = prod.Supplier_Email;
            lbl_supplid.Text = supplname.ToString();

        }

        protected void btn_place_Click(object sender, EventArgs e)
        {
            string pass = "1234567890";

            Random r = new Random();
            char[] mypass = new char[5];

            for (int i = 0; i < 5; i++)
            {
                mypass[i] = pass[r.Next(pass.Length)];
            }
            var kan = new String(mypass);

            int result = 0;
            ProductOrdering coup = new ProductOrdering(kan, cal_delivery.SelectedDate.ToString("dd/MMM/yyyy hh:mm:ss"), tb_quantity.Text, lbl_id.Text, "Not Completed");
            result = coup.orderInsert();


            if (result > 0)
            {
                Response.Write("<script>alert('order placed successful');</script>");
                Response.Redirect("Orders(lermin).aspx?result =" + result);
            }
            else { Response.Write("<script>alert('order placed NOT successful');</script>"); }
        }

        protected void cal_delivery_DayRender(object sender, DayRenderEventArgs e)
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