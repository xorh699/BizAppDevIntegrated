using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BizAppDev
{
    public partial class EduVideoInsert : System.Web.UI.Page
    {
        string _connStr = ConfigurationManager.ConnectionStrings["ServicesContext"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (eduVidUpload.FileContent.Length > 104857600)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void eduInsert_Click(object sender, EventArgs e)
        {
            if (eduVidUpload.HasFile)
            {
            string filename = Path.GetFileName(eduVidUpload.FileName);
                if (eduVidUpload.PostedFile.ContentLength < 104857600)
                {
                    eduVidUpload.SaveAs(Server.MapPath("/EducationalVideos/" + filename));
                    SqlConnection sqlconn = new SqlConnection(_connStr);
                    string query = "insert into EducationVideo(Category,Description,Path)" + "values (@Cat,@Desc,@Path)";
                    sqlconn.Open();
                    SqlCommand sqlcomm = new SqlCommand(query, sqlconn);
                    sqlcomm.Parameters.AddWithValue("@Cat", DropDownList1.SelectedItem.Text);
                    sqlcomm.Parameters.AddWithValue("@Desc", tb_vidDesc.Text);
                    sqlcomm.Parameters.AddWithValue("@Path", "/EducationalVideos/" + filename);
                    sqlcomm.ExecuteNonQuery();
                    sqlconn.Close();
                    Response.Redirect("EduVideoInsert.aspx");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            gv_eduVid.DataSourceID = null;
            if (ddlSort.SelectedItem.Text == "Default")
            {
                gv_eduVid.DataSource = SqlDataSource3;
                gv_eduVid.DataBind();
            }
            if (ddlSort.SelectedItem.Text == "Chinese New Year")
            {
                gv_eduVid.DataSource = SqlDataSource2;
                gv_eduVid.DataBind();
            }
            if (ddlSort.SelectedItem.Text == "Qing Ming Festival")
            {
                gv_eduVid.DataSource = SqlDataSource2;
                gv_eduVid.DataBind();
            }
            if (ddlSort.SelectedItem.Text == "Mid Authumn Festival")
            {
                gv_eduVid.DataSource = SqlDataSource2;
                gv_eduVid.DataBind();
            }

        }
    }
}