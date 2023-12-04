using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Interview_Practice
{
    public partial class Multi_Record_Delete_GridView : System.Web.UI.Page
    {
        string CS = ConfigurationManager.ConnectionStrings["TestDB1"].ConnectionString;
        int deleteCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridViewData();
            }
        }

        private void BindGridViewData()
        {
            SqlConnection sqlcon = new SqlConnection(CS);
            SqlDataAdapter sda = new SqlDataAdapter("select * from Person", sqlcon);
            DataTable dt = new DataTable();

            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GridViewPerson.DataSource = dt;
                GridViewPerson.DataBind();
            }
        }



        protected void GridViewPerson_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteMulti")
            {
                //Response.Write("<script>alert('ddddddd')</script>");
                foreach (GridViewRow r in GridViewPerson.Rows)
                {
                    CheckBox chk = (CheckBox)r.FindControl("CheckBox1");
                    if (chk.Checked)
                    {
                        int id = Convert.ToInt32((r.Cells[0]).Text);
                        //Response.Write("<script>alert('" + id + "')</script>");

                        deleteRow(id);

                    }
                }
                BindGridViewData();
                Response.Write("<script>alert('" + deleteCount + " Records Deleted...')</script>");


            }
        }

        private void deleteRow(int id)
        {
            SqlConnection sqlcon = new SqlConnection(CS);
            SqlCommand sqlcmd = new SqlCommand("Delete From Person where ID=@id", sqlcon);
            sqlcmd.Parameters.AddWithValue("@id", id);
            if (sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();
            }
            int isDelete = sqlcmd.ExecuteNonQuery();
            if (isDelete > 0)
            {
                deleteCount++;
            }
            sqlcon.Close();
        }
    }
}