using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BizAppDev
{
    public partial class CouponInsert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*CompareValidator compareValidator = new CompareValidator();
            compareValidator.ID = "Validator";
            compareValidator.ControlToValidate = "calendar_startDate"; // StartDate is the ID of the first DatePicker 
            compareValidator.ControlToCompare = "calendar_endDate";// EndDate is the ID of the second DatePicker 
            compareValidator.Operator = ValidationCompareOperator.LessThan;
            compareValidator.Type = ValidationDataType.Date;
            compareValidator.ErrorMessage = "The end date must be after the start one.";
            this.form1.Controls.Add(compareValidator);*/
            tb_enddate.Attributes.Add("ReadOnly", "ReadOnly");
            tb_startdate.Attributes.Add("ReadOnly", "ReadOnly");
        }

        protected void btn_Insert_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                int result = 0;
                string pass = "1234567890";

                Random r = new Random();
                char[] mypass = new char[5];

                for (int i = 0; i < 5; i++)
                {
                    mypass[i] = pass[r.Next(pass.Length)];
                }
                var kan = new String(mypass);


                Coupons coup = new Coupons(kan, tb_name.Text, calendar_startDate.SelectedDate.ToString("dd / MMM / yyyy hh: mm:ss"),
                    calendar_endDate.SelectedDate.ToString("dd / MMM / yyyy hh: mm:ss"), tb_desc.Text, decimal.Parse(tb_amt.Text));
                result = coup.CouponInsert();

                if (result > 0)
                {
                    Response.Write("<script>alert('Insert successful');</script>");
                    Response.Redirect("Coupons(lermin).aspx?result =" + result);
                }
                else { Response.Write("<script>alert('Insert NOT successful');</script>"); }
            }

        }

        protected void btn_view_Click(object sender, EventArgs e)
        {
            Response.Redirect("Coupons(lermin).aspx");
        }

        protected void cal_delivery_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date < DateTime.Now.Date)
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Red;
                e.Cell.Font.Strikeout = true;
            }
        }

        protected void calendar_startDate_SelectionChanged(object sender, EventArgs e)
        {

            // BirthDateCalendar.SelectedDate = BirthDateCalendar.VisibleDate;
            tb_startdate.Text = calendar_startDate.SelectedDate.ToShortDateString();
            //IsValidDate();

        }

        protected void calendar_endDate_SelectionChanged(object sender, EventArgs e)
        {
            tb_enddate.Text = calendar_endDate.SelectedDate.ToShortDateString();
            //IsValidDate();
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime startDate = Convert.ToDateTime(tb_startdate.Text);
            DateTime endDate = Convert.ToDateTime(tb_enddate.Text);

            if (endDate < startDate)
            {
                args.IsValid = false;
            }
        }



    }
}