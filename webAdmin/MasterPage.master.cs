using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class webAdmin_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count > 0)
        {
            userInfo();
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
        if (!IsPostBack)
        {

            fetchProjectNameForTopBar();
            if (Session["projectIDForDropDown"] != null) ddlProjectSelect.SelectedValue = Session["projectIDForDropDown"].ToString();
        }
        
        
        string currentPageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
        if (currentPageName == "addIssue.aspx" || currentPageName == "ViewIssue.aspx" || currentPageName == "dashboard.aspx")
        {
            pnlIfAdminInUsersDirectory.Visible = true;
            pnlIfAdminInOwnDirectory.Visible = false;
            profileLink.NavigateUrl = "../webAdmin/account_page.aspx";
            logoutLink.NavigateUrl = "../webAdmin/Default.aspx";
           
        }
        else
        {
            profileLink.NavigateUrl = "account_page.aspx";
            logoutLink.NavigateUrl = "Default.aspx";
           
        }
    }
    protected void fetchProjectNameForTopBar()
    {
        manageProject mgp = new manageProject();
        mgp._userName = Session["UserName"].ToString();
        mgp._userAccessLevel = Session["userAccessLevel"].ToString();
        DataSet ds = mgp.fetchProjectNames();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlProjectSelect.DataSource = ds;
            ddlProjectSelect.DataTextField = "projectName";
            ddlProjectSelect.DataValueField = "projectID";
            ddlProjectSelect.DataBind();
        }
    }

    protected void ddlProjectSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        long selectedValue = Convert.ToInt32(ddlProjectSelect.SelectedValue);
        Session["projectIDForDropDown"] = selectedValue;
        string currentPage = this.Page.ToString();
        if (currentPage == "ASP.webusers_dashboard_aspx") Response.Redirect("dashboard.aspx");
        else if (currentPage == "ASP.webusers_searchissues_aspx") Response.Redirect("SearchIssues.aspx");
    }

    protected void userInfo()
    {
        clsLogin obj = new clsLogin();
        obj._username = Session["UserName"].ToString();
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
}
