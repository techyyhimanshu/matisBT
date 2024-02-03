using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class webAdmin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Keys.Count > 0)
        {
            Session.Abandon();
        }
    }

    protected void signin_Click(object sender, EventArgs e)
    {
        clsLogin logObj = new clsLogin();
        logObj._username = txtUsername.Text.Trim();
        logObj._pass = txtPassword.Text.Trim();
        DataSet ds = logObj.authenticateUser();
        if (ds.Tables[0].Rows.Count > 0)
        {
            string username = ds.Tables[0].Rows[0]["userName"].ToString();
            string userAccessLevel = ds.Tables[0].Rows[0]["userAccessLevel"].ToString();
            string userPasss = ds.Tables[0].Rows[0]["userPassword"].ToString();
            string defaultProjectDrop = "0";
            if (userAccessLevel == "Administrator")
            {
                Response.Write("<script>alert('Unauthorized access')</script>");
                Response.Write("<script>setTimeout(function() { window.location.href = 'SignIn.aspx'; }, 100);</script>");
            }
            else
            {
                Session.Add("LoginTime", DateTime.Now);
                Session.Add("projectIDForDropDown", defaultProjectDrop);
                Session.Add("UserName", username);
                Session.Add("UserAccessLevel", userAccessLevel);
                Session.Add("UserPass", userPasss);
                counters._countForLogin = 1;
                Response.Redirect("dashboard.aspx");
            }
        }
        else
        {
            Response.Write("<script>alert('Login failed')</script>");
        }
    }
}