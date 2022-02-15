using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BizAppDev
{
    public class Admin
    {
        string _connStr = ConfigurationManager.ConnectionStrings["Project"].ConnectionString;

        private string _AdmID = null;
        private string _AdmName = "";
        private string _NRIC = "";
        private string _Birthdate = "";
        private string _Gender = "";
        private string _Contactno = "";
        private string _Email = "";
        private string _Position = "";
        private string _Address = "";
        private string _Password = "";
        public Admin()
        {
        }

        public Admin(string AdmID, string AdmName, string NRIC, string Birthdate, string Gender, string Contactno, string Email, string Address)
        {
            _AdmID = AdmID;
            _AdmName = AdmName;
            _NRIC = NRIC;
            _Birthdate = Birthdate;
            _Gender = Gender;
            _Contactno = Contactno;
            _Email = Email;
            _Address = Address;
        }

        public string AdmID
        {
            get { return _AdmID; }
            set { _AdmID = value; }
        }

        public string AdmName
        {
            get { return _AdmName; }
            set { _AdmName = value; }
        }
        public string NRIC
        {
            get { return _NRIC; }
            set { _NRIC = value; }
        }
        public string Birthdate
        {
            get { return _Birthdate; }
            set { _Birthdate = value; }
        }
        public string Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }
        public string Contactno
        {
            get { return _Contactno; }
            set { _Contactno = value; }
        }
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public string Position
        {
            get { return _Position; }
            set { _Position = value; }
        }

        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        public Admin getAdmin(string AdmID)
        {
            Admin AdmDetail = null;

            string Adm_name, Adm_NRIC, Adm_Bdate, Adm_gender, Adm_Contact, Adm_Email, Adm_Address;

            string queryStr = "SELECT * FROM Admin WHERE AdmID = @AdmID";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@AdmID", AdmID);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Adm_name = dr["AdmName"].ToString();
                Adm_NRIC = dr["NRIC"].ToString();
                Adm_Bdate = dr["Birthdate"].ToString();
                Adm_gender = dr["Gender"].ToString();
                Adm_Contact = dr["Contactno"].ToString();
                Adm_Email = dr["Email"].ToString();
                Adm_Address = dr["Address"].ToString();
                AdmDetail = new Admin(AdmID, Adm_name, Adm_NRIC, Adm_Bdate, Adm_gender, Adm_Contact, Adm_Email, Adm_Address);
            }
            else
            {
                AdmDetail = null;
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return AdmDetail;
        }

        public List<Admin> getAdminAll()
        {
            List<Admin> AdmList = new List<Admin>();

            string AdmID, Adm_name, Adm_NRIC, Adm_Bdate, Adm_gender, Adm_Contact, Adm_Email, Adm_Address;

            string queryStr = "SELECT * FROM Admin Order By AdmID";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                AdmID = dr["AdmID"].ToString();
                Adm_name = dr["AdmName"].ToString();
                Adm_NRIC = dr["NRIC"].ToString();
                Adm_Bdate = dr["Birthdate"].ToString();
                Adm_gender = dr["Gender"].ToString();
                Adm_Contact = dr["Contactno"].ToString();
                Adm_Email = dr["Email"].ToString();
                Adm_Address = dr["Address"].ToString();
                Admin e = new Admin(AdmID, Adm_name, Adm_NRIC, Adm_Bdate, Adm_gender, Adm_Contact, Adm_Email, Adm_Address);
                AdmList.Add(e);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return AdmList;
        }

        public int AdminInsert()
        {
            int result = 0;

            string queryStr = "INSERT INTO Admin(AdmID, AdmName, NRIC, Birthdate, Gender, Contactno, Email, Address, Password)"
                + " values (@AdmID, @AdmName, @NRIC, @Birthdate, @Gender, @Contactno, @Email, @Address, @Password)";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            cmd.Parameters.AddWithValue("@AdmID", this.AdmID);
            cmd.Parameters.AddWithValue("@AdmName", this.AdmName);
            cmd.Parameters.AddWithValue("@NRIC", this.NRIC);
            cmd.Parameters.AddWithValue("@Birthdate", this.Birthdate);
            cmd.Parameters.AddWithValue("@Gender", this.Gender);
            cmd.Parameters.AddWithValue("@Contactno", this.Contactno);
            cmd.Parameters.AddWithValue("@Email", this.Email);
            cmd.Parameters.AddWithValue("@Address", this.Address);
            cmd.Parameters.AddWithValue("@Password", "Default@123");

            conn.Open();
            result += cmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }
        public int AdminDelete(string AdmID)
        {
            string queryStr = "DELETE FROM Admin WHERE AdmID=@AdmID";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@AdmID", AdmID);
            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();
            conn.Close();
            return nofRow;
        }//end Delete
    }
}
