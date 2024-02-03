using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

public partial class webAdmin_manage_user : System.Web.UI.Page
{
    string isEnabled;
    // This method is called when the page is loaded.
    protected void Page_Load(object sender, EventArgs e)
    {
        if (counters._countForNewUser == 1)
        {
            manageUsersByAdmin mgu = new manageUsersByAdmin();
            lblCreatedUser.Text = "A wild " + "\"" + counters._newUserCreatedUserName + "\" " + " appeared  <img src='..\\Images\\pika.gif' alt='Wild Gif' style='width:25px; height:25px;'>";
            pnlAlertMessageForNewUser.Visible = true;
            counters._countForNewUser = 2;
        }
        else pnlAlertMessageForNewUser.Visible = false;
        if (counters._countForUserDeleted == 1)
        {
            pnlPopupForDeleteUser.Visible = true;
            lblUserDeleted.Text = "Good bye " + "\"" + counters._newUserCreatedUserName + "\" 💀";
            counters._countForUserDeleted = 2;
        }
        else pnlPopupForDeleteUser.Visible = false;

        if (counters._countForUserProtectedOrNot == 1)
        {
            lblProtectedUserDeletionMessage.Text = "User is Protected🤫.";
            pnlPopupForProtectedUserDeletion.Visible = true;
            counters._countForUserProtectedOrNot = 2;
        }
        else pnlPopupForProtectedUserDeletion.Visible = false;

        if (counters._countForUserProtectedOrNot == 11)
        {
            lblProtectedUserDeletionMessage.Text = "Can't delete the Admin account🙄🙄.";
            pnlPopupForProtectedUserDeletion.Visible = true;
            counters._countForUserProtectedOrNot = 2;
        }
        // Call the fetchAllUsers method to populate the grid with user details.
        if (!IsPostBack)
        {
            
            fetchAllUsers();
        }
    }

    // This method fetches all user details and populates the grid.
    public void fetchAllUsers()
    {
        // Create an instance of the 'manageUsersByAdmin' class.
        manageUsersByAdmin mgp = new manageUsersByAdmin();

        // Call the 'fetchUserDetails' method to retrieve user details from the database.
        DataSet ds = mgp.fetchUserDetails();

        // Check if there are user details in the dataset.
        if (ds.Tables[0].Rows.Count > 0)
        {
            gridViewUserDetails.AutoGenerateColumns = false;
            // Bind the dataset to the 'gridViewUserDetails' grid.
            gridViewUserDetails.DataSource = ds;
            gridViewUserDetails.DataBind();
           
        }
    }

