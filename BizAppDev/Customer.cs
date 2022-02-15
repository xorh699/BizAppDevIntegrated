using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel.DataAnnotations;

namespace BizAppDev
{
    public class Customer
    {
        string _connStr = ConfigurationManager.ConnectionStrings["Project"].ConnectionString;

        private string _CustID = string.Empty;
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        private string _email = string.Empty;
        private int _points = 0;
        private string _address = string.Empty;
        private string _phoneNo = string.Empty;
        private string _DOB = string.Empty;
        private string _gender = string.Empty;
        private string _username = string.Empty;
        private int _pointTierID = 0;
        private int _lvlPoints = 0;
        private string _Password = string.Empty;
        private string _Cfmpassword = string.Empty;
        private DateTime _pointExpiry = new DateTime();



        public Customer()
        {

        }
        public Customer(string CustID, string firstName, string lastName, string gender, string email, string address, string phoneNo, string DOB, string Password, string Cfmpassword, string username)
        {
            _CustID = CustID;
            _firstName = firstName;
            _lastName = lastName;
            _gender = gender;
            _email = email;
            _address = address;
            _phoneNo = phoneNo;
            _DOB = DOB;
            _Password = Password;
            _Cfmpassword = Cfmpassword;
            _username = username;
        }
        public Customer(string CustID, string firstName, string lastName, string email, int points, string address, string phoneNo, string DOB, string gender, string username, int pointTierID, int lvlPoints, DateTime pointExpiry)

        {
            _CustID = CustID;
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _points = points;
            _address = address;
            _phoneNo = phoneNo;
            _DOB = DOB;
            _gender = gender;
            _username = username;
            _pointTierID = pointTierID;
            _lvlPoints = lvlPoints;
            _pointExpiry = pointExpiry;
        }

        [Required(ErrorMessage = "Title is required")]
        public string Cust_ID
        {
            get { return _CustID; }
            set { _CustID = value; }
        }
        [Required(ErrorMessage = "Title is required")]

        public string first_Name
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        [Required(ErrorMessage = "Title is required")]

        public string last_Name
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public string address
        {
            get { return _address; }
            set { _address = value; }
        }
        public string email
        {
            get { return _email; }
            set { _email = value; }
        }
        public int points
        {
            get { return _points; }
            set { _points = value; }
        }
        public string phoneNo
        {
            get { return _phoneNo; }
            set { _phoneNo = value; }
        }
        public string DOB
        {
            get { return _DOB; }
            set { _DOB = value; }
        }

        public string gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
        [Required(ErrorMessage = "Title is required")]

        public string username
        {
            get { return _username; }
            set { _username = value; }
        }

        public int pointTierID
        {
            get { return _pointTierID; }
            set { _pointTierID = value; }
        }
        public int lvlPoints
        {
            get { return _lvlPoints; }
            set { _lvlPoints = value; }
        }

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        public string Cfmpassword
        {
            get { return _Cfmpassword; }
            set { _Cfmpassword = value; }
        }

        public DateTime pointExpiry
        {
            get { return _pointExpiry; }
            set { _pointExpiry = value; }
        }
        public Customer getCustomer(string CustID)
        {
            Customer custDetail = null;
            string first_Name, last_Name, phone_No, email, address, DOB, gender, username;
            int points, pointTierID, lvlPoints;
            DateTime pointExpiry;

            string queryStr = "SELECT * FROM Customer WHERE Cust_ID = @CustID";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@CustID", CustID);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                first_Name = dr["First_Name"].ToString();
                last_Name = dr["Last_Name"].ToString();
                address = dr["Address"].ToString();
                DOB = dr["DOB"].ToString();
                pointTierID = int.Parse(dr["pointTierID"].ToString());
                phone_No = dr["PhoneNo"].ToString();
                points = int.Parse(dr["Points"].ToString());
                gender = dr["Gender"].ToString();
                email = dr["Email"].ToString();
                username = dr["Username"].ToString();
                lvlPoints = int.Parse(dr["lvlPoints"].ToString());
                pointExpiry = Convert.ToDateTime(dr["pointExpiry"].ToString());

                custDetail = new Customer(CustID, first_Name, last_Name, email, points, address, phone_No, DOB, gender, username, pointTierID, lvlPoints, pointExpiry);
                return custDetail;

            }
            else
            {
                custDetail = null;
            }

