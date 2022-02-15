using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace BizAppDev
{
    public class Coupons
    {
        string _connStr = ConfigurationManager.ConnectionStrings["Project"].ConnectionString;
        private string _couponID = null;
        private string _couponName = string.Empty;
        private string _couponstartDate = ""; // this is another way to specify empty string
        private string _couponendDate = "";
        private string _couponDesc = "";
        private decimal _couponamt = 0;

        public Coupons()
        {

        }

        public Coupons(string couponID, string couponName, string couponstartDate, string couponendDate, string couponDesc, decimal couponAmt)
        {
            _couponID = couponID;
            _couponName = couponName;
            _couponstartDate = couponstartDate;
            _couponendDate = couponendDate;
            _couponDesc = couponDesc;
            _couponamt = couponAmt;
        }

        /*public Coupons(string couponID, string couponName, 
                        string couponstartDate, string couponendDate, string couponDesc): this(null, couponName, couponstartDate, couponendDate, couponDesc)
        {
        }

        public Coupons(string couponID) : this(couponID, "", "", "", "")
        {

        }*/
        public string couponID
        {
            get { return _couponID; }
            set { _couponID = value; }
        }
        public string couponName
        {
            get { return _couponName; }
            set { _couponName = value; }
        }
        public string couponendDate
        {
            get { return _couponendDate; }
            set { _couponendDate = value; }
        }
        public string couponstartDate
        {
            get { return _couponstartDate; }
            set { _couponstartDate = value; }
        }
        public string couponDesc
        {
            get { return _couponDesc; }
            set { _couponDesc = value; }
        }

        public decimal couponAmt
        {
            get { return _couponamt; }
            set { _couponamt = value; }
        }
        public Coupons getCoupon(string couponID)
        {

            Coupons coupDetail = null;

            string couponName, couponDesc, couponstartDate, couponendDate;
            decimal couponAmt;

            string queryStr = "SELECT * FROM Coupons WHERE coupon_ID = @coupon_ID";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@coupon_ID", couponID);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                couponName = dr["coupon_Name"].ToString();
                couponDesc = dr["coup_Desc"].ToString();
                couponstartDate = dr["coupon_startDate"].ToString();
                couponendDate = dr["coupon_endDate"].ToString();
                couponAmt = Decimal.Parse(dr["coup_disccountamt"].ToString());


                coupDetail = new Coupons(couponID, couponName, couponstartDate, couponendDate, couponDesc, couponAmt);
            }
            else
            {
                coupDetail = null;
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return coupDetail;
        }

        public List<Coupons> getCoupAll()
        {
            List<Coupons> coupList = new List<Coupons>();

            string couponID, couponName, couponDesc, couponstartDate, couponendDate;
            decimal couponAmt;

            string queryStr = "SELECT * FROM Coupons Order By coupon_Name";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                couponID = dr["coupon_ID"].ToString();
                couponName = dr["coupon_Name"].ToString();
                couponDesc = dr["coup_Desc"].ToString();
                couponstartDate = dr["coupon_startDate"].ToString();
                couponendDate = dr["coupon_endDate"].ToString();
                couponAmt = Decimal.Parse(dr["coup_disccountamt"].ToString());
                Coupons a = new Coupons(couponID, couponName, couponstartDate, couponendDate, couponDesc, couponAmt);
                coupList.Add(a);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return coupList;
        }

        public int CouponDelete(string ID)
        {
            string queryStr = "DELETE FROM Coupons WHERE coupon_ID=@ID";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@ID", ID);
            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();
            //  Response.Write("<script>alert('Delete successful');</script>");
            conn.Close();
            return nofRow;

        }//end Delete

        public int CouponInsert()
        {

            // string msg = null;
            int result = 0;

            string queryStr = "INSERT INTO Coupons(coupon_ID,coupon_Name, coupon_startDate, coupon_endDate,coup_Desc, coup_disccountamt)"
                + " values (@coupon_ID,@coupon_Name, @coupon_startDate, @coupon_endDate, @coup_Desc, @coup_Amt)";
            //+ "values (@Product_ID, @Product_Name, @Product_Desc, @Unit_Price, @Product_Image,@Stock_Level)";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@coupon_ID", this.couponID);
            cmd.Parameters.AddWithValue("@coupon_Name", this.couponName);
            cmd.Parameters.AddWithValue("@coupon_startDate", this.couponstartDate);
            cmd.Parameters.AddWithValue("@coupon_endDate", this.couponendDate);
            cmd.Parameters.AddWithValue("@coup_Desc", this.couponDesc);
            cmd.Parameters.AddWithValue("@coup_Amt", this.couponAmt);

            conn.Open();
            result += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
            conn.Close();

            return result;
        }//end Insert

        public int CoupUpdate(string cId, string cName, string cstartDate, string cEndDate, decimal cAmt)
        {
            string queryStr = "UPDATE Coupons SET" +
                //" Product_ID = @productID, " +
                " coupon_Name = @cName, " +
                " coupon_startDate = @cstartdate, " +
                "coupon_endDate = @cenddate, " +
                "coup_disccountamt = @cAmt " +

                " WHERE coupon_ID = @cId";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@cId", cId);
            cmd.Parameters.AddWithValue("@cName", cName);
            cmd.Parameters.AddWithValue("@cstartdate", cstartDate);
            cmd.Parameters.AddWithValue("@cenddate", cEndDate);

            cmd.Parameters.AddWithValue("@cAmt", cAmt);

            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();

            conn.Close();

            return nofRow;

        }
        public List<Coupons> afterfilter()
        {
            List<Coupons> coupList = new List<Coupons>();

            string couponID, couponName, couponDesc, couponstartDate, couponendDate;
            decimal couponAmt;


            string queryStr = "SELECT * FROM Coupons WHERE coupon_startDate < @date AND coupon_endDate >= @date1";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@date", DateTime.Now);
            cmd.Parameters.AddWithValue("@date1", DateTime.Now);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                couponID = dr["coupon_ID"].ToString();
                couponName = dr["coupon_Name"].ToString();
                couponDesc = dr["coup_Desc"].ToString();
                couponstartDate = dr["coupon_startDate"].ToString();
                couponendDate = dr["coupon_endDate"].ToString();
                couponAmt = Decimal.Parse(dr["coup_disccountamt"].ToString());
                Coupons a = new Coupons(couponID, couponName, couponstartDate, couponendDate, couponDesc, couponAmt);
                coupList.Add(a);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return coupList;
        }
        public List<Coupons> pastcoupons()
        {
            List<Coupons> coupList = new List<Coupons>();

            string couponID, couponName, couponDesc, couponstartDate, couponendDate;
            decimal couponAmt;

            string queryStr = "SELECT * FROM Coupons WHERE coupon_endDate < @date";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@date", DateTime.Now);


            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                couponID = dr["coupon_ID"].ToString();
                couponName = dr["coupon_Name"].ToString();
                couponDesc = dr["coup_Desc"].ToString();
                couponstartDate = dr["coupon_startDate"].ToString();
                couponendDate = dr["coupon_endDate"].ToString();
                couponAmt = Decimal.Parse(dr["coup_disccountamt"].ToString());
                Coupons a = new Coupons(couponID, couponName, couponstartDate, couponendDate, couponDesc, couponAmt);
                coupList.Add(a);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return coupList;
        }

        public List<Coupons> upcomingcoupon()
        {
            List<Coupons> coupList = new List<Coupons>();

            string couponID, couponName, couponDesc, couponstartDate, couponendDate;
            decimal couponAmt;

            string queryStr = "SELECT * FROM Coupons WHERE coupon_startDate > @date";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@date", DateTime.Now);


            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                couponID = dr["coupon_ID"].ToString();
                couponName = dr["coupon_Name"].ToString();
                couponDesc = dr["coup_Desc"].ToString();
                couponstartDate = dr["coupon_startDate"].ToString();
                couponendDate = dr["coupon_endDate"].ToString();
                couponAmt = Decimal.Parse(dr["coup_disccountamt"].ToString());
                Coupons a = new Coupons(couponID, couponName, couponstartDate, couponendDate, couponDesc, couponAmt);
                coupList.Add(a);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return coupList;
        }



    }
}