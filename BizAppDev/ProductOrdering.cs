using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace BizAppDev
{
    public class ProductOrdering
    {
        string _connStr = ConfigurationManager.ConnectionStrings["Project"].ConnectionString;
       
        private string _orderid = null;
        private string _orderquantity = "";
        private string _orderdate = ""; // this is another way to specify empty string
        private string _status = "";
        private string _prodid = "";

        // Default constructor
        public ProductOrdering()
        {
        }

        // Constructor that take in all data required to build a Product object
        public ProductOrdering(string orderid, string orderdate,
                       string orderquantity, string prodid, string status)
        {
            _orderid = orderid;
            _orderquantity = orderquantity;
            _orderdate = orderdate;
            _prodid = prodid;
            _status = status;
        }

        // Constructor that take in all except product ID


        // Get/Set the attributes of the Product object.
        // Note the attribute name (e.g. Product_ID) is same as the actual database field name.
        // This is for ease of referencing.
        public string order_ID
        {
            get { return _orderid; }
            set { _orderid = value; }
        }
        public string order_Quantity
        {
            get { return _orderquantity; }
            set { _orderquantity = value; }
        }
        public string order_Date
        {
            get { return _orderdate; }
            set { _orderdate = value; }
        }

        public string prod_id
        {
            get { return _prodid; }
            set { _prodid = value; }
        }

        public string status
        {
            get { return _status; }
            set { _status = value; }
        }
        public int orderInsert()
        {

            // string msg = null;
            int result = 0;

            string queryStr = "INSERT INTO OrderingProducts(id,prodID, quantity, date, status)"
                + " values (@id, @prodID, @quantity, @delivery, @status)";
            //+ "values (@Product_ID, @Product_Name, @Product_Desc, @Unit_Price, @Product_Image,@Stock_Level)";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@id", this.order_ID);
            cmd.Parameters.AddWithValue("@prodID", this.prod_id);
            cmd.Parameters.AddWithValue("@quantity", this.order_Quantity);
            cmd.Parameters.AddWithValue("@delivery", this.order_Date);
            cmd.Parameters.AddWithValue("@status", "Not Completed");


            conn.Open();
            result += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
            conn.Close();

            return result;
        }//end Insert
        public List<ProductOrdering> getOrderAll()
        {
            List<ProductOrdering> orderList = new List<ProductOrdering>();

            string id, prod_name, delivery, stock, status;

            string queryStr = "select * from OrderingProducts o INNER JOIN Products p on o.prodID = p.Product_ID order by Product_Name";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                id = dr["id"].ToString();
                stock = dr["quantity"].ToString();
                delivery = dr["date"].ToString();

                prod_name = dr["Product_Name"].ToString();
                status = dr["status"].ToString();

                ProductOrdering a = new ProductOrdering(id, delivery, stock, prod_name, status);
                orderList.Add(a);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return orderList;
        }
        public int UpdateOrder(string quantity, string prodName)
        {
            string queryStr = "UPDATE Products SET" +
                //" Product_ID = @productID, " +
                " Stock_Level = Stock_Level + @quantity " +
                "WHERE Product_Name = @prodName";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.Parameters.AddWithValue("@prodName", prodName);

            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();

            conn.Close();
            return nofRow;


        }//end Update

        public int UpdateStatus(string status, string orderID)
        {
            string queryStr = "UPDATE OrderingProducts SET" +
                //" Product_ID = @productID, " +
                " status = 'Completed' " +
                "WHERE id = @id";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            cmd.Parameters.AddWithValue("@id", orderID);

            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();

            conn.Close();
            return nofRow;


        }//end U

        public ProductOrdering getStatus(string offer_ID)
        {

            ProductOrdering orderdetails = null;

            string id, prod_id, delivery, stock, status;


            string queryStr = "SELECT * FROM OrderingProducts WHERE id = @id";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@id", offer_ID);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                id = dr["id"].ToString();
                prod_id = dr["prodID"].ToString();
                delivery = dr["date"].ToString();
                stock = dr["quantity"].ToString();
                status = dr["status"].ToString();

                orderdetails = new ProductOrdering(offer_ID, delivery, stock, prod_id, status);
            }
            else
            {
                orderdetails = null;
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return orderdetails;
        }

    }
}