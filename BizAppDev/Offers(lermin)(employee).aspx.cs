using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BizAppDev
{
    public partial class Offers_lermin__employee_ : System.Web.UI.Page
    {
        Offers aOffer = new Offers();

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
            List<Offers> offerList = new List<Offers>();
            offerList = aOffer.getOffersAll();
            gvOffer.DataSource = offerList;
            gvOffer.DataBind();
        }

        protected void gvOffer_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvOffer.SelectedRow;

            // Get Product ID from the selected row, which is the 
            // first row, i.e. index 0.
            string offerID = row.Cells[0].Text;

            // Redirect to next page, with the Product Id added to the URL,
            // e.g. ProductDetails.aspx?ProdID=1
            Response.Redirect("offerDetails(employee).aspx?offerID=" + offerID);

        }

      

        protected void gvOffer_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvOffer.EditIndex = e.NewEditIndex;
            bind();
        }

        protected void gvOffer_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int result = 0;
            Offers offer = new Offers();
            GridViewRow row = (GridViewRow)gvOffer.Rows[e.RowIndex];
            string oid = ((TextBox)row.Cells[0].Controls[0]).Text;
            string oname = ((TextBox)row.Cells[1].Controls[0]).Text;
            string ostartDate = ((TextBox)row.Cells[2].Controls[0]).Text;
            string oendDate = ((TextBox)row.Cells[3].Controls[0]).Text;

            result = offer.OfferUpdate(oid, oname, ostartDate, oendDate);
            if (result > 0)
            {
                Response.Write("<script>alert('Offer updated successfully');</script>");
                lbl_alert.Text = "Offer update successfully";
                lbl_alert.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                Response.Write("<script>alert('Offer NOT updated');</script>");
                lbl_alert.Text = "Offer update NOT successfully";
                lbl_alert.ForeColor = System.Drawing.Color.Red;
            }
            gvOffer.EditIndex = -1;
            bind();

        }

        protected void gvOffer_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvOffer.EditIndex = -1;
            bind();

        }

        protected void gvOffer_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                for (int i = 0; i < gvOffer.Rows.Count; i++)
                {
                    DateTime date = Convert.ToDateTime(gvOffer.Rows[i].Cells[3].Text);
                    DateTime date1 = Convert.ToDateTime(gvOffer.Rows[i].Cells[2].Text);
                    if (DateTime.Now > date)
                    {
                        gvOffer.Rows[i].Cells[3].ForeColor = System.Drawing.Color.Red;
                        gvOffer.Rows[i].Cells[2].ForeColor = System.Drawing.Color.Red;
                    }
                    else if (date1 < DateTime.Now)
                    {
                        if (DateTime.Now <= date)
                        {
                            gvOffer.Rows[i].Cells[3].ForeColor = System.Drawing.Color.Green;
                            gvOffer.Rows[i].Cells[2].ForeColor = System.Drawing.Color.Green;
                        }
                    }

                }
            }
            catch
            {

            }
        }

        protected void gvOffer_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            Offers coup = new Offers();
            GridViewRow row = gvOffer.Rows[e.RowIndex];
            Label itemIdLabel = (Label)row.FindControl("offer ID");
            string itemId = row.Cells[0].Text;
            //string categoryID = gvCoupons.DataKeys[e.RowIndex].Value.ToString();
            Console.WriteLine(itemId);
            result = coup.offerDelete(itemId);

            if (result > 0)
            {
                Response.Write("<script>alert('Product Remove successfully');</script>");
                lbl_alert.Text = "Offer remove succesfully.";
                lbl_alert.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                Response.Write("<script>alert('Product Removal NOT successfully');</script>");
                lbl_alert.Text = "Offer removal was NOT succesfully.";
                lbl_alert.ForeColor = System.Drawing.Color.Red;
            }

            Response.Redirect("Coupons(lermin).aspx");
        }

        protected void filter_click(object sender, EventArgs e)
        {
            List<Offers> offerList = new List<Offers>();
            offerList = aOffer.afterfilter();
            gvOffer.DataSource = offerList;
            gvOffer.DataBind();
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            List<Offers> offerList = new List<Offers>();
            offerList = aOffer.getOffersAll();
            gvOffer.DataSource = offerList;
            gvOffer.DataBind();
        }

        protected void lb_upcoming_coupons_Click(object sender, EventArgs e)
        {
            List<Offers> offerList = new List<Offers>();
            offerList = aOffer.upcomingoffer();
            gvOffer.DataSource = offerList;
            gvOffer.DataBind();
        }

        protected void lb_past_coupons_Click(object sender, EventArgs e)
        {
            List<Offers> offerList = new List<Offers>();
            offerList = aOffer.pastoffers();
            gvOffer.DataSource = offerList;
            gvOffer.DataBind();
        }



    }
}