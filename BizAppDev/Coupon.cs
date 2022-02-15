using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace BizAppDev
{
    public class Coupon
    {
        string _connStr = ConfigurationManager.ConnectionStrings["Project"].ConnectionString;
        private int _CouponID = 0;
        private string _cDesc = string.Empty;
        private string _cName = string.Empty;
        private int _amount = 0;
        private int _cost = 0;
        private string _discount = string.Empty;
        private string _code = string.Empty;
        private int _validDays = 0;
        private int _validMonths = 0;
        private int _validYears = 0;
        private string _category = string.Empty;

        public Coupon()
        {

        }
        public Coupon(int couponID, string cDesc, string cName, int amount, int cost, string discount, string expiry, string code, int validDays, int validMonths, int validYears, string category)
        {
            _CouponID = couponID;
            _cDesc = cDesc;
            _cName = cName;
            _amount = amount;
            _cost = cost;
            _discount = discount;
            _code = code;
            _validDays = validDays;
            _validMonths = validMonths;
            _validYears = validYears;
            _category = category;
        }
        public string category
        {
            get { return _category; }
            set { _category = value; }
        }
        public int validDays
        {
            get { return _validDays; }
            set { _validYears = value; }
        }
        public int validMonths
        {
            get { return _validMonths; }
            set { _validMonths = value; }
        }
        public int validYears
        {
            get { return _validYears; }
            set { _validYears = value; }
        }

        public int CouponID
        {
            get { return _CouponID; }
            set { _CouponID = value; }
        }
        public string cDesc
        {
            get { return _cDesc; }
            set { _cDesc = value; }
        }
        public string cName
        {
            get { return _cName; }
            set { _cName = value; }

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
        public string discount
        {
            get { return _discount; }
            set { _discount = value; }
        }

        
        public string code
        {
            get { return _code; }
            set { _code = value; }
        }

        public int claimCoupon(string CustID,int CouponID, string code,string coupName, int coupQuantity, int coupDiscount, int validDays, int validMonths, int validYears, string coupDesc, string category)
        {
            SqlConnection conn = new SqlConnection(_connStr);

            string queryStr = "INSERT into CustCoupon " + "values(@Cust_ID,@CouponID,@code,@coupName,@coupQuantity,@coupDiscount,@coupExpiry,@coupDesc,@category)";
            string minusqueryStr = "UPDATE Coupon set amount = amount - @coupQuantity where CouponID = @CouponID";
            SqlCommand minuscmd = new SqlCommand(minusqueryStr, conn);
            minuscmd.Parameters.AddWithValue("@coupQuantity", coupQuantity);
            minuscmd.Parameters.AddWithValue("@CouponID",CouponID);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            DateTime purchaseDateTime = DateTime.Now;
            purchaseDateTime = purchaseDateTime.AddDays(validDays);
            purchaseDateTime = purchaseDateTime.AddMonths(validMonths);
            purchaseDateTime = purchaseDateTime.AddYears(validYears);
            cmd.Parameters.AddWithValue("@Cust_ID", CustID);
            cmd.Parameters.AddWithValue("@CouponID", CouponID);
            cmd.Parameters.AddWithValue("@code", code);
            cmd.Parameters.AddWithValue("@coupName", coupName);
            cmd.Parameters.AddWithValue("@coupQuantity", coupQuantity);
            cmd.Parameters.AddWithValue("@coupDiscount", coupDiscount);
            DateTime expiry = purchaseDateTime;
            cmd.Parameters.AddWithValue("@coupExpiry", expiry);
            cmd.Parameters.AddWithValue("@coupDesc", coupDesc);
            cmd.Parameters.AddWithValue("@category", category);


            conn.Open();
            int nofRow = 0;
            int minusRow = 0;
            nofRow += cmd.ExecuteNonQuery();
            minusRow += minuscmd.ExecuteNonQuery();

            conn.Close();
            return nofRow;
        }

        public Coupon getCoupon(string CustID)
        {
            Coupon coupDetail = null;
            string cDesc, cName, discount, expiry, code,category;
            int CouponID, amount, cost, vDays, vMonths, vYears;
            string queryStr = "SELECT * FROM Coupon WHERE Cust_ID = @CustID";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@CustID", CustID);


            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                cDesc = dr["cDesc"].ToString();
                cName = dr["cName"].ToString();
                discount = dr["discount"].ToString();
                expiry = dr["expiry"].ToString();
                code = dr["code"].ToString();
                CouponID = int.Parse(dr["CouponID"].ToString());
                amount = int.Parse(dr["amount"].ToString());
                cost = int.Parse(dr["cost"].ToString());
                vDays = int.Parse(dr["validDays"].ToString());
                vMonths = int.Parse(dr["validMonths"].ToString());
                vYears = int.Parse(dr["validYears"].ToString());
                category = dr["category"].ToString();



                coupDetail = new Coupon(CouponID,cDesc,cName,amount,cost,discount,expiry,code,vDays,vMonths,vYears,category);
                conn.Close();

                return coupDetail;

            }
            else
            {
                coupDetail = null;
                conn.Close();

                return coupDetail;

            }

        }
        public int useCoupon(string CustID,string code)
        {
            string queryStr = "UPDATE CustCoupon set coupQuantity = coupQuantity - 1 WHERE code = @code";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@CustID", CustID);
            cmd.Parameters.AddWithValue("@code", code);
            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();
            conn.Close();
            return nofRow;



        }

    }




    }