using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BizAppDev
{
    public partial class Customer1 : System.Web.UI.Page
    {
        Customer acustomer = new Customer();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }
        }
        protected void bind()
        {
            List<Customer> customerList = new List<Customer>();

            DataList1.RepeatColumns = 4;
            DataList1.RepeatDirection = RepeatDirection.Horizontal;
            //DataList1.DataSource = tierList;
            //DataList1.DataBind();
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {

                Label lbl = (Label)e.Item.FindControl("lbl_id");
                Response.Redirect("CustomerMoreInfo.aspx?customerid=" + lbl.Text);
            }

        }
    }
}