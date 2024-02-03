using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
public partial class webAdmin_manage_category_edit : System.Web.UI.Page
{
    // This method is called when the page is loaded.
    protected void Page_Load(object sender, EventArgs e)
    {
        // Check if the page is being loaded for the first time.
        if (!IsPostBack)
        {
            // Call the fetchCategoryDetails method to populate the page with category details.
            fetchCategoryDetails();
        }
    }
    public long refineQueryString()
    {
        string catIdFromQueryString = Request.QueryString["id"];

        // Remove special symbols and non-numeric characters from tag_id
        string cleanedCatId = Regex.Replace(catIdFromQueryString, "[^0-9]", "");
        long refinedCatID;
        long.TryParse(cleanedCatId, out refinedCatID);
        return refinedCatID;
    }

    // This method fetches category details based on the ID from the query string.
    protected void fetchCategoryDetails()
    {
        // Create an instance of the 'manageCat' class.
        manageCat mgc = new manageCat();

        // Get the 'id' from the query string and convert it to an integer.
        mgc._catID = refineQueryString();

        // Call the 'fetchCategoryNameForUpdate' method to retrieve category details from the database.
        DataSet ds = mgc.fetchCategoryNameForUpdate();

        // Check if the dataset contains data.
        if (ds.Tables.Count > 0)
        {
            // Set the text of 'txtCatName' control to the category name retrieved from the dataset.
            txtCatName.Text = ds.Tables[0].Rows[0]["CatName"].ToString();

            // Call the 'PopulateUsers' method to populate a dropdown list with user names.
            //PopulateUsers();
        }
    }

    // This method populates a dropdown list with user names from the database.
    //protected void PopulateUsers()
    //{
    //    // Replace with your connection string.
    //    string connectionString = Utility.strconn;

    //    // Create a SqlConnection using the connection string.
    //    using (SqlConnection connection = new SqlConnection(connectionString))
    //    {
    //        // Define a SQL query to select user names from a table.
    //        string query = "select userName from tbl_Users";

    //        // Create a SqlCommand using the query and connection.
    //        using (SqlCommand cmd = new SqlCommand(query, connection))
    //        {
    //            // Open the database connection.
    //            connection.Open();

    //            // Execute the SQL query and populate the dropdown list with user names.
    //            using (SqlDataReader reader = cmd.ExecuteReader())
    //            {
    //                dlAssignedToUsers.DataSource = reader;
    //                dlAssignedToUsers.DataTextField = "userName"; // Displayed text
    //                dlAssignedToUsers.DataBind();
    //            }
    //        }
    //    }
    //}

    // This method is called when the "btnUpdateCat" button is clicked.
    protected void btnUpdateCat_Click(object sender, EventArgs e)
    {
        // Create an instance of the 'manageCat' class.
        manageCat mgc = new manageCat();

        // Get the category ID from the query string and convert it to an integer.
        mgc._catID = refineQueryString();

        // Get the category name from the 'txtCatName' textbox.
        mgc._catName = txtCatName.Text.Trim();

        // Get the selected item from the dropdown list and convert it to a string.
        //mgc._assignUser = Convert.ToString(dlAssignedToUsers.SelectedItem);

        // Call the 'updateCategoryDetails' method to update category details in the database.
        int res = mgc.updateCategoryDetails();

        // Check if the update was successful, and then redirect to another page.
        if (res > 0)
        {
            Response.Redirect("manage_category.aspx");
        }
    }
}
