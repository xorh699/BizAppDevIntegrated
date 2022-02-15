using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BizAppDev
{
    public partial class nonmemberproductpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataList1.RepeatColumns = 5;
            DataList1.RepeatDirection = RepeatDirection.Horizontal;
            if(Request.QueryString["categories"] != null)
            {
                DataList1.DataSourceID = null;
                DataList1.DataSource = SqlDataSource3;
                DataList1.DataBind();
            }
        }

        protected void btn_searchproduct_Click(object sender, EventArgs e)
        {
           
            if(tb_search.Text != "")
            {
                DataList1.DataSourceID = null;
                DataList1.DataSource = SqlDataSource2;
                DataList1.DataBind();
            }
            
            if(tb_search.Text == "")
            {
                Response.Write("<script type=\"text/javascript\">alert('Please Enter A Product!!!');</script>");
            }
        }

        protected void lb_jsticks_Click(object sender, EventArgs e)
        {
            Response.Redirect("nonmemberproductpage.aspx?categories=joss sticks");
        }

        protected void lb_Jpaper_Click(object sender, EventArgs e)
        {
            Response.Redirect("nonmemberproductpage.aspx?categories=joss paper");
        }

        protected void lb_jmoney_Click(object sender, EventArgs e)
        {
            Response.Redirect("nonmemberproductpage.aspx?categories=joss money");
        }

        protected void lb_candles_Click(object sender, EventArgs e)
        {
            Response.Redirect("nonmemberproductpage.aspx?categories=candle");
        }

        protected void lb_cProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("home.aspx");
        }

        protected void lb_packages_Click(object sender, EventArgs e)
        {
            Response.Redirect("home.aspx");
        }

        protected void lb_Allp_Click(object sender, EventArgs e)
        {
            DataList1.DataSourceID = null;
            DataList1.DataSource = SqlDataSource1;
            DataList1.DataBind();
        }

        protected void Btn_sort_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedItem.Text == "Default")
            {
                DataList1.DataSourceID = null;
                DataList1.DataSource = SqlDataSource1;
                DataList1.DataBind();
            }

            if(DropDownList1.SelectedItem.Text=="Low to High Price")
            {
                DataList1.DataSourceID = null;
                DataList1.DataSource = SqlDataSource4;
                DataList1.DataBind();
            }
           
            if(DropDownList1.SelectedItem.Text== "High to Low Price")
            {
                DataList1.DataSourceID = null;
                DataList1.DataSource = SqlDataSource5;
                DataList1.DataBind();
            }
             
        

        }
    }    
}