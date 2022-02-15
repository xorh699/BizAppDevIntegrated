using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace BizAppDev
{
    public partial class EditOrder : System.Web.UI.Page
    {
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {

            }
            else
            {
                if (Request.QueryString["id"] != null)
                {
                    dt = (DataTable)Session["buyitems"];

                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        int sr;
                        int sr1;
                        sr = Convert.ToInt32(dt.Rows[i]["Product_ID"].ToString());
                        Label4.Text = sr.ToString();
                        sr1 = Convert.ToInt32(Label4.Text);
                        if (sr == sr1)
                        {
                            Label4.Text = dt.Rows[i]["Product_ID"].ToString();
                            Label5.Text = dt.Rows[i]["Product_Name"].ToString();
                            Label6.Text = dt.Rows[i]["Unit_Price"].ToString();
                            tb_quantity.Text = dt.Rows[i]["Product_ID"].ToString();
                            Label7.Text = dt.Rows[i]["total"].ToString();
                        }

                    }
                    tb_quantity.Text = "";
                }
                else
                {
                }
            }
        }

        protected void tb_quantity_TextChanged(object sender, EventArgs e)
        {
            int q;
            q = Convert.ToInt32(tb_quantity.Text);
            decimal cost;
            cost = decimal.Parse(Label6.Text);
            decimal totalcost;
            totalcost = cost * q;
            Label7.Text = totalcost.ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            dt = (DataTable)Session["buyitems"];

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                int sr;
                int sr1;
                sr = Convert.ToInt32(dt.Rows[i]["Product_ID"].ToString());
                sr1 = Convert.ToInt32(Label4.Text);

                if (sr == sr1)
                {
                    dt.Rows[i]["Product_ID"] = Label4.Text;
                    dt.Rows[i]["Product_Name"] = Label5.Text;
                    dt.Rows[i]["quantity"] = tb_quantity.Text;
                    dt.Rows[i]["Unit_Price"] = Label6.Text;
                    dt.Rows[i]["total"] = Label7.Text;
                    dt.AcceptChanges();

                }
            }
            tb_quantity.Text = "";
            Response.Redirect("ViewCart.aspx");
        }
    }
}