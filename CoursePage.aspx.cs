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
    public partial class CoursePage : System.Web.UI.Page
    {
        string nim;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.DataBind();
            }
        }

        protected void course_bounds(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dr = (DataRowView)e.Row.DataItem;
                string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["course_pic"]);
                (e.Row.FindControl("Banner") as Image).ImageUrl = imageUrl;
            }
        }

        protected void course_comm(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "viewTutor")
            {
                nim = Convert.ToString(e.CommandArgument).Trim();
                Response.Redirect("visitProfile.aspx?NIM="+ nim.ToString().Trim());
            }
        }
        }
}