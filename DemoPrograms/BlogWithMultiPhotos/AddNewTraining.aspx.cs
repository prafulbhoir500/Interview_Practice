using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Interview_Practice.DemoPrograms.BlogWithMultiPhotos
{
    public partial class AddNewTraining : System.Web.UI.Page
    {
        DataTable dtImages;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitializeDataTable();
            }
        }

        private void InitializeDataTable()
        {
            dtImages = new DataTable();
            dtImages.Columns.Add("ImageURL", typeof(string));
            dtImages.Columns.Add("ImageAlt", typeof(string));
            dtImages.Columns.Add("IsActive", typeof(bool));
            dtImages.Columns.Add("IsDefault", typeof(bool));

            ViewState["Images"] = dtImages;
        }

        protected void btnAddImage_Click(object sender, EventArgs e)
        {
            dtImages = (DataTable)ViewState["Images"];

            foreach (HttpPostedFile file in FileUpload1.PostedFiles)
            {
                string fileName = Path.GetFileName(file.FileName);
                string filePath = "~/Images/" + fileName; // You can customize the path as needed
                file.SaveAs(Server.MapPath(filePath));

                DataRow dr = dtImages.NewRow();
                dr["ImageURL"] = filePath;
                dr["ImageAlt"] = txtImageName.Text;
                dr["IsActive"] = chkActive.Checked;
                dr["IsDefault"] = chkDefault.Checked;

                dtImages.Rows.Add(dr);
            }

            ViewState["Images"] = dtImages;
            gvImages.DataSource = dtImages;
            gvImages.DataBind();
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            int rowIndex = int.Parse((sender as Button).CommandArgument);
            dtImages = (DataTable)ViewState["Images"];

            if (rowIndex >= 0 && rowIndex < dtImages.Rows.Count)
            {
                dtImages.Rows.RemoveAt(rowIndex);
                gvImages.DataSource = dtImages;
                gvImages.DataBind();
                
            }
        }



    }
}