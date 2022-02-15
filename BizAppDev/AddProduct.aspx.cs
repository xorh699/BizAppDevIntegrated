using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BizAppDev
{
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_view_Click(object sender, EventArgs e)
        {
            Response.Redirect("Products(lermin).aspx");
        }

        protected void btn_edit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int result = 0;
                string pass = "1234567890";
                Random r = new Random();
                char[] mypass = new char[5];
                string image = "";

                if (fu_image.HasFile == true)
                {
                    image = "Images\\" + fu_image.FileName;
                }
                for (int i = 0; i < 5; i++)
                {
                    mypass[i] = pass[r.Next(pass.Length)];
                }
                var kan = new String(mypass);

                Product coup = new Product(kan, tb_name.Text, tb_desc.Text,
                    decimal.Parse(tb_price.Text), fu_image.FileName, int.Parse(tb_stock.Text), tb_supplname.Text, tb_supplemail.Text, tb_keywords.Text, ddl_category.SelectedItem.Text);
                result = coup.ProductInsert();

                if (result > 0)
                {
                    Response.Write("<script>alert('Insert successful');</script>");
                    Response.Redirect("Products(lermin).aspx?result =" + result);
                }
                else { Response.Write("<script>alert('Insert NOT successful');</script>"); }
            }
        }



    }
}