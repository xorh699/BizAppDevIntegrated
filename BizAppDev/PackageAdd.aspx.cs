using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BizAppDev
{
    public partial class PackageAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_insert_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int result = 0;
                string image = "";
                string str = "";
                string IMAGE = "images\\";

                for (int i = 0; i < CheckBoxList1.Items.Count; i++)
                {
                    if (CheckBoxList1.Items[i].Selected == true)
                    { // getting selected value from CheckBox List  
                        str += CheckBoxList1.Items[i].Text + " ," + "<br/>"; // add selected Item text to the String .  
                    }
                }

                if (FileUpload1.HasFile == true)
                {
                    image = IMAGE + FileUpload1.FileName;
                }

                Package package = new Package(tb_name.Text, str, tb_desc.Text,
                    decimal.Parse(tb_price.Text), FileUpload1.FileName, td_keyword.Text);
                result = package.packageInsert();

                if (result > 0)
                {
                    string saveimg = Server.MapPath(" ") + "\\" + image;
                    Label1.Text = saveimg.ToString();
                    FileUpload1.SaveAs(saveimg);
                    //loadProductInfo();
                    //loadProduct();
                    //clear1();
                    Response.Write("<script>alert('Insert successful');</script>");
                    Response.Redirect("Products(lermin).aspx?result = " + result);
                }
                else { Response.Write("<script>alert('Insert NOT successful');</script>"); }
            }
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs e)
        {

        }



    }
}