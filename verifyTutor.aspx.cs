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
    public partial class verifyTutor : System.Web.UI.Page
    {
        string nim;
        string strcon = ConfigurationManager.ConnectionStrings["swiftDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["role"] == null)
            {
                Response.Redirect("homepage.aspx");
            }
            if (!IsPostBack)
            {
                tutorVerifGrid.DataBind();
            }
        }

        protected void verifTutorBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dr = (DataRowView)e.Row.DataItem;
                string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["tutor_fotoKTM"]);
                (e.Row.FindControl("KTMimg") as Image).ImageUrl = imageUrl;
            }
            
        }

        protected void verif_Command(object sender, GridViewCommandEventArgs e)
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            if (e.CommandName == "approve")
            {
                
                nim = Convert.ToString(e.CommandArgument).Trim();
                SqlDataSource1.Update();
                //SqlCommand cmd = new SqlCommand("update tutor_master_table set tutor_verif = 1 where tutor_NIM='" + nim + "';", con);
                //cmd.ExecuteNonQuery();
                //con.Close();
                Response.Write("<script>alert('approving succeed for'"+ nim +");</script>");
            }
            else if(e.CommandName == "delete")
            {
                nim = Convert.ToString(e.CommandArgument).Trim();
                SqlDataSource1.Delete();
                //SqlCommand cmd = new SqlCommand("delete from tutor_master_table where tutor_NIM='" + nim + "';", con);
                //cmd.ExecuteNonQuery();
                //con.Close();
                Response.Write("<script>alert('deleting succeed');</script>");
            }
        }

        protected void onUpdate(object sender, SqlDataSourceCommandEventArgs e)
        {
            e.Command.Parameters[0].Value = nim;
        }
        protected void onDelete(object sender, SqlDataSourceCommandEventArgs e)
        {
            e.Command.Parameters[0].Value = nim;
        }
    }

}