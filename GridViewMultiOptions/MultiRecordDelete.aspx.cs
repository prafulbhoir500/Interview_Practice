using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Interview_Practice.GridViewMultiOptions
{
    public partial class MultiRecordDelete : System.Web.UI.Page
    {
        string CS = ConfigurationManager.ConnectionStrings["TestDbCon"].ConnectionString;
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
            SqlDataAdapter sda = new SqlDataAdapter("Select * from Person", sqlcon);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                GridViewPersonData.DataSource = dt;
                GridViewPersonData.DataBind();
            }
        }
        void ClearForm()
        {
            txtName.Text = "";
            txtCity.Text = "";
            rdoGender.SelectedIndex = -1;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(CS);
            try
            {
                SqlCommand sqlcmd = new SqlCommand("insert into Person (Name,Gender,City) values (@name,@gender,@city)", sqlcon);
                sqlcmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@gender", rdoGender.SelectedValue);
                sqlcmd.Parameters.AddWithValue("@city", txtCity.Text.Trim());
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }

                int isInsert = sqlcmd.ExecuteNonQuery();

                if (isInsert > 0)
                {
                    Response.Write("<script>alert('New Record Added...')</script>");
                    BindGridViewData();
                    ClearForm();
                }
                else
                {
                    Response.Write("<script>alert('New Record Added...')</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
            finally
            {
                if (sqlcon.State == ConnectionState.Open)
                {
                    sqlcon.Close();
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow r in GridViewPersonData.Rows)
            {
                CheckBox chk = (CheckBox)r.FindControl("chkRecord");

                if (chk.Checked)
                {
                    //int id=Convert.ToInt32(r.FindControl ("id"));
                    int id = Convert.ToInt32((GridViewPersonData.DataKeys[r.RowIndex].Value));
                    Response.Write("<script>alert('" + id + "')</script>");
                }
            }
        }
    }
}