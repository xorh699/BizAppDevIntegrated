using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BizAppDev

{
    public class ProductCust
    {
        string _connStr = ConfigurationManager.ConnectionStrings["Project"].ConnectionString;

        private string _custID = "";
        private string _prodcustID = null;
        private string _prodcustCat = "";
        private string _prodcustCol = "";
        private string _prodcustScent = "";
        private string _name = "";
        private string _email = "";
        private string _contact = "";
        private string _date = "";
        private string _status = "";

        public ProductCust()
        {
        }
        public ProductCust(string custID, string prodcustID, string prodcustCat, string prodcustCol, string prodcustScent, string name, string email, string contact, string date)
        {
            _custID = custID;
            _prodcustID = prodcustID;
            _prodcustCat = prodcustCat;
            _prodcustCol = prodcustCol;
            _prodcustScent = prodcustScent;
            _name = name;
            _email = email;
            _contact = contact;
            _date = date;
        }
        public ProductCust(string custID, string prodcustID, string prodcustCat, string prodcustCol, string prodcustScent, string name, string email, string contact, string date, string status)
        {
            _custID = custID;
            _prodcustID = prodcustID;
            _prodcustCat = prodcustCat;
            _prodcustCol = prodcustCol;
            _prodcustScent = prodcustScent;
            _name = name;
            _email = email;
            _contact = contact;
            _date = date;
            _status = status;
        }
        public ProductCust(string custID, string prodcustCat, string prodcustCol, string prodcustScent, string name, string email, string contact, string date)
        : this(custID, null, prodcustCat, prodcustCol, prodcustScent, name, email, contact, date)
        {
        }


        public string CustID
        {
            get { return _custID; }
            set { _custID = value; }
        }
        public string CustomizationID
        {
            get { return _prodcustID; }
            set { _prodcustID = value; }
        }
        public string Category
        {
            get { return _prodcustCat; }
            set { _prodcustCat = value; }
        }
        public string Colour
        {
            get { return _prodcustCol; }
            set { _prodcustCol = value; }
        }
        public string Scent
        {
            get { return _prodcustScent; }
            set { _prodcustScent = value; }
        }
        public string Fullname
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Contactno
        {
            get { return _contact; }
            set { _contact = value; }
        }
        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public string status
        {
            get { return _status; }
            set { _status = value; }
        }
        public int ProdCustInsert()
        {

            int result = 0;

            string queryStr = "INSERT INTO ProductCust(CustID,Category,Colour,Scent,Fullname,Email,Contactno,Date)" +
                " values (@custID,@prodcustCat,@prodcustCol,@prodcustScent,@name,@email,@contact,@date)";
            try
            {
                SqlConnection conn = new SqlConnection(_connStr);
                SqlCommand cmd = new SqlCommand(queryStr, conn);
                cmd.Parameters.AddWithValue("@custID", this.CustID);
                cmd.Parameters.AddWithValue("@prodcustCat", this.Category);
                cmd.Parameters.AddWithValue("@prodcustCol", this.Colour);
                cmd.Parameters.AddWithValue("@prodcustScent", this.Scent);
                cmd.Parameters.AddWithValue("@name", this.Fullname);
                cmd.Parameters.AddWithValue("@email", this.Email);
                cmd.Parameters.AddWithValue("@contact", this.Contactno);
                cmd.Parameters.AddWithValue("@date", this.Date);

                conn.Open();
                result += cmd.ExecuteNonQuery();
                conn.Close();

                return result;
            }
            catch (SqlException ex)
            {
                return 0;
            }

        }

        public List<ProductCust> getProdCust(string CustID)
        {
            List<ProductCust> ProductCustList = new List<ProductCust>();

            string custID, prodcustID, prodcustCat, prodcustCol, prodcustScent, name, email, contact, date;

            string queryStr = "SELECT * FROM ProductCust WHERE CustID = @custID";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@custID", CustID);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                custID = dr["CustID"].ToString();
                prodcustID = dr["CustomizationID"].ToString();
                prodcustCat = dr["Category"].ToString();
                prodcustCol = dr["Colour"].ToString();
                prodcustScent = dr["Scent"].ToString();
                name = dr["Fullname"].ToString();
                email = dr["Email"].ToString();
                contact = dr["Contactno"].ToString();
                date = dr["Date"].ToString();
                ProductCust a = new ProductCust(custID, prodcustID, prodcustCat, prodcustCol, prodcustScent, name, email, contact, date);
                ProductCustList.Add(a);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return ProductCustList;
        }

        public int ProdCustUpdate(string PCid, string PCcat, string PCcol, string PCscent, string name, string email, string contact, string date)
        {
            string queryStr = "UPDATE ProductCust SET" +
                " Category = @prodcustCat, " +
                " Colour = @prodcustCol, " +
                " Scent = @prodcustScent, " +
                " Fullname = @name," +
                " Email = @email," +
                " Contactno = @contact," +
                " Date = @date" +
                " WHERE CustomizationID = @prodcustID";
            try
            {
                SqlConnection conn = new SqlConnection(_connStr);
                SqlCommand cmd = new SqlCommand(queryStr, conn);
                cmd.Parameters.AddWithValue("@prodcustID", PCid);
                cmd.Parameters.AddWithValue("@prodcustCat", PCcat);
                cmd.Parameters.AddWithValue("@prodcustCol", PCcol);
                cmd.Parameters.AddWithValue("@prodcustScent", PCscent);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@contact", contact);
                cmd.Parameters.AddWithValue("@date", date);

                conn.Open();
                int nofRow = 0;
                nofRow = cmd.ExecuteNonQuery();

                conn.Close();

                return nofRow;
            }
            catch (SqlException ex)
            {
                return 0;
            }
        }
        public int ProdCustDelete(string CustID)
        {
            string queryStr = "DELETE FROM ProductCust WHERE CustID = @CustID";
            try
            {
                SqlConnection conn = new SqlConnection(_connStr);
                SqlCommand cmd = new SqlCommand(queryStr, conn);
                cmd.Parameters.AddWithValue("@CustID", CustID);
                conn.Open();
                int nofRow = 0;
                nofRow = cmd.ExecuteNonQuery();
                conn.Close();
                return nofRow;
            }
            catch (SqlException ex)
            {
                return 0;
            }

        }

    }
}
