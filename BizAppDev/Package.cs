using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace BizAppDev
{
    public class Package
    {
        string _connStr = ConfigurationManager.ConnectionStrings["Project"].ConnectionString;
        private string _packageName = "";
        private string _packageItems = "";
        private string _packageDesc = "";
        private decimal _packagePrice = 0;
        private string _packageImage = "";
        private string _packageKeyword = "";
        // Default constructor
        public Package()
        {
        }

        // Constructor that take in all data required to build a Product object
        public Package(string packageName, string packageItems, string packageDesc, decimal packagePrice, string packageImage, string packageKeyword)
        {
            _packageName = packageName;
            _packageItems = packageItems;
            _packageDesc = packageDesc;
            _packagePrice = packagePrice;
            _packageImage = packageImage;
            _packageKeyword = packageKeyword;
        }

        // Constructor that take in all except product ID


        // Get/Set the attributes of the Product object.
        // Note the attribute name (e.g. Product_ID) is same as the actual database field name.
        // This is for ease of referencing.
        public string package_Name
        {
            get { return _packageName; }
            set { _packageName = value; }
        }

        public string package_Items
        {
            get { return _packageItems; }
            set { _packageItems = value; }
        }

        public string package_Desc
        {
            get { return _packageDesc; }
            set { _packageDesc = value; }
        }

        public decimal package_Price
        {
            get { return _packagePrice; }
            set { _packagePrice = value; }
        }

        public string package_Image
        {
            get { return _packageImage; }
            set { _packageImage = value; }
        }
        public string package_Keyword
        {
            get { return _packageKeyword; }
            set { _packageKeyword = value; }
        }
        public Package get_Package(string package_Name)
        {

            Package package_details = null;

            string package_Items, package_Desc, package_Image, package_Keyword;
            decimal package_Price;



            string queryStr = "SELECT * FROM Package WHERE  package_Name = @pname";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@name", package_Name);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                package_Image = dr["package_Image"].ToString();
                package_Items = dr["package_Items"].ToString();
                package_Desc = dr["package_Desc"].ToString();
                package_Price = decimal.Parse(dr["prodDesc"].ToString());
                package_Keyword = dr["package_keyword"].ToString();

                package_details = new Package(package_Name.ToString(), package_Items, package_Desc, package_Price, package_Image, package_Keyword);
            }
            else
            {
                package_details = null;
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return package_details;
        }
        public List<Package> getPackageAll()
        {
            List<Package> packageList = new List<Package>();

            string package_Name, package_Items, package_Desc, package_Image, package_Keyword;
            decimal package_Price;


            string queryStr = "SELECT * FROM Package Order By package_Name";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                package_Image = dr["package_Image"].ToString();
                package_Items = dr["package_Items"].ToString();
                package_Desc = dr["package_Desc"].ToString();
                package_Price = decimal.Parse(dr["package_Price"].ToString());
                package_Name = dr["package_Name"].ToString();
                package_Keyword = dr["package_keyword"].ToString();

                Package a = new Package(package_Name, package_Items, package_Desc, package_Price, package_Image, package_Keyword);
                packageList.Add(a);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return packageList;
        }
        public int packageInsert()
        {

            // string msg = null;
            int result = 0;

            string queryStr = "INSERT INTO Package(package_Name,package_Items, package_Desc, package_Price,package_Image, package_keyword) "
                + "values (@package_Name,@package_Items, @package_Desc, @package_Price, @package_Image, @package_keyword)";


            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@package_Name", this.package_Name);
            cmd.Parameters.AddWithValue("@package_Items", this.package_Items);
            cmd.Parameters.AddWithValue("@package_Desc", this.package_Desc);
            cmd.Parameters.AddWithValue("@package_Price", this.package_Price);
            cmd.Parameters.AddWithValue("@package_Image", this.package_Image);
            cmd.Parameters.AddWithValue("@package_keyword", this.package_Keyword);

            conn.Open();
            result += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
            conn.Close();

            return result;
        }//end Insert

    }
}