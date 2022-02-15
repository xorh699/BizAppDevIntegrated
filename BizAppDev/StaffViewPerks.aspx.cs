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
    public partial class StaffViewPerks : System.Web.UI.Page
    {
        string _connStr = ConfigurationManager.ConnectionStrings["Project"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void dl_Perks_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dl_Perks_EditCommand(object source, DataListCommandEventArgs e)
        {

            dl_Perks.EditItemIndex = e.Item.ItemIndex;
            dl_Perks.DataBind();
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
            string queryStr = "DELETE from Perks where PerkID = @PerkID";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@PerkID", PerkID);
            conn.Open();
            int noofrow = 0;
            noofrow = cmd.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("StaffviewPerks.aspx");
        }

        protected void dl_Perks_CancelCommand(object source, DataListCommandEventArgs e)
        {
            dl_Perks.EditItemIndex = -1;
            dl_Perks.DataBind();
        }

        protected void dl_Perks_UpdateCommand(object source, DataListCommandEventArgs e)
        {
            TextBox tb_Name = (TextBox)(e.Item.FindControl("tb_NewName"));
            TextBox tb_PDesc = (TextBox)(e.Item.FindControl("tb_NewPDesc"));
            Label lbl_PerkID = (Label)(e.Item.FindControl("lbl_PerkID"));
            string Name = tb_Name.Text;
            string PDesc = tb_PDesc.Text;
            int PerkID = int.Parse(lbl_PerkID.Text);
            string queryStr = "UPDATE Perks SET" +
    " Name = @Name," +
    " PDesc = @PDesc" +
    " WHERE PerkID = @PerkID";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@PDesc", PDesc);
            cmd.Parameters.AddWithValue("@PerkID", PerkID);

            conn.Open();
            int noofrow = 0;
            noofrow = cmd.ExecuteNonQuery();
            conn.Close();
            dl_Perks.EditItemIndex = -1;
            dl_Perks.DataBind();
        }
    }
}