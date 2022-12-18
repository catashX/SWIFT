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

        public class userDatas
        {
            public string nim { get; set; }
            public string Hash { get; set; }
            public string Salt { get; set; }
        }
        public class HashSalt
        {
            public string Hash { get; set; }
            public string Salt { get; set; }
        }

        userDatas user = new userDatas();

        string oldHash;
        string oldSalt;
        string strcon = ConfigurationManager.ConnectionStrings["swiftDB"].ConnectionString;
        public static bool VerifyPassword(string enteredPassword, string storedHash, string storedSalt)
        {
            var saltBytes = Convert.FromBase64String(storedSalt);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(enteredPassword, saltBytes, 10000);
            return (Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256)) == storedHash);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Session["role"] == null || Session["role"].Equals(""))
                    {
                        Response.Write("<script>alert('login first!');</script>");
                        Response.Redirect("login.aspx");
                    }
                    else if (Session["role"].Equals("member"))
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
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
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
                    angkatanUser.Text = dr.GetValue(2).ToString().Trim();
                    deptUser.Text = dr.GetValue(3).ToString().Trim();
                    teleponUser.Text = dr.GetValue(4).ToString().Trim();
                    NIMUser.Text = Session["NIM"].ToString().Trim();
                    genderUser.Text = dr.GetValue(8).ToString().Trim();
                    descBox.Text = dr.GetValue(7).ToString().Trim();

                    oldHash = dr["member_hash"].ToString().Trim();
                    oldSalt = dr["member_salt"].ToString().Trim();

                    if (Convert.ToBase64String((byte[])dr["member"]) == null)
                    {
                        picUser.ImageUrl = "imgs/generaluser.png";
                    }
                    else
                    {
                        string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["member_pic"]);
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


                    oldHash = dr["tutor_hash"].ToString().Trim();
                    oldSalt = dr["tutor_salt"].ToString().Trim();

                    //user = new HashSalt { Hash = dr["tutor_hash"].ToString().Trim(), Salt = dr["tutor_salt"].ToString().Trim()};

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
            try
            {
                
                if (Session["role"] == null || Session["role"].Equals(""))
                {
                    Response.Write("<script>alert('login first!');</script>");
                    Response.Redirect("login.aspx");
                }
                else if (Session["role"].Equals("member"))
                {
                    updateProfileMember();
                    //Response.Redirect(Request.RawUrl);
                }
                else if (Session["role"].Equals("tutor"))
                {
                    //Response.Write("<script>alert('terpencet tutor');</script>");
                    updateProfileTutor();
                    //Response.Redirect(Request.RawUrl);
                }
                else
                {
                    Response.Write("<script>alert('login first!');</script>");
                    Response.Redirect("login.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void updateProfileMember()
        {
            try
            {
                //Response.Write("<script>alert('trying');</script>");
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    //Response.Write("<script>alert('buka');</script>");
                    con.Open();
                }
                else
                {
                    //Response.Write("<script>alert('con state');</script>");
                }
                SqlCommand cmd = new SqlCommand("SELECT member_hash, member_salt,member_pic from member_master_table where member_NIM ='" + NIMUser.Text.ToString().Trim() + "';", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    oldHash = dr["member_hash"].ToString().Trim();
                    oldSalt = dr["member_salt"].ToString().Trim();
                }
                con.Close();
                bool isPaswordMatched = VerifyPassword(oldPass.Text.ToString().Trim(), oldHash.ToString().Trim(), oldSalt.ToString().Trim());
                if (con.State == ConnectionState.Closed)
                {
                    //Response.Write("<script>alert('buka');</script>");
                    con.Open();
                }
                else
                {
                    //Response.Write("<script>alert('con state');</script>");
                }
                if (isPaswordMatched)
                {
                    //Response.Write("<script>alert('passBener');</script>");
                    SqlCommand cmd2 = new SqlCommand("UPDATE member_master_table set member_name=@tutr_name," +
                        "member_email=@tutr_mail," +
                        "member_angkatan=@tutr_angkatan," +
                        "member_departemen=@tutr_dept," +
                        "member_telepon=@tutr_telepon," +
                        "member_hash=@tutr_hash," +
                        "member_salt=@tutr_salt," +
                        "member_deskripsi=@tDesc WHERE member_NIM='" + NIMUser.Text.Trim() + "';", con);

                    cmd2.Parameters.AddWithValue("@tutr_name", NamaUser.Text.Trim());
                    cmd2.Parameters.AddWithValue("@tutr_mail", emailUser.Text.Trim());
                    cmd2.Parameters.AddWithValue("@tutr_angkatan", angkatanUser.Text.Trim());
                    cmd2.Parameters.AddWithValue("@tutr_dept", deptUser.Text.Trim());
                    cmd2.Parameters.AddWithValue("@tutr_telepon", teleponUser.Text.Trim());
                    cmd2.Parameters.AddWithValue("@tDesc", descBox.Text.Trim());

                    //pass
                    byte[] img_bytes;
                    if (tutorPIC.HasFile || tutorPIC.HasFiles)
                    {
                        using (BinaryReader br = new BinaryReader(tutorPIC.PostedFile.InputStream))
                        {
                            img_bytes = br.ReadBytes(tutorPIC.PostedFile.ContentLength);
                        }
                        string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String(img_bytes);
                        picUser.ImageUrl = imageUrl;
                        SqlCommand cmd3 = new SqlCommand("UPDATE member_master_table set member_pic=@Data where member_NIM ='" + NIMUser.Text.Trim() + "';", con);
                        cmd3.Parameters.AddWithValue("@Data", img_bytes);
                        cmd3.ExecuteNonQuery();
                    }
                    if (newPass.Text == null || newPass.Text == "")
                    {
                        cmd2.Parameters.AddWithValue("@member_hash", user.Hash);
                        cmd2.Parameters.AddWithValue("@member_salt", user.Salt);
                    }
                    else
                    {
                        HashSalt newpass = GenerateSaltedHash(64, newPass.Text);
                        cmd2.Parameters.AddWithValue("@member_hash", newpass.Hash);
                        cmd2.Parameters.AddWithValue("@member_salt", newpass.Salt);
                    }
                    cmd2.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('update success');</script>");
                }
                else
                {
                    con.Close();
                    Response.Write("<script>alert('try again the password');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void updateProfileTutor()
        {
            //Response.Write("<script>alert('updating');</script>");
            try
            {
                //Response.Write("<script>alert('trying');</script>");
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    //Response.Write("<script>alert('buka');</script>");
                    con.Open();
                }
                else
                {
                    //Response.Write("<script>alert('con state');</script>");
                }
                SqlCommand cmd = new SqlCommand("SELECT tutor_hash, tutor_salt,tutor_foto from tutor_master_table where tutor_NIM ='"+ NIMUser.Text.ToString().Trim() +"';", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    oldHash = dr["tutor_hash"].ToString().Trim();
                    oldSalt = dr["tutor_salt"].ToString().Trim();
                }
                con.Close();
                bool isPaswordMatched = VerifyPassword(oldPass.Text.ToString().Trim(), oldHash.ToString().Trim(), oldSalt.ToString().Trim());
                if (con.State == ConnectionState.Closed)
                {
                    //Response.Write("<script>alert('buka');</script>");
                    con.Open();
                }
                else
                {
                    //Response.Write("<script>alert('con state');</script>");
                }
                if (isPaswordMatched)
                {
                    //Response.Write("<script>alert('passBener');</script>");
                    SqlCommand cmd2 = new SqlCommand("UPDATE tutor_master_table set tutor_name=@tutr_name," +
                        "tutor_email=@tutr_mail," +
                        "tutor_angkatan=@tutr_angkatan," +
                        "tutor_departemen=@tutr_dept," +
                        "tutor_telepon=@tutr_telepon," +
                        "tutor_hash=@tutr_hash," +
                        "tutor_salt=@tutr_salt," +
                        "tutor_deskripsi=@tDesc WHERE tutor_NIM='"+NIMUser.Text.Trim()+"';", con);

                        cmd2.Parameters.AddWithValue("@tutr_name", NamaUser.Text.Trim());
                        cmd2.Parameters.AddWithValue("@tutr_mail", emailUser.Text.Trim());
                        cmd2.Parameters.AddWithValue("@tutr_angkatan", angkatanUser.Text.Trim());
                        cmd2.Parameters.AddWithValue("@tutr_dept", deptUser.Text.Trim());
                        cmd2.Parameters.AddWithValue("@tutr_telepon", teleponUser.Text.Trim());
                        cmd2.Parameters.AddWithValue("@tDesc", descBox.Text.Trim());

                    //pass
                    byte[] img_bytes;
                    if (tutorPIC.HasFile || tutorPIC.HasFiles)
                    {
                        using (BinaryReader br = new BinaryReader(tutorPIC.PostedFile.InputStream))
                        {
                            img_bytes = br.ReadBytes(tutorPIC.PostedFile.ContentLength);
                        }
                        string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String(img_bytes);
                        picUser.ImageUrl = imageUrl;
                        SqlCommand cmd3 = new SqlCommand("UPDATE tutor_master_table set tutor_foto=@Data where tutor_NIM ='" + NIMUser.Text.Trim() + "';", con);
                        cmd3.Parameters.AddWithValue("@Data", img_bytes);
                        cmd3.ExecuteNonQuery();
                    }
                    if (newPass.Text == null || newPass.Text == "")
                    {
                        cmd2.Parameters.AddWithValue("@tutr_hash", user.Hash);
                        cmd2.Parameters.AddWithValue("@tutr_salt", user.Salt);
                    }
                    else
                    {
                        HashSalt newpass = GenerateSaltedHash(64, newPass.Text);
                        cmd2.Parameters.AddWithValue("@tutr_hash", newpass.Hash);
                        cmd2.Parameters.AddWithValue("@tutr_salt", newpass.Salt);
                    }
                    cmd2.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('update success');</script>");
                }
                else
                {
                    con.Close();
                    Response.Write("<script>alert('try again the password');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        public static HashSalt GenerateSaltedHash(int size, string password)
        {
            var saltBytes = new byte[size];
            var provider = new RNGCryptoServiceProvider();
            provider.GetNonZeroBytes(saltBytes);
            var salt = Convert.ToBase64String(saltBytes);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, 10000);
            var hashPassword = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

            HashSalt hashSalt = new HashSalt { Hash = hashPassword, Salt = salt };
            return hashSalt;
        }
    }
}