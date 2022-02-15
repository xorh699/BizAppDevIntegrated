﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BizAppDev
{
    public partial class CouponsValidity_lermin__employee_ : System.Web.UI.Page
    {
        Coupons2 aCoup = new Coupons2();
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
            List<Coupons2> couponList = new List<Coupons2>();
            couponList = aCoup.getCoupAll();
            GridView1.DataSource = couponList;
            GridView1.DataSourceID = string.Empty;
            GridView1.DataBind();
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

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    int amount = int.Parse(GridView1.Rows[i].Cells[3].Text);

                    if (amount == 0)
                    {
                        GridView1.Rows[i].ForeColor = System.Drawing.Color.Red;

                    }
                    else if (amount > 0)
                    {
                        GridView1.Rows[i].ForeColor = System.Drawing.Color.Green;
                    }

                }
            }
            catch
            {

            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            bind();
        }



        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            bind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            string couponID = row.Cells[0].Text;
            Response.Redirect("Coupons2Detail(employee).aspx?couponID=" + couponID);
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddPersonalCoupon.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            List<Coupons2> couponList = new List<Coupons2>();
            couponList = aCoup.getavailablecoupons();
            GridView1.DataSource = couponList;
            GridView1.DataSourceID = string.Empty;
            GridView1.DataBind();
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            List<Coupons2> couponList = new List<Coupons2>();
            couponList = aCoup.getredeemedcoupons();
            GridView1.DataSource = couponList;
            GridView1.DataSourceID = string.Empty;
            GridView1.DataBind();
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            List<Coupons2> couponList = new List<Coupons2>();
            couponList = aCoup.getCoupAll();
            GridView1.DataSource = couponList;
            GridView1.DataSourceID = string.Empty;
            GridView1.DataBind();
        }


    }
}