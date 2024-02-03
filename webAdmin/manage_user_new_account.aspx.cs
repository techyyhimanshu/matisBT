using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class webAdmin_manage_user_new_account : System.Web.UI.Page
{
    // This method is called when the page is loaded.
    protected void Page_Load(object sender, EventArgs e)
    {
        // Page_Load is currently empty, and no specific actions are taken when the page loads.
    }

    // This event handler is called when the "Add User" button is clicked.
    protected void btnAddUser_Click(object sender, EventArgs e)
    {
        // Create an instance of the 'manageUsersByAdmin' class.
        manageUsersByAdmin mgu = new manageUsersByAdmin();

        // Set properties of the user to be added based on form inputs.
        mgu._username = txtUserName.Text.Trim();
        int resp= checkUserExistsOrNot(mgu._username);
        if (resp == 1)
        {
            counters._newUserCreatedUserName = mgu._username;
            mgu._realName = txtRealName.Text.Trim();
            mgu._email = txtEmail.Text.Trim();
            mgu._userAccesLevel = Convert.ToString(ddlUserAccessLevel.SelectedItem);
            mgu._isEnabled = Convert.ToString(chkEnabled.Checked);
            mgu._isProtected = Convert.ToString(chkProtected.Checked);

            // Call the 'addNewUser' method to add the new user to the database.
            int res = mgu.addNewUser();

            // Check if the user was successfully added.
            if (res > 0)
            {
                // Store the logged-in username in a session variable.
                Session["LoggedInUsername"] = mgu._username;

                // Clear form fields.
                txtEmail.Text = "";
                txtRealName.Text = "";
                txtUserName.Text = "";

                // Hide the "Create New User" panel and show the "Success" panel.
                counters._countForNewUser = 1;
                Response.Redirect("manage_user.aspx");
            }
        }
        else
        {
            Response.Write("<script>alert('user already exist')</script>");
        }
    }

    // This event handler is called when the "Proceed" button in the success panel is clicked.
    protected void btnProceed_Click(object sender, EventArgs e)
    {
        // Redirect to the "manage_user_update.aspx" page.
        Response.Redirect("manage_user_update.aspx");
    }
    protected int checkUserExistsOrNot(string userNameForChecking)
    {
        int returnVal=1;
        manageUsersByAdmin mgu = new manageUsersByAdmin();
        mgu._username = userNameForChecking;
        DataSet ds = mgu.isUserExists();
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["userName"] != "")
            {
                returnVal=0;
            }
            else
            {
                returnVal = 1;
            }
        }
        return returnVal;
    }
}
