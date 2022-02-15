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
    public partial class Rewards: System.Web.UI.Page
    {
        string _connStr = ConfigurationManager.ConnectionStrings["Project"].ConnectionString;

        Customer aCust = new Customer();
        Customer Cust = new Customer();
        pointsTier aTier = new pointsTier();
        pointsTier Tier = new pointsTier();

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext context = HttpContext.Current;
            string CID = (string)(context.Session["CustID"]);
            Cust = aCust.getCustomer(CID);
            lbl_Points.Text = Cust.points.ToString();
            int tierID = Cust.pointTierID;
            Tier = aTier.getPointsTier(tierID);
            lbl_TierName.Text = Tier.name;
            lbl_Name.Text = Cust.first_Name + " " + Cust.last_Name;
            lbl_Email.Text = Cust.email;
            lbl_Expiry.Text = Cust.pointExpiry.ToString("dddd, dd MMMM yyyy");
            decimal custLvlPoints = Cust.lvlPoints;
            string queryStr = "SELECT COUNT(*) FROM CustCoupon WHERE Cust_ID = @CustID";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@CustID", CID);
            string ptqueryStr = "SELECT TOP 1 * FROM PointTiers WHERE price>@custPoints order by price asc";
            SqlCommand ptcmd = new SqlCommand(ptqueryStr, conn);
            ptcmd.Parameters.AddWithValue("@custPoints", custLvlPoints);
            conn.Open();
            SqlDataReader dr = ptcmd.ExecuteReader();
            decimal nextPTprice = -1;
            decimal percentProgress = 0;
            string nextPTname = "";
            if (dr.Read())
            {
                nextPTprice = Convert.ToInt32(dr["price"].ToString());
                nextPTname = dr["name"].ToString();
            }
          
            if (nextPTprice == -1)
            {
                percentProgress = 100;
                string percentToNext = percentProgress.ToString() + "%";
                pointBar.Style.Add("width", percentToNext);
                lbl_exp.Text = "You're at the top tier!";
            }
            else
            {
                percentProgress = (custLvlPoints / nextPTprice) * 100;
                string percentToNext = percentProgress.ToString() + "%";
                pointBar.Style.Add("width", percentToNext);
                lbl_exp.Text = nextPTname+": "+custLvlPoints.ToString() + " / " + nextPTprice.ToString();
            }
            dr.Close();
            dr.Dispose();
            int noVouchers = Convert.ToInt32(cmd.ExecuteScalar());
            lbl_NoVouchers.Text = noVouchers.ToString();


            }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btn_Claim_Click(object sender, EventArgs e)
        {

        }



        protected void btn_Perks_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerViewPerks.aspx?pointTierID=" + Cust.pointTierID);
        }

        protected void btn_Coupons_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerCoupons.aspx");
        }

        protected void btn_PointsHistory_Click(object sender, EventArgs e)
        {
            Response.Redirect("PointsTransactions.aspx");

        }

        protected void btn_ViewTiers_Click(object sender, EventArgs e)
        {
            Response.Redirect("PointTierList.aspx");
        }
    }
}