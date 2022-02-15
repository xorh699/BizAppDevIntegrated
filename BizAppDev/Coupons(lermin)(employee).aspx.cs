using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BizAppDev
{
    public partial class Coupons_lermin__employee_ : System.Web.UI.Page
    {
        Coupons aCoup = new Coupons();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int result = int.Parse(Request.QueryString["result"].ToString());
                if (result > 0)
                {
                    lbl_alert.Text = "Added Sucessfully.";
                    lbl_alert.ForeColor = System.Drawing.Color.Green;
                }
            }
            catch
            {

            }
            finally
            {
                if (!IsPostBack)
                {
                    bind();
                }
            }

        }
        protected void bind()
        {
            List<Coupons> couponList = new List<Coupons>();
            couponList = aCoup.getCoupAll();
            gvCoupons.DataSource = couponList;
            gvCoupons.DataSourceID = string.Empty;
            gvCoupons.DataBind();
        }

        protected void gvCoupons_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvCoupons.SelectedRow;
            string couponID = row.Cells[0].Text;
            Response.Redirect("CouponDetail(employee).aspx?couponID=" + couponID);
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("CouponInsert.aspx");

        }

        protected void gvCoupons_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvCoupons.EditIndex = e.NewEditIndex;
            bind();
        }

        protected void gvCoupons_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCoupons.EditIndex = -1;
            bind();
        }

        protected void gvCoupons_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int result = 0;
            Coupons coup = new Coupons();
            GridViewRow row = (GridViewRow)gvCoupons.Rows[e.RowIndex];
            string cid = ((TextBox)row.Cells[0].Controls[0]).Text;
            string cname = ((TextBox)row.Cells[1].Controls[0]).Text;
            string cstartdate = ((TextBox)row.Cells[2].Controls[0]).Text;
            string cenddate = ((TextBox)row.Cells[3].Controls[0]).Text;

            Decimal cAmt = decimal.Parse(((TextBox)row.Cells[4].Controls[0]).Text);

            result = coup.CoupUpdate(cid, cname, cstartdate, cenddate, cAmt);
            if (result > 0)
            {
                Response.Write("<script>alert('Coupon updated successfully');</script>");
                lbl_alert.Text = "Coupon updated successfully.";
                lbl_alert.ForeColor = System.Drawing.Color.Green;

            }
            else
            {
                Response.Write("<script>alert('Coupon NOT updated');</script>");
                lbl_alert.Text = "Coupon NOT updated.";
                lbl_alert.ForeColor = System.Drawing.Color.Red;
            }
            gvCoupons.EditIndex = -1;
            bind();
        }

        protected void gvCoupons_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            try
            {
                for (int i = 0; i < gvCoupons.Rows.Count; i++)
                {
                    DateTime date = Convert.ToDateTime(gvCoupons.Rows[i].Cells[3].Text);
                    DateTime date1 = Convert.ToDateTime(gvCoupons.Rows[i].Cells[2].Text);
                    if (DateTime.Now > date)
                    {
                        gvCoupons.Rows[i].Cells[3].ForeColor = System.Drawing.Color.Red;
                        gvCoupons.Rows[i].Cells[2].ForeColor = System.Drawing.Color.Red;
                    }
                    else if (date1 < DateTime.Now)
                    {
                        if (DateTime.Now <= date)
                        {
                            gvCoupons.Rows[i].Cells[3].ForeColor = System.Drawing.Color.Green;
                            gvCoupons.Rows[i].Cells[2].ForeColor = System.Drawing.Color.Green;
                        }
                    }

                }
            }
            catch
            {

            }

        }

        protected void gvCoupons_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            Coupons coup = new Coupons();
            GridViewRow row = gvCoupons.Rows[e.RowIndex];
            Label itemIdLabel = (Label)row.FindControl("coupon ID");
            string itemId = row.Cells[0].Text;
            //string categoryID = gvCoupons.DataKeys[e.RowIndex].Value.ToString();
            Console.WriteLine(itemId);
            result = coup.CouponDelete(itemId);

            if (result > 0)
            {
                Response.Write("<script>alert('Product Remove successfully');</script>");
                lbl_alert.Text = "Coupon remove successfully";
                lbl_alert.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                Response.Write("<script>alert('Product Removal NOT successfully');</script>");
                lbl_alert.Text = "Coupon removal NOT successful";
                lbl_alert.ForeColor = System.Drawing.Color.Red;
            }

            Response.Redirect("Coupons(lermin)(employee).aspx");
        }

        protected void filter_click(object sender, EventArgs e)
        {
            List<Coupons> couponList = new List<Coupons>();
            couponList = aCoup.afterfilter();
            gvCoupons.DataSource = couponList;
            gvCoupons.DataSourceID = string.Empty;
            gvCoupons.DataBind();

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            List<Coupons> couponList = new List<Coupons>();
            couponList = aCoup.getCoupAll();
            gvCoupons.DataSource = couponList;
            gvCoupons.DataSourceID = string.Empty;
            gvCoupons.DataBind();
        }

        protected void lb_upcoming_coupons_Click(object sender, EventArgs e)
        {
            List<Coupons> couponList = new List<Coupons>();
            couponList = aCoup.upcomingcoupon();
            gvCoupons.DataSource = couponList;
            gvCoupons.DataSourceID = string.Empty;
            gvCoupons.DataBind();
        }

        protected void lb_past_coupons_Click(object sender, EventArgs e)
        {
            List<Coupons> couponList = new List<Coupons>();
            couponList = aCoup.pastcoupons();
            gvCoupons.DataSource = couponList;
            gvCoupons.DataSourceID = string.Empty;
            gvCoupons.DataBind();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "1")
            {
                Response.Redirect("Coupons(lermin)(employee).aspx");
            }
            if (DropDownList1.SelectedValue == "2")
            {
                Response.Redirect("CouponsValidity(lermin)(employee).aspx");
            }
        }

    }
}