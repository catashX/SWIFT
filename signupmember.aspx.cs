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

namespace SWIFT
{
    public partial class signupmember : System.Web.UI.Page
    {
        public class HashSalt
        {
            public string Hash { get; set; }
            public string Salt { get; set; }
        }

        string strcon = ConfigurationManager.ConnectionStrings["swiftDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegButtonMember_Click(object sender, EventArgs e)
        {
            if (checkMemberExists())
            {

                Response.Write("<script>alert('Member Already Exist with this Member ID, try other ID');</script>");
            }
            else
            {
                signUpNewMember();
            }
        }
        // user defined method
        bool checkMemberExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from member_master_table where member_NIM='" + member_nim.Text + "';", con);
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
        void signUpNewMember()
        {
            //Response.Write("<script>alert('Testing');</script>");
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                
                
                if(member_pass.Text.Trim() == member_passwordRep.Text.Trim())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO member_master_table(member_name,member_email,member_angkatan,member_departemen,member_telepon,member_NIM,member_gender,member_hash,member_salt) values(@memb_name,@memb_mail,@memb_angkatan,@memb_dept,@memb_telepon,@memb_NIM,@memb_gend,@memb_hash,@memb_salt)", con);
                    cmd.Parameters.AddWithValue("@memb_name", namaMember.Text.Trim());
                    cmd.Parameters.AddWithValue("@memb_mail", member_email.Text.Trim());
                    cmd.Parameters.AddWithValue("@memb_angkatan", member_angkatan.Text.Trim());
                    cmd.Parameters.AddWithValue("@memb_dept", member_departemen.Text.Trim());
                    cmd.Parameters.AddWithValue("@memb_telepon", member_telepon.Text.Trim());
                    cmd.Parameters.AddWithValue("@memb_NIM", member_nim.Text.Trim());
                    if (dot_male.Checked)
                    {
                        cmd.Parameters.AddWithValue("@memb_gend", "male");
                    }
                    else if (dot_female.Checked)
                    {
                        cmd.Parameters.AddWithValue("memb_gend", "female");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@memb_gend", "-");
                    }
                    //pass
                    HashSalt hashsalt = GenerateSaltedHash(64, member_pass.Text.Trim());
                    cmd.Parameters.AddWithValue("@memb_hash", hashsalt.Hash);
                    cmd.Parameters.AddWithValue("@memb_salt", hashsalt.Salt);
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