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
    public partial class CustomerCoupon : System.Web.UI.Page
    {
        Coupon coup = new Coupon();
        SqlDataSource SearchDS = new SqlDataSource();


        protected void Page_Load(object sender, EventArgs e)
        {
            SearchDS.ID = "SearchDS_ID";
            this.Page.Controls.Add(SearchDS);
            SearchDS.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Project"].ConnectionString;
            HttpContext context = HttpContext.Current;
            string CID = (string)(context.Session["CustID"]);

        }

        protected void CouponDatalist_ItemCommand(object source, DataListCommandEventArgs e)
        {
            Coupon coup = new Coupon();
            Customer cust = new Customer();
            Customer acust = new Customer();
            HttpContext context = HttpContext.Current;
            string CID = (string)(context.Session["CustID"]);
            acust = cust.getCustomer(CID);
            if (e.CommandName == "makePurchase")
            {
                Label lblCouponID = (Label)(e.Item.FindControl("CouponIDLabel"));
                int CouponID = int.Parse(lblCouponID.Text);
                int result = 0;
                string pass = "1234567890";
                Random r = new Random();
                char[] mypass = new char[5];
                Label lblcoupName = (Label)(e.Item.FindControl("cNameLabel"));
                string coupName = lblcoupName.Text;
                Label lblCouponDiscount = (Label)(e.Item.FindControl("discountLabel"));
                int CouponDiscount = int.Parse(lblCouponDiscount.Text);
                Label lblvalidDays = (Label)(e.Item.FindControl("validDaysLabel"));
                int validDays = int.Parse(lblvalidDays.Text);
                Label lblvalidMonths = (Label)(e.Item.FindControl("validMonthsLabel"));
                int validMonths = int.Parse(lblvalidMonths.Text);
                Label lblvalidYears = (Label)(e.Item.FindControl("validYearsLabel"));
                int validYears = int.Parse(lblvalidYears.Text);
                Label lblcoupDesc = (Label)(e.Item.FindControl("lbl_Desc"));
                string coupDesc = lblcoupDesc.Text;
                Label lblCategory = (Label)(e.Item.FindControl("lbl_Category"));
                string category = lblCategory.Text;
                Label leftQuantity = (Label)(e.Item.FindControl("lbl_leftQuantity"));
                TextBox tbCoupQuantity = (TextBox)(e.Item.FindControl("tb_quantity"));
                int CouponQuantity = Convert.ToInt32(tbCoupQuantity.Text);


                for (int i = 0; i < 5; i++)
                {
                    mypass[i] = pass[r.Next(pass.Length)];
                }
                var kan = new String(mypass);
                Label lblcost = (Label)(e.Item.FindControl("costLabel"));
                int cost = int.Parse(lblcost.Text);
                cost = cost * CouponQuantity;
                cost = -cost;
                if ((acust.points + cost)>0)
                {

                    string reason = "Purchase Coupon: " + coupName;
                    DateTime now = DateTime.Now;
                    PointsTransaction pt = new PointsTransaction(cost,reason,CID,now);
                    int ptresult = 0;
                    ptresult = pt.PointsTransactionInsert();
                    result = coup.claimCoupon(CID, CouponID, kan, coupName, CouponQuantity, CouponDiscount, validDays, validMonths, validYears,coupDesc,category);
                    if (ptresult > 0)
                    {
                        Response.Redirect("CustomerCoupons.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Coupon purchase unsuccessful');</script>");

                    }


                }
                else
                {
                    Response.Write("<script>alert('Not enough points!');</script>");
                }
            } 
        }

        protected void btn_Search_Click(object sender, EventArgs e)
        {
            string order = "";
            string sortBy = "";
            string searchValue = tb_Search.Text;
            string queryStr = "SELECT * FROM Coupon WHERE amount>0 AND cName like '" + searchValue + "%'";
            string sortcolumn = "";
            if (ddl_Sort.SelectedValue != "")
            {
                string value = ddl_Sort.SelectedValue;
                sortBy = "and category = '"+value+"' ";

            }
            if (ddl_Column.SelectedValue != "")
            {
                sortcolumn = "ORDER BY "+ ddl_Column.SelectedValue+" ";
                if (ddl_Order.SelectedValue != "")
                {
                    order = ddl_Order.SelectedValue;
                }
            }

            SearchDS.SelectCommand = "SELECT * FROM Coupon WHERE cName like '%" + searchValue + "%' " +sortBy+ sortcolumn + order;
            CouponDatalist.DataSourceID = "";
            CouponDatalist.DataSourceID = "SearchDS_ID";

        }
    }
    }
