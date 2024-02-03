using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class webAdmin_project_management : System.Web.UI.Page
{
    void Page_PreInit(Object sender, EventArgs e)
    {
        if (Session["UserAccessLevel"] != null)
        {
            string session = Session["UserAccessLevel"].ToString();
            if (session == "Manager")
            {
                this.MasterPageFile = "../webUsers/MasterPage.master";
            }
            else
            {
                this.MasterPageFile = "../webAdmin/MasterPage.master";
            }
        }
        else Response.Redirect("Default.aspx");
    }
    // This method is called when the page is loaded.
    protected void Page_Load(object sender, EventArgs e)
    {
        

        if (Session["UserAccessLevel"].ToString() != "Administrator")
        {
            btnCreateProject.Visible = false;
        }
        if (!IsPostBack)
        {
            // Call a method to populate the dropdown on the initial page load.
            if (Request.QueryString["parent_id"] != null)
            {
                pnlAddProj.Visible = true;
                btnCreateProject.Visible = false;
                pnlHeading.Visible = false;
                //chkInheritParentCategory.Visible = true;
                //pnlChkInheritCat.Visible = true;
            }
            else
            {
                // Call the method to fetch and display project details.
                if (!IsPostBack)
                {
                    fetchProjectDetails();
                }
            }
        }
    }

    // This event handler is called when the "Create Project" button is clicked.
    protected void btnCreateProject_Click(object sender, EventArgs e)
    {
        pnlAddProj.Visible = true;
        btnCreateProject.Visible = false;
        pnlShowAllProjects.Visible = false;
    }

    // This event handler is called when the "Add Project" button is clicked.
    protected void btnAddProject_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtProjName.Text.Trim()))
        {
            Response.Write("<script>alert('Enter a project name')</script>");
        }
        else
        {
            // Get the selected project status from the dropdown list.
            string selectedStatus = Convert.ToString(ddlProjectStatus.SelectedItem);
            string selectedViewStatus = Convert.ToString(dlStatus.SelectedItem);

            // Check if a project status is selected.
            if (!string.IsNullOrEmpty(selectedStatus))
            {
                // Create an instance of 'manageProject'.
                manageProject mgp = new manageProject();

                // Set project properties from user inputs.
               // mgp._inheritCat = Convert.ToString(chkGlobalCategory.Checked);
                mgp._projName = txtProjName.Text.Trim();
                mgp._parentProjectID = Convert.ToInt32(Request.QueryString["parent_id"]);
                mgp._projStatus = selectedStatus;
                mgp._viewStatus = selectedViewStatus;
                mgp._projDescripion = txtDescription.Text.Trim();
               // mgp._chkInheritParentCat = Convert.ToString(chkInheritParentCategory.Checked);

                // Check if this is a top-level project or a subproject.
                if (mgp._parentProjectID == 0)
                {
                    // Call the method to add a new project.
                    int res = mgp.addNewProject();

                    // Check the result of the insertion.
                    if (res != 0)
                    {

                        Response.Redirect("project_management.aspx");
                    }
                }
                else
                {
                    // Call the method to create a new subproject.
                    long resp = mgp.createNewSubproject();

                    // Check the result of subproject creation.
                    if (resp > 0)
                    {
                        Response.Redirect("project_management.aspx");
                        txtProjName.Text = "";
                        txtDescription.Text = "";
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('Please select a project status')</script>");
            }
        }
    }

    // This method fetches and displays project details.
    protected void fetchProjectDetails()
    {
        // Create an instance of 'manageProject'.
        manageProject mgp = new manageProject();
        mgp._userName=Session["UserName"].ToString();
        mgp._userName = Session["UserName"].ToString();
        mgp._userAccessLevel = Session["UserAccessLevel"].ToString();
        // Call the method to fetch project details.
        DataSet ds = mgp.fetchProjectDetails();

        // Check if there are project details in the dataset.
        if (ds.Tables[0].Rows.Count > 0)
        {
            // Bind the dataset to the 'gridShowProjectDetails' grid.
            gridShowProjectDetails.DataSource = ds;
            gridShowProjectDetails.DataBind();
        }
    }

    // This event handler is called when the "Back" button is clicked.
    protected void btnBack_Click(object sender, EventArgs e)
    {
        pnlShowAllProjects.Visible = true;
        pnlAddProj.Visible = false;
        btnCreateProject.Visible = true;
    }
}
