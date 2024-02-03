using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Threading;

public partial class webUsers_addIssue : System.Web.UI.Page
{
    long originalID;
    long cloneID;
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
            lblRelatedTo.Text = Request.QueryString["cl"].ToString();
            originalID = Convert.ToInt64(Request.QueryString["cl"].ToString());
            pnlClone.Visible = true;
            if (!IsPostBack) parentIssue();
        }
        if (!IsPostBack)
        {
            fetchCategory();
            projectDrop();
            fetchTags();
        }
    }
    protected void ddlTags_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Your event handling code here
    }


    protected void fetchCategory()
    {
        Issue issueObj = new Issue();
        DataSet ds = issueObj.fetchCategories();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddCategory.DataSource = ds;
            ddCategory.DataBind();
        }
    }

    protected void fetchTags()
    {
        Issue issueObj = new Issue();
        DataSet ds = issueObj.fetchTags();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlTags.DataSource = ds;
            ddlTags.DataBind();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Request.QueryString.HasKeys())
        {
            cloneIssue();
        }
        else
        {
            addIssue();
        }
    }

    protected void addIssue()
    {
        Issue obj = new Issue();
        obj._category = Convert.ToInt64(ddCategory.SelectedValue.ToString());
        obj._bugSeverity = ddSeverity.SelectedValue.ToString();
        obj._bugPriority = ddPriority.SelectedValue.ToString();
        obj._projectID = Convert.ToInt64(ddProject.SelectedValue.ToString());
        string strPth = "..\\webUsers\\userImg\\" + fuAttachment.FileName;
        if (fuAttachment.HasFile)
        {
            obj._image = strPth;
            string strActPath = Server.MapPath(strPth);
            fuAttachment.SaveAs(strActPath);
        }
        obj._bugSummary = txtSummary.Text;
        obj._bugDescription = txtDescription.Text;
        obj._stepsToReproduce = txtStepsToReproduce.Text;
        obj._bugReproducibility = ddReproducibility.SelectedValue.ToString();
        obj._bugreporter = Session["UserName"].ToString();
        obj._additionalInfo = txtAdditionalInformation.Text;
        obj._bugTags = txtTags.Text;
        //obj._productVersion = txtVersion.Text.Trim();
        obj._bugviewStatus = rbViewStatus.SelectedValue.ToString();
        string returnID = obj.addIssue();
        if (returnID != "")
        {
            long createdBugID = Convert.ToInt64(returnID);
            int addedInTime = TimeLine.addedIssue(Session["UserName"].ToString(), createdBugID);
            issueTagging(returnID);
            if (cbReportStay.Checked == true)
            {
                counters._countForNewIssue = 0;
                Response.Write("<script>setTimeout(function() { window.location.href = 'addIssue.aspx'; }, 100);</script>");
            }
            else
            {
                counters._countForNewIssue = 1;
                Response.Write("<script>setTimeout(function() { window.location.href = 'dashboard.aspx'; }, 100);</script>");
            }

            
        }
    }

    protected void projectDrop()
    {
        Issue obj = new Issue();
        obj._username = Session["UserName"].ToString();
        DataSet ds = obj.projectsDrop();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddProject.DataSource = ds;
            ddProject.DataBind();
        }
    }

    protected void cloneIssue()
    {
        Issue obj = new Issue();
        obj._category = Convert.ToInt64(ddCategory.SelectedValue.ToString());
        obj._bugSeverity = ddSeverity.SelectedValue.ToString();
        obj._bugPriority = ddPriority.SelectedValue.ToString();
        obj._projectID = Convert.ToInt64(ddProject.SelectedValue.ToString());
        if (cbCopyAttachments.Checked == true)
        {
            obj._image = issueImage.ImageUrl;
        }
        else
        {
            string strPth = "..\\webUsers\\userImg\\" + fuAttachment.FileName;
            if (fuAttachment.HasFile)
            {
                obj._image = strPth;
                string strActPath = Server.MapPath(strPth);
                fuAttachment.SaveAs(strActPath);
            }
        }
        obj._bugSummary = txtSummary.Text;
        obj._bugDescription = txtDescription.Text;
        obj._stepsToReproduce = txtStepsToReproduce.Text;
        obj._bugReproducibility = ddReproducibility.SelectedValue.ToString();
        obj._bugreporter = Session["UserName"].ToString();
        //obj._productVersion = txtVersion.Text.Trim();
        obj._additionalInfo = txtAdditionalInformation.Text;
        obj._bugviewStatus = rbViewStatus.SelectedValue.ToString();
        string returnID = obj.cloneIssue();
        if (returnID != "")
        {
            cloneID = Convert.ToInt64(returnID);
            int addedInTime = TimeLine.cloneIssue(Session["UserName"].ToString(),cloneID);
            if(ddRelationship.SelectedValue != "none") addRelation();
            if (cbCopyNotes.Checked == true) copyNotes();
            Response.Write("<script>alert('Issue Added');</script>");
            if (cbReportStay.Checked == true)
            {
                Response.Write("<script>setTimeout(function() { window.location.href = 'addIssue.aspx'; }, 100);</script>");
            }
            else
            {
                Response.Write("<script>setTimeout(function() { window.location.href = 'dashboard.aspx'; }, 100);</script>");
            }
        }
    }

    protected void parentIssue()
    {
        Issue obj = new Issue();
        obj._bugId = originalID;
        DataSet ds = obj.parentIssue();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddCategory.SelectedValue = ds.Tables[0].Rows[0]["bugCategory"].ToString();
            ddReproducibility.SelectedValue = ds.Tables[0].Rows[0]["bugReproducibility"].ToString();
            ddSeverity.SelectedValue = ds.Tables[0].Rows[0]["bugSeverity"].ToString();
            ddPriority.SelectedValue = ds.Tables[0].Rows[0]["bugPriority"].ToString();
            ddProject.SelectedValue = ds.Tables[0].Rows[0]["projectID"].ToString();
            txtSummary.Text = ds.Tables[0].Rows[0]["bugSummary"].ToString();
            txtDescription.Text = ds.Tables[0].Rows[0]["bugDescription"].ToString();
            txtStepsToReproduce.Text = ds.Tables[0].Rows[0]["bugStepsToReproduce"].ToString();
            txtAdditionalInformation.Text = ds.Tables[0].Rows[0]["bugAdditionalInfo"].ToString();
            rbViewStatus.SelectedValue = ds.Tables[0].Rows[0]["bugViewStatus"].ToString();
            issueImage.ImageUrl = ds.Tables[0].Rows[0]["bugImage"].ToString();
        }
    }

    protected void addRelation()
    {
        Relationships obj = new Relationships();
        obj._cloneID = cloneID;
        obj._originalID = originalID;
        obj._relation = ddRelationship.SelectedValue.ToString();
        obj.reverseRelation = ddRelationship.SelectedValue.ToString();
        int i = obj.addRelation();
    }

    protected void copyNotes()
    {
        Activity obj = new Activity();
        obj._bugID = originalID;
        obj._cloneID = cloneID;
        int i = obj.copyNotes();
    }
    protected void issueTagging(string issueID)
    {
        string[] seprator = { ", ",","};
        string tags = txtTags.Text;
        string[] tagReplace = tags.Split(seprator, StringSplitOptions.RemoveEmptyEntries);
        List<string> tagList = new List<string>(tagReplace);
        foreach (string tag in tagList)
        {
            Issue obj = new Issue();
            obj._tag = tag;
            obj._bugId = Convert.ToInt64(issueID);
            obj.tagIssue();
        }
    }
}