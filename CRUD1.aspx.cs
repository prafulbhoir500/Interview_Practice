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
    public partial class CRUD1 : System.Web.UI.Page
    {
        string CS = ConfigurationManager.ConnectionStrings["TestDbCon"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindGridData();
            }
        }

        private void BindGridData()
        {
            SqlConnection sqlcon=new SqlConnection(CS);
            SqlDataAdapter sda = new SqlDataAdapter("select * from Person", sqlcon);
            DataTable dt=new DataTable();
            sda.Fill(dt);

            if(dt.Rows.Count>0)
            {
                GridViewData.DataSource = dt;
                GridViewData.DataBind();
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        private void clearForm()
        {
            foreach (var c in form1.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Text = "";
                }
                if (c is DropDownList)
                {
                    ((DropDownList)c).SelectedIndex = 0;
                }
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(CS);
            try
            {

                SqlCommand sqlcmd = new SqlCommand("insert into Person (Name,Gender,City) values(@name,@gender,@city)", sqlcon);
                sqlcmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                sqlcmd.Parameters.AddWithValue("gender", ddlGender.SelectedValue);
                sqlcmd.Parameters.AddWithValue("@city", txtCity.Text.Trim());
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                int isInsert = sqlcmd.ExecuteNonQuery();
                if (isInsert > 0)
                {
                    Response.Write("<script>alert('Data Added...')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Data Not Added...')</script>");
                }
                BindGridData();
                clearForm();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                if(sqlcon != null)
                {
                    if(sqlcon.State==ConnectionState.Open)
                    {
                        sqlcon.Close();
                    }
                }
            }
        }

        protected void GridViewData_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridViewData.DataKeys[e.RowIndex].Value);
            //Response.Write("<script>alert('"+id+"')</script>");
            SqlConnection sqlcon = new SqlConnection(CS);
            string query = "DELETE FROM Person where ID=@id";
            SqlCommand sqlcmd = new SqlCommand(query,sqlcon);
            sqlcmd.Parameters.AddWithValue("@id", id);
            if (sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();
            }
            int isDelete = sqlcmd.ExecuteNonQuery();
            if (isDelete > 0)
            {
                Response.Write("<script>alert('Data Deleted...')</script>");
            }
            else
            {
                Response.Write("<script>alert('Data Not Deleted...')</script>");
            }
            BindGridData();


        }

        protected void GridViewData_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int id = Convert.ToInt32(GridViewData.DataKeys[e.NewEditIndex].Value);
            //Response.Write("<script>alert('" + id + "')</script>");
            if(fillData(id)==0)
            {
                Response.Write("<script>alert('Somthing is Wrong')</script>");

            }
        }

        private int fillData(int id)
        {
            SqlConnection sqlcon = new SqlConnection(CS);
            SqlDataAdapter sda = new SqlDataAdapter("select * from Person where id="+id+"", sqlcon);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                txtID.Text = dt.Rows[0]["ID"].ToString();
                txtName.Text = dt.Rows[0]["Name"].ToString();
                ddlGender.SelectedValue = dt.Rows[0]["Gender"].ToString();
                txtCity.Text = dt.Rows[0]["City"].ToString();
                btnSubmit.Visible = false;
                btnUpdate.Visible = true;
                return 1;
            }
            else
            {
                return 0;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(CS);
            string query = "Update Person SET Name=@name, Gender=@gender,City=@city where ID=@id";
            SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
            sqlcmd.Parameters.AddWithValue("@id",txtID.Text.Trim());
            sqlcmd.Parameters.AddWithValue("@name",txtName.Text.Trim());
            sqlcmd.Parameters.AddWithValue("@gender",ddlGender.SelectedValue);
            sqlcmd.Parameters.AddWithValue("@city",txtCity.Text.Trim());
            if (sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();
            }
            int isUpdate = sqlcmd.ExecuteNonQuery();
            if (isUpdate > 0)
            {
                Response.Write("<script>alert('Data Updated...')</script>");
            }
            else
            {
                Response.Write("<script>alert('Data Not Updated...')</script>");
            }
            BindGridData();
            btnSubmit.Visible = true;
            btnUpdate.Visible = false;
            clearForm();
        }
    }
}