using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BizAppDev
{
    public partial class AcceptedOrder : System.Web.UI.Page
    {
        Orderdetails details = new Orderdetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }
        }
        protected void bind()
        {
            List<Orderdetails> OrderList = new List<Orderdetails>();
            OrderList = details.PendingOrder();
            GvOrder.DataSource = OrderList;
            GvOrder.DataBind();
        }

       
        protected void GvOrder_RowEditing1(object sender, GridViewEditEventArgs e)
        {
            int result = 0;
            Orderdetails details = new Orderdetails();
            GvOrder.EditIndex = e.NewEditIndex;
            bind();
            GridViewRow row = (GridViewRow)GvOrder.Rows[e.NewEditIndex];
            string ID = GvOrder.DataKeys[e.NewEditIndex].Value.ToString();
            string OrderID = row.Cells[0].Text;
            string OrderStatus = row.Cells[2].Text;

            result = details.OrderAcceptance(OrderID, OrderStatus);
            if (result > 0)
            {
                
                Response.Write("<script>alert('Order accepted');</script>");
            }
            else
            {
                Response.Write("<script>alert('Order NOT accepted');</script>");
            }
            GvOrder.EditIndex = e.NewEditIndex;
            bind();
            Response.Redirect("Orderstatus.aspx");
        }

        protected void GvOrder_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            Orderdetails details = new Orderdetails();
            string OrderID = GvOrder.DataKeys[e.RowIndex].Value.ToString();
            result += details.OrderdetailsDelete(OrderID);

            if (result > 0)
            {
                Response.Write("<script>alert('This order has been rejected successfully');</script>");
            }
            else
            {
                Response.Write("<script>alert('This order has not been rejected successfully');</script>");
            }

            GvOrder.EditIndex = -1;
            GvOrder.DataBind();
        }
    }
}