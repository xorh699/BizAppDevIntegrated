using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BizAppDev
{
    public partial class ProductCustView : System.Web.UI.Page
    {
        ProductCust aProdCust = new ProductCust();
        protected void Page_Load(object sender, EventArgs e)
        {
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
            List<ProductCust> ProductCustList = new List<ProductCust>();
            ProductCustList = aProdCust.getProdCust(CID);
            gvProdCust.DataSource = ProductCustList;
            gvProdCust.DataBind();
        }

        protected void gvProdCust_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int result = 0;
            ProductCust productCust = new ProductCust();
            string categoryID = gvProdCust.DataKeys[e.RowIndex].Value.ToString();
            result = productCust.ProdCustDelete(categoryID);

            if (result > 0)
            {
                Response.Write("<script>alert('Customization details deleted');</script>");
            }
            else
            {
                Response.Write("<script>alert('Delete unsuccessful');</script>");
            }

            Response.Redirect("ProductCustView.aspx");
        }

        protected void gvProdCust_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvProdCust.EditIndex = e.NewEditIndex;
            bind();
        }

        protected void gvProdCust_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvProdCust.EditIndex = -1;
            bind();
        }

        protected void gvProdCust_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int result = 0;
            ProductCust productCust = new ProductCust();
            GridViewRow row = (GridViewRow)gvProdCust.Rows[e.RowIndex];
            string pcID = gvProdCust.DataKeys[e.RowIndex].Value.ToString();
            DropDownList ddl_catview = (DropDownList)gvProdCust.Rows[e.RowIndex].FindControl("ddl_catview") as DropDownList;
            string pcCat = ddl_catview.SelectedItem.Text;
            DropDownList ddl_colview = (DropDownList)gvProdCust.Rows[e.RowIndex].FindControl("ddl_colview") as DropDownList;
            string pcCol = ddl_colview.SelectedItem.Text;
            DropDownList ddl_stview = (DropDownList)gvProdCust.Rows[e.RowIndex].FindControl("ddl_stview") as DropDownList;
            string pcScent = ddl_stview.SelectedItem.Text;
            TextBox tbname = (TextBox)gvProdCust.Rows[e.RowIndex].FindControl("TextBox1");
            string name = tbname.Text;
            TextBox tbemail = (TextBox)gvProdCust.Rows[e.RowIndex].FindControl("TextBox2");
            string email = tbemail.Text;
            string contact = ((TextBox)row.Cells[7].Controls[0]).Text;
            Calendar cal = (Calendar)gvProdCust.Rows[e.RowIndex].FindControl("Calendar1");
            TextBox tbdate = (TextBox)gvProdCust.Rows[e.RowIndex].FindControl("TextBox3");
            string date = tbdate.Text;


            if (ddl_colview.SelectedItem.Text != "Default" && ddl_stview.SelectedItem.Text != "Default")
            {
               if(cal.SelectedDate.ToString("dd/MM/yyyy") != "01/01/0001")
                {
                    string datee = cal.SelectedDate.ToString("dd/MM/yyyy");
                    result = productCust.ProdCustUpdate(pcID, pcCat, pcCol, pcScent, name, email, contact, datee);
                }
                else
                {
                    result = productCust.ProdCustUpdate(pcID, pcCat, pcCol, pcScent, name, email, contact, date);
                }
            }
            else
            {
                Response.Write("<script>alert('Select at least 1 customization');</script>");
            }
            if (result > 0)
            {
                Response.Write("<script>alert('Update Successful');</script>");
            }


            gvProdCust.EditIndex = -1;
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