    // This event handler is called when the "Create New User" button is clicked.
    protected void btnCreateNewUser_Click(object sender, EventArgs e)
    {
        // Redirect to the page for creating a new user account.
        Response.Redirect("manage_user_new_account.aspx");
    }
    public string checkUserIsProtectedOrNot(string username)
    {
        manageUsersByAdmin mgu = new manageUsersByAdmin();
        mgu._username = username;
        DataSet ds=mgu.isProtectedOrNot();
        string isProtected = ds.Tables[0].Rows[0]["isProtected"].ToString();
        return isProtected;
    }
    // This event handler is called when a row command is triggered in the 'gridUserDetails' grid.
    protected void gridUserDetails_Row(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            // Retrieve the command argument, which should contain the username to delete.
            string usernameToDelete = e.CommandArgument.ToString();

            // Check if the username is "admin," and if so, display a message and do not delete.
            if (usernameToDelete == "Jesus")
            {
                counters._countForUserProtectedOrNot = 11;
                Response.Redirect("manage_user.aspx");
            }
            else if (checkUserIsProtectedOrNot(usernameToDelete) == "True")
            {
                counters._countForUserProtectedOrNot = 1;
                Response.Redirect("manage_user.aspx");
            }
            else
            {
                // Create an instance of the 'manageUsersByAdmin' class.
                manageUsersByAdmin mgu = new manageUsersByAdmin();

                // Set the username to delete in the class.
                mgu._username = usernameToDelete;
                counters._newUserCreatedUserName = mgu._username;

                // Call the 'deleteUser' method to delete the user.
                int res = mgu.deleteUser();

                // Check if the deletion was successful and display a message.
                if (res > 0)
                {
                    counters._countForUserDeleted = 1;
                    Response.Redirect("manage_user.aspx");

                }

            }

        }
        else
        {
            if (e.CommandName == "update")
            {
                // Create an instance of the 'manageUsersByAdmin' class.
                manageUsersByAdmin mgu = new manageUsersByAdmin();

                // Retrieve the username to update from the command argument.
                string usernameToUpdate = e.CommandArgument.ToString();

                // Store the username to update in a session variable and redirect to the update page.
                Session["UsernameToUpdate"] = usernameToUpdate;
                Response.Redirect("manage_user_update.aspx");
            }
        }
    }

    // This event handler is called when a row is being deleted in the 'gridUserDetails' grid.
    protected void gridUserDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // This event handler is left empty as it's not needed for your scenario.
    }

    // This event handler is called when a row command is triggered in the 'gridSpecificUserDetails' grid.
    protected void gridSpecificUserDetails_Row(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            // Retrieve the command argument, which should contain the username to delete.
            string usernameToDelete = e.CommandArgument.ToString();

            // Create an instance of the 'manageUsersByAdmin' class.
            manageUsersByAdmin mgu = new manageUsersByAdmin();

            // Set the username to delete in the class.
            mgu._username = usernameToDelete;

            // Call the 'deleteUser' method to delete the user.
            int res = mgu.deleteUser();

            // Check if the deletion was successful and display a message.
            if (res > 0)
            {
                Response.Write("<script>alert('User Deleted')</script>");
                Response.Redirect("manage_user.aspx");
            }
        }
        else
        {
            if (e.CommandName == "update")
            {
                // Create an instance of the 'manageUsersByAdmin' class.
                manageUsersByAdmin mgu = new manageUsersByAdmin();

                // Retrieve the username to update from the command argument.
                string usernameToUpdate = e.CommandArgument.ToString();

                // Store the username to update in a session variable and redirect to the update page.
                Session["UsernameToUpdate"] = usernameToUpdate;
                Response.Redirect("manage_user_update.aspx");
            }
        }
    }

    // This event handler is called when a row is being deleted in the 'gridSpecificUserDetails' grid.
    protected void gridSpecificUserDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // This event handler is left empty as it's not needed for your scenario.
    }

    // This event handler is called when the "Apply Filter" button is clicked.
    protected void btnApplyFilter_Click(object sender, EventArgs e)
    {
        counters._countForUserDeleted = 0;
        pnlAlertMessageForNewUser.Visible = false;
        string str = txtSearchUser.Text.Trim();
        isEnabled = chkShowDisabled.Checked.ToString();
        if (str != "" && isEnabled.Equals("False"))
        {
            // Show the specific user grid and hide the all users grid.
            pnlViewSpecificUser.Visible = true;
            pnlViewAllUsers.Visible = false;

            // Create an instance of the 'manageUsersByAdmin' class.
            manageUsersByAdmin mgu = new manageUsersByAdmin();

            // Set the username and email to search for in the class.
            mgu._username = mgu._email = txtSearchUser.Text.Trim();

            // Call the 'searchUser' method to search for users.
            DataSet ds = mgu.searchUser();

            // Check if there are search results and bind them to the specific user grid.
            if (ds.Tables[0].Rows.Count > 0)
            {
               
                gridViewSpecificUserDetailss.DataSource = ds;
                gridViewSpecificUserDetailss.DataBind();
            }
        }
        else if (chkShowDisabled.Checked == true && txtSearchUser.Text == "")
        {
            // Show the specific user grid and hide the all users grid.
            pnlViewSpecificUser.Visible = true;
            pnlViewAllUsers.Visible = false;

            // Create an instance of the 'manageUsersByAdmin' class.
            manageUsersByAdmin mgu = new manageUsersByAdmin();

            // Set the username and email to search for in the class.
            mgu._isEnabled = "False";
            mgu._username = "";

            // Call the 'searchUser' method to search for users.
            DataSet ds = mgu.searchDisabledUser();

            // Check if there are search results and bind them to the specific user grid.
            if (ds.Tables[0].Rows.Count > 0)
            {
                gridViewSpecificUserDetailss.DataSource = ds;
                gridViewSpecificUserDetailss.DataBind();
            }
        }
        else if (chkShowDisabled.Checked == true && txtSearchUser.Text.Trim() != "")
        {
            // Show the specific user grid and hide the all users grid.
            pnlViewSpecificUser.Visible = true;
            pnlViewAllUsers.Visible = false;

            // Create an instance of the 'manageUsersByAdmin' class.
            manageUsersByAdmin mgu = new manageUsersByAdmin();

            // Set the username and email to search for in the class.
            mgu._username = txtSearchUser.Text.Trim();
            mgu._isEnabled = "False";

            // Call the 'searchUser' method to search for users.
            DataSet ds = mgu.searchDisabledUser();

            // Check if there are search results and bind them to the specific user grid.
            if (ds.Tables[0].Rows.Count > 0)
            {
                gridViewSpecificUserDetailss.DataSource = ds;
                gridViewSpecificUserDetailss.DataBind();
            }
            else
            {
                pnlViewAllUsers.Visible = false;
                pnlViewSpecificUser.Visible=false;
            }

        }
        else
        {
            // Show the all users grid and hide the specific user grid.
            pnlViewAllUsers.Visible = true;
            pnlViewSpecificUser.Visible = false;

            // Fetch and display all users.
            fetchAllUsers();
        }
        
       
        
        
    }
}