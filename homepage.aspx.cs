using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SWIFT
{
    public partial class homepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["role"] == null || Session["role"].Equals(""))
            {
                to_login.Visible = true;
                to_signup.Visible = true;
            }
            else
            {
                to_login.Visible = false;
                to_signup.Visible = false;
            }
        }

        protected void to_login_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void to_signup_Click(object sender, EventArgs e)
        {
            Response.Redirect("signupmember.aspx");
        }
    }

    
}