using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SWIFT
{
    public partial class swift : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"] == null)
                {
                    login.Visible = true;
                    LinkButton2.Visible = true;

                    viewCourseButton.Visible = false;
                    LogoutButton.Visible = false;
                    ProfileButton.Visible = false;
                    //ProfileButton.Text = "Hello" + Session["username"].ToString().Trim();
                }
                else if (Session["role"].Equals("admin"))
                {
                    login.Visible = false;
                    LinkButton2.Visible = false;

                    viewCourseButton.Visible = true;
                    LogoutButton.Visible = true;
                    ProfileButton.Visible = true;
                    ProfileButton.Text = "Hello" + Session["username"].ToString().Trim();
                }
                else if (Session["role"].Equals("member"))
                {

                }
                else if (Session["role"].Equals("tutor"))
                {

                }
                else
                {
                    login.Visible = true;
                    LinkButton2.Visible = true;

                    viewCourseButton.Visible = false;
                    LogoutButton.Visible = false;
                    ProfileButton.Visible = false;
                    //ProfileButton.Text = "Hello" + Session["username"].ToString().Trim();
                }
            }
            catch(Exception ex)
            {

            }
            
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("loginadmin.aspx");
        }

        protected void LinkButton10_Click1(object sender, EventArgs e)
        {
            Response.Redirect("signuptutor.aspx");
        }
    }

}