using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace BizAppDev
{
    public class MembershipTier
    {
        string _connStr = ConfigurationManager.ConnectionStrings["Project"].ConnectionString;
        private string _membershipID = null;
        private string _membershipTier = string.Empty;
        private string _membershipDesc = ""; // this is another way to specify empty string
        private string _membershipBenefits = "";
        private decimal _membershipPrice = 0;
        private string _membershipLength = "";

        public MembershipTier()
        {

        }

        public MembershipTier(string membershipID, string membershipTier, string membershipDesc, string membershipBenefits, decimal membershipPrice, string membershipLength)
        {
            _membershipID = membershipID;
            _membershipTier = membershipTier;
            _membershipDesc = membershipDesc;
            _membershipBenefits = membershipBenefits;
            _membershipPrice = membershipPrice;
            _membershipLength = membershipLength;
        }

        /*public Coupons(string couponID, string couponName, 
                        string couponstartDate, string couponendDate, string couponDesc): this(null, couponName, couponstartDate, couponendDate, couponDesc)
        {
        }

        public Coupons(string couponID) : this(couponID, "", "", "", "")
        {

        }*/
        public string membershipID
        {
            get { return _membershipID; }
            set { _membershipID = value; }
        }
        public string membershipTier
        {
            get { return _membershipTier; }
            set { _membershipTier = value; }
        }
        public string membershipDesc
        {
            get { return _membershipDesc; }
            set { _membershipDesc = value; }
        }
        public string membershipBenefits
        {
            get { return _membershipBenefits; }
            set { _membershipBenefits = value; }
        }
        public decimal membershipPrice
        {
            get { return _membershipPrice; }
            set { _membershipPrice = value; }
        }

        public List<MembershipTier> getTier(string membershipID)
        {

            List<MembershipTier> tierList = new List<MembershipTier>();

            string membershipName, membershipDesc, membershipBenefits, membershipLength;
            decimal membershipPrice;

            string queryStr = "SELECT * FROM Membership WHERE membership_id = @membership_ID";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@membership_ID", membershipID);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                membershipName = dr["membership_name"].ToString();
                membershipDesc = dr["membership_desc"].ToString();
                membershipBenefits = dr["membership_benefits"].ToString();
                membershipPrice = Decimal.Parse(dr["membership_price"].ToString());
                membershipLength = dr["membership_length"].ToString();

                MembershipTier a = new MembershipTier(membershipID, membershipName, membershipDesc, membershipBenefits, membershipPrice, membershipLength);
                tierList.Add(a);
            }
            else
            {
                tierList = null;
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return tierList;
        }

        public List<MembershipTier> getTierAll()
        {
            List<MembershipTier> tierList = new List<MembershipTier>();

            string membershipID, membershipName, membershipDesc, membershipBenefits, membershipLength;
            decimal membershipPrice;


            string queryStr = "SELECT * FROM Membership Order By membership_id";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                membershipID = dr["membership_id"].ToString();
                membershipName = dr["membership_name"].ToString();
                membershipDesc = dr["membership_desc"].ToString();
                membershipBenefits = dr["membership_benefits"].ToString();
                membershipPrice = Decimal.Parse(dr["membership_price"].ToString());
                membershipLength = dr["membership_length"].ToString();
                MembershipTier a = new MembershipTier(membershipID, membershipName, membershipDesc, membershipBenefits, membershipPrice, membershipLength);
                tierList.Add(a);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return tierList;
        }
    }
}
   