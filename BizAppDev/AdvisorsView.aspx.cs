using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BizAppDev
{
    public partial class AdvisorsView : System.Web.UI.Page
    {
        Advisor aAdvisor = new Advisor();
        protected void Page_Load(object sender, EventArgs e)
        {
            gvAdvisor.Attributes.Add("style", "word-break:break-all; word-wrap:break-word");
            if (!IsPostBack)
            {
                bind();  
            }
        }
        protected void bind()
        {
            HttpContext context = HttpContext.Current;
            //Session["CID"] = "ss1";
            string CID = Session["CID"].ToString();
            List<Advisor> AdvisorList = new List<Advisor>();
            AdvisorList = aAdvisor.GetAdvisor(CID);
            gvAdvisor.DataSource = AdvisorList;
            gvAdvisor.DataBind();
        }

        protected void gvAdvisor_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvAdvisor.EditIndex = e.NewEditIndex;
            bind();
        }

        protected void gvAdvisor_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvAdvisor.EditIndex = -1;
            bind();
        }

        protected void gvAdvisor_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            Advisor advisor = new Advisor();
            string categoryID = gvAdvisor.DataKeys[e.RowIndex].Value.ToString();
            result = advisor.AdvisorDelete(categoryID);

            if (result > 0)
            {
                Response.Write("<script>alert('Appointment deleted');</script>");
            }
            else
            {
                Response.Write("<script>alert('Delete unsuccessful');</script>");
            }
        }

        protected void gvAdvisor_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int result = 0;
            Advisor advisor = new Advisor();
            GridViewRow row = (GridViewRow)gvAdvisor.Rows[e.RowIndex];
            string AUid = gvAdvisor.DataKeys[e.RowIndex].Value.ToString();
            TextBox tb2 = (TextBox)gvAdvisor.Rows[e.RowIndex].FindControl("TextBox2");
            string AUdesc = tb2.Text;
            DropDownList ddl_mode = (DropDownList)gvAdvisor.Rows[e.RowIndex].FindControl("ddlMode");
            string AUmode = ddl_mode.SelectedItem.Text;
            Calendar cal = (Calendar)gvAdvisor.Rows[e.RowIndex].FindControl("Calendar1");
            TextBox tb1 = (TextBox)gvAdvisor.Rows[e.RowIndex].FindControl("TextBox1");
            string AUdate = tb1.Text;

            if (cal.SelectedDate.ToString("dd/MM/yyyy") != "01/01/0001")
            {
                string AUdatee = cal.SelectedDate.ToString("dd/MM/yyyy");
                result = advisor.AdvisorUpdate(AUid, AUdesc, AUmode, AUdatee);
            }
            else
            {
                result = advisor.AdvisorUpdate(AUid, AUdesc, AUmode, AUdate);
            }

            if (result > 0)
            {
                Response.Write("<script>alert('Update Successful');</script>");
            }

            gvAdvisor.EditIndex = -1;
            bind();
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date < DateTime.Now.Date)
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Red;
                e.Cell.Font.Strikeout = true;
            }
        }
    }
}