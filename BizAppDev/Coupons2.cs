using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace BizAppDev
{
    public class Coupons2
    {
        string _connStr = ConfigurationManager.ConnectionStrings["Project"].ConnectionString;
        private string _coupID = null;
        private string _couponName = string.Empty;
        private string _couponDesc = ""; // this is another way to specify empty string
        private int _amount = 0;
        private int _cost = 0;
        private decimal _discount = 0;
        private int _validdays = 0;
        private int _validmonths = 0;
        private int _validyears = 0;
        private string _category = "";
        public Coupons2()
        {

        }

        public Coupons2(string couponID, string couponName, string couponDesc, int amount, int cost, decimal discount, int validdays, int validmonths, int validyears, string category)
        {
            _coupID = couponID;
            _couponName = couponName;
            _couponDesc = couponDesc;
            _amount = amount;
            _cost = cost;
            _discount = discount;
            _validdays = validdays;
            _validmonths = validmonths;
            _validyears = validyears;
            _category = category;
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
            get { return _coupID; }
            set { _coupID = value; }
        }
        public string couponName
        {
            get { return _couponName; }
            set { _couponName = value; }
        }
        public string couponDesc
        {
            get { return _couponDesc; }
            set { _couponDesc = value; }
        }
        public int amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        public int cost
        {
            get { return _cost; }
            set { _cost = value; }
        }

        public decimal discount
        {
            get { return _discount; }
            set { _discount = value; }
        }

        public int validDays
        {
            get { return _validdays; }
            set { _validdays = value; }
        }

        public int validMonths
        {
            get { return _validmonths; }
            set { _validmonths = value; }
        }

        public int validYears
        {
            get { return _validyears; }
            set { _validyears = value; }
        }
        public string category
        {
            get { return _category; }
            set { _category = value; }
        }
        public Coupons2 getCoupon(string couponID)
        {

            Coupons2 coupDetail = null;

            string couponName, couponDesc, category;
            decimal couponDiscount;
            int amount, cost, validDays, validMonths, validYears;


            string queryStr = "SELECT * FROM Coupon WHERE couponID = @coupon_ID";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@coupon_ID", couponID);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                couponName = dr["cName"].ToString();
                couponDesc = dr["cDesc"].ToString();
                couponDiscount = decimal.Parse(dr["discount"].ToString());
                amount = int.Parse(dr["amount"].ToString());
                cost = int.Parse(dr["cost"].ToString());
                validDays = int.Parse(dr["validDays"].ToString());
                validMonths = int.Parse(dr["validMonths"].ToString());
                validYears = int.Parse(dr["validYears"].ToString());
                category = dr["Category"].ToString();

                coupDetail = new Coupons2(couponID, couponName, couponDesc, amount, cost, couponDiscount, validDays, validMonths, validYears, category);
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

        public List<Coupons2> getCoupAll()
        {
            List<Coupons2> coupList = new List<Coupons2>();

            string couponID, couponName, couponDesc, category;
            decimal couponDiscount;
            int amount, cost, validDays, validMonths, validYears;

            string queryStr = "SELECT * FROM Coupon Order By cName";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                couponID = dr["couponID"].ToString();
                couponName = dr["cName"].ToString();
                couponDesc = dr["cDesc"].ToString();
                couponDiscount = decimal.Parse(dr["discount"].ToString());
                amount = int.Parse(dr["amount"].ToString());
                cost = int.Parse(dr["cost"].ToString());
                validDays = int.Parse(dr["validDays"].ToString());
                validMonths = int.Parse(dr["validMonths"].ToString());
                validYears = int.Parse(dr["validYears"].ToString());
                category = dr["Category"].ToString();
                Coupons2 a = new Coupons2(couponID, couponName, couponDesc, amount, cost, couponDiscount, validDays, validMonths, validYears, category);
                coupList.Add(a);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return coupList;
        }

        public int CouponDelete(string ID)
        {
            string queryStr = "DELETE FROM Coupon WHERE couponID=@ID";
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

            string queryStr = "INSERT INTO Coupon(couponID, cName, cDesc, amount, cost, discount, validDays, validMonths, validYears, Category)"
                + " values (@id,@name, @desc, @amount, @cost, @discount, @days, @months, @years, @category)";
            //+ "values (@Product_ID, @Product_Name, @Product_Desc, @Unit_Price, @Product_Image,@Stock_Level)";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@id", this.couponID);
            cmd.Parameters.AddWithValue("@name", this.couponName);
            cmd.Parameters.AddWithValue("@desc", this.couponDesc);
            cmd.Parameters.AddWithValue("@amount", this.amount);
            cmd.Parameters.AddWithValue("@cost", this.cost);
            cmd.Parameters.AddWithValue("@discount", this.discount);
            cmd.Parameters.AddWithValue("@days", this.validDays);
            cmd.Parameters.AddWithValue("@months", this.validMonths);
            cmd.Parameters.AddWithValue("@years", this.validYears);
            cmd.Parameters.AddWithValue("@category", this.category);

            conn.Open();
            result += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
            conn.Close();

            return result;
        }//end Insert

        public int CoupUpdate(string cId, string cName, string desc, int amount, decimal discount, int validDays, int validMonths, int validYears, string category)
        {
            string queryStr = "UPDATE Coupon SET" +
                //" Product_ID = @productID, " +
                " cName = @cName, " +
                " cDesc = @desc, " +
                "amount = @amount, " +
                "validDays = @days, " +
                "validMonths = @month, " +
                "validYears = @years, " +
                "Category = @category, " +

                "discount = @discount" +
                " WHERE couponID = @cId";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@cId", cId);
            cmd.Parameters.AddWithValue("@cName", cName);
            cmd.Parameters.AddWithValue("@desc", desc);
            cmd.Parameters.AddWithValue("@amount", amount);
            cmd.Parameters.AddWithValue("@days", validDays);
            cmd.Parameters.AddWithValue("@month", validMonths);
            cmd.Parameters.AddWithValue("@year", validYears);
            cmd.Parameters.AddWithValue("@category", category);

            cmd.Parameters.AddWithValue("@discount", discount);

            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();

            conn.Close();

            return nofRow;

        }
        public List<Coupons2> nomorecoup()
        {
            List<Coupons2> coupList = new List<Coupons2>();

            string couponID, couponName, couponDesc, category;
            decimal couponDiscount;
            int amount, cost, validDays, validMonths, validYears;


            string queryStr = "SELECT * FROM Coupon WHERE amount = 0";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);


            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                couponID = dr["couponID"].ToString();
                couponName = dr["cName"].ToString();
                couponDesc = dr["cDesc"].ToString();
                category = dr["Category"].ToString();
                couponDiscount = decimal.Parse(dr["discount"].ToString());
                amount = int.Parse(dr["amount"].ToString());
                cost = int.Parse(dr["cost"].ToString());
                validDays = int.Parse(dr["validDays"].ToString());
                validMonths = int.Parse(dr["validMonths"].ToString());
                validYears = int.Parse(dr["validYears"].ToString());
                Coupons2 a = new Coupons2(couponID, couponName, couponDesc, amount, cost, couponDiscount, validDays, validMonths, validYears, category);
                coupList.Add(a);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return coupList;
        }
        public List<Coupons2> somemorecoup()
        {
            List<Coupons2> coupList = new List<Coupons2>();

            string couponID, couponName, couponDesc, category;
            decimal couponDiscount;
            int amount, cost, validDays, validMonths, validYears;

            string queryStr = "SELECT * FROM Coupon WHERE amount > 0";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);


            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                couponID = dr["couponID"].ToString();
                couponName = dr["cName"].ToString();
                couponDesc = dr["cDesc"].ToString();
                category = dr["Category"].ToString();
                couponDiscount = decimal.Parse(dr["discount"].ToString());
                amount = int.Parse(dr["amount"].ToString());
                cost = int.Parse(dr["cost"].ToString());
                validDays = int.Parse(dr["validDays"].ToString());
                validMonths = int.Parse(dr["validMonths"].ToString());
                validYears = int.Parse(dr["validYears"].ToString());
                Coupons2 a = new Coupons2(couponID, couponName, couponDesc, amount, cost, couponDiscount, validDays, validMonths, validYears, category);
                coupList.Add(a);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return coupList;
        }

        public List<Coupons2> getavailablecoupons()
        {
            List<Coupons2> coupList = new List<Coupons2>();

            string couponID, couponName, couponDesc, category;
            decimal couponDiscount;
            int amount, cost, validDays, validMonths, validYears;

            string queryStr = "SELECT * FROM Coupon where amount > 0";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);


            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                couponID = dr["couponID"].ToString();
                couponName = dr["cName"].ToString();
                couponDesc = dr["cDesc"].ToString();
                category = dr["Category"].ToString();
                couponDiscount = decimal.Parse(dr["discount"].ToString());
                amount = int.Parse(dr["amount"].ToString());
                cost = int.Parse(dr["cost"].ToString());
                validDays = int.Parse(dr["validDays"].ToString());
                validMonths = int.Parse(dr["validMonths"].ToString());
                validYears = int.Parse(dr["validYears"].ToString());
                Coupons2 a = new Coupons2(couponID, couponName, couponDesc, amount, cost, couponDiscount, validDays, validMonths, validYears, category);
                coupList.Add(a);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return coupList;
        }
        public List<Coupons2> getredeemedcoupons()
        {
            List<Coupons2> coupList = new List<Coupons2>();

            string couponID, couponName, couponDesc, category;
            decimal couponDiscount;
            int amount, cost, validDays, validMonths, validYears;

            string queryStr = "SELECT * FROM Coupon where amount = 0";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                couponID = dr["couponID"].ToString();
                couponName = dr["cName"].ToString();
                couponDesc = dr["cDesc"].ToString();
                category = dr["Category"].ToString();
                couponDiscount = decimal.Parse(dr["discount"].ToString());
                amount = int.Parse(dr["amount"].ToString());
                cost = int.Parse(dr["cost"].ToString());
                validDays = int.Parse(dr["validDays"].ToString());
                validMonths = int.Parse(dr["validMonths"].ToString());
                validYears = int.Parse(dr["validYears"].ToString());
                Coupons2 a = new Coupons2(couponID, couponName, couponDesc, amount, cost, couponDiscount, validDays, validMonths, validYears, category);
                coupList.Add(a);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return coupList;
        }




    }
}

