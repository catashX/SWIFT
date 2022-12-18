using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.IO;

namespace SWIFT
{
    public partial class visitProfile : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["swiftDB"].ConnectionString;
        string nim;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showProfile();
            }
        }

        void showProfile()
        {
            try
            {
                nim = Request.QueryString["NIM"];
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from tutor_master_table where tutor_NIM='" + nim + "';", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    NamaUser.Text = dr.GetValue(1).ToString().Trim();
                    emailUser.Text = dr.GetValue(2).ToString().Trim();
                    angkatanUser.Text = dr.GetValue(3).ToString().Trim();
                    deptUser.Text = dr.GetValue(12).ToString().Trim();
                    teleponUser.Text = dr.GetValue(4).ToString().Trim();
                    NIMUser.Text = nim;
                    genderUser.Text = dr.GetValue(13).ToString().Trim();

                    if (Convert.ToBase64String((byte[])dr["tutor_foto"]) == null)
                    {
                        picUser.ImageUrl = "imgs/generaluser.png";
                    }
                    else
                    {
                        string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["tutor_foto"]);
                        picUser.ImageUrl = imageUrl;
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}