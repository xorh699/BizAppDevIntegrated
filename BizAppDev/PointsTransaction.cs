using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BizAppDev
{
    public class PointsTransaction
    {
        string _connStr = ConfigurationManager.ConnectionStrings["Project"].ConnectionString;
        private string _PT_Reason = "";
        private string _PT_CustID = "";
        private int _PT_Points = 0;
        private DateTime _PT_Date;

        public PointsTransaction()
        {

        }
        public PointsTransaction(int PT_Points, string PT_Reason, string PT_CustID, DateTime PT_Date)
        {
            _PT_CustID = PT_CustID;
            _PT_Points = PT_Points;
            _PT_Reason = PT_Reason;
            _PT_Date = PT_Date;
        }
        public DateTime PT_Date
        {
            get { return _PT_Date; }
            set { _PT_Date = value; }
        }
        public string PT_Reason
        {
            get { return _PT_Reason; }
            set { _PT_Reason = value; }
        }

        public int PT_Points
        {
            get { return _PT_Points; }
            set { _PT_Points = value; }
        }

        public string PT_CustID
        {
            get { return _PT_CustID; }
            set { _PT_CustID = value; }
        }

        public PointsTransaction GetPointsTransaction(int PTID)
        {
            PointsTransaction PTdetail = null;
            DateTime PT_Date;
            string PT_Reason, CustID;
            int points;
            string queryStr = "Select * FROM PointsTransaction WHERE PTID = @PTID";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                PT_Reason = dr["PT_Reason"].ToString();
                points = Convert.ToInt32(dr["PT_Points"]);
                CustID = dr["PT_CustID"].ToString();
                PT_Date = Convert.ToDateTime(dr["PT_Date"]);

                PTdetail = new PointsTransaction(points,PT_Reason,CustID,PT_Date);
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return PTdetail;


        }

        public List<PointsTransaction> GetPointsTransactionAll()
        {
            List<PointsTransaction> PTList = new List<PointsTransaction>();
            DateTime PT_Date;
            int PTID, PT_Points;
            string PT_Reason, PT_CustID;
            string queryStr = "SELECT * FROM PointsTransaction Order by PTID";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                PTID = Convert.ToInt32(dr["PTID"].ToString());
                PT_CustID = dr["PT_CustID"].ToString();
                PT_Points = Convert.ToInt32(dr["PT_Points"].ToString());
                PT_Reason = dr["PT_Reason"].ToString();
                PT_Date = Convert.ToDateTime(dr["PT_Date"]);
                PointsTransaction pt = new PointsTransaction(PT_Points, PT_Reason, PT_CustID,PT_Date);
                PTList.Add(pt);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return PTList;
        }
        public int PointsTransactionInsert()
        {
            SqlConnection conn = new SqlConnection(_connStr);
            int result = 0;
            int custresult = 0;
            string queryStr = "INSERT INTO PointsTransaction(PT_Points, PT_Reason, PT_CustID, PT_Date)" + " values(@PT_Points,@PT_Reason,@PT_CustID, @PT_Date)";
            string custqueryStr = "UPDATE Customer set points = points + @PT_Points WHERE Cust_ID = @PT_CustID";
            Customer aCust = new Customer();
            Customer Cust = new Customer();
            Cust = aCust.getCustomer(this.PT_CustID);
            pointsTier pt = new pointsTier();
            pointsTier apt = new pointsTier();
            pt = apt.getPointsTier(Cust.pointTierID);
            if (this.PT_Points > 0)
            {
                string addptsqueryStr = "UPDATE Customer set lvlpoints = lvlpoints + @PT_Points WHERE Cust_ID = @PT_CustID";
                SqlCommand addptscmd = new SqlCommand(custqueryStr, conn);
                addptscmd.Parameters.AddWithValue("@PT_CustID", this.PT_CustID);
                addptscmd.Parameters.AddWithValue("@PT_Points", (this.PT_Points) * pt.pointMultiplier);
                conn.Open();
                int addptsresult = addptscmd.ExecuteNonQuery();
                conn.Close();

            }
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            SqlCommand custcmd = new SqlCommand(custqueryStr, conn);
            custcmd.Parameters.AddWithValue("@PT_CustID", this.PT_CustID);
            custcmd.Parameters.AddWithValue("@PT_Points", this.PT_Points);
            cmd.Parameters.AddWithValue("@PT_Points", this.PT_Points);
            cmd.Parameters.AddWithValue("@PT_Reason", this.PT_Reason);
            cmd.Parameters.AddWithValue("@PT_CustID", this.PT_CustID);
            cmd.Parameters.AddWithValue("@PT_Date", this.PT_Date);

            conn.Open();
            result += cmd.ExecuteNonQuery();
            custresult += custcmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }
    }

    }
