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
    public partial class signuptutor : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["swiftDB"].ConnectionString;
        public class HashSalt
        {
            public string Hash { get; set; }
            public string Salt { get; set; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegButtonTutor_Click(object sender, EventArgs e)
        {
            if (checkTutorExists())
            {

                Response.Write("<script>alert('Tutor Already Exist with this tutor ID, try other ID');</script>");
            }
            else
            {
                signUpNewTutor();
            }
        }

        bool checkTutorExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from tutor_master_table where tutor_NIM='" + tutor_nim.Text + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }
        void signUpNewTutor()
        {
            //Response.Write("<script>alert('Testing');</script>");
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                if (tutor_pass.Text.Trim() == tutor_passwordRep.Text.Trim())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO tutor_master_table(tutor_name,tutor_email,tutor_angkatan,tutor_departemen,tutor_telepon,tutor_NIM,tutor_gender,tutor_hash,tutor_salt,tutor_verif,tutor_fotoKTM)values(@tut_name,@tut_mail,@tut_angkatan,@tut_dept,@tut_telepon,@tut_NIM,@tut_gend,@tut_hash,@tut_salt,@verified,@Data)", con);
                    cmd.Parameters.AddWithValue("@tut_name", namaTutor.Text.Trim());
                    cmd.Parameters.AddWithValue("@tut_mail", tutor_email.Text.Trim());
                    cmd.Parameters.AddWithValue("@tut_angkatan", tutor_angkatan.Text.Trim());
                    cmd.Parameters.AddWithValue("@tut_dept", tutor_departemen.Text.Trim());
                    cmd.Parameters.AddWithValue("@tut_telepon", tutor_telepon.Text.Trim());
                    cmd.Parameters.AddWithValue("@tut_NIM", tutor_nim.Text.Trim());
                    cmd.Parameters.AddWithValue("@verified", 0);
                    //cmd.Parameters.AddWithValue("@Name", Path.GetFileName(ktm.PostedFile.FileName));
                    //cmd.Parameters.AddWithValue("@ContentType", ktm.PostedFile.ContentType);
                    byte[] img_bytes;
                    if (ktm.HasFile || ktm.HasFiles)
                    {
                        using (BinaryReader br = new BinaryReader(ktm.PostedFile.InputStream))
                        {
                            img_bytes = br.ReadBytes(ktm.PostedFile.ContentLength);
                        }
                        cmd.Parameters.AddWithValue("@Data", img_bytes);
                    }
                    else
                    {
                        Response.Write("<script>alert('input ktm!');</script>");
                    }
                    if (dot_male.Checked)
                    {
                        cmd.Parameters.AddWithValue("@tut_gend", "male");
                    }
                    else if (dot_female.Checked)
                    {
                        cmd.Parameters.AddWithValue("@tut_gend", "female");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@tut_gend", "-");
                    }
                    //pass
                    HashSalt hashsalt = GenerateSaltedHash(64, tutor_pass.Text.Trim());
                    cmd.Parameters.AddWithValue("@tut_hash", hashsalt.Hash);
                    cmd.Parameters.AddWithValue("@tut_salt", hashsalt.Salt);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Sign Up Successful. Go to User Login to Login');</script>");
                    Response.Redirect("login.aspx");
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