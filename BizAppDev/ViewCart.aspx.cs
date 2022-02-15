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
    public partial class ViewCart : System.Web.UI.Page
    {
        static Boolean availabledesignid = false;
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (Session["addproduct"].ToString() == "true")
                {
                    Session["addproduct"] = "false";
                    DataTable dt = new DataTable();
                    DataRow dr;
                    dt.Columns.Add("images");
                    dt.Columns.Add("Product_ID");
                    dt.Columns.Add("Product_Name");
                    dt.Columns.Add("quantity");
                    dt.Columns.Add("Unit_Price");
                    dt.Columns.Add("total");
                    dt.Columns.Add("Category");


                    if (Request.QueryString["id"] != null)
                    {
                        if (Session["Buyitems"] == null)
                        {
                            dr = dt.NewRow();
                            string mycon = ConfigurationManager.ConnectionStrings["Project"].ConnectionString;
                            SqlConnection scon = new SqlConnection(mycon);
                            string myquery = "select * from Products where Product_ID=" + Request.QueryString["id"];
                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandText = myquery;
                            cmd.Connection = scon;
                            SqlDataAdapter da = new SqlDataAdapter();
                            da.SelectCommand = cmd;
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            dr["images"] = ds.Tables[0].Rows[0]["Product_Image"].ToString();
                            dr["Product_ID"] = ds.Tables[0].Rows[0]["Product_ID"].ToString();
                            dr["Product_Name"] = ds.Tables[0].Rows[0]["Product_Name"].ToString();
                            dr["quantity"] = Request.QueryString["quantity"];
                            dr["Unit_Price"] = ds.Tables[0].Rows[0]["Unit_Price"].ToString();
                            dr["Category"] = ds.Tables[0].Rows[0]["Category"].ToString();

                            decimal Unit_Price = decimal.Parse(ds.Tables[0].Rows[0]["Unit_Price"].ToString());
                            Int64 quantity = int.Parse(Request.QueryString["quantity"].ToString());
                            decimal totalprice = Unit_Price * quantity;
                            dr["total"] = totalprice;
                            dt.Rows.Add(dr);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                            Session["buyitems"] = dt;
                            GridView1.FooterRow.Cells[6].Text = "SubTotal";
                            GridView1.FooterRow.Cells[7].Text = grandtotal().ToString();

                        }
                        else
                        {
                            checkdesignid();
                            if (availabledesignid == true)
                            {
                                Response.Write("Designid " + Request.QueryString["id"] + " " + availabledesignid);
                                updatequantity();
                                DataTable dt1;
                                dt1 = (DataTable)Session["buyitems"];
                                GridView1.DataSource = dt1;
                                GridView1.DataBind();
                                availabledesignid = false;
                            }
                            else
                            {
                                dt = (DataTable)Session["buyitems"];
                                int sr;
                                sr = dt.Rows.Count;

                                dr = dt.NewRow();
                                string mycon = ConfigurationManager.ConnectionStrings["Project"].ConnectionString;
                                SqlConnection scon = new SqlConnection(mycon);
                                string myquery = "select * from Products where Product_ID=" + Request.QueryString["id"];
                                SqlCommand cmd = new SqlCommand();
                                cmd.CommandText = myquery;
                                cmd.Connection = scon;
                                SqlDataAdapter da = new SqlDataAdapter();
                                da.SelectCommand = cmd;
                                DataSet ds = new DataSet();
                                da.Fill(ds);
                                dr["images"] = ds.Tables[0].Rows[0]["Product_Image"].ToString();
                                dr["Product_ID"] = ds.Tables[0].Rows[0]["Product_ID"].ToString();
                                dr["Product_Name"] = ds.Tables[0].Rows[0]["Product_Name"].ToString();
                                dr["quantity"] = Request.QueryString["quantity"];
                                dr["Unit_Price"] = ds.Tables[0].Rows[0]["Unit_Price"].ToString();
                                dr["Category"] = ds.Tables[0].Rows[0]["Category"].ToString();

                                decimal Unit_Price = decimal.Parse(ds.Tables[0].Rows[0]["Unit_Price"].ToString());
                                Int64 quantity = int.Parse(Request.QueryString["quantity"].ToString());
                                decimal totalprice = Unit_Price * quantity;
                                dr["total"] = totalprice;
                                dt.Rows.Add(dr);
                                GridView1.DataSource = dt;
                                GridView1.DataBind();

                                Session["buyitems"] = dt;
                                GridView1.FooterRow.Cells[6].Text = "SubTotal";
                                GridView1.FooterRow.Cells[7].Text = grandtotal().ToString();

                            }
                        }
                    }

                }
                else
                {
                    DataTable dt;
                    dt = (DataTable)Session["buyitems"];
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    if (GridView1.Rows.Count > 0)
                    {
                        GridView1.FooterRow.Cells[6].Text = "SubTotal";
                        GridView1.FooterRow.Cells[7].Text = grandtotal().ToString();
                    }

                }
            }
            catch
            {

            }
        }
        private void checkdesignid()
        {
            DataTable dt1;
            int Product_ID;
            int queryproductid = int.Parse(Request.QueryString["id"]);
            dt1 = (DataTable)Session["buyitems"];
            foreach (DataRow row in dt1.Rows)
            {
                Product_ID = int.Parse(row["Product_ID"].ToString());
                if (Product_ID == queryproductid)
                {
                    availabledesignid = true;
                }
            }
        }
        private void updatequantity()
        {
            DataTable dt1;
            int Product_ID;
            int queryproductid = int.Parse(Request.QueryString["id"]);
            dt1 = (DataTable)Session["buyitems"];
            foreach (DataRow row in dt1.Rows)
            {
                Product_ID = int.Parse(row["Product_ID"].ToString());
                if (Product_ID == queryproductid)
                {
                    int newquantity = int.Parse(row["quantity"].ToString()) + int.Parse(Request.QueryString["quantity"].ToString());
                    row["quantity"] = newquantity;
                    decimal price = decimal.Parse(row["Unit_Price"].ToString());
                    decimal totalprice = price * newquantity;
                    row["total"] = totalprice;
                    break;
                }
            }
            Session["buyitems"] = dt1;
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            DataTable dt = new DataTable();
            dt = (DataTable)Session["buyitems"];
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                int sr;
                int sr1;
                string qdata;
                string dtdata;
                sr = Convert.ToInt32(dt.Rows[i]["Product_ID"].ToString());
                TableCell cell = GridView1.Rows[e.RowIndex].Cells[1];
                qdata = cell.Text;
                dtdata = sr.ToString();
                sr1 = int.Parse(qdata);

                if (sr == sr1)
                {
                    dt.Rows[i].Delete();
                    dt.AcceptChanges();
                }
            }
            for (int i = 1; i <= dt.Rows.Count; i++)
            {
                dt.Rows[i - 1]["Product_ID"] = i;
                dt.AcceptChanges();
            }
            Session["butitems"] = dt;
            Response.Redirect("ViewCart.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("EditOrder.aspx?id=" + GridView1.SelectedRow.Cells[1].Text);
        }
        public decimal grandtotal()
        {

            DataTable dt = new DataTable();
            dt = (DataTable)Session["buyitems"];
            int nrow = dt.Rows.Count;
            int i = 0;
            decimal gtotal = 0;
            while (i < nrow)
            {
                gtotal = gtotal + decimal.Parse(dt.Rows[i]["total"].ToString());
                i = i + 1;
            }
            return gtotal;
        }

        protected void btn_checkout_Click(object sender, EventArgs e)
        {

            Response.Redirect("checkout.aspx");


        }
    }
}