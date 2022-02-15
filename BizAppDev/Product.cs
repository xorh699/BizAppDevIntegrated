using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BizAppDev
{
    public class Product
    {
        string _connStr = ConfigurationManager.ConnectionStrings["Project"].ConnectionString;
        private string _prodID = null;
        private string _prodName = string.Empty;
        private string _prodDesc = ""; // this is another way to specify empty string
        private decimal _unitPrice = 0;
        private string _prodImage = "";
        private int _stockLevel = 0;
        private string _supplName = "";
        private string _supplEmail = "";
        private string _keywords = "";
        private string _category = "";

        // Default constructor
        public Product()
        {
        }

        // Constructor that take in all data required to build a Product object
        public Product(string prodID, string prodName, string prodDesc,
                       decimal unitPrice, string prodImage, int stockLevel, string supplName, string supplEmail, string keywords, string category)
        {
            _prodID = prodID;
            _prodName = prodName;
            _prodDesc = prodDesc;
            _unitPrice = unitPrice;
            _prodImage = prodImage;
            _stockLevel = stockLevel;
            _supplName = supplName;
            _supplEmail = supplEmail;
            _keywords = keywords;
            _category = category;
        }

        // Constructor that take in all except product ID


        // Get/Set the attributes of the Product object.
        // Note the attribute name (e.g. Product_ID) is same as the actual database field name.
        // This is for ease of referencing.
        public string Product_ID
        {
            get { return _prodID; }
            set { _prodID = value; }
        }
        public string Product_Name
        {
            get { return _prodName; }
            set { _prodName = value; }
        }
        public string Product_Desc
        {
            get { return _prodDesc; }
            set { _prodDesc = value; }
        }
        public decimal Unit_Price
        {
            get { return _unitPrice; }
            set { _unitPrice = value; }
        }
        public string Product_Image
        {
            get { return _prodImage; }
            set { _prodImage = value; }
        }
        public int Stock_Level
        {
            get { return _stockLevel; }
            set { _stockLevel = value; }
        }

        public string Supplier_Name
        {
            get { return _supplName; }
            set { _supplName = value; }
        }

        public string Supplier_Email
        {
            get { return _supplEmail; }
            set { _supplEmail = value; }
        }
        public string keyword
        {
            get { return _keywords; }
            set { _keywords = value; }
        }
        public string category
        {
            get { return _category; }
            set { _category = value; }
        }
        public Product getProd(string supplname)
        {

            Product productdetails = null;

            string prodID, prodName, prodDesc, prodImage, supplName, supplEmail, category, keyword;
            decimal unitPrice;
            int stockLevel;


            string queryStr = "SELECT * FROM Products WHERE supplierName = @supplName";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@supplName", supplname);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                prodID = dr["Product_ID"].ToString();
                prodName = dr["Product_Name"].ToString();
                prodImage = dr["Product_Image"].ToString();
                prodDesc = dr["Product_Desc"].ToString();
                supplName = dr["supplierName"].ToString();
                supplEmail = dr["supplierEmail"].ToString();
                unitPrice = decimal.Parse(dr["Unit_Price"].ToString());
                stockLevel = int.Parse(dr["Stock_Level"].ToString());
                category = dr["Category"].ToString();
                keyword = dr["keywordsearch"].ToString();

                productdetails = new Product(prodID, prodName, prodDesc, unitPrice, prodImage, stockLevel, supplName, supplEmail, keyword, category);
            }
            else
            {
                productdetails = null;
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return productdetails;
        }
        public int ProductInsert()
        {

            // string msg = null;
            int result = 0;

            string queryStr = "INSERT INTO Products(Product_ID,Product_Name, Product_Desc, Unit_Price,Product_Image,Stock_Level, supplierName, supplierEmail, keywordsearch, Category)"
                + " values (@id,@name, @desc, @price, @image,@stock, @supplname, @supplemail, @keywordsearch, @category)";
            //+ "values (@Product_ID, @Product_Name, @Product_Desc, @Unit_Price, @Product_Image,@Stock_Level)";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@id", this.Product_ID);
            cmd.Parameters.AddWithValue("@name", this.Product_Name);
            cmd.Parameters.AddWithValue("@desc", this.Product_Desc);
            cmd.Parameters.AddWithValue("@price", this.Unit_Price);
            cmd.Parameters.AddWithValue("@image", this.Product_Image);
            cmd.Parameters.AddWithValue("@stock", this.Stock_Level);
            cmd.Parameters.AddWithValue("@supplname", this.Supplier_Name);
            cmd.Parameters.AddWithValue("@supplemail", this.Supplier_Email);
            cmd.Parameters.AddWithValue("@keywordsearch", this.keyword);
            cmd.Parameters.AddWithValue("@category", this.category);

            conn.Open();
            result += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
            conn.Close();

            return result;
        }//end Insert


    }
}