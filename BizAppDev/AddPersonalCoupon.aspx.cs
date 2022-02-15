using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BizAppDev
{
    public partial class AddPersonalCoupon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_insert_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int result = 0;
                string pass = "1234567890";

                Random r = new Random();
                char[] mypass = new char[5];

                for (int i = 0; i < 5; i++)
                {
                    mypass[i] = pass[r.Next(pass.Length)];
                }
                var kan = new String(mypass);
                Coupons2 coup = new Coupons2(kan, tb_name.Text, tb_desc.Text, int.Parse(tb_amount.Text), int.Parse(tb_cost.Text), decimal.Parse(tb_discount.Text), int.Parse(tb_validdays.Text), int.Parse(tb_validmonths.Text), int.Parse(tb_validyears.Text), ddl_category.SelectedItem.Text);
                result = coup.CouponInsert();

                if (result > 0)
                {
                    Response.Write("<script>alert('Insert successful');</script>");
                    Response.Redirect("CouponsValidity(lermin).aspx?result=" + result);
                }
                else { Response.Write("<script>alert('Insert NOT successful');</script>"); }
            }
        }

        protected void btn_view_Click(object sender, EventArgs e)
        {
            Response.Redirect("CouponsValidity(lermin).aspx");
        }



    }
}