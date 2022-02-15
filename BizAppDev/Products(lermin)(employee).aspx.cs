using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;



namespace BizAppDev
{
    public partial class Products_lermin__employee_ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataList1.RepeatColumns = 3;
            DataList1.RepeatDirection = RepeatDirection.Horizontal;

        }

        protected void DataList1_EditCommand(object source, DataListCommandEventArgs e)
        {
            DataList1.EditItemIndex = e.Item.ItemIndex;
            // Rebind the data to the DataList

            DataList1.DataBind();
        }

        protected void DataList1_CancelCommand(object source, DataListCommandEventArgs e)
        {
            DataList1.EditItemIndex = -1;
            // Rebind the data to the DataList
            DataList1.DataBind();
        }

        protected void DataList2_UpdateCommand(object source, DataListCommandEventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Project"].ToString());
            Label productid = (Label)e.Item.FindControl("Label1");
            Label productitem = (Label)e.Item.FindControl("Label2");

            TextBox packagedesc = (TextBox)e.Item.FindControl("tb_desc");
            TextBox packageprice = (TextBox)e.Item.FindControl("tb_price");
            TextBox packagefestive = (TextBox)e.Item.FindControl("tb_festival");



            string queryStr = "UPDATE Package SET" +
           //" Product_ID = @productID, " +

           " package_Desc = @desc," +
           " package_festival = @festive," +
           " package_Price = @price " +

           " WHERE package_Name = @id";
            SqlCommand cmd = new SqlCommand(queryStr, con);
            int nofRow = 0;

            cmd.Parameters.AddWithValue("@desc", packagedesc.Text);
            cmd.Parameters.AddWithValue("@price", decimal.Parse(packageprice.Text));
            cmd.Parameters.AddWithValue("@festive", packagefestive.Text);

            cmd.Parameters.AddWithValue("@id", productid.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            nofRow = cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            if (nofRow > 0)
            {
                Response.Write("<script type=\"text/javascript\">alert('Updated Successfully!!!');</script>");
                DataList2.EditItemIndex = -1;
                DataList2.DataBind();
            }
            else
            {
                Response.Write("<script type=\"text/javascript\">alert('not updated Successfully!!!');</script>");
            }
        }

        protected void DataList1_ItemCommand1(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Order")
            {
                Label lbl = (Label)e.Item.FindControl("lbl_supplname");
                Response.Redirect("ProductsOrdering.aspx?supplierName=" + lbl.Text);
            }
        }

        protected void DataList2_CancelCommand(object source, DataListCommandEventArgs e)
        {
            DataList2.EditItemIndex = -1;
            // Rebind the data to the DataList
            DataList2.DataBind();
        }

        protected void DataList2_EditCommand(object source, DataListCommandEventArgs e)
        {
            DataList2.EditItemIndex = e.Item.ItemIndex;
            // Rebind the data to the DataList
            DataList2.DataBind();
        }

        protected void DataList1_UpdateCommand(object source, DataListCommandEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Project"].ToString());
                Label label1 = (Label)e.Item.FindControl("lbl_id");
                string membershipid = label1.Text;
                TextBox desc = (TextBox)e.Item.FindControl("tb_desc");
                TextBox price = (TextBox)e.Item.FindControl("tb_price");
                TextBox supplname = (TextBox)e.Item.FindControl("tb_supplname");
                TextBox supplemail = (TextBox)e.Item.FindControl("tb_supplemail");

                string queryStr = "UPDATE Products SET" +
               //" Product_ID = @productID, " +
               " Product_Desc = @desc, " +
               " Unit_Price = @price, " +
               "supplierName = @name, " +
               "supplierEmail = @email" +
               " WHERE Product_ID = @memberid";
                SqlCommand cmd = new SqlCommand(queryStr, con);
                int nofRow = 0;

                cmd.Parameters.AddWithValue("@memberid", label1.Text);
                cmd.Parameters.AddWithValue("@desc", desc.Text);
                cmd.Parameters.AddWithValue("@price", decimal.Parse(price.Text));
                cmd.Parameters.AddWithValue("@name", supplname.Text);
                cmd.Parameters.AddWithValue("@email", supplemail.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                nofRow = cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();
                if (nofRow > 0)
                {
                    Response.Write("<script type=\"text/javascript\">alert('Updated Successfully!!!');</script>");
                    DataList1.EditItemIndex = -1;
                    DataList1.DataBind();
                }
                else
                {
                    Response.Write("<script type=\"text/javascript\">alert('not updated Successfully!!!');</script>");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void DataList2_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Project"].ToString());
            Label packagename = (Label)e.Item.FindControl("package_NameLabel");

            string queryStr = "DELETE FROM Package WHERE package_Name=@ID";
            SqlCommand cmd = new SqlCommand(queryStr, con);
            int nofRow = 0;


            cmd.Parameters.AddWithValue("@ID", packagename.Text);
            con.Open();
            nofRow += cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            if (nofRow > 0)
            {
                Response.Write("<script type=\"text/javascript\">alert('Delete Successfully!!!');</script>");
                DataList2.EditItemIndex = -1;
                DataList2.DataBind();
            }
            else
            {
                Response.Write("<script type=\"text/javascript\">alert('not deleted Successfully!!!');</script>");
            }
        }

        protected void DataList1_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Project"].ToString());
            Label prod_ID = (Label)e.Item.FindControl("lbl_id");

            string queryStr = "DELETE FROM Products WHERE Product_ID=@ID";
            SqlCommand cmd = new SqlCommand(queryStr, con);
            int nofRow = 0;


            cmd.Parameters.AddWithValue("@ID", prod_ID.Text);
            con.Open();
            nofRow += cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            if (nofRow > 0)
            {
                Response.Write("<script type=\"text/javascript\">alert('Delete Successfully!!!');</script>");
                DataList1.EditItemIndex = -1;
                DataList1.DataBind();
            }
            else
            {
                Response.Write("<script type=\"text/javascript\">alert('not deleted Successfully!!!');</script>");
            }
        }

        protected void btn_add_product_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddProduct.aspx");
        }

        protected void btn_addpackage_Click(object sender, EventArgs e)
        {
            Response.Redirect("PackageAdd.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Project"].ToString());
            string querystring = "SELECT * FROM Products WHERE(Product_Name like '%' + @name +'%');";
            SqlCommand cmd = new SqlCommand(querystring, con);
            cmd.Parameters.AddWithValue("@name", tb_search.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds, "Product_Name");
            DataList1.DataSource = ds;
            DataList1.DataSourceID = string.Empty;
            DataList1.Height = 500;
            DataList1.DataBind();
            con.Close();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Project"].ToString());
            string querystring = "SELECT * FROM Package WHERE(package_keyword like '%' + @name +'%');";
            SqlCommand cmd = new SqlCommand(querystring, con);
            cmd.Parameters.AddWithValue("@name", tb_name2.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds, "package_keyword");
            DataList2.DataSource = ds;
            DataList2.DataSourceID = string.Empty;
            DataList2.Height = 500;
            DataList2.DataBind();
            con.Close();
        }

        protected void tb_name2_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Project"].ToString());
            string querystring = "SELECT * FROM Package WHERE(package_keyword like '%' + @name +'%');";
            SqlCommand cmd = new SqlCommand(querystring, con);
            cmd.Parameters.AddWithValue("@name", tb_name2.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds, "package_keyword");
            DataList2.DataSource = ds;
            DataList2.DataSourceID = string.Empty;
            DataList2.Height = 500;
            DataList2.DataBind();
            con.Close();
        }

        protected void tb_search_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Project"].ToString());
            string querystring = "SELECT * FROM Products WHERE(Product_Name like '%' + @name +'%');";

            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("SELECT * FROM Products WHERE Product_Name like '%" + tb_search.Text + " %' ", con);

            DataTable dt = new DataTable();
            adapt.Fill(dt);
            DataList1.DataSource = dt;

            con.Close();


        }
        protected void ddl_sortproduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_sortproduct.SelectedIndex.ToString() == "0")
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Project"].ToString());
                string querystring = "SELECT * FROM Products ORDER BY Unit_Price desc;";
                SqlCommand cmd = new SqlCommand(querystring, con);

                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds, "Unit_Price");
                DataList1.DataSource = ds;
                DataList1.DataSourceID = string.Empty;
                DataList1.Height = 500;
                DataList1.DataBind();
                con.Close();
            }
            if (ddl_sortproduct.SelectedIndex.ToString() == "1")
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Project"].ToString());
                string querystring = "SELECT * FROM Products order by Unit_Price;";
                SqlCommand cmd = new SqlCommand(querystring, con);

                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds, "Unit_Price");
                DataList1.DataSource = ds;
                DataList1.DataSourceID = string.Empty;
                DataList1.Height = 500;
                DataList1.DataBind();
                con.Close();
            }
            if (ddl_sortproduct.SelectedIndex.ToString() == "2")
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Project"].ToString());
                string querystring = "SELECT * FROM Products order by Stock_Level desc;";
                SqlCommand cmd = new SqlCommand(querystring, con);

                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds, "Stock_Level");
                DataList1.DataSource = ds;
                DataList1.DataSourceID = string.Empty;
                DataList1.Height = 500;
                DataList1.DataBind();
                con.Close();
            }
            if (ddl_sortproduct.SelectedIndex.ToString() == "3")
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Project"].ToString());
                string querystring = "SELECT * FROM Products order by Stock_Level;";
                SqlCommand cmd = new SqlCommand(querystring, con);

                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds, "Stock_Level");
                DataList1.DataSource = ds;
                DataList1.DataSourceID = string.Empty;
                DataList1.Height = 500;
                DataList1.DataBind();
                con.Close();
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex.ToString() == "0")
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Project"].ToString());
                string querystring = "SELECT * FROM Package ORDER BY package_Price desc;";
                SqlCommand cmd = new SqlCommand(querystring, con);

                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds, "package_Price");
                DataList2.DataSource = ds;
                DataList2.DataSourceID = string.Empty;
                DataList2.Height = 500;
                DataList2.DataBind();
                con.Close();
            }
            if (DropDownList1.SelectedIndex.ToString() == "1")
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Project"].ToString());
                string querystring = "SELECT * FROM Package ORDER BY package_Price;";
                SqlCommand cmd = new SqlCommand(querystring, con);

                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds, "package_Price");
                DataList2.DataSource = ds;
                DataList2.DataSourceID = string.Empty;
                DataList2.Height = 500;
                DataList2.DataBind();
                con.Close();
            }
        }



    }
}