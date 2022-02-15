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
    public partial class StaffAddPointTier : System.Web.UI.Page
    {
        string _connStr = ConfigurationManager.ConnectionStrings["Project"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void btn_Submit_Click1(object sender, EventArgs e)
        {
            int pointtierresult = 0;
            bool valid = true;
            string tierqueryStr = "INSERT INTO PointTiers" + " values (@name,@descr,@price,@pointMultiplier)";
            string _connStr = ConfigurationManager.ConnectionStrings["Project"].ConnectionString;
            SqlConnection tierconn = new SqlConnection(_connStr);
            SqlCommand tiercmd = new SqlCommand(tierqueryStr, tierconn);
            string name = tb_Name.Text;
            string descr = tb_descr.Text;
            int price = int.Parse(tb_price.Text);
            decimal pointMultiplier = decimal.Parse(tb_pointMultiplier.Text);
            tiercmd.Parameters.AddWithValue("@name", name);
            tiercmd.Parameters.AddWithValue("@descr", descr);
            tiercmd.Parameters.AddWithValue("@price", price);
            tiercmd.Parameters.AddWithValue("@pointMultiplier", pointMultiplier);


            tierconn.Open();
            pointtierresult += tiercmd.ExecuteNonQuery();
            if (pointtierresult > 0)
            {

            }
            else
            {
                valid = false;
            }
            int result = 0;
            int no_Perks = 0;

            //retrieving ID of tier just created
            int tierID = 0;
            Session["tierID"] = tierID;
            List<int> addedPerks = new List<int>();
            HttpContext.Current.Session["list"] = addedPerks;
            addedPerks = (List<int>)HttpContext.Current.Session["list"];
            HttpContext.Current.Session["list"] = addedPerks;
            string perkIDqueryStr = "SELECT top 1 pointTierID from PointTiers order by pointTierID desc";
            SqlConnection IDconn = new SqlConnection(_connStr);
            SqlCommand IDcmd = new SqlCommand(perkIDqueryStr, IDconn);
            IDconn.Open();
            SqlDataReader dr = IDcmd.ExecuteReader();
            if (dr.Read())
            {
                tierID = int.Parse(dr["pointTierID"].ToString());
                IDconn.Close();
                Session["tierID"] = tierID;

            }
            else
            {
                Response.Write("<script>alert('walao!');</script>");
            }
                foreach (DataListItem item in DataList1.Items)
            {

                CheckBox check = (CheckBox)item.FindControl("cb_Perks");
                if (check.Checked)
                {
                    no_Perks += 1;
                    string queryStr = "INSERT INTO PointTiersPerks(PerkID,pointTierID)"
                           + " values (@PerkID,@pointTierID)";
                    SqlConnection conn = new SqlConnection(_connStr);
                    SqlCommand cmd = new SqlCommand(queryStr, conn);
                    int PerkID = int.Parse(check.Text);
                    cmd.Parameters.AddWithValue("@PerkID", PerkID);
                    cmd.Parameters.AddWithValue("@pointTierID", tierID);
                    conn.Open();
                    result += cmd.ExecuteNonQuery();

                }
            }
            if (no_Perks == result)
            {
                Response.Write("<script>alert('Points tier created!');</script>");
                Response.Redirect("StaffViewTiers.aspx");
            }
            else
            {
                Response.Write("<script>alert('Point tier creation unsuccessful');</script>");
            }


        }


        

        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DataList1_ItemCommand1(object source, DataListCommandEventArgs e)
        {

        }
    }
}