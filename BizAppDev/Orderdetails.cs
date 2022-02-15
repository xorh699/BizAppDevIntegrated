using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BizAppDev
{
    public class Orderdetails
    {
        string _connStr = ConfigurationManager.ConnectionStrings["Project"].ConnectionString;
        private string _serialno = null;
        private string _orderid = "";
        private string _Product_ID = "";
        private string _Product_Name = "";
        private string _price = "";
        private string _quantity = "";
        private string _grandtotal = "";
        private string _deliverydate = "";
        private string _deliveryoption = "";
        private string _OrderStatus = "";
        private string _discountedtotal = "";


        public Orderdetails()
        {
        }

        public Orderdetails(string serialno, string orderid, string Product_ID, string Product_Name, string price, string quantity, string grandtotal, string deliverydate, string deliveryoption, string OrderStatus, string discountedtotal)
        {
            _serialno = serialno;
            _orderid = orderid;
            _Product_ID = Product_ID;
            _Product_Name = Product_Name;
            _price = price;
            _quantity = quantity;
            _grandtotal = grandtotal;
            _deliverydate = deliverydate;
            _deliveryoption = deliveryoption;
            _OrderStatus = OrderStatus;
            _discountedtotal = discountedtotal;
        }

        public string serialno
        {
            get { return _serialno; }
            set { _serialno = value; }
        }
        public string orderid
        {
            get { return _orderid; }
            set { _orderid = value; }
        }

        public string Product_ID
        {
            get { return _Product_ID; }
            set { _Product_ID = value; }
        }
        public string Product_Name
        {
            get { return _Product_Name; }
            set { _Product_Name = value; }
        }
        public string price
        {
            get { return _price; }
            set { _price = value; }
        }
        public string quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        public string grandtotal
        {
            get { return _grandtotal; }
            set { _grandtotal = value; }
        }
        public string deliverydate
        {
            get { return _deliverydate; }
            set { _deliverydate = value; }
        }

        public string deliveryoption
        {
            get { return _deliveryoption; }
            set { _deliveryoption = value; }
        }

        public string OrderStatus
        {
            get { return _OrderStatus; }
            set { _OrderStatus = value; }
        }

        public string discountedtotal
        {
            get { return _discountedtotal; }
            set { _discountedtotal = value; }
        }

        public int OrderdetailsDelete(string orderid)
        {
            string queryStr = "DELETE FROM Orderdetails WHERE orderid=@orderid";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@orderid", orderid);
            conn.Open();
            int nofRow = 0;
            nofRow += cmd.ExecuteNonQuery();
            conn.Close();
            return nofRow;
        }

        public List<Orderdetails> getAllOrder()
        {
            List<Orderdetails> OrderList = new List<Orderdetails>();

            string orderid, Product_ID, Product_Name, price, quantity, grandtotal, deliverydate, deliveryoption, OrderStatus;

            string queryStr = "SELECT * FROM Orderdetails Order By orderid";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                serialno = dr["serialno"].ToString();
                orderid = dr["orderid"].ToString();
                Product_ID = dr["Product_ID"].ToString();
                Product_Name = dr["Product_Name"].ToString();
                price = dr["price"].ToString();
                quantity = dr["quantity"].ToString();
                grandtotal = dr["grandtotal"].ToString();
                deliverydate = dr["deliverydate"].ToString();
                deliveryoption = dr["deliveryoption"].ToString();
                OrderStatus = dr["OrderStatus"].ToString();
                discountedtotal = dr["discountedtotal"].ToString();
                Orderdetails o = new Orderdetails(serialno, orderid, Product_ID, Product_Name, price, quantity, grandtotal, deliverydate, deliveryoption, OrderStatus, discountedtotal);
                OrderList.Add(o);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return OrderList;
        }

        public int OrderAcceptance(string orderid, string OrderStatus)
        {
            string queryStr = "UPDATE Orderdetails SET" +
                       //" Product_ID = @Product_ID, " +                   
                       " OrderStatus = @OrderStatus " +
                       " WHERE orderid = @orderid";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@orderid", orderid);
            cmd.Parameters.AddWithValue("@OrderStatus", "Accepted");

            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();

            conn.Close();

            return nofRow;
        }//end Update

        public List<Orderdetails> PendingOrder()
        {
            List<Orderdetails> OrderList = new List<Orderdetails>();

            string orderid, Product_ID, Product_Name, price, quantity, grandtotal, deliverydate, deliveryoption, OrderStatus;

            string queryStr = "SELECT * FROM Orderdetails WHERE OrderStatus = 'Pending'";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                serialno = dr["serialno"].ToString();
                orderid = dr["orderid"].ToString();
                Product_ID = dr["Product_ID"].ToString();
                Product_Name = dr["Product_Name"].ToString();
                price = dr["price"].ToString();
                quantity = dr["quantity"].ToString();
                grandtotal = dr["grandtotal"].ToString();
                deliverydate = dr["deliverydate"].ToString();
                deliveryoption = dr["deliveryoption"].ToString();
                OrderStatus = dr["OrderStatus"].ToString();
                discountedtotal = dr["discountedtotal"].ToString();

                Orderdetails e = new Orderdetails(serialno, orderid, Product_ID, Product_Name, price, quantity, grandtotal, deliverydate, deliveryoption, OrderStatus, discountedtotal);
                OrderList.Add(e);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return OrderList;
        }

        public List<Orderdetails> AcceptedOrder()
        {
            List<Orderdetails> OrderList = new List<Orderdetails>();

            string orderid, Product_ID, Product_Name, price, quantity, grandtotal, deliverydate, deliveryoption, OrderStatus;

            string queryStr = "SELECT * FROM Orderdetails WHERE OrderStatus = 'Accepted'";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                serialno = dr["serialno"].ToString();
                orderid = dr["orderid"].ToString();
                Product_ID = dr["Product_ID"].ToString();
                Product_Name = dr["Product_Name"].ToString();
                price = dr["price"].ToString();
                quantity = dr["quantity"].ToString();
                grandtotal = dr["grandtotal"].ToString();
                deliverydate = dr["deliverydate"].ToString();
                deliveryoption = dr["deliveryoption"].ToString();
                OrderStatus = dr["OrderStatus"].ToString();
                discountedtotal = dr["discountedtotal"].ToString();

                Orderdetails e = new Orderdetails(serialno, orderid, Product_ID, Product_Name, price, quantity, grandtotal, deliverydate, deliveryoption, OrderStatus, discountedtotal);
                OrderList.Add(e);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return OrderList;
        }
    }
}