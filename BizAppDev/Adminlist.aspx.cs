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
    public partial class Adminlist : System.Web.UI.Page
    {
        Admin aAdm = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            DataList5.RepeatColumns = 3;
            DataList5.RepeatDirection = RepeatDirection.Horizontal;
        }

        protected void DataList5_ItemCommand(object source, DataListCommandEventArgs e)
        {
            Label lbl = (Label)e.Item.FindControl("lbl_AdmID");
            Response.Redirect("Admininfo.aspx?AdmID=" + lbl.Text);
        }

        protected void DataList5_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            int result = 0;
            Admin Adm = new Admin();
            string AdmID = DataList5.DataKeys[e.Item.ItemIndex].ToString();
            result = Adm.AdminDelete(AdmID);

            if (result > 0)
            {
                Response.Write("<script>alert('Admin Deleted successfully');</script>");
            }
            else
            {
                Response.Write("<script>alert('Admin NOT successfully Deleted');</script>");
            }

            DataList5.EditItemIndex = -1;
            DataList5.DataBind();
        }

        protected void DataList5_EditCommand(object source, DataListCommandEventArgs e)
        {
            Label lbl = (Label)e.Item.FindControl("lbl_AdmID");
            Response.Redirect("Admininfo.aspx?AdmID=" + lbl.Text);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string _connStr = ConfigurationManager.ConnectionStrings["Project"].ConnectionString;
            SqlConnection conn = new SqlConnection(_connStr);
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Admin where AdmID like '%" + tb_SearchAdm.Text + "%'", conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            DataList5.DataSourceID = null;
            DataList5.DataSource = dt;
            DataList5.DataBind();
            conn.Close();
        }

        protected void DataList5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
