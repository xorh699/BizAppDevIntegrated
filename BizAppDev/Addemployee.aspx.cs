using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BizAppDev
{
    public partial class Addemployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DropDownPosition.SelectedItem.Text == "Staff") {

                int result = 0;
                string pass = "1234567890";
                Random r = new Random();
                char[] mypass = new char[5];

                for (int i = 0; i < 5; i++)
                {
                    mypass[i] = pass[r.Next(pass.Length)];
                }
                var kan = "S" + new String(mypass);

                Employee emp = new Employee(kan, tb_EmpName.Text, tb_NRIC.Text, cal_Birthdate.SelectedDate.ToString(), rbl_Gender.Text, tb_Contactno.Text, tb_Email.Text, tb_Address.Text);
                result = emp.EmployeeInsert();

                if (result > 0)
                {
                    Response.Write("<script>alert('Insert successful');</script>");
                    Response.Redirect("Employeelist.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Insert NOT successful');</script>");
                }
            }
            if (DropDownPosition.SelectedItem.Text == "Admin")
            {
                int result = 0;
                string pass = "1234567890";
                Random r = new Random();
                char[] mypass = new char[5];

                for (int i = 0; i < 5; i++)
                {
                    mypass[i] = pass[r.Next(pass.Length)];
                }
                var kan = "A" + new String(mypass);

                Admin emp = new Admin(kan, tb_EmpName.Text, tb_NRIC.Text, cal_Birthdate.SelectedDate.ToString(), rbl_Gender.Text, tb_Contactno.Text, tb_Email.Text, tb_Address.Text);
                result = emp.AdminInsert();

                if (result > 0)
                {
                    Response.Write("<script>alert('Insert successful');</script>");
                    Response.Redirect("Adminlist.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Insert NOT successful');</script>");
                }
            }

        }
    }
}