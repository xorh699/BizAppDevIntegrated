using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BizAppDev
{
    public partial class CouponDetail_employee_ : System.Web.UI.Page
    {
        Coupons coup = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            Coupons acoup = new Coupons();
            string couponID = Request.QueryString["couponID"].ToString();
            coup = acoup.getCoupon(couponID);

            lbl_couponID.Text = couponID.ToString();
            lbl_couponName.Text = coup.couponName;
            lbl_startDate.Text = coup.couponstartDate;
            lbl_endDate.Text = coup.couponendDate;
            lbl_desc.Text = coup.couponDesc;

        }
        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Coupons(lermin)(employee).aspx");
        }

    }
}