            conn.Close();
            dr.Close();
            dr.Dispose();


            return custDetail;
        }
        public int CustomerUpdate(string CustID, string first_Name, string last_Name, string email, string address, string phone_No, string DOB, string gender, string username)
        {
            string queryStr = "UPDATE Customer SET" +
                " first_Name = @first_Name, " +
                " last_Name = @last_Name," +
                " email = @email," +
                " address = @address," +
                " phoneNo = @phone_No," +
                " DOB = @DOB," +
                " gender = @gender," +
                " username = @username" +
                " WHERE Cust_ID = @CustID";
            DateTime convertDOB = Convert.ToDateTime(DOB);
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@CustID", CustID);
            cmd.Parameters.AddWithValue("@first_Name", first_Name);
            cmd.Parameters.AddWithValue("@last_Name", last_Name);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@phone_No", phone_No);
            cmd.Parameters.AddWithValue("@DOB", convertDOB);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@username", username);


            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();

            conn.Close();

            return nofRow;


        }
        public int CustomerUpdatePoints(string CustID, int addedpoints)
        {
            DateTime now = DateTime.Now;
            DateTime newExpiry = now.AddDays(50);
            int pointTierID = 0;
            Customer ptCust = new Customer();
            Customer aCust = new Customer();
            ptCust = aCust.getCustomer(CustID);
            pointsTier aPT = new pointsTier();
            int custPoints = ptCust.lvlPoints;
            List<pointsTier> tierList = new List<pointsTier>();
            tierList = aPT.getTiersAll();
            string ptqueryStr = "SELECT TOP 1 * FROM PointTiers WHERE price<=@custPoints order by price desc";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand ptcmd = new SqlCommand(ptqueryStr, conn);
            ptcmd.Parameters.AddWithValue("@custPoints", custPoints + addedpoints);
            conn.Open();
            SqlDataReader dr = ptcmd.ExecuteReader();
            if (dr.Read())
            {
                pointTierID = Convert.ToInt32(dr["pointTierID"].ToString());
            }
            else
            {
                pointTierID = 0;
            }


            conn.Close();
            dr.Close();
            dr.Dispose();


            string queryStr = "UPDATE Customer SET" +
                " lvlPoints = lvlPoints +@addedpoints, " +
                " pointTierID = @pointTierID, " +
                " pointExpiry = @pointExpiry, " +

                " Points = Points + @addedpoints " +
                " WHERE Cust_ID = @CustID";
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@pointTierID", pointTierID);
            cmd.Parameters.AddWithValue("@CustID", CustID);
            cmd.Parameters.AddWithValue("@addedpoints", addedpoints);
            cmd.Parameters.AddWithValue("@pointExpiry", newExpiry);
            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();

            conn.Close();

            return nofRow;
        }
        public int CustomerInsert()
        {
            int result = 0;

            string queryStr = "INSERT INTO Customer(Cust_ID, first_Name, last_Name, gender, email, address, phoneNo, DOB, Password, Cfmpassword, pointTierID)"
                + " values (@CustID, @firstName, @lastName, @gender, @email, @address, @phoneNo, @DOB, @Password, @Cfmpassword, @pointTierID)";
            string tierqueryStr = "SELECT * From PointTiers WHERE price=0";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand tiercmd = new SqlCommand(tierqueryStr, conn);

            conn.Open();
            SqlDataReader dr = tiercmd.ExecuteReader();
            int pointTierID = 0;
            if (dr.Read())
            {
                pointTierID = int.Parse(dr["pointTierID"].ToString());
            }
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            cmd.Parameters.AddWithValue("@CustID", Cust_ID);
            cmd.Parameters.AddWithValue("@firstName", first_Name);
            cmd.Parameters.AddWithValue("@lastName", last_Name);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@phoneNo", phoneNo);
            cmd.Parameters.AddWithValue("@DOB", DOB);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@Cfmpassword", Cfmpassword);
            cmd.Parameters.AddWithValue("@pointTierID", pointTierID);


            conn.Open();
            result += cmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }
    }
}

