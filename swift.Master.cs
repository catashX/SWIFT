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
                    tutorList.Visible = false;

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
                    tutorList.Visible = false;

                    LogoutButton.Visible = true;
                    ProfileButton.Visible = true;
                    ProfileButton.Text = "Hello" + Session["username"].ToString().Trim();

                    validateCourse.Visible = true;
                    validateTutor.Visible = true;

                    createCourse.Visible = false;
                }
                else if (Session["role"].Equals("member"))
                {
                    login.Visible = false;
                    LinkButton2.Visible = false;

                    viewCourseButton.Visible = true;
                    tutorList.Visible = true;

                    LogoutButton.Visible = true;
                    ProfileButton.Visible = true;
                    ProfileButton.Text = "Hello" + Session["username"].ToString().Trim();

                    validateCourse.Visible = false;
                    validateTutor.Visible = false;

                    createCourse.Visible = false;
                }
                else if (Session["role"].Equals("tutor"))
                {
                    login.Visible = false;
                    LinkButton2.Visible = false;

                    viewCourseButton.Visible = false;
                    tutorList.Visible = false;

                    LogoutButton.Visible = true;
                    ProfileButton.Visible = true;
                    ProfileButton.Text = "Hello" + Session["username"].ToString().Trim();

                    validateCourse.Visible = false;
                    validateTutor.Visible = false;

                    createCourse.Visible = true;
                }
                else
                {
                    login.Visible = true;
                    LinkButton2.Visible = true;

                    viewCourseButton.Visible = false;
                    tutorList.Visible = false;

                    LogoutButton.Visible = false;
                    ProfileButton.Visible = false;

                    validateCourse.Visible = false;
                    validateTutor.Visible = false;

                    createCourse.Visible = false;
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