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
    public partial class viewProfile : System.Web.UI.Page
    {

        public class userData
        {
            public string nim { get; set; }
            public string hash { get; set; }
            public string salt { get; set; }
        }

        userData user = new userData();
        string strcon = ConfigurationManager.ConnectionStrings["swiftDB"].ConnectionString;
        public static bool VerifyPassword(string enteredPassword, string storedHash, string storedSalt)
        {
            var saltBytes = Convert.FromBase64String(storedSalt);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(enteredPassword, saltBytes, 10000);
            return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256)) == storedHash;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["role"] == null)
            {
                Response.Write("<script>alert('login first!');</script>");
                Response.Redirect("login.aspx");
            }
            else if(Session["role"].Equals("member"))
            {
                showProfileMember();
                descBox.Visible = false;
            }
            else if (Session["role"].Equals("tutor"))
            {
                showProfileTutor();
                descBox.Visible = true;
            }
            else
            {
                Response.Write("<script>alert('login first!');</script>");
                Response.Redirect("login.aspx");
            }
            
        }

        void showProfileMember()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from member_master_table where member_NIM='" + Session["NIM"] + "';", con);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    NamaUser.Text = dr.GetValue(0).ToString().Trim();
                    emailUser.Text = dr.GetValue(1).ToString().Trim();
                    angkatanUser.Text = dr.GetString(2).Trim();
                    deptUser.Text = dr.GetString(3).Trim();
                    teleponUser.Text = dr.GetString(4).Trim();
                    NIMUser.Text = dr.GetString(5).Trim();
                    genderUser.Text = dr.GetString(8).Trim();
                    descBox.Text = dr.GetString(7).Trim();

                    

                    if (dr.GetSqlBinary(5) == null)
                    {
                        picUser.ImageUrl = "imgs/generaluser.png";
                    }
                    else
                    {
                        string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr.GetSqlBinary(5));
                        picUser.ImageUrl = imageUrl;
                    }
                }
                
                con.Close();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void showProfileTutor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from tutor_master_table where tutor_NIM='" + Session["NIM"].ToString().Trim() + "';", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    NamaUser.Text = dr.GetValue(1).ToString().Trim();
                    emailUser.Text = dr.GetValue(2).ToString().Trim();
                    angkatanUser.Text = dr.GetValue(3).ToString().Trim();
                    deptUser.Text = dr.GetValue(12).ToString().Trim();
                    teleponUser.Text = dr.GetValue(4).ToString().Trim();
                    NIMUser.Text = Session["NIM"].ToString().Trim();
                    genderUser.Text = dr.GetValue(13).ToString().Trim();

                    user.hash = dr.GetValue(10).ToString().Trim();
                    user.salt = dr.GetValue(11).ToString().Trim();

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

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            if (Session["role"].Equals("member"))
            {
                showProfileMember();
                Response.Redirect(Request.RawUrl);
            }
            else if (Session["role"].Equals("tutor"))
            {
                updateProfileTutor();
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                Response.Write("<script>alert('login first!');</script>");
                Response.Redirect("login.aspx");
            }
        }

        void updateProfileMember()
        {
            try
            {
                bool isPaswordMatched = VerifyPassword(oldPass.Text.Trim(), user.hash, user.salt);
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                if ( isPaswordMatched )
                {
                    SqlCommand cmd = new SqlCommand("UPDATE member_master_table(member_name,member_email,member_angkatan,member_departemen,member_telepon,member_NIM,member_gender,member_hash,member_salt) values(@memb_name,@memb_mail,@memb_angkatan,@memb_dept,@memb_telepon,@memb_NIM,@memb_gend,@memb_hash,@memb_salt)", con);
                    cmd.Parameters.AddWithValue("@memb_name", namaMember.Text.Trim());
                    cmd.Parameters.AddWithValue("@memb_mail", member_email.Text.Trim());
                    cmd.Parameters.AddWithValue("@memb_angkatan", member_angkatan.Text.Trim());
                    cmd.Parameters.AddWithValue("@memb_dept", member_departemen.Text.Trim());
                    cmd.Parameters.AddWithValue("@memb_telepon", member_telepon.Text.Trim());
                    cmd.Parameters.AddWithValue("@memb_NIM", member_nim.Text.Trim());

                    //pass
                    byte[] img_bytes;
                    if (tutorPIC.HasFile || tutorPIC.HasFiles)
                    {
                        using (BinaryReader br = new BinaryReader(tutorPIC.PostedFile.InputStream))
                        {
                            img_bytes = br.ReadBytes(tutorPIC.PostedFile.ContentLength);
                        }
                        cmd.Parameters.AddWithValue("@Data", img_bytes);
                    }

                }
                else
                {
                    con.Close();
                    Response.Write("<script>alert('try again the password');</script>");
                }

            }
            catch(Exception ex)
            {

            }
        }

        void updateProfileTutor()
        {

        }
    }
}