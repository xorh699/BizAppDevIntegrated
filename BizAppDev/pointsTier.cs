using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace BizAppDev
{
    public class pointsTier
    {
        string _connStr = ConfigurationManager.ConnectionStrings["Project"].ConnectionString;
        private int _pointTierID = 0;
        private string _name = string.Empty;
        private string _descr = string.Empty;
        private int _price = 0;
        private decimal _pointMultiplier = 1;

        public pointsTier()
        {

        }
        public pointsTier(int pointTierID,string name, string descr, int price, decimal pointMultiplier)
        {
            _pointTierID = pointTierID;
            _name = name;
            _descr = descr;
            _price = price;
            _pointMultiplier = pointMultiplier;

        }
        public pointsTier(string name, string descr, int price, decimal pointMultiplier)
        {
            _name = name;
            _descr = descr;
            _price = price;
            _pointMultiplier = pointMultiplier;

        }

        public decimal pointMultiplier
        {
            get { return _pointMultiplier; }
            set { _pointMultiplier = value; }
        }
        public int pointTierID
        {
            get { return _pointTierID; }
            set { _pointTierID = value; }
        }

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string descr
        {
            get { return _descr; }
            set { _descr = value; }
        }

        public int price
        {
            get { return _price; }
            set { _price = value; }
        }




        public pointsTier getPointsTier(int pointTierID)
        {
            pointsTier tierDetail = null;
            string name, descr;
            int price;
            decimal pointMultiplier;
            string queryStr = "SELECT * FROM PointTiers WHERE pointTierID = @pointTierID";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@pointTierID", pointTierID);


            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                name = dr["name"].ToString();
                descr = dr["descr"].ToString();
                price = int.Parse(dr["price"].ToString());
                pointMultiplier = decimal.Parse(dr["price"].ToString());


                tierDetail = new pointsTier(name, descr, price,pointMultiplier);
                conn.Close();

                return tierDetail;

            }
            else
            {
                tierDetail = null;
                conn.Close();

                return tierDetail;

            }

        }
        public int TierDelete(int pointTierID)
        {
            string queryStr = "DELETE FROM PointTiers WHERE pointTierID=@pointTierID";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@pointTierID", pointTierID);
            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();
            //  Response.Write("<script>alert('Delete successful');</script>");
            conn.Close();
            return nofRow;

        }
        public int TierUpdate(int pointTierID,string name, string descr, int price,decimal pointMultiplier)
        {
            string queryStr = "UPDATE PointTiers SET" +
                " name = @name," +
                " pointMultiplier = @pointMultiplier," +
                " descr = @descr," +
                " price = @price"+

                " WHERE pointTierID = @pointTierID";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@pointTierID", pointTierID);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@descr", descr);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@pointMultiplier", pointMultiplier);


            conn.Open();
            int noofrow = 0;
            noofrow = cmd.ExecuteNonQuery();
            conn.Close();
            return noofrow;

        }
        public List<pointsTier> getTiersAll()
        {
            List<pointsTier> tierList = new List<pointsTier>();

            string name, descr;
            int pointTierID,price;
            decimal pointMultiplier;
            string queryStr = "SELECT * FROM PointTiers Order By pointTierID";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                name = dr["name"].ToString();
                descr = dr["descr"].ToString();
                pointTierID = int.Parse(dr["pointTierID"].ToString());
                price = int.Parse(dr["price"].ToString());
                pointMultiplier = decimal.Parse(dr["pointMultiplier"].ToString());
                pointsTier a = new pointsTier(pointTierID,name,descr,price,pointMultiplier);    
                tierList.Add(a);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return tierList;
        }

    }
}