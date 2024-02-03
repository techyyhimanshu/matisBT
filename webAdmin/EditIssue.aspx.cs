using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class webAdmin_EditIssue : System.Web.UI.Page
{
    long issueID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.HasKeys())
        {
            issueID = Convert.ToInt64(Request.QueryString["mn"].ToString());

            if (!IsPostBack)
            {
                fetchIssue(); 
                fetchCategory();
                fetchUsersToAssignBug();
              //  fetchTags();
                fetchAllTags();
                fetchTagss();
                if (!dlTags.HasControls()) lbTags.Visible = false;
            }
        }
    }
    protected void fetchTagss()
    {
        Issue obj = new Issue();
        obj._bugId = issueID;
        DataSet ds = obj.fetchTagsOfIssue();
        if (ds.Tables[0].Rows.Count > 0)
        {
            dlTags.DataSource = ds;
            dlTags.DataBind();
        }
    }
    protected void fetchIssue()
    {
        Issue obj = new Issue();
        obj._bugId = issueID;
        DataSet ds = obj.viewIssue();
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblID.Text = ds.Tables[0].Rows[0]["bugID"].ToString();
            lblProject.Text = ds.Tables[0].Rows[0]["projectName"].ToString();
            ddCategory.SelectedValue = ds.Tables[0].Rows[0]["bugCategory"].ToString();
            lblDateSubmit.Text = ds.Tables[0].Rows[0]["bugCreatedDate"].ToString();
            lblLastUpdate.Text = ds.Tables[0].Rows[0]["bugUpdatedDate"].ToString();
            ddReproducibility.SelectedValue = ds.Tables[0].Rows[0]["bugReproducibility"].ToString();
            ddSeverity.SelectedValue = ds.Tables[0].Rows[0]["bugSeverity"].ToString();
            rbViewStatus.SelectedValue = ds.Tables[0].Rows[0]["bugViewStatus"].ToString();
            ddPriority.SelectedValue = ds.Tables[0].Rows[0]["bugPriority"].ToString();
            txtSummary.Text = ds.Tables[0].Rows[0]["bugSummary"].ToString();
            txtDescription.Text = ds.Tables[0].Rows[0]["bugDescription"].ToString();
            txtStepsToReproduce.Text = ds.Tables[0].Rows[0]["bugStepsToReproduce"].ToString();
            txtAdditionalInformation.Text = ds.Tables[0].Rows[0]["bugAdditionalINfo"].ToString();
            ddAssignedTo.SelectedValue = ds.Tables[0].Rows[0]["bugAssignedTo"].ToString();
        }
    }

    protected void fetchCategory()
    {
        Issue obj = new Issue();
        DataSet ds = obj.fetchCategories();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddCategory.DataSource = ds;
            ddCategory.DataBind();
        }
    }
    protected void fetchAllTags()
    {
        Issue issueObj = new Issue();
        DataSet ds = issueObj.fetchTags();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlTags.DataSource = ds;
            ddlTags.DataBind();
        }
    }
    //protected void fetchTags()
    //{
    //    Issue issueObj = new Issue();
    //    issueObj._bugId = issueID;
    //    DataSet ds = issueObj.fetchTagsOfIssue();
    //    if (ds.Tables[0].Rows.Count> 0)
    //    {
    //        if (ds.Tables[0].Rows[0]["Tags"].ToString() != "")
    //        {
    //            txtTags.Text = ds.Tables[0].Rows[0]["Tags"].ToString();

    //        }
    //        else
    //        {
    //            txtTags.Text = "No tags attached";
    //        }
    //    }
       
    //}

    protected void fetchUsersToAssignBug()
    {
        Issue obj = new Issue();
        DataSet ds = obj.fetchUserToAssignBug();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddAssignedTo.DataSource = ds;
            ddAssignedTo.DataBind();
        }
    }


    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Issue obj = new Issue();
        obj._bugId = issueID;
        obj._category = Convert.ToInt64(ddCategory.SelectedValue.ToString());
        obj._bugReproducibility = ddReproducibility.SelectedValue.ToString();
        obj._bugSeverity = ddSeverity.SelectedValue.ToString();
        obj._bugviewStatus = rbViewStatus.SelectedValue.ToString();
        obj._bugPriority = ddPriority.SelectedValue.ToString();
        obj._bugSummary = txtSummary.Text.Trim();
        obj._bugDescription = txtDescription.Text;
        obj._stepsToReproduce = txtStepsToReproduce.Text;
        obj._additionalInfo = txtAdditionalInformation.Text;
        obj.BugAssignedTo = ddAssignedTo.SelectedValue;
        issueTagging(issueID);
        int rowAffected = obj.updateIssue();
        if (rowAffected > 0)
        {
            TimeLine.updateIssue(Session["userName"].ToString(),issueID);
            //Response.Write("<script>alert('Issue Edited');</script>");
            //Response.Write("<script>setTimeout(function() { window.location.href = '..\\webUsers\\dashboard.aspx'; }, 100);</script>");
            Response.Redirect("..\\webUsers\\ViewIssue.aspx?mn=" + issueID);
        }
    }
    protected void btnRemoveTag_Click(object sender, EventArgs e)
    {
        // Get the tag name from the command argument
        string tagName = (sender as Button).CommandArgument.ToString();
        Issue obj = new Issue();
        obj._tagName = tagName;
        int res = obj.deleteTag();
        if (res > 0)
        {
            fetchTagss();
            updatePanel.Update();
            dlTags.DataBind();
            if (!dlTags.HasControls()) lbTags.Visible = false;
            
        }
    }
    protected void issueTagging(long issueID)
    {
        string[] seprator = { ", ","," };
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

    protected void dlTags_ItemCommand(object source, DataListCommandEventArgs e)
    {
        
    }

}