using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class webUsers_dashboard : System.Web.UI.Page
{
    
    long projID = variables.ValueOfSelectedProjectName;
    void Page_PreInit(Object sender, EventArgs e)
    {
        if (Session.Count > 0)
        {
            string userRole = Session["UserAccessLevel"].ToString();
            if (userRole == "Administrator")
            {
                this.MasterPageFile = "../webAdmin/MasterPage.master";
            }
            else
            {
                this.MasterPageFile = "../webUsers/MasterPage.master";
            }
        }
        else Response.Redirect("SignIn.aspx");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
      
        if (counters._countForLogin==1)
        {
            loginSuccess.Text = "Welcome" +" "+ Session["UserName"].ToString() + " 😎";
            pnlAlertMessageForLoginSuccess.Visible = true;
            counters._countForLogin = 2;
        }
        if (counters._countForNewIssue == 1)
        {
            pnlAlertForNewIssue.Visible = true;
            counters._countForNewIssue = 2;
        }
        else pnlAlertForNewIssue.Visible = false;
        unassignedIssues();
        reportedByMe();
        resolvedIssues();
        recentlyModified();
        monitoredByMe();
        assignedToMe();
        timeLine();
    }

   
   
    protected void unassignedIssues()
    {
        
        Dashboard obj = new Dashboard();
        if (Session["projectIDForDropDown"] != null) obj.ProjectID = Session["projectIDForDropDown"].ToString();
        else obj.ProjectID = "0";
        obj._userName = Session["UserName"].ToString();
        DataSet ds = obj.unassignedIssues();
        if (ds.Tables[0].Rows.Count > 0)
        {
            dlUnassigned.DataSource = ds;
            dlUnassigned.DataBind();
        }
    }

    protected void reportedByMe()
    {
        Dashboard obj = new Dashboard();
        if (Session.Count > 0)
        {

            obj.ProjectID = Session["projectIDForDropDown"].ToString();
            obj._userName = Session["UserName"].ToString();
            DataSet ds = obj.reportedByMe();
            if (ds.Tables[0].Rows.Count > 0)
            {
                dlByMe.DataSource = ds;
                dlByMe.DataBind();
            }
        }
        else Response.Redirect("SignIn.aspx");
    }

    protected void resolvedIssues()
    {
        Dashboard obj = new Dashboard();
        obj.ProjectID = Session["projectIDForDropDown"].ToString();
        obj._userName = Session["UserName"].ToString();
        DataSet ds = obj.resolvedIssues();
        if (ds.Tables[0].Rows.Count > 0)
        {
            dlResolved.DataSource = ds;
            dlResolved.DataBind();
        }
    }

    protected void recentlyModified()
    {
        Dashboard obj = new Dashboard();
        obj.ProjectID = Session["projectIDForDropDown"].ToString();
        obj._userName = Session["UserName"].ToString();
        DataSet ds = obj.recentlyModified();
        if (ds.Tables[0].Rows.Count > 0)
        {
            dlRecently.DataSource = ds;
            dlRecently.DataBind();
        }
    }

    protected void monitoredByMe()
    {
        Dashboard obj = new Dashboard();
        if (Session.Count > 0)
        {
            obj.ProjectID = Session["projectIDForDropDown"].ToString();
            obj._userName = Session["userName"].ToString();
            DataSet ds = obj.monitoredByMe();
            if (ds.Tables[0].Rows.Count > 0)
            {
                dlMonitoredByMe.DataSource = ds;
                dlMonitoredByMe.DataBind();
            }
        }
        else Response.Redirect("SignIn.aspx");
    }

    protected void assignedToMe()
    {
        Dashboard obj = new Dashboard();
        obj.ProjectID = Session["projectIDForDropDown"].ToString();
        obj._userName = Session["userName"].ToString();
        DataSet ds = obj.assignedToMe();
        if (ds.Tables[0].Rows.Count > 0)
        {
            dlAssignedToMe.DataSource = ds;
            dlAssignedToMe.DataBind();
        }
        else
        {
            pnlAssignedToMe.Visible = false;
        }
    }

    protected string GetLinkColor(string bugPriority)
    {
        return Color.priorityColor(bugPriority); 
    }

    protected void timeLine()
    {
        Dashboard obj = new Dashboard();
        obj.ProjectID = Session["projectIDForDropDown"].ToString();
        obj._userName = Session["userName"].ToString();
        DataSet ds = obj.timeLine();
        if (ds.Tables[0].Rows.Count > 0)
        {
            dlTimeLine.DataSource = ds;
            dlTimeLine.DataBind();
        }
    }

    protected string GetTimeLineItem(string userName, string action, string obj)
    {
        if (action == "addIssue") return "<p>" + userName + " reported the issue </p><a href='ViewIssue.aspx?mn=" + obj + "'>" + obj + "</a>";
        else if (action == "updateIssue") return "<p>" + userName + " updated the issue </p><a href='ViewIssue.aspx?mn=" + obj + "'>" + obj + "</a>";
        else if (action == "cloneIssue") return "<p>" + userName + " created a clone issue </p><a href='ViewIssue.aspx?mn=" + obj + "'>" + obj + "</a>";
        else if (action == "addNote") return "<p>" + userName + " commented on issue </p><a href='ViewIssue.aspx?mn=" + obj + "'>" + obj + "</a>";
        else if (action == "acknowledgedIssue") return "<p>" + userName + " acknowledged issue </p><a href='ViewIssue.aspx?mn=" + obj + "'>" + obj + "</a>";
        else if (action == "resolvedIssue") return "<p>" + userName + " resolved issue </p><a href='ViewIssue.aspx?mn=" + obj + "'>" + obj + "</a>";
        else if (action == "closedIssue") return "<p>" + userName + " closed issue </p><a href='ViewIssue.aspx?mn=" + obj + "'>" + obj + "</a>";
        else if (action == "reopenedIssue") return "<p>" + userName + " reopened issue </p><a href='ViewIssue.aspx?mn=" + obj + "'>" + obj + "</a>";
        else if (action == "notFixableIssue") return "<p>" + userName + " marked issue </p><a href='ViewIssue.aspx?mn=" + obj + "'>" + obj + "</a> as not fixable";
        else if (action == "suspendedIssue") return "<p>" + userName + " suspended issue </p><a href='ViewIssue.aspx?mn=" + obj + "'>" + obj + "</a>";
        else if (action == "assignedTo") return "<p>Issue </p><a href='ViewIssue.aspx?mn=" + obj + "'>" + obj + "</a><p> is assigned to " + userName + "</p>";
        else if (action == "unassigned") return "<p>" + userName + " unassigned issue </p><a href='ViewIssue.aspx?mn=" + obj + "'>" + obj + "</a>";
        else return "";
    }

}