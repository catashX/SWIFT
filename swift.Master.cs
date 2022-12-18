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

                    validateCourse.Visible = false;
                    validateTutor.Visible = false;

                    createCourse.Visible = false;
                }
                else if (Session["role"].Equals("admin"))
                {
                    login.Visible = false;
                    LinkButton2.Visible = false;

                    viewCourseButton.Visible = false;

                    LogoutButton.Visible = true;
                    ProfileButton.Visible = true;
                    ProfileButton.Text = "Hello " + Session["username"].ToString().Trim();
                    ProfileButton.Enabled = false;

                    validateCourse.Visible = true;
                    validateTutor.Visible = true;

                    createCourse.Visible = false;
                }
                else if (Session["role"].Equals("member"))
                {
                    login.Visible = false;
                    LinkButton2.Visible = false;

                    viewCourseButton.Visible = true;

                    LogoutButton.Visible = true;
                    ProfileButton.Visible = true;
                    ProfileButton.Text = "Hello " + Session["username"].ToString().Trim();
                    ProfileButton.Enabled = true;

                    validateCourse.Visible = false;
                    validateTutor.Visible = false;

                    createCourse.Visible = false;
                }
                else if (Session["role"].Equals("tutor"))
                {
                    login.Visible = false;
                    LinkButton2.Visible = false;

                    viewCourseButton.Visible = false;

                    LogoutButton.Visible = true;
                    ProfileButton.Visible = true;
                    ProfileButton.Text = "Hello " + Session["username"].ToString().Trim();
                    ProfileButton.Enabled = true;

                    validateCourse.Visible = false;
                    validateTutor.Visible = false;

                    createCourse.Visible = true;
                }
                else
                {
                    login.Visible = true;
                    LinkButton2.Visible = true;

                    viewCourseButton.Visible = false;

                    LogoutButton.Visible = false;
                    ProfileButton.Visible = false;

                    validateCourse.Visible = false;
                    validateTutor.Visible = false;

                    createCourse.Visible = false;
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
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

        protected void toVerifyTutor(object sender, EventArgs e)
        {
            Response.Redirect("verifyTutor.aspx");
        }

        protected void viewProfile(object sender, EventArgs e)
        {
            Response.Redirect("viewProfile.aspx");
        }

        protected void Logout(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Cookies.Clear();
            Response.Redirect("homepage.aspx");
        }

        protected void tutManagement(object sender, EventArgs e)
        {
            Response.Redirect("verifyTutor.aspx");
        }

        protected void courseList(object sender, EventArgs e)
        {
            Response.Redirect("CoursePage.aspx");
        }

        protected void usLogin(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void signUp(object sender, EventArgs e)
        {
            Response.Redirect("signupmember.aspx");
        }

        protected void createCourses(object sender, EventArgs e)
        {
            Response.Redirect("createCourse.aspx");
        }

        protected void validateS(object sender, EventArgs e)
        {
            Response.Redirect("adminPage.aspx");
        }
    }

}