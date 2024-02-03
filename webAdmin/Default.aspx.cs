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

        counters._countForLogin = 0;
    }
    #region Login
    /// <summary>
    /// This region is used for admin login
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void signin_Click(object sender, EventArgs e)
    {
        // Class For login function
        adminLogin logObj = new adminLogin();
        // Get username and password from textbox and assign to respected properties of "clsLogin" class
        logObj._username = txtUsername.Text.Trim();
        logObj._pass = txtPassword.Text.Trim();

        // Calling the authenticateUser function of class ClsLogin to check the username and password match with the entered credentials by the admin
        // If the credentials are matched then the function return the respected Username and stores into variable "validUser"
        DataSet ds = logObj.authenticateUser();

        //If "validUser" value is not empty then it redirects to "Welcome.aspx" and created a session with the corresponding username
        if (ds.Tables[0].Rows.Count>0)
        {
            Session.Add("UserName", ds.Tables[0].Rows[0]["userName"]);
            Session.Add("UserPass", ds.Tables[0].Rows[0]["userPassword"]);
            Session.Add("UserAccessLevel", ds.Tables[0].Rows[0]["userAccessLevel"]);
            string defaultProjectDrop = "0";
            Session.Add("projectIDForDropDown", defaultProjectDrop);
            Response.Write("<script>alert('')</script>");
            counters._countForLogin = 1;
            Response.Redirect("../webUsers/dashboard.aspx");
        }
        // Otherwise it prompts a message "Login failed"
        else
        {
            Response.Write("<script>alert('Login failed')</script>   ");
        }
    }
    #endregion
}