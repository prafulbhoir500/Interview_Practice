using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Interview_Practice
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string CS = ConfigurationManager.ConnectionStrings["TestDB1"].ConnectionString;
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

        private void ClearGridViewTextBox()
        {
            (GridViewPerson.FooterRow.FindControl("txtNameFooter") as TextBox).Text = "";
            (GridViewPerson.FooterRow.FindControl("txtGenderFooter") as TextBox).Text = "";
            (GridViewPerson.FooterRow.FindControl("txtCityFooter") as TextBox).Text = "";
        }

        protected void GridViewPerson_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "AddNew")
                {
                    SqlConnection sqlcon = new SqlConnection(CS);

                    SqlCommand sqlcmd = new SqlCommand("insert into Person (Name,Gender,City) values(@name,@gender,@city)", sqlcon);

                    sqlcmd.Parameters.AddWithValue("@name", (GridViewPerson.FooterRow.FindControl("txtNameFooter") as TextBox).Text.Trim());

                    sqlcmd.Parameters.AddWithValue("@gender", (GridViewPerson.FooterRow.FindControl("txtGenderFooter") as TextBox).Text);
                    sqlcmd.Parameters.AddWithValue("@city", (GridViewPerson.FooterRow.FindControl("txtCityFooter") as TextBox).Text);

                    if (sqlcon.State == ConnectionState.Closed)
                    {
                        sqlcon.Open();
                    }
                    int isInsert = sqlcmd.ExecuteNonQuery();
                    if (isInsert > 0)
                    {
                        Response.Write("<script>alert('Data Added...')</script>");
                        ClearGridViewTextBox();
                        BindGridViewData();

                    }
                    else
                    {
                        Response.Write("<script>alert('Data Not Added...')</script>");

                    }
                    sqlcon.Close();

                }
            }
            catch (Exception ex)
            {

                Response.Write(ex.Message);
            }
        }

        protected void GridViewPerson_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewPerson.EditIndex = e.NewEditIndex;
            BindGridViewData();
        }

        protected void GridViewPerson_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewPerson.EditIndex = -1;
            BindGridViewData();
        }

        protected void GridViewPerson_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridViewPerson.DataKeys[e.RowIndex].Value);

            SqlConnection sqlcon = new SqlConnection(CS);

            SqlCommand sqlcmd = new SqlCommand("delete from Person where id=@id", sqlcon);
            sqlcmd.Parameters.AddWithValue("@id", id);

            if (sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();
            }

            int isDelete = sqlcmd.ExecuteNonQuery();
            if (isDelete > 0)
            {
                Response.Write("<script>alert('Data Deleted...')</script>");
                ClearGridViewTextBox();
                BindGridViewData();

            }
            else
            {
                Response.Write("<script>alert('Data Not Deleted...')</script>");

            }
            sqlcon.Close();
        }

        protected void GridViewPerson_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(CS);

            SqlCommand sqlcmd = new SqlCommand("UPDATE Person SET Name=@name,Gender=@gender,City=@city where id=@id", sqlcon);
            sqlcmd.Parameters.AddWithValue("@id", Convert.ToInt32(GridViewPerson.DataKeys[e.RowIndex].Value));
            sqlcmd.Parameters.AddWithValue("@name", (GridViewPerson.Rows[e.RowIndex].FindControl("txtName") as TextBox).Text.Trim());
            sqlcmd.Parameters.AddWithValue("@gender", (GridViewPerson.Rows[e.RowIndex].FindControl("txtGender") as TextBox).Text.Trim());
            sqlcmd.Parameters.AddWithValue("@city", (GridViewPerson.Rows[e.RowIndex].FindControl("txtCity") as TextBox).Text.Trim());

            if (sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();
            }

            int isUpdate = sqlcmd.ExecuteNonQuery();
            if (isUpdate > 0)
            {
                Response.Write("<script>alert('Data Updated...')</script>");
                ClearGridViewTextBox();
                GridViewPerson.EditIndex = -1;
                BindGridViewData();

            }
            else
            {
                Response.Write("<script>alert('Data Not Updated...')</script>");

            }
            sqlcon.Close();
        }
    }
}