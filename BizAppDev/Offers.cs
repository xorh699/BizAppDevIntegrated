using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BizAppDev
{
    public class Offers
    {
        string _connStr = ConfigurationManager.ConnectionStrings["Project"].ConnectionString;
        private string _offer_ID = null;
        private string _offer_Name = string.Empty;
        private string _offer_startDate = ""; // this is another way to specify empty string
        private string _offer_endDate = "";
        private string _offer_Image = "";
        private string _offer_Desc = "";

        // Default constructor
        public Offers()
        {
        }

        public Offers(string offer_ID, string offer_Name, string offer_startDate, string offer_endDate, string offer_Image, string offer_Desc)
        {
            _offer_ID = offer_ID;
            _offer_Name = offer_Name;
            _offer_startDate = offer_startDate;
            _offer_endDate = offer_endDate;
            _offer_Image = offer_Image;
            _offer_Desc = offer_Desc;
        }


        // Constructor that take in all except product ID
        // Get/Set the attributes of the Product object.
        // Note the attribute name (e.g. Product_ID) is same as the actual database field name.
        // This is for ease of referencing.
        public string offer_ID
        {
            get { return _offer_ID; }
            set { _offer_ID = value; }
        }
        public string offer_Name
        {
            get { return _offer_Name; }
            set { _offer_Name = value; }
        }
        public string offer_startDate
        {
            get { return _offer_startDate; }
            set { _offer_startDate = value; }
        }
        public string offer_endDate
        {
            get { return _offer_endDate; }
            set { _offer_endDate = value; }
        }
        public string offer_Image
        {
            get { return _offer_Image; }
            set { _offer_Image = value; }
        }
        public string offer_Desc
        {
            get { return _offer_Desc; }
            set { _offer_Desc = value; }
        }



        //Below as the Class methods for some DB operations. 
        public Offers getOffer(string offer_ID)
        {

            Offers offerDetail = null;

            string offer_Name, offer_startDate, offer_endDate, offer_Desc, offer_Image;


            string queryStr = "SELECT * FROM Offers WHERE offer_ID = @offerID";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@offerID", offer_ID);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                offer_Name = dr["offer_Name"].ToString();
                offer_startDate = dr["offer_startDate"].ToString();
                offer_endDate = dr["offer_endDate"].ToString();
                offer_Desc = dr["offer_Desc"].ToString();
                offer_Image = dr["offer_Image"].ToString();

                offerDetail = new Offers(offer_ID, offer_Name, offer_startDate, offer_endDate, offer_Image, offer_Desc);
            }
            else
            {
                offerDetail = null;
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return offerDetail;
        }

        public List<Offers> getOffersAll()
        {
            List<Offers> offerList = new List<Offers>();

            string offerID, offerName, offerstartDate, offerendDate, offerImage, offerDesc;

            string queryStr = "SELECT * FROM Offers Order By offer_Name";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                offerID = dr["offer_ID"].ToString();
                offerstartDate = dr["offer_startDate"].ToString();
                offerendDate = dr["offer_endDate"].ToString();
                offerDesc = dr["offer_Desc"].ToString();
                offerImage = dr["offer_Image"].ToString();
                offerName = dr["offer_Name"].ToString();
                Offers a = new Offers(offerID, offerName, offerstartDate, offerendDate, offerImage, offerDesc);
                offerList.Add(a);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return offerList;
        }

        public int offerInsert()
        {

            // string msg = null;
            int result = 0;

            string queryStr = "INSERT INTO Offers(offer_ID,offer_Name, offer_startDate, offer_endDate,offer_Image,offer_Desc)"
                + " values (@offer_ID,@offer_Name, @offer_startDate, @offer_endDate, @offer_Image,@offer_Desc)";
            //+ "values (@Product_ID, @Product_Name, @Product_Desc, @Unit_Price, @Product_Image,@Stock_Level)";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@offer_ID", this.offer_ID);
            cmd.Parameters.AddWithValue("@offer_Name", this.offer_Name);
            cmd.Parameters.AddWithValue("@offer_startDate", this.offer_startDate);
            cmd.Parameters.AddWithValue("@offer_endDate", this.offer_endDate);
            cmd.Parameters.AddWithValue("@offer_Image", this.offer_Image);
            cmd.Parameters.AddWithValue("@offer_Desc", this.offer_Desc);

            conn.Open();
            result += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
            conn.Close();

            return result;
        }//end Insert


        public int offerDelete(string ID)
        {
            string queryStr = "DELETE FROM Offers WHERE offer_ID=@ID";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@ID", ID);
            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();
            //  Response.Write("<script>alert('Delete successful');</script>");
            conn.Close();
            return nofRow;

        }//end Delete

        public int OfferUpdate(string oId, string oName, string ostartDate, string oendDate)
        {
            string queryStr = "UPDATE Offers SET" +
                //" Product_ID = @productID, " +
                " offer_Name = @offerName, " +
                " offer_startDate = @offerstartDate, " +
                " offer_endDate = @offerendDate " +
                "WHERE offer_ID = @offerID";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@offerName", oName);
            cmd.Parameters.AddWithValue("@offerstartDate", ostartDate);
            cmd.Parameters.AddWithValue("@offerendDate", oendDate);
            cmd.Parameters.AddWithValue("@offerID", oId);

            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();

            conn.Close();

            return nofRow;
        }//end Update

        public List<Offers> afterfilter()
        {
            List<Offers> offerList = new List<Offers>();

            string offerID, offerName, offerstartDate, offerendDate, offerImage, offerDesc;

            string queryStr = "SELECT * FROM Offers WHERE offer_startDate < @date AND offer_endDate >= @date1";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@date", DateTime.Now);
            cmd.Parameters.AddWithValue("@date1", DateTime.Now);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                offerID = dr["offer_ID"].ToString();
                offerstartDate = dr["offer_startDate"].ToString();
                offerendDate = dr["offer_endDate"].ToString();
                offerDesc = dr["offer_Desc"].ToString();
                offerImage = dr["offer_Image"].ToString();
                offerName = dr["offer_Name"].ToString();
                Offers a = new Offers(offerID, offerName, offerstartDate, offerendDate, offerImage, offerDesc);
                offerList.Add(a);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return offerList;
        }
        public List<Offers> pastoffers()
        {
            List<Offers> offerList = new List<Offers>();

            string offerID, offerName, offerstartDate, offerendDate, offerImage, offerDesc;

            string queryStr = "SELECT * FROM Offers WHERE offer_endDate < @date";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@date", DateTime.Now);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                offerID = dr["offer_ID"].ToString();
                offerstartDate = dr["offer_startDate"].ToString();
                offerendDate = dr["offer_endDate"].ToString();
                offerDesc = dr["offer_Desc"].ToString();
                offerImage = dr["offer_Image"].ToString();
                offerName = dr["offer_Name"].ToString();
                Offers a = new Offers(offerID, offerName, offerstartDate, offerendDate, offerImage, offerDesc);
                offerList.Add(a);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return offerList;
        }
        public List<Offers> upcomingoffer()
        {
            List<Offers> offerList = new List<Offers>();

            string offerID, offerName, offerstartDate, offerendDate, offerImage, offerDesc;

            string queryStr = "SELECT * FROM Offers WHERE offer_startDate > @date1";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@date1", DateTime.Now);


            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                offerID = dr["offer_ID"].ToString();
                offerstartDate = dr["offer_startDate"].ToString();
                offerendDate = dr["offer_endDate"].ToString();
                offerDesc = dr["offer_Desc"].ToString();
                offerImage = dr["offer_Image"].ToString();
                offerName = dr["offer_Name"].ToString();
                Offers a = new Offers(offerID, offerName, offerstartDate, offerendDate, offerImage, offerDesc);
                offerList.Add(a);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return offerList;
        }
    }
}