using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BizAppDev
{
    public partial class orders_lermin_ : System.Web.UI.Page
    {
        ProductOrdering aOrder = new ProductOrdering();
        ProductOrdering aOrders = new ProductOrdering();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }
        }

        protected void bind()
        {
            List<ProductOrdering> ordersList = new List<ProductOrdering>();
            ordersList = aOrder.getOrderAll();
            gv_orders.DataSource = ordersList;
            gv_orders.DataBind();
        }

        protected void gv_orders_RowDataBound(object sender, GridViewRowEventArgs e)
        {


        }

        protected void gv_orders_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            ProductOrdering order = null;
            for (int i = 0; i < gv_orders.Rows.Count; i++)
            {
                DateTime date = Convert.ToDateTime(gv_orders.Rows[i].Cells[3].Text);
                if (DateTime.Now >= date)
                {
                    gv_orders.Rows[i].Cells[3].ForeColor = System.Drawing.Color.Green;
                    string id = gv_orders.Rows[i].Cells[0].Text;
                    order = aOrder.getStatus(id);
                    if (order.status == "Not Completed")
                    {
                        int result, result1;
                        string quantity = gv_orders.Rows[i].Cells[2].Text;
                        string prodName = gv_orders.Rows[i].Cells[1].Text;
                        string status = gv_orders.Rows[i].Cells[3].Text;
                        string orderID = gv_orders.Rows[i].Cells[0].Text;

                        result = aOrder.UpdateOrder(quantity, prodName);
                        result1 = aOrders.UpdateStatus(status, orderID);

                        Response.Write("<script>alert('delivered successful');</script>");
                    }
                }
                else
                {
                    gv_orders.Rows[i].Cells[3].ForeColor = System.Drawing.Color.Red;
                }
            }
        }



    }
}