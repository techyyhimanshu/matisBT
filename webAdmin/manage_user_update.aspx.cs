using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Threading;

public partial class webAdmin_manage_user_update : System.Web.UI.Page
{
    static string picPath;
   
    string usernameforAssignedProjects; // Variable to store the username for assigned projects
    
    // This method is called when the page is loaded.
    public void Page_Load(object sender, EventArgs e)
    {
        fetchAllData();
    }
    public void fetchAllData()
    {
        if (!IsPostBack)
        {
            // Create an instance of the 'manageUsersByAdmin' class.
            manageUsersByAdmin mgu = new manageUsersByAdmin();

            // Get the logged-in username and the username to update from session variables.
            string loggedInUsername = Session["LoggedInUsername"] as string;
            string UpdatedUsername = Session["UsernameToUpdate"] as string;

            // Set properties in the 'manageUsersByAdmin' class for fetching user details for update.
            mgu._username = loggedInUsername;
            mgu._usernameForUpdate = UpdatedUsername;

            // Call the 'fetchUserDetailsForUpdate' method to retrieve user details for updating.
            DataSet ds = mgu.fetchUserDetailsForUpdate();

            // Check if the dataset contains data.
            if (ds.Tables.Count > 0)
            {
                // Populate form fields with user details.
                picPath = ds.Tables[0].Rows[0]["userPicPath"].ToString();
                txtUserName.Text = usernameforAssignedProjects = UpdatedUsername;
                //PopulateAssignedProjects();
                //PopulateUnassignedProjects();
                txtRealName.Text = ds.Tables[0].Rows[0]["userRealName"].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0]["userEmail"].ToString();
                ddlUserAccessLevel.SelectedValue = ds.Tables[0].Rows[0]["userAccessLevel"].ToString();
                if (ds.Tables[0].Rows[0]["isEnabled"].ToString() != "")
                {
                    chkEnabled.Checked = true;
                }
                if (ds.Tables[0].Rows[0]["isProtected"].ToString() != "")
                {
                    chkProtected.Checked = true;
                }
            }
        }
    }
    // This event handler is called when the "Delete User" button is clicked.
    //protected void btnDeleterUser_Click(object sender, EventArgs e)
    //{
    //    // Create an instance of the 'manageUsersByAdmin' class.
    //    manageUsersByAdmin mgu = new manageUsersByAdmin();

    //    // Get the logged-in username from the session.
    //    string loggedInUsername = Session["LoggedInUsername"] as string;

    //    // Set the username in the 'manageUsersByAdmin' class.
    //    mgu._username = loggedInUsername;

    //    // Call the 'deleteUser' method to delete the user.
    //    int res = mgu.deleteUser();

    //    // Check if the user deletion was successful and display a message.
    //    if (res > 0)
    //    {
    //        Response.Write("<script>alert('User deleted')</script>");
    //        txtUserName.Text = "";
    //        txtRealName.Text = "";
    //        txtEmail.Text = "";
    //    }
    //}

    // This event handler is called when the "Update User" button is clicked.
    protected void btnUpdateUser_Click(object sender, EventArgs e)
    {
        // Create an instance of the 'manageUsersByAdmin' class.
        manageUsersByAdmin mgu = new manageUsersByAdmin();

        // Get the logged-in username from the session.
        string loggedInUsername = Session["LoggedInUsername"] as string;
        string useraccesslevel;
        // Set properties in the 'manageUsersByAdmin' class for updating user details.
        mgu._username = txtUserName.Text.Trim();
        mgu._usernameForUpdate = Session["UsernameToUpdate"].ToString();
        mgu._realName = txtRealName.Text.Trim();
        mgu._email = txtEmail.Text.Trim();
        mgu._picPath = picPath;
        mgu._userAccesLevel = useraccesslevel = Convert.ToString(ddlUserAccessLevel.SelectedItem);
        mgu._isEnabled = Convert.ToString(chkEnabled.Checked);
        mgu._isProtected = Convert.ToString(chkProtected.Checked);

        // Call the 'updateUser' method to update user details.
        int res = mgu.updateUser();
        Response.Redirect("manage_user.aspx");
        // Check if the user update was successful and display a message.
        //if (res!=0)
        //{
        //    if (useraccesslevel == "Administrator")
        //    {
        //        Response.Redirect("manage_user.aspx");
        //    }
        //    else
        //    {
        //        Response.Redirect("..//webUsers//Signin.aspx");
        //    }
                
        //}
    }

    // This event handler is called when the "Back" button is clicked.
    protected void btnBack_Click(object sender, EventArgs e)
    {
        // Redirect to the "manage_user.aspx" page.
        Response.Redirect("manage_user.aspx");
    }

    // This method populates the list of unassigned projects.
    //protected void PopulateUnassignedProjects()
    //{
    //    // Replace with your connection string.
       

    //    using (SqlConnection connection = new SqlConnection(Utility.strconn))
    //    {
    //        // Define a SQL query to select unassigned projects for the user.
    //        string query = "select projectName, projectID from tbl_Project_Details where projectID not in (select projectID from tbl_assigned_projects where userName='" + usernameforAssignedProjects + "')";

    //        using (SqlCommand cmd = new SqlCommand(query, connection))
    //        {
    //            connection.Open();

    //            // Execute the SQL query and populate the "dlUnassignedProjects" dropdown list.
    //            using (SqlDataReader reader = cmd.ExecuteReader())
    //            {
    //                dlUnassignedProjects.DataSource = reader;
    //                dlUnassignedProjects.DataTextField = "projectName"; // Displayed text
    //                dlUnassignedProjects.DataValueField = "projectID"; // Value when selected
    //                dlUnassignedProjects.DataBind();
    //            }
    //        }
    //    }
    //}

    // This method populates the list of assigned projects.
    //protected void PopulateAssignedProjects()
    //{
    //    // Replace with your connection string.
       

    //    using (SqlConnection connection = new SqlConnection(Utility.strconn))
    //    {
    //        // Define a SQL query to select assigned projects for the user.
    //        string query = "select projectName, projectID from tbl_Project_Details where projectID in (select projectID from tbl_assigned_projects where userName='" + usernameforAssignedProjects + "')";

    //        using (SqlCommand cmd = new SqlCommand(query, connection))
    //        {
    //            connection.Open();

    //            // Execute the SQL query and populate the "dlAssignedProjects" dropdown list.
    //            using (SqlDataReader reader = cmd.ExecuteReader())
    //            {
    //                dlAssignedProjects.DataSource = reader;
    //                dlAssignedProjects.DataTextField = "projectName"; // Displayed text
    //                dlAssignedProjects.DataValueField = "projectID"; // Value when selected
    //                dlAssignedProjects.DataBind();
    //            }
    //        }
    //    }
    //}

    // This event handler is called when the "Assign Project" button is clicked.
    //protected void btnAssignedProject_Click(object sender, EventArgs e)
    //{
    //    // Create an instance of the 'manageUsersByAdmin' class.
    //    manageUsersByAdmin mgu = new manageUsersByAdmin();

    //    // Set the username and project ID to assign.
    //    mgu._username = txtUserName.Text.Trim();
    //    mgu._projectID = Convert.ToInt32(dlUnassignedProjects.SelectedValue);

    //    // Call the 'assignProjectToUser' method to assign the project to the user.
    //    int res = mgu.assignProjectToUser();

    //    // Check if the project assignment was successful and display a message.
    //    if (res > 0)
    //    {
    //        Response.Write("<script>alert('Project Assigned')</script>");
    //        Thread.Sleep(1);
    //        Response.Redirect("manage_user_update.aspx");
    //    }
    //}
}

