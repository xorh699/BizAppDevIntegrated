using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BizAppDev
{
    public partial class CustomerEditDetails1 : System.Web.UI.Page
    {

        Customer aCust = new Customer();
        Customer Cust = new Customer();
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext context = HttpContext.Current;
            string CID = (string)(context.Session["CustID"]);
            if (!IsPostBack)
            {
                Cust = aCust.getCustomer(CID);
                tb_FirstName.Text = Cust.first_Name;
                tb_LastName.Text = Cust.last_Name;
                cal_DOB.SelectedDate = Convert.ToDateTime(Cust.DOB);
                rbl_Gender.SelectedValue = Cust.gender;
                tb_Address.Text = Cust.address;
                tb_Email.Text = Cust.email;
                tb_PhoneNo.Text = Cust.phoneNo;
                tb_Username.Text = Cust.username;
            }



        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            HttpContext context = HttpContext.Current;
            string CID = (string)(context.Session["CustID"]);
            int result = 0;
            string firstName = tb_FirstName.Text;
            string lastName = tb_LastName.Text;
            string DOB = cal_DOB.SelectedDate.ToString();
            string gender = rbl_Gender.SelectedValue;
            string address = tb_Address.Text;
            string email = tb_Email.Text;
            string phoneNo = tb_PhoneNo.Text;
            string username = tb_Username.Text;
            result = Cust.CustomerUpdate(CID, firstName, lastName, email, address, phoneNo, DOB, gender, username);
            if (result > 0)
            {

                Response.Redirect("CustomerDetails.aspx");
                Response.Write("<script>alert('Customer updated successfully');</script>");
            }
            else
            {
                Response.Write("<script>alert('Customer update unsuccessful ');</script>");
            }
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerDetails.aspx");
        }

    }
}