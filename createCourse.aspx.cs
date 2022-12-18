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
    public partial class createCourse : System.Web.UI.Page
    {
        string courseIDs;
        string strcon = ConfigurationManager.ConnectionStrings["swiftDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            SqlDataSource1.DataBind();
            if(Session["role"] == null)
            {
                Response.Redirect("login.aspx");
            }
        }


        void createCourses()
        {
            try
            {
                Response.Write("<script>alert('trying');</script>");
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO course_master_table (course_id, matkul, course_name, course_time, course_capacity, course_price, course_details, course_pic, course_verif, tutor_NIM) values(NEWID(),@matkul,@name,@time,@cap,@price,@details,@Data, 0,'" + Session["NIM"].ToString().Trim() + "');", con);

                DateTime jadwals = DateTime.ParseExact(Jadwal.Text, "yyyy-MM-ddTHH:mm", null);
                cmd.Parameters.AddWithValue("@matkul", Matkul.SelectedItem.Text.ToString().Trim());
                cmd.Parameters.AddWithValue("@name", Judul.Text.ToString().Trim());
                cmd.Parameters.AddWithValue("@time", jadwals.ToString("yyyy-MM-dd h:m:s"));
                cmd.Parameters.AddWithValue("@cap", Cap.Text.ToString().Trim());
                cmd.Parameters.AddWithValue("@price", Convert.ToDecimal(Price.Text));
                cmd.Parameters.AddWithValue("@details", Desk.Text.ToString().Trim());

                Response.Write("<script>alert('"+ jadwals.ToString("yyyy-MM-dd h:m:s") + "');</script>");
                byte[] img_bytes; 
                if(BannerUpload.HasFile || BannerUpload.HasFiles)
                {
                    using (BinaryReader br = new BinaryReader(BannerUpload.PostedFile.InputStream))
                    {
                        img_bytes = br.ReadBytes(BannerUpload.PostedFile.ContentLength);
                    }
                    string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String(img_bytes);
                    Banner.ImageUrl = imageUrl;
                    cmd.Parameters.AddWithValue("@Data", img_bytes);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Data", null);
                }
                Response.Write("<script>alert('value added');</script>");
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('success');</script>");
                SqlDataSource1.DataBind();
                Response.Redirect(Request.RawUrl);
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void select(object sender, GridViewCommandEventArgs e)
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            if (e.CommandName == "Select"){
                courseIDs = Convert.ToString(e.CommandArgument).Trim();
                Course_id.Text = courseIDs;
                SqlCommand cmd = new SqlCommand("SELECT * from course_master_table where course_id ='" + courseIDs + "';",con);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (dr["course_pic"] != null)
                    {
                        string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["course_pic"]);
                        Banner.ImageUrl = imageUrl;
                    }
                    DateTime jadwals = DateTime.ParseExact(dr["course_time"].ToString().Trim(), "dd/MM/yyyy hh:mm:ss", null);
                    Judul.Text = dr["course_name"].ToString().Trim();
                    Jadwal.Text = jadwals.ToString("yyyy-MM-ddTHH:mm");
                    Matkul.SelectedItem.Text = dr["matkul"].ToString().Trim();
                    Course_id.Text = dr["course_id"].ToString().Trim();
                    Cap.Text = dr["course_capacity"].ToString().Trim();
                    Price.Text = dr["course_price"].ToString().Trim();
                    Desk.Text = dr["course_details"].ToString().Trim();
                }
            }
            con.Close();
        }



        protected void Add_Click(object sender, EventArgs e)
        {
            createCourses();
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("Update course_master_table set matkul=@matkul, course_name=@name, course_time=@time, course_capacity=@cap, course_price=@price, course_details=@details where course_id='"+Course_id.Text.ToString().Trim()+"';",con);
            DateTime jadwals = DateTime.ParseExact(Jadwal.Text, "yyyy-MM-ddTHH:mm", null);
            cmd.Parameters.AddWithValue("@matkul", Matkul.SelectedItem.Text.ToString().Trim());
            cmd.Parameters.AddWithValue("@name", Judul.Text.ToString().Trim());
            cmd.Parameters.AddWithValue("@time", jadwals.ToString("yyyy-MM-dd h:m:s"));
            cmd.Parameters.AddWithValue("@cap", Cap.Text.ToString().Trim());
            cmd.Parameters.AddWithValue("@price", Convert.ToDecimal(Price.Text));
            cmd.Parameters.AddWithValue("@details", Desk.Text.ToString().Trim());

            //Response.Write("<script>alert('" + jadwals.ToString("yyyy-MM-dd h:m:s") + "');</script>");
            byte[] img_bytes;
            if (BannerUpload.HasFile || BannerUpload.HasFiles)
            {
                using (BinaryReader br = new BinaryReader(BannerUpload.PostedFile.InputStream))
                {
                    img_bytes = br.ReadBytes(BannerUpload.PostedFile.ContentLength);
                }
                SqlCommand cmd1 = new SqlCommand("Update course_master_table set course_pic=@Data where course_id='"+ courseIDs.ToString().Trim() + "';",con);
                string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String(img_bytes);
                Banner.ImageUrl = imageUrl;
                cmd1.Parameters.AddWithValue("@Data", img_bytes);
                cmd1.ExecuteNonQuery();
            }
            cmd.ExecuteNonQuery();
            con.Close();
            SqlDataSource1.DataBind();
            Response.Redirect(Request.RawUrl);
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("Delete from course_master_table where course_id='"+ Course_id.Text.ToString().Trim() + "';",con);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect(Request.RawUrl);
        }
    }
}