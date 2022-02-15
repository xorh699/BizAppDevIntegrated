using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BizAppDev
{
    public partial class PriestsView : System.Web.UI.Page
    {
        Priests aPriest = new Priests();
        protected void Page_Load(object sender, EventArgs e)
        {
            gvPriest.Attributes.Add("style", "word-break:break-all; word-wrap:break-word");
            if (!IsPostBack)
            {
                bind();
            }
        }
        protected void bind()
        {
            HttpContext context = HttpContext.Current;
            //Session["CID"] = "ss4";
            string CID = Session["CID"].ToString();
            List<Priests> PriestList = new List<Priests>();
            PriestList = aPriest.GetPriest(CID);
            gvPriest.DataSource = PriestList;
            gvPriest.DataBind();
        }

        protected void gvPriest_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPriest.EditIndex = e.NewEditIndex;
            bind();
        }

        protected void gvPriest_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvPriest.EditIndex = -1;
            bind();
        }

        protected void gvPriest_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            Priests priest = new Priests();
            string categoryID = gvPriest.DataKeys[e.RowIndex].Value.ToString();
            result = priest.PriestDelete(categoryID);

            if (result > 0)
            {
                Response.Redirect("PriestsView.aspx");

            }
            else
            {
                Response.Write("<script>alert('Delete unsuccessful');</script>");
            }
        }

        protected void gvPriest_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int result = 0;
            Priests priest = new Priests();
            GridViewRow row = (GridViewRow)gvPriest.Rows[e.RowIndex];
            string AUid = gvPriest.DataKeys[e.RowIndex].Value.ToString();
            TextBox tb_location =(TextBox)gvPriest.Rows[e.RowIndex].FindControl("Textbox2");
            string AUlocation = tb_location.Text;
            Calendar cal = (Calendar)gvPriest.Rows[e.RowIndex].FindControl("Calendar1");
            TextBox tb1 = (TextBox)gvPriest.Rows[e.RowIndex].FindControl("TextBox1");
            string AUdate = tb1.Text;
            if (cal.SelectedDate.ToString("dd/MM/yyyy") != "01/01/0001")
            {
                string AUdatee = cal.SelectedDate.ToString("dd/MM/yyyy");
                result = priest.PriestUpdate(AUid, AUlocation, AUdatee);
            }
            else
            {
                result = priest.PriestUpdate(AUid, AUlocation, AUdate);
            }

            if (result > 0)
            {
                Response.Write("<script>alert('Update Successful');</script>");
            }

            gvPriest.EditIndex = -1;
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