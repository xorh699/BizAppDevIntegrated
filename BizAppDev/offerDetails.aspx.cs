using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BizAppDev
{
    public partial class offerDetails : System.Web.UI.Page
    {
        Offers offer = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            Offers aOffer = new Offers();
            string offerID = Request.QueryString["offerID"].ToString();
            offer = aOffer.getOffer(offerID);

            lbl_offerID.Text = offerID.ToString();
            lbl_offerName.Text = offer.offer_Name;
            lbl_offerDesc.Text = offer.offer_Desc;
            lbl_offerstartDate.Text = offer.offer_startDate;
            lbl_endDate.Text = offer.offer_endDate;
            img_offer.ImageUrl = "~\\images\\" + offer.offer_Image;

        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Offers(lermin).aspx");
        }


    }
}