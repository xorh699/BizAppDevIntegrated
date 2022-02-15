using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace BizAppDev
{
    public partial class StaffViewTierPerks : System.Web.UI.Page
    {
        string _connStr = ConfigurationManager.ConnectionStrings["Project"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void dl_Perks_DeleteCommand(object source, DataListCommandEventArgs e)
        {

            Label lbl_PerkID = (Label)(e.Item.FindControl("lbl_PerkID"));
            int PerkID = int.Parse(lbl_PerkID.Text);
            string ptpqueryStr = "DELETE from PointTiersPerks where PerkID = @PerkID";
            SqlConnection ptpconn = new SqlConnection(_connStr);
            SqlCommand ptpcmd = new SqlCommand(ptpqueryStr, ptpconn);
            ptpcmd.Parameters.AddWithValue("@PerkID", PerkID);
            ptpconn.Open();
            int ptpnoofrow = 0;
            ptpnoofrow = ptpcmd.ExecuteNonQuery();
            ptpconn.Close();
            int TierID = int.Parse(Request.QueryString["pointTierID"]);
            Response.Redirect("StaffViewTierPerks.aspx?pointTierID=" + TierID);
        }
    }
}
