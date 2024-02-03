using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;
public partial class webUsers_ViewIssue : System.Web.UI.Page
{
    long issueID;
    
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
        if (Request.QueryString.HasKeys())
        {
            issueID = refineQueryString();
            viewIssue();
            //fetchTags();
            viewNotes();
            viewRelations();
            isMonitored();
            if (!IsPostBack) fetchUsersToAssignBug();
        }
        string userRole = Session["UserAccessLevel"].ToString();
        string projectRole = checkProjectRole();
        if (userRole == "Administrator" || projectRole == "manager")
        {
            btnAssignTo.Visible = true;
            ddAssignedTo.Visible = true;

            if (lbStatus.Text.ToString() == "open" || lbStatus.Text.ToString() == "reopened")
            {
                btnEdit.Visible = true;
                btnClose.Visible = true;
            }
            else if (lbStatus.Text.ToString() == "resolved")
            {
                btnClose.Visible = true;
                btnReopen.Visible = true;
            }
        }
        if (lbAssignedTo.Text == Session["userName"].ToString())
        {
            if (lbStatus.Text.ToString() == "open" || lbStatus.Text.ToString() == "reopened")
            {
                btnAcknowledge.Visible = true;
                btnResolved.Visible = false;
                //btnClose.Visible = true;
                btnReopen.Visible = false;
                btnSuspend.Visible = false;
            }
            else if (lbStatus.Text.ToString() == "acknowledged")
            {
                btnAcknowledge.Visible = false;
                btnResolved.Visible = true;
                //btnClose.Visible = true;
                btnReopen.Visible = false;
                btnSuspend.Visible = true;
            }
            else if (lbStatus.Text.ToString() == "resolved")
            {
                btnAcknowledge.Visible = false;
                btnResolved.Visible = false;
                //btnClose.Visible = true;
                btnReopen.Visible = true;
                btnSuspend.Visible = false;
            }
            else if (lbStatus.Text.ToString() == "closed")
            {
                btnAcknowledge.Visible = false;
                btnResolved.Visible = false;
                //btnClose.Visible = false;
                btnReopen.Visible = false;
                btnSuspend.Visible = false;
            }
            else if (lbStatus.Text.ToString() == "suspended")
            {
                btnAcknowledge.Visible = false;
                btnResolved.Visible = false;
                //btnClose.Visible = true;
                btnReopen.Visible = true;
                btnSuspend.Visible = false;
            }
        }

        
    }
    public long refineQueryString()
    {
        string bugIdFromQueryString = Request.QueryString["mn"];

        // Remove special symbols and non-numeric characters from tag_id
        string cleanedBugId = Regex.Replace(bugIdFromQueryString, "[^0-9]", "");
        long refinedBugID;
        long.TryParse(cleanedBugId, out refinedBugID);
        return refinedBugID;
    }
    protected void viewIssue()
    {
        Issue obj = new Issue();
        obj._bugId = issueID;
        DataSet ds = obj.viewIssue();
        if (ds.Tables[0].Rows.Count > 0)
        {
            lbID.Text = ds.Tables[0].Rows[0]["bugID"].ToString();
            lbProject.Text = ds.Tables[0].Rows[0]["projectName"].ToString();
            lbCategory.Text = ds.Tables[0].Rows[0]["catName"].ToString();
            lbViewStatus.Text = ds.Tables[0].Rows[0]["bugViewStatus"].ToString();
            lbDateSubmitted.Text = ds.Tables[0].Rows[0]["bugCreatedDate"].ToString();
            lbLastUpdate.Text = ds.Tables[0].Rows[0]["bugUpdatedDate"].ToString();
            lbReporter.Text = ds.Tables[0].Rows[0]["bugReporter"].ToString();
            lbAssignedTo.Text = ds.Tables[0].Rows[0]["bugAssignedTo"].ToString();
            lbPriority.Text = ds.Tables[0].Rows[0]["bugPriority"].ToString();
            lbSeverity.Text = ds.Tables[0].Rows[0]["bugSeverity"].ToString();
            lbReproducibility.Text = ds.Tables[0].Rows[0]["bugReproducibility"].ToString();
            lbStatus.Text = ds.Tables[0].Rows[0]["bugStatus"].ToString();
            //lbResolution.Text = ds.Tables[0].Rows[0]["bugID"].ToString();
            lbSummary.Text = ds.Tables[0].Rows[0]["bugSummary"].ToString();
            lbDescription.Text = ds.Tables[0].Rows[0]["bugDescription"].ToString();
            imgBug.ImageUrl = ds.Tables[0].Rows[0]["bugImage"].ToString();
            lbStepsToReproduce.Text = ds.Tables[0].Rows[0]["bugStepsToReproduce"].ToString();
            lbAdditionalInfo.Text = ds.Tables[0].Rows[0]["bugAdditionalINfo"].ToString();

        }
        else
        {
            Response.Redirect("SearchIssues.aspx");
        }
    }
    //protected void fetchTags()
    //{
    //    Issue obj = new Issue();
    //    obj._bugId = issueID;
    //    DataSet ds = obj.fetchTagsOfIssue();
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        string[] seprator = {", "};
    //        string tags = ds.Tables[0].Rows[0]["Tags"].ToString();
    //        string[] tagReplace=tags.Split(seprator,StringSplitOptions.RemoveEmptyEntries);
    //        List<string> tagList = new List<string>(tagReplace);

    //        // Set the list as the datasource for the DataList
    //        dlTags.DataSource = tagList;

    //        // Bind the DataList to the datasource
    //        dlTags.DataBind();
            
    //    }
    //}

    protected void btnAddNote_Click(object sender, EventArgs e)
    {
        addNote();
    }

    protected void addNote()
    {
        Activity obj = new Activity();
        if (cbPrivateNote.Checked == true)
        {
            obj._noteVisibility = "private";
        }
        else
        {
            obj._noteVisibility = "public";
        }
        obj._noteDiscription = txtNote.Text;
        string strPth = "..\\webUsers\\noteImg\\" + fuNoteFile.FileName;

        if (fuNoteFile.HasFile)
        {
            obj._noteImage = strPth;
            string strActPath = Server.MapPath(strPth);
            fuNoteFile.SaveAs(strActPath);
        }
        obj._userName = Session["userName"].ToString();
        obj._bugID = issueID;
        int rowAffected = obj.addNote();
        if (rowAffected > 0)
        {
            int addedInTime = TimeLine.addedNote(Session["userName"].ToString(),issueID);
            Response.Write("<script>alert('Note Added');</script>");
            Response.Write("<script>setTimeout(function() { window.location.href = 'ViewIssue.aspx?mn=" + issueID + "'; }, 100);</script>");
        }
    }

    protected void viewNotes()
    {
        Activity obj = new Activity();
        obj._bugID = issueID;
        obj._userName = Session["userName"].ToString();
        DataSet ds = obj.viewNotes();
        if (ds.Tables[0].Rows.Count > 0)
        {
            dlIssues.DataSource = ds;
            dlIssues.DataBind();
        }
    }

    protected void viewRelations()
    {
        Relationships obj = new Relationships();
        obj._cloneID = issueID;
        DataSet ds = obj.issueRelations();
        if (ds.Tables[0].Rows.Count > 0)
        {
            dlRelationships.DataSource = ds;
            dlRelationships.DataBind();
        }
    }


    protected void btnClone_Click(object sender, EventArgs e)
    {
        cloneIssue();
    }

    protected void cloneIssue()
    {
        Response.Redirect("addIssue.aspx?cl=" + issueID);
    }

    protected void btnMonitor_Click(object sender, EventArgs e)
    {
        Monitor obj = new Monitor();
        obj._bugID = issueID;
        obj._userName = Session["userName"].ToString();
        if (btnMonitor.Text == "Monitor")
        {
            int i = obj.startMonitor();
        }
        else if (btnMonitor.Text == "End Monitoring")
        {
            int i = obj.endMonitor();
        }
        Response.Redirect("ViewIssue.aspx?mn=" + issueID);
    }

    protected void isMonitored()
    {
        Monitor obj = new Monitor();
        obj._userName = Session["userName"].ToString();
        obj._bugID = issueID;
        DataSet ds = obj.checkMonitor();
        if (ds.Tables[0].Rows.Count > 0)
        {
            btnMonitor.Text = "End Monitoring";
        }
        else
        {
            btnMonitor.Text = "Monitor";
        }
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("../webAdmin/EditIssue.aspx?mn=" + issueID);
    }

    protected void btnAcknowledge_Click(object sender, EventArgs e)
    {
        Issue obj = new Issue();
        obj._bugId = issueID;
        obj._bugStatus = "acknowledged";
        int rowAffected = obj.changeStatus();
        if (rowAffected > 0)
        {
            int addedInTime = TimeLine.changeStatus(Session["userName"].ToString(), issueID, "acknowledgedIssue");
            Response.Redirect("ViewIssue.aspx?mn=" + issueID);
        }
    }

    protected void btnResolved_Click(object sender, EventArgs e)
    {
        Issue obj = new Issue();
        obj._bugId = issueID;
        obj._bugStatus = "resolved";
        int rowAffected = obj.changeStatus();
        if (rowAffected > 0)
        {
            int addedInTime = TimeLine.changeStatus(Session["userName"].ToString(), issueID, "resolvedIssue");
            Response.Redirect("ViewIssue.aspx?mn=" + issueID);
        }
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        Issue obj = new Issue();
        obj._bugId = issueID;
        obj._bugStatus = "closed";
        int rowAffected = obj.changeStatus();
        if (rowAffected > 0)
        {
            int addedInTime = TimeLine.changeStatus(Session["userName"].ToString(), issueID, "closedIssue");
            Response.Redirect("ViewIssue.aspx?mn=" + issueID);
        }
    }

    protected void btnReopen_Click(object sender, EventArgs e)
    {
        Issue obj = new Issue();
        obj._bugId = issueID;
        obj._bugStatus = "reopened";
        int rowAffected = obj.changeStatus();
        if (rowAffected > 0)
        {
            int addedInTime = TimeLine.changeStatus(Session["userName"].ToString(), issueID, "reopenedIssue");
            Response.Redirect("ViewIssue.aspx?mn=" + issueID);
        }
    }

    protected void btnSuspend_Click(object sender, EventArgs e)
    {
        Issue obj = new Issue();
        obj._bugId = issueID;
        obj._bugStatus = "suspended";
        int rowAffected = obj.changeStatus();
        if (rowAffected > 0)
        {
            int addedInTime = TimeLine.changeStatus(Session["userName"].ToString(), issueID, "suspendedIssue");
            Response.Redirect("ViewIssue.aspx?mn=" + issueID);
        }
    }

    protected void fetchUsersToAssignBug()
    {
        Issue obj = new Issue();
        obj._bugId = issueID;
        DataSet ds = obj.fetchUserToAssignBug();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddAssignedTo.DataSource = ds;
            ddAssignedTo.DataBind();
        }
    }

    protected void btnAssignTo_Click(object sender, EventArgs e)
    {
        Issue obj = new Issue();
        obj._bugId = issueID;
        obj.BugAssignedTo = ddAssignedTo.SelectedValue.ToString();
        int rowAffected = obj.assignIssue();
        if (rowAffected > 0)
        {
            
            if(ddAssignedTo.SelectedValue.ToString() != "") TimeLine.assignIssue(ddAssignedTo.SelectedValue.ToString(),issueID);
            else TimeLine.unassignIssue(Session["userName"].ToString(), issueID);
            Response.Redirect("ViewIssue.aspx?mn=" + issueID);
        }
    }

    protected string checkProjectRole()
    {
        Issue obj = new Issue();
        obj._username = Session["userName"].ToString();
        obj._bugId = issueID;
        DataSet ds = obj.projectRole();
        string projectRole;
        if (ds.Tables[0].Rows.Count > 0)
        {
            projectRole = ds.Tables[0].Rows[0]["userAccessLevel"].ToString();
        }
        else 
        {
            projectRole = "None";
        }
        return projectRole;

    }
}

