using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class webUsers_MasterPage : System.Web.UI.MasterPage
{
    void Page_PreInit(Object sender, EventArgs e)
    {
        string session = Session["UserAccessLevel"].ToString();
        if (session == "Administrator")
        {
            this.MasterPageFile = "../webAdmin/MasterPage.master";
        }
        else
        {
            this.MasterPageFile = "../webUsers/MasterPage.master";
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count > 0)
        {
            userInfo();
        }
        else
        {
            Response.Redirect("SignIn.aspx");
        }
        if (!IsPostBack)
        {
            projectList();
            if (Session["projectIDForDropDown"] != null) ddProjectList.SelectedValue = Session["projectIDForDropDown"].ToString();
        }
    }
    [System.Web.Services.WebMethod]
    public static string GetUpdatedLabelText()
    {
        // Your logic to get the updated label text goes here
        // For example, you might fetch data from a database
        return DateTime.Now.ToString("hh:mm:ss tt");
    }

    protected void userInfo()
    {
        clsLogin obj = new clsLogin();
        obj._username = Session["UserName"].ToString();
        string accessLevel = Session["UserAccessLevel"].ToString();
        if (accessLevel == "Manager")
        {
            hlManageProjectForManager.Visible = true;
            hlManageTagsForManager.Visible = false;
            hlLogout.NavigateUrl = "../webUsers/SignIn.aspx";
        }
        else
        {
            if (accessLevel != "Reporter" && accessLevel != "Developer")
            {
                hlManageProjectForManager.Visible = false;
                hlManageTagsForManager.Visible = false;
                hlLogout.NavigateUrl = "SignIn.aspx";
                hlAddIssue.Visible = false;
            }
            else
            {
                hlManageProjectForManager.Visible = false;
                hlManageTagsForManager.Visible = false;
                hlAddIssue.Visible = true;
                hlLogout.NavigateUrl = "../webUsers/SignIn.aspx";
            }
        }
        DataSet ds = obj.fetchUserData();
        if (ds.Tables[0].Rows.Count > 0)
        {
            lbUserName.Text = ds.Tables[0].Rows[0]["userName"].ToString();
            lbUserName2.Text = ds.Tables[0].Rows[0]["userName"].ToString();
            imgUser.ImageUrl = ds.Tables[0].Rows[0]["userPicPath"].ToString();
            imgUser2.ImageUrl = ds.Tables[0].Rows[0]["userPicPath"].ToString();
            lbUserRole.Text = ds.Tables[0].Rows[0]["userAccessLevel"].ToString();
        }
    }

    protected void projectList()
    {
        manageProject obj = new manageProject();
        obj._userName = Session["UserName"].ToString();
        obj._userAccessLevel = Session["userAccessLevel"].ToString();
        DataSet ds = obj.fetchProjectNames();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddProjectList.DataSource = ds;
            ddProjectList.DataBind();
        }
    }

    protected void ddProjectList_SelectedIndexChanged(object sender, EventArgs e)
    {
        long selectedValue = Convert.ToInt32(ddProjectList.SelectedValue);
        Session["projectIDForDropDown"] = selectedValue;
        string currentPage = this.Page.ToString();
        if (currentPage == "ASP.webusers_dashboard_aspx") Response.Redirect("dashboard.aspx");
        else if (currentPage == "ASP.webusers_searchissues_aspx") Response.Redirect("SearchIssues.aspx");
    }
}
