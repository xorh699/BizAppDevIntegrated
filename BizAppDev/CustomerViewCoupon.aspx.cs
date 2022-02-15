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
    public partial class CustomerViewCoupon : System.Web.UI.Page
    {
        Coupon coup = new Coupon();
        Coupon acoup = new Coupon();


        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CUSTOMER.MDF;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext context = HttpContext.Current;
            string CID = (string)(context.Session["CustID"]);

        }


        protected void btn_Claim_Click(object sender, EventArgs e)
        {


        }

        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "UseCoupon")
            {
                Label lblQuantity = (Label)(e.Item.FindControl("coupQuantityLabel"));
                int quantity = int.Parse(lblQuantity.Text);
                Label lbldelCode = (Label)(e.Item.FindControl("CodeLabel"));
                string Code = lbldelCode.Text;
                string _connStr = ConfigurationManager.ConnectionStrings["Project"].ConnectionString;
                if (quantity == 1)
                {
                    string delqueryStr = "DELETE from CustCoupon WHERE Code = @Code";
                    SqlConnection delconn = new SqlConnection(_connStr);
                    SqlCommand delcmd = new SqlCommand(delqueryStr, delconn);
                    delcmd.Parameters.AddWithValue("@Code", Code);
                    delconn.Open();
                    int delnofRow = 0;
                    delnofRow = delcmd.ExecuteNonQuery();
                    Response.Redirect("CustomerViewCoupon.aspx");

                }
                else
                {
                    string queryStr = "UPDATE CustCoupon SET" +
                    " coupQuantity = coupQuantity - 1" +
                    " WHERE Code = @Code";

                    Label lblCouponID = (Label)(e.Item.FindControl("CouponIDLabel"));
                    int CouponID = int.Parse(lblCouponID.Text);
                    SqlConnection conn = new SqlConnection(_connStr);
                    SqlCommand cmd = new SqlCommand(queryStr, conn);
                    cmd.Parameters.AddWithValue("@Code", Code);
                    cmd.Parameters.AddWithValue("@CouponID", CouponID);
                    conn.Open();
                    int nofRow = 0;
                    nofRow = cmd.ExecuteNonQuery();
                    conn.Close();
                    Response.Redirect("CustomerViewCoupon.aspx");
                }

            }
        }

        protected void dl_SeasonalCoupon_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dl_SeasonalCoupon_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "showcode")
            {
                
            }
        }

        protected void dl_SeasonalCoupon_ItemDataBound(object sender, DataListItemEventArgs e)
        {
        }
    }
}