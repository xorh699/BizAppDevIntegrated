using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Data;
namespace BizAppDev
{
    public partial class nonmemberhome : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
         
        }

        protected void Button_shopnow_Click(object sender, EventArgs e)
        {
            Response.Redirect("nonmemberproductpage.aspx");
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            try
            {
                var from = "josspapery2@gmail.com";
                var to = "josspapeey2@gmaail.com";
                const string Password = "Bf2001grp4";
                string mail_subject = tb_subject.Text.ToString();
                string mail_message = "From:" + tb_name.Text + " " + tb_lastname.Text + "\n";
                mail_message += "Email:" + tb_email.Text + "\n";
                mail_message += "Subject:" + tb_subject.Text + "\n";
                mail_message += "Message:" + tb_message.Text + "\n";

                var smtp = new SmtpClient();
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(from, Password);
                    smtp.Timeout = 20000;
                }

                smtp.Send(from, to, mail_subject, mail_message);

                Confirm();
                lbl_confirm.Text = "Thank you for your contacting us!";

                tb_name.Text = "";
                tb_lastname.Text = "";
                tb_email.Text = "";
                tb_subject.Text = "";
                tb_message.Text = "";
            }
            catch (Exception)
            {
                lbl_confirm.Text = "Something went wrong! Please try again";
                lbl_confirm.ForeColor = Color.Red;
            }
        }

        private void BindListView()
        {
            string constr = ConfigurationManager.ConnectionStrings["Project"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT offer_Name, offer_startDate, offer_endDate, offer_Desc, offer_Image FROM Offers WHERE offer_startDate > = @EventDate AND offer_endDate < = @EventDate";
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@EventDate", DateTime.Now.ToString("dd / MMM / yyyy hh: mm:ss"));
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        DataList1.DataSource = dt;
                        DataList1.DataBind();
                    }
                }
            }
        }
        private void BindListView1()
        {
            string constr = ConfigurationManager.ConnectionStrings["Project"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT coupon_Name, coup_disccountamt FROM Coupons WHERE coupon_startDate > = @EventDate AND coupon_endDate < = @EventDate";
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@EventDate", DateTime.Now.ToString("dd / MMM / yyyy hh: mm:ss"));
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        DataList1.DataSource = dt;
                        DataList1.DataBind();
                    }
                }
            }
        }
        private void Confirm()
        {
            string ToEmail = tb_email.Text.Trim();
            string UserName = tb_name.Text + tb_lastname.Text;
            string subject2 = tb_subject.Text;

            MailMessage mailMessage = new MailMessage("emailaddress@gmail.com", ToEmail);

            StringBuilder sbEmailBody = new StringBuilder();
            sbEmailBody.Append("Dear  " + UserName);
            sbEmailBody.Append("<br/><br/>");
            sbEmailBody.Append("Thank you for your email");
            sbEmailBody.Append("<br/><br/>");
            sbEmailBody.Append("We receieved your email regarding  " + subject2 + "<br/>"); ;
            sbEmailBody.Append("We will be back to you as soon as possible.");
            sbEmailBody.Append("<br/><br/><br/>");
            sbEmailBody.Append("Sincerely,");
            sbEmailBody.Append("Xavier Ong, Kim Simi Zua Team .");

            mailMessage.IsBodyHtml = true;

            mailMessage.Body = sbEmailBody.ToString();
            mailMessage.Subject = "Re: Thank you for your email ";
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "josspapery2@gmail.com",
                Password = "Bf2001grp4"
            };

            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            Label lbl = (Label)e.Item.FindControl("Label1");
            Response.Redirect("nonmembermembershiptierlistmoreinfo.aspx?memberID=" + lbl.Text);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("nonmemberhome.aspx");
        }
    }

}