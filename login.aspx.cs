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
    
    public partial class login : System.Web.UI.Page
    {
        public class userLoginData
        {
            public string nim { get; set; }
            public string hash { get; set; }
            public string salt { get; set; }
        }

        string strcon = ConfigurationManager.ConnectionStrings["swiftDB"].ConnectionString;
        public static bool VerifyPassword(string enteredPassword, string storedHash, string storedSalt)
        {
            var saltBytes = Convert.FromBase64String(storedSalt);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(enteredPassword, saltBytes, 10000);
            return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256)) == storedHash;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginUserButton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("select member_nim,member_hash,member_salt,member_name from member_master_table where member_NIM='" + user_nim_login.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows && user_nim_login.Text.Trim() !=  "")
                {
                    while (dr.Read())
                    {
                        userLoginData user = new userLoginData();
                        user.hash = dr.GetString(1).Trim();
                        user.salt = dr.GetString(2).Trim();

                        bool isPasswordMatched = VerifyPassword(user_pass_login.Text, user.hash, user.salt);

                        if (isPasswordMatched)
                        {
                            Response.Write("<script>alert('Successful login');</script>");
                            Response.Redirect("CoursePage.aspx");
                            Session["role"] = "member";
                            Session["username"] = dr.GetValue(3).ToString().Trim();
                            Session["NIM"] = dr.GetValue(0).ToString().Trim();
                        }
                        else
                        {
                            Response.Write("<script>alert('Login failed, wrong password');</script>");
                        }   
                    }
                }
                else
                {
                    con.Close();
                    check_tutor(user_nim_login.Text.Trim(), con);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void check_tutor(string nim,SqlConnection con)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();

            }
            SqlCommand cmd = new SqlCommand("select tutor_NIM,tutor_hash,tutor_salt,tutor_name,tutor_verif from tutor_master_table where tutor_verif=1 and tutor_NIM='" + nim + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows && user_nim_login.Text.Trim() != "")
            {
                while (dr.Read())
                {
                    userLoginData user = new userLoginData();
                    user.hash = dr.GetString(1).Trim();
                    user.salt = dr.GetString(2).Trim();

                    bool isPasswordMatched = VerifyPassword(user_pass_login.Text, user.hash, user.salt);

                    if (isPasswordMatched)
                    {
                        Response.Write("<script>alert('Successful login');</script>");
                        Session["role"] = "tutor";
                        Session["username"] = dr.GetValue(3).ToString().Trim();
                        Session["NIM"] = dr.GetValue(0).ToString().Trim();
                        Response.Redirect("createCourse.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Login failed, wrong password');</script>");
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid credentials or your account is not verified yet');</script>");
            }
        }
    }
}