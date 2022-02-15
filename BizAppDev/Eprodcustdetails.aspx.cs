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
    public partial class Eprodcustdetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }
        }
        protected void bind()
        {
            List<ProductCust> ProductCustList = new List<ProductCust>();

            DataList2.RepeatColumns = 3;
            DataList2.RepeatDirection = RepeatDirection.Horizontal;
            //DataList1.DataSource = ProductCustList;
            //DataList1.DataBind();
        }
        protected void myListEditHandler(object source, DataListCommandEventArgs e)
        {
            DataList2.EditItemIndex = e.Item.ItemIndex;
            DataList2.DataBind();
        }

        protected void myListCancelHandler(Object src, DataListCommandEventArgs e)
        {
            DataList2.EditItemIndex = -1;
            DataList2.DataBind();
            Response.Redirect("Eproductcust.aspx");
        }

        protected void myListUpdateHandler(Object src, DataListCommandEventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Project"].ToString());
            Label CustID = (Label)e.Item.FindControl("CustIDLabel");


            DropDownList CollectionStatus = (DropDownList)e.Item.FindControl("DropDownList3");


            string queryStr = "UPDATE ProductCust SET" +
           //" Product_ID = @productID, " +
           " status = @status " +
           " WHERE CustID = @CustID";
            SqlCommand cmd = new SqlCommand(queryStr, con);
            int nofRow = 0;

            cmd.Parameters.AddWithValue("@status", CollectionStatus.Text);
            cmd.Parameters.AddWithValue("@CustID", CustID.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            nofRow = cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();

            if (nofRow > 0)
            {
                Response.Write("<script type=\"text/javascript\">alert('Updated Successfully!!!');</script>");
                DataList2.EditItemIndex = -1;
                DataList2.DataBind();
            }
            else
            {
                Response.Write("<script type=\"text/javascript\">alert('Not updated Successfully!!!');</script>");
            }
            Response.Redirect("Eproductcust.aspx");

        }

        protected void DataList2_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            int result = 0;
            ProductCust details = new ProductCust();
            string CustID = DataList2.DataKeys[e.Item.ItemIndex].ToString();
            result = details.ProdCustDelete(CustID);

            if (result > 0)
            {
                Response.Write("<script>alert('Order Remove successfully');</script>");
            }
            else
            {
                Response.Write("<script>alert('Order Removal NOT successfully');</script>");
            }

            DataList2.EditItemIndex = -1;
            DataList2.DataBind();
        }
    }
}