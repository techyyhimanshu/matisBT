     using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Text.RegularExpressions;
public partial class webAdmin_project_management_edit : System.Web.UI.Page
{
    void Page_PreInit(Object sender, EventArgs e)
    {
        if (Session["UserAccessLevel"] != null)
        {
            string session = Session["UserAccessLevel"].ToString();
            if (session != "Administrator")
            {
                this.MasterPageFile = "../webUsers/MasterPage.master";
            }
            else
            {
                this.MasterPageFile = "../webAdmin/MasterPage.master";
            }
        }
        else Response.Redirect("project_management.aspx");
       
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserAccessLevel"].ToString() != "Administrator")
            {
                btnDelete.Visible = false;
                btnCreateNewSubProject.Visible = false;
            }
            fetchAllProjectDetails();
            fecthUserToAdd();
            showMembers();
        }
    }
    public long refineQueryString()
    {
        string projIdFromQueryString = Request.QueryString["id"];

        // Remove special symbols and non-numeric characters from tag_id
        string cleanedProjectId = Regex.Replace(projIdFromQueryString, "[^0-9]", "");
        long refinedProjectID;
        long.TryParse(cleanedProjectId, out refinedProjectID);
        return refinedProjectID;
    }
    protected void fetchAllProjectDetails()
    {
        long projectID = 0;
        projectID = refineQueryString();

        if (projectID != 0)
        {
            manageProject mgp = new manageProject();
            mgp._projID = projectID;
            mgp._userAccessLevel = Session["userAccessLevel"].ToString();
            mgp._userName=Session["UserName"].ToString();
            DataSet ds, dsTwo, dsForSubproject;
            mgp.fetchProjectDetailsForUpdate(out ds, out dsTwo, out dsForSubproject);
            if (ds.Tables.Count > 0)
            {
                txtProjName.Text = ds.Tables[0].Rows[0]["projectName"].ToString();
                //string inheritCat = ds.Tables[0].Rows[0]["isInheritCategory"].ToString();
                ddlProjectStatus.SelectedValue = ds.Tables[0].Rows[0]["status"].ToString();
                txtDescription.Text = ds.Tables[0].Rows[0]["projectDescription"].ToString();
                dlStatus.SelectedValue = ds.Tables[0].Rows[0]["viewStatus"].ToString();
                string isEnabled = ds.Tables[0].Rows[0]["isEnabled"].ToString();
                //if (inheritCat.Equals("True"))
                //{
                //    chkGlobalCategory.Checked = true;
                //}
                if (!isEnabled.Equals("False"))
                {
                    chkEnabled.Checked = true;
                }

            }
            if (dsTwo.Tables.Count > 0)
            {
                dlProjectDetailsForSubprojectCreation.DataSource = dsTwo;
                dlProjectDetailsForSubprojectCreation.DataTextField = "projectName";
                dlProjectDetailsForSubprojectCreation.DataValueField = "projectID";
                dlProjectDetailsForSubprojectCreation.DataBind();
            }
            if (dsForSubproject.Tables.Count > 0)
            {
                gridShowSubprojects.DataSource = dsForSubproject;
                gridShowSubprojects.DataBind();
            }
        }

    }
    protected void btnUpdateProject_Click(object sender, EventArgs e)
    {
        manageProject mgp = new manageProject();
        long projectID = 0;
        projectID = refineQueryString();
        mgp._projID = projectID;
        mgp._projName = txtProjName.Text.Trim(); ;
        mgp._projDescripion = txtDescription.Text.Trim();
        //mgp._inheritCat = Convert.ToString(chkGlobalCategory.Checked);
        mgp._projStatus = Convert.ToString(ddlProjectStatus.SelectedItem);
        mgp._viewStatus = Convert.ToString(dlStatus.SelectedItem);
        mgp._isEnabled = Convert.ToString(chkEnabled.Checked);
        int res = mgp.updateProjectDetails();
        if (res != 0)
        {
            Response.Redirect("project_management.aspx");
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("project_management.aspx");
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {

        manageProject mgp = new manageProject();
        mgp._projID = refineQueryString();
        int res = mgp.deleteProject();
        if (res != null)
        {
            Response.Redirect("project_management.aspx");
        }
    }

    protected void btnCreateNewSubProject_Click(object sender, EventArgs e)
    {
        long parentProjectID = refineQueryString();
        Response.Redirect("project_management.aspx?parent_id=" + parentProjectID);
    }
    protected void btnAddAsSubProject_Click(object sender, EventArgs e)
    {
        manageProject mgp = new manageProject();
        mgp._parentProjectID = refineQueryString();// Parent ID for subproject creation
        long subProjectID = Convert.ToInt32(dlProjectDetailsForSubprojectCreation.SelectedValue);  // To select the subproject id from dropdownlist
        mgp._projID = subProjectID;
        int res = mgp.addSubproject();
        if (res != null)
        {
            Response.Redirect("project_management_edit.aspx?id=" + refineQueryString());
        }
    }

    protected void gridSubProjects_Row(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "unlink")
        {
            // Retrieve the command argument, which should contain the username to delete
            long subProjectID = Convert.ToInt32(e.CommandArgument.ToString());
            manageProject mgp = new manageProject();
            mgp._projID = subProjectID;
            int res = mgp.unlinkSubproject();
            if (res != 0)
            {

                Response.Redirect("project_management_edit.aspx?id=" + refineQueryString());

            }
        }
    }

    protected void gridSubProjects_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void btnAddUser_Click(object sender, EventArgs e)
    {
        ProjectMembers obj = new ProjectMembers();
        obj._projectID = refineQueryString();
        obj._userName = ddusersToAdd.SelectedValue.ToString();
        obj._userAccessLevel = dduserAccessLevel.SelectedValue.ToString();
        int rowAffected = obj.addUserToProject();
        Response.Redirect("project_management_edit.aspx?id=" + Request.QueryString["id"]);
    }

    protected void fecthUserToAdd()
    {
        ProjectMembers obj = new ProjectMembers();
        obj._projectID = refineQueryString();
        DataSet ds = obj.usersToAdd();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddusersToAdd.DataSource = ds;
            ddusersToAdd.DataBind();
        }
    }

    protected void showMembers()
    {
        ProjectMembers obj = new ProjectMembers();
        obj._projectID = refineQueryString();
        DataSet ds = obj.showMembers();
        gvMembers.DataSource = ds;
        gvMembers.DataBind();
        foreach (GridViewRow row in gvMembers.Rows)
        {
            DropDownList ddAccessLevel = row.FindControl("ddmemberAccessLevel") as DropDownList;
            ddAccessLevel.SelectedValue = row.Cells[1].Text; 
        }
    }


    protected void btnEditMembers_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gvMembers.Rows)
        {
            
            CheckBox checkRemove = row.FindControl("cbRemove") as CheckBox;
            DropDownList ddAccessLevel = row.FindControl("ddmemberAccessLevel") as DropDownList;
            ProjectMembers obj = new ProjectMembers();
            obj._userName = row.Cells[0].Text;
            obj._projectID = Convert.ToInt64(Request.QueryString["id"]);
            if (checkRemove.Checked == true)
            {
                int rowAffected = obj.removeMember();
            }
            else
            {
                obj._userAccessLevel = ddAccessLevel.SelectedValue;
                int rowAffected = obj.updateMember();
            }
            
        }
        Response.Redirect("project_management_edit.aspx?id=" + refineQueryString());
    }
}