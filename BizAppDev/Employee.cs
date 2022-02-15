using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BizAppDev
{
    public class Employee
    {
        string _connStr = ConfigurationManager.ConnectionStrings["Project"].ConnectionString;

        private string _EmpID = null;
        private string _EmpName = "";
        private string _NRIC = "";
        private string _Birthdate = "";
        private string _Gender = "";
        private string _Contactno = "";
        private string _Email = "";
        private string _Position = "not set";
        private string _Address = "";
        private string _Password = "";

        public Employee()
        {
        }

        public Employee(string EmpID, string EmpName, string NRIC, string Birthdate, string Gender, string Contactno, string Email, string Address)
        {
            _EmpID = EmpID;
            _EmpName = EmpName;
            _NRIC = NRIC;
            _Birthdate = Birthdate;
            _Gender = Gender;
            _Contactno = Contactno;
            _Email = Email;
            _Address = Address;
        }

        public string EmpID
        {
            get { return _EmpID; }
            set { _EmpID = value; }
        }

        public string EmpName
        {
            get { return _EmpName; }
            set { _EmpName = value; }
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

        public Employee getEmployee(string EmpID)
        {
            Employee EmpDetail = null;

            string emp_name, emp_NRIC, emp_Bdate, emp_gender, emp_Contact, emp_Email, emp_Address;

            string queryStr = "SELECT * FROM Employee WHERE EmpID = @EmpID";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);


            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                emp_name = dr["EmpName"].ToString();
                emp_NRIC = dr["NRIC"].ToString();
                emp_Bdate = dr["Birthdate"].ToString();
                emp_gender = dr["Gender"].ToString();
                emp_Contact = dr["Contactno"].ToString();
                emp_Email = dr["Email"].ToString();
                emp_Address = dr["Address"].ToString();
                EmpDetail = new Employee(EmpID, emp_name, emp_NRIC, emp_Bdate, emp_gender, emp_Contact, emp_Email, emp_Address);
            }
            else
            {
                EmpDetail = null;
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return EmpDetail;
        }

        public List<Employee> getEmployeeAll()
        {
            List<Employee> empList = new List<Employee>();

            string EmpID, emp_name, emp_NRIC, emp_Bdate, emp_gender, emp_Contact, emp_Email, emp_Address;

            string queryStr = "SELECT * FROM Employee Order By EmpID";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                EmpID = dr["EmpID"].ToString();
                emp_name = dr["EmpName"].ToString();
                emp_NRIC = dr["NRIC"].ToString();
                emp_Bdate = dr["Birthdate"].ToString();
                emp_gender = dr["Gender"].ToString();
                emp_Contact = dr["Contactno"].ToString();
                emp_Email = dr["Email"].ToString();
                emp_Address = dr["Address"].ToString();
                Employee e = new Employee(EmpID, emp_name, emp_NRIC, emp_Bdate, emp_gender, emp_Contact, emp_Email, emp_Address);
                empList.Add(e);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return empList;
        }

        public int EmployeeInsert()
        {
            int result = 0;

            string queryStr = "INSERT INTO Employee(EmpID, EmpName, NRIC, Birthdate, Gender, Contactno, Email, Address, Password)"
                + " values (@EmpID, @EmpName, @NRIC, @Birthdate, @Gender, @Contactno, @Email, @Address, @Password)";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            cmd.Parameters.AddWithValue("@EmpID", this.EmpID);
            cmd.Parameters.AddWithValue("@EmpName", this.EmpName);
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
        public int EmployeeDelete(string EmpID)
        {
            string queryStr = "DELETE FROM Employee WHERE EmpID=@EmpID";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@EmpID", EmpID);
            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();
            conn.Close();
            return nofRow;
        }//end Delete
    }
}
