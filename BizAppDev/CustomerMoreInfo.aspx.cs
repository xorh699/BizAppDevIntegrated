using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BizAppDev
{
    public partial class CustomerMoreInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void DataList1_ItemCommand1(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "back")
            {
                Response.Redirect("Customer.aspx");
            }

        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Customer.aspx");
        }
    }
}