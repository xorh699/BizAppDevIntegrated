using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BizAppDev
{
    public partial class CustomerCoupons : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["now"]=DateTime.Now;
        }

        protected void cbl_Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataList1.DataBind();
        }

        protected void ddl_Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataList1.DataBind();

        }
    }
}