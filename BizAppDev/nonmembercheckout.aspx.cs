using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Data;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace BizAppDev
{
    public partial class nonmembercheckout : System.Web.UI.Page
    {
        static Boolean availabledesignid = false;
        static Decimal gtotal;
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

                            decimal Unit_Price = decimal.Parse(ds.Tables[0].Rows[0]["Unit_Price"].ToString());
                            Int64 quantity = int.Parse(Request.QueryString["quantity"].ToString());
                            decimal totalprice = Unit_Price * quantity;
                            dr["total"] = totalprice;
                            dt.Rows.Add(dr);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                            Session["buyitems"] = dt;
                            GridView1.FooterRow.Cells[4].Text = "SubTotal";
                            GridView1.FooterRow.Cells[5].Text = grandtotal().ToString();
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

                                decimal Unit_Price = decimal.Parse(ds.Tables[0].Rows[0]["Unit_Price"].ToString());
                                Int64 quantity = int.Parse(Request.QueryString["quantity"].ToString());
                                decimal totalprice = Unit_Price * quantity;
                                dr["total"] = totalprice;
                                dt.Rows.Add(dr);
                                GridView1.DataSource = dt;
                                GridView1.DataBind();

                                Session["buyitems"] = dt;
                                GridView1.FooterRow.Cells[4].Text = "SubTotal";
                                GridView1.FooterRow.Cells[5].Text = grandtotal().ToString();
                                Response.Redirect("home.aspx");
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
                        GridView1.FooterRow.Cells[4].Text = "SubTotal";
                        GridView1.FooterRow.Cells[5].Text = grandtotal().ToString();
                        Labelgrandtotal.Text = grandtotal().ToString();
                    }
                }

                Labelgst.Text = gst().ToString();
                Labelgrandtotal.Text = grandtotall().ToString();
                createorderid();
                lbl_orderDate.Text = DateTime.Now.ToShortDateString();
                DeliveryDate.Text = Calendar2.SelectedDate.ToString();
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
        public decimal gst()
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
            decimal gst = Math.Round(Convert.ToDecimal(gtotal) * Convert.ToDecimal(0.07), 2);
            return gst;
        }
        public decimal grandtotall()
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
            decimal gst = Math.Round(Convert.ToDecimal(gtotal) * Convert.ToDecimal(0.07), 2);
            decimal Grandtotal = Math.Round(Convert.ToDecimal(gtotal) + Convert.ToDecimal(gst), 2);
            return Grandtotal;
        }
        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date < DateTime.Now.Date)
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Red;
                e.Cell.Font.Strikeout = true;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            decimal discount;
            decimal finalprice;




            string mycon = ConfigurationManager.ConnectionStrings["Project"].ConnectionString;
            String myquery = "Select * from SeasonalCoupon where coupon_Name='" + tb_discountcode0.Text + "'";
            SqlConnection con = new SqlConnection(mycon);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = myquery;
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lbl_couponcode.Text = "Coupon Code " + tb_discountcode0.Text + " Applied Successfully";
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
                decimal gst = Math.Round(Convert.ToDecimal(gtotal) * Convert.ToDecimal(0.07), 2);
                decimal Grandtotal = Math.Round(Convert.ToDecimal(gtotal) + Convert.ToDecimal(gst), 2);

                discount = decimal.Parse(ds.Tables[0].Rows[0]["coup_discountamt"].ToString());
                finalprice = Math.Round(Grandtotal * (1 - discount));
                Labelgrandtotal.Text = Grandtotal.ToString();
                lbl_discountedprice.Text = finalprice.ToString();


            }
            else
            {
                lbl_couponcode.Text = "Counpon Code is Invalid";
            }
        }
        public void createorderid()
        {
            string pass = "1234567890";
            Random r = new Random();
            char[] mypass = new char[5];

            for (int i = 0; i < 5; i++)
            {
                mypass[i] = pass[r.Next(pass.Length)];
            }
            var kan = new String(mypass);
            String orderid;
            orderid = "Order" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + kan + DateTime.Now.Second.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString();
            lbl_orderid.Text = orderid;
        }
        protected void btn_pay_Click(object sender, EventArgs e)
        {
            DataTable dt;
            dt = (DataTable)Session["buyitems"];

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                string updatepass = "insert into orderdetails(orderid,Product_ID,Product_Name,price,quantity,deliveryoption,deliverydate,grandtotal,discountedtotal,OrderStatus,Cust_ID)"
                    + "values(@orderid,@product_id,@product_name,@price,@quantity,@deliveryoption,@deliverydate,@grandtotal,@discountedtotal,@OrderStatus,@Cust_ID)";
                string mycon = ConfigurationManager.ConnectionStrings["Project"].ConnectionString;

                SqlConnection conn = new SqlConnection(mycon);

                SqlCommand cmd = new SqlCommand();
                string product_id = dt.Rows[i]["Product_ID"].ToString();
                cmd.Parameters.AddWithValue("@orderid", lbl_orderid.Text.ToString());
                cmd.Parameters.AddWithValue("@product_id", product_id);
                cmd.Parameters.AddWithValue("@product_name", Convert.ToString(dt.Rows[i]["Product_Name"]));
                cmd.Parameters.AddWithValue("@price", Convert.ToDecimal(dt.Rows[i]["Unit_Price"]));
                cmd.Parameters.AddWithValue("@quantity", Convert.ToInt64(dt.Rows[i]["quantity"]));
                cmd.Parameters.AddWithValue("@deliveryoption", DropDownList1.Text);
                cmd.Parameters.AddWithValue("@deliverydate", Calendar2.SelectedDate);
                cmd.Parameters.AddWithValue("@grandtotal", Convert.ToDecimal(Labelgrandtotal.Text));
                cmd.Parameters.AddWithValue("@OrderStatus", "Pending");
                cmd.Parameters.AddWithValue("@Cust_ID", "Guest");
                if (lbl_discountedprice.Text == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@discountedtotal", Convert.ToDecimal(0.00));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@discountedtotal", Convert.ToDecimal(lbl_discountedprice.Text));
                }

                conn.Open();

                cmd.CommandText = updatepass;
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            Response.Redirect("nonmembercheckoutoverview.aspx?orderid=" + lbl_orderid.Text);
        }
    }
}