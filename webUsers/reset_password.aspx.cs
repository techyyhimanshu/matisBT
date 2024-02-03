using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class reset_password : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string token = Request.QueryString["token"];
            if (token != null)
            {
                forgotPassword fp = new forgotPassword();
                fp._resetToken = token;

                // Check if the session variable exists
                if (Session["TokenExpiration"] != null)
                {
                    DateTime expirationTime = (DateTime)Session["TokenExpiration"];

                    if (DateTime.Now < expirationTime)
                    {

                    }
                    else
                    {

                        Response.Write("<script>alert('Session Expired')</script>");
                        Response.Write("<script>setTimeout(function() { window.location.href = 'SignIn.aspx'; }, 200);</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Token Expired')</script>");
                    Response.Write("<script>setTimeout(function() { window.location.href = 'SignIn.aspx'; }, 200);</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Token Expired')</script>");
                Response.Write("<script>setTimeout(function() { window.location.href = 'SignIn.aspx'; }, 200);</script>");
            }
        }
    }

    protected void btnResetPassword_Click(object sender, EventArgs e)
    {
        forgotPassword fp = new forgotPassword();
        if (txtNewPassword.Text == txtConfirmPassword.Text)
        {
            fp._password = txtNewPassword.Text.Trim();
            fp._resetToken=Request.QueryString["token"];
            int res=fp.resetPassword();
            if (res > 0)
            {
                Response.Write("<script>alert('Password reset successfully')</script>");
                Response.Write("<script>setTimeout(function() { window.location.href = 'SignIn.aspx'; }, 200);</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('Password does not match')</script>");
        }
    }
}