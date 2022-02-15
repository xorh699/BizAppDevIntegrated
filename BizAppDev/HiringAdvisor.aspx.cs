using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BizAppDev
{
    public partial class HiringAdvisor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AdvisorDate.Visible = false;
            }
        }

        protected void calImg_Click(object sender, ImageClickEventArgs e)
        {
            if (AdvisorDate.Visible)
            {
                AdvisorDate.Visible = false;
            }
            else
            {
                AdvisorDate.Visible = true;
            }
        }

        protected void AdvisorDate_SelectionChanged(object sender, EventArgs e)
        {
            tbAdDate.Text = AdvisorDate.SelectedDate.ToString("dd/MM/yyyy");
            AdvisorDate.Visible = false;
        }

        protected void hireBtn_Click(object sender, EventArgs e)
        {
            int result = 0;
            Session["CID"] = TextBox1.Text;
            Advisor hireAdvisor = new Advisor(TextBox1.Text,tbAdDesc.Text,
                ddlAdMode.SelectedItem.Text, tbAdDate.Text);
            result = hireAdvisor.AdvisorInsert();
            if (result > 0)
            {
                Response.Redirect("AdvisorsView.aspx");
            }
        }

        protected void AdvisorDate_DayRender(object sender, DayRenderEventArgs e)
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