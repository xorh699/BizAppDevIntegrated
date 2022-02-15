using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BizAppDev
{
    public partial class Signuppage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Register_Btn_Click(object sender, EventArgs e)
        {
            int result = 0;
            string pass = "1234567890";
            Random r = new Random();
            char[] mypass = new char[5];

            for (int i = 0; i < 5; i++)
            {
                mypass[i] = pass[r.Next(pass.Length)];
            }
            var kan = "C" + new String(mypass);

            Customer cust = new Customer(kan, tb_Firstname.Text, tb_Lastname.Text, rbl_Gender.Text, tb_Email.Text, tb_Address.Text, tb_Contactno.Text, tb_Birthdate.Text, tb_Password.Text, tb_CfmPassword.Text, tb_username.Text);
            result = cust.CustomerInsert();

            if (result > 0)
            {
                Response.Write("<script>alert('Sign up successful');</script>");
                Response.Redirect("Loginpage.aspx");
            }
            else
            {
                Response.Write("<script>alert('Sign up NOT successful');</script>");
            }
        }
    }
}