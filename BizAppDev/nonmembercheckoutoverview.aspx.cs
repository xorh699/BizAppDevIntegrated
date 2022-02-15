using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Stripe.Checkout;
using Stripe;

namespace BizAppDev
{
    public partial class nonmembercheckoutoverview : System.Web.UI.Page
    {
        public string sessionIds = "";

        SqlConnection knn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CUSTOMER.MDF;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            decimal discountedtotal;
            decimal grandtotal;
            knn.Open();
            SqlCommand cmd = knn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select grandtotal,discountedtotal,orderid,deliveryoption,deliverydate from orderdetails where orderid=@orderid";
            cmd.Parameters.AddWithValue("@orderid", Request.QueryString["orderid"].ToString());
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                if (row.Field<decimal>("discountedtotal").ToString() == "0.00")
                {
                    Labelgg.Text = row.Field<decimal>("grandtotal").ToString();
                    Labelorderii.Text = row.Field<string>("orderid").ToString();
                    lbldelop.Text = "Delivery Option: " + row.Field<string>("deliveryoption").ToString();
                    lbldeldate.Text = "Delivery Date: " + row.Field<DateTime>("deliverydate").ToString();
                    break;

                }
                if (row.Field<decimal>("discountedtotal") > Convert.ToDecimal(0.00))
                {
                    Labelorderii.Text = row.Field<string>("orderid").ToString();
                    Labelgg.Text = row.Field<decimal>("grandtotal").ToString();
                    Labeldisc.Text = "Discount Total:$ " + row.Field<decimal>("discountedtotal").ToString();
                    lbldelop.Text = "Delivery Option: " + row.Field<string>("deliveryoption").ToString();
                    lbldeldate.Text = "Delivery Date: " + row.Field<DateTime>("deliverydate").ToString();
                    break;
                }

            }
            StripeConfiguration.ApiKey = "sk_test_51KHh6JKpf4tgYB9Ke4eDF1XVljQDR71m6WZ4570lLYBVO2Hyn1MT1YcmjfiUgOgDXWyFIH9eAfnWkzfWeU97CTuy00js5wzoZj";

            var options = new SessionCreateOptions
            {
                SuccessUrl = "https://localhost:44397/nonmembersuccess.aspx",
                CancelUrl = "https://localhost:44397/nonmembercheckout.aspx",
                PaymentMethodTypes = new List<string>
                {
                    "card",
                },
                LineItems = new List<SessionLineItemOptions>
                  {
                    new SessionLineItemOptions
                    {
                        Name="Please Pay",

                      Amount= Convert.ToInt64(Decimal.Parse(Labelgg.Text)*100) ,
                     Currency="sgd",
                      Quantity=1,
                    },
                  },
                Mode = "payment",
            };
            var service = new SessionService();
            Session session = service.Create(options);
            sessionIds = session.Id;
            knn.Close();
        }
        protected void btn_proceed_Click(object sender, EventArgs e)
        {
            Response.Redirect("payment.aspx");
        }
    }
}