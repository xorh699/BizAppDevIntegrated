using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BizAppDev
{
    public class Advisor
    {
        string _connStr = ConfigurationManager.ConnectionStrings["ServicesContext"].ConnectionString;

        private string _CustID = "";
        private string _haID = null;
        private string _haDescription = "";
        private string _haMode = ""; 
        private string _haDate = "";

        public Advisor()
        {
        }

        public Advisor(string CustID,string haID,string haDescription, string haMode, string haDate)
        {
            _CustID = CustID;
            _haID = haID;
            _haDescription = haDescription;
            _haMode = haMode;
            _haDate = haDate;
        }
        public Advisor(string CustID,string haDescription, string haMode, string haDate)
        : this(CustID,null,haDescription, haMode, haDate)
        {
        }
        public string CustID
        {
            get { return _CustID; }
            set { _CustID = value; }
        }
        public string ID
        {
            get { return _haID; }
            set { _haID = value; }
        }
        public string Description
        {
            get { return _haDescription; }
            set { _haDescription = value; }
        }
        public string Mode
        {
            get { return _haMode; }
            set { _haMode = value; }
        }
        public string Date
        {
            get { return _haDate; }
            set { _haDate = value; }
        }
        public int AdvisorInsert()
        {
            int result = 0;

            string queryStr = "INSERT INTO AdvisorHire(CustID,Description,Mode,Date)"
                + " values (@custID,@desc, @mode, @date)";
            try
            {
                SqlConnection conn = new SqlConnection(_connStr);
                SqlCommand cmd = new SqlCommand(queryStr, conn);
                cmd.Parameters.AddWithValue("@custID", this.CustID);
                cmd.Parameters.AddWithValue("@desc", this.Description);
                cmd.Parameters.AddWithValue("@mode", this.Mode);
                cmd.Parameters.AddWithValue("@date", this.Date);

                conn.Open();
                result += cmd.ExecuteNonQuery();
                conn.Close();

                return result;
            }
            catch(SqlException ex)
            {
                return 0;
            }

        }
     
        public List<Advisor> GetAdvisor(string CustID)
        {
            List<Advisor> AdvisorList = new List<Advisor>();

            string haID,haDescription, haMode, haDate;

            string queryStr = "SELECT * FROM AdvisorHire WHERE CustID = @custID";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@custID", CustID);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                CustID = dr["CustID"].ToString();
                haID = dr["ID"].ToString();
                haDescription = dr["Description"].ToString();
                haMode = dr["Mode"].ToString();
                haDate = dr["Date"].ToString();
                Advisor a = new Advisor(CustID,haID, haDescription, haMode, haDate);
                AdvisorList.Add(a);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return AdvisorList;
        }
        public int AdvisorDelete(string haID)
        {
            string queryStr = "DELETE FROM AdvisorHire WHERE ID = @haID";
            try
            {
                SqlConnection conn = new SqlConnection(_connStr);
                SqlCommand cmd = new SqlCommand(queryStr, conn);
                cmd.Parameters.AddWithValue("@haID", haID);
                conn.Open();
                int nofRow = 0;
                nofRow = cmd.ExecuteNonQuery();
                conn.Close();
                return nofRow;
            }
            catch(SqlException ex)
            {
                return 0;
            }

        }
        public int AdvisorUpdate(string auID, string auDesc, string auMode, string auDate)
        {
            string queryStr = "UPDATE AdvisorHire SET" +
                " Description = @haDescription, " +
                " Mode = @haMode, " +
                " Date = @haDate " +
                " WHERE ID = @haID";
            try
            {
                SqlConnection conn = new SqlConnection(_connStr);
                SqlCommand cmd = new SqlCommand(queryStr, conn);
                cmd.Parameters.AddWithValue("@haID", auID);
                cmd.Parameters.AddWithValue("@haDescription", auDesc);
                cmd.Parameters.AddWithValue("@haMode", auMode);
                cmd.Parameters.AddWithValue("@haDate", auDate);

                conn.Open();
                int nofRow = 0;
                nofRow = cmd.ExecuteNonQuery();

                conn.Close();

                return nofRow;
            }
            catch(SqlException ex)
            {
                return 0;
            }

        }
    }
}