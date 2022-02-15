using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BizAppDev
{
    public partial class VideosView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GridView1.DataSourceID = null;
            if (ddlSort.SelectedItem.Text == "Default")
            {
                GridView1.DataSource = SqlDataSource1;
                GridView1.DataBind();
            }
            if (ddlSort.SelectedItem.Text == "Chinese New Year")
            {
                GridView1.DataSource = SqlDataSource2;
                GridView1.DataBind();
            }
            if (ddlSort.SelectedItem.Text == "Qing Ming Festival")
            {
                GridView1.DataSource = SqlDataSource2;
                GridView1.DataBind();
            }
            if (ddlSort.SelectedItem.Text == "Mid Authumn Festival")
            {
                GridView1.DataSource = SqlDataSource2;
                GridView1.DataBind();
            }

        }
    }
}