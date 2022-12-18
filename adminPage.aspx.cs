using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace SWIFT
{
    public partial class adminPage : System.Web.UI.Page
    {
        string courseIDs;
        string strcon = ConfigurationManager.ConnectionStrings["swiftDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] == null)
            {
                Response.Redirect("homepage.aspx");
            }
            if (!IsPostBack)
            {
                course_verif_grid.DataBind();
            }
        }
        protected void course_bound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dr = (DataRowView)e.Row.DataItem;
                string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["course_pic"]);
                (e.Row.FindControl("Banner") as Image).ImageUrl = imageUrl;
            }

        }
        protected void course_verif(object sender, GridViewCommandEventArgs e)
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            if (e.CommandName == "approve")
            {

                courseIDs = Convert.ToString(e.CommandArgument).Trim();
                SqlDataSource1.Update();
                Response.Write("<script>alert('approving succeed for'" + courseIDs + ");</script>");
            }
            else if (e.CommandName == "delete")
            {
                courseIDs = Convert.ToString(e.CommandArgument).Trim();
                SqlDataSource1.Delete();;
                Response.Write("<script>alert('deleting succeed');</script>");
            }
        }

        protected void onUpdate(object sender, SqlDataSourceCommandEventArgs e)
        {
            e.Command.Parameters[0].Value = courseIDs;
        }
        protected void onDelete(object sender, SqlDataSourceCommandEventArgs e)
        {
            e.Command.Parameters[0].Value = courseIDs;
        }
    }
}