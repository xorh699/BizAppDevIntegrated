using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BizAppDev
{
    public class Priests
    {
        string _connStr = ConfigurationManager.ConnectionStrings["ServicesContext"].ConnectionString;

        private string _CustID = "";
        private string _hpID = null;
        private string _hpLocation = "";
        private string _hpDate = "";

        public Priests()
        {
        }

        public Priests(string custID, string hpID, string hpLocation, string hpDate)
        {
            _CustID = custID;
            _hpID = hpID;
            _hpLocation = hpLocation;
            _hpDate = hpDate;
        }
        public Priests(string custID, string hpLocation, string hpDate)
       : this(custID ,null, hpLocation, hpDate)
        {
        }
        public string CustomerID
        {
            get { return _CustID; }
            set { _CustID = value; }
        }
        public string ID
        {
            get { return _hpID; }
            set { _hpID = value; }
        }
        public string Location
        {
            get { return _hpLocation; }
            set { _hpLocation = value; }
        }
        public string Date
        {
            get { return _hpDate; }
            set { _hpDate = value; }
        }
        public int PriestInsert()
        {
            int result = 0;

            string queryStr = "INSERT INTO HirePriest(CustomerID,Location,Date)"
                + " values (@custID,@location, @date)";
            try
            {
                SqlConnection conn = new SqlConnection(_connStr);
                SqlCommand cmd = new SqlCommand(queryStr, conn);
                cmd.Parameters.AddWithValue("@custID", this.CustomerID);
                cmd.Parameters.AddWithValue("@location", this.Location);
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
        public List<Priests> GetPriest(string CustID)
        {
            List<Priests> PriestList = new List<Priests>();

            string custID, hpID, hpLocation, hpDate;

            string queryStr = "SELECT * FROM HirePriest WHERE CustomerID = @custID ";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@custID", CustID);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                custID = dr["CustomerID"].ToString();
                hpID = dr["ID"].ToString();
                hpLocation = dr["Location"].ToString();
                hpDate = dr["Date"].ToString();
                Priests a = new Priests(custID,hpID, hpLocation, hpDate);
                PriestList.Add(a);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return PriestList;
        }
        public int PriestDelete(string hpID)
        {
            string queryStr = "DELETE FROM HirePriest WHERE ID = @hpID";
            try
            {
                SqlConnection conn = new SqlConnection(_connStr);
                SqlCommand cmd = new SqlCommand(queryStr, conn);
                cmd.Parameters.AddWithValue("@hpID", hpID);
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
        public int PriestUpdate(string auID, string auLocation ,string auDate)
        {
            string queryStr = "UPDATE HirePriest SET" +
                " Location = @hpLocation, " +
                " Date = @hpDate " +
                " WHERE ID = @hpID";
            try
            {
                SqlConnection conn = new SqlConnection(_connStr);
                SqlCommand cmd = new SqlCommand(queryStr, conn);
                cmd.Parameters.AddWithValue("@hpID", auID);
                cmd.Parameters.AddWithValue("@hpLocation", auLocation);
                cmd.Parameters.AddWithValue("@hpDate", auDate);

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