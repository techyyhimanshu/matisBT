using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class webUsers_SearchIssues : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Session.Count > 0)
        {
            string userAccessLvl = Session["UserAccessLevel"].ToString();
            if (userAccessLvl == "Administrator")
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

        if (!IsPostBack)
        {
            dropDownsData();
        }
        else
        {
            if (ViewState["reporters"] != null) ddReporters.SelectedValue = ViewState["reporters"].ToString();
            if (ViewState["assignedTo"] != null) ddAssignedTo.SelectedValue = ViewState["assignedTo"].ToString();
            if (ViewState["monitoredBy"] != null) ddMonitoredBy.SelectedValue = ViewState["monitoredBy"].ToString();
            if (ViewState["noteBy"] != null) ddNoteBy.SelectedValue = ViewState["noteBy"].ToString();
            if (ViewState["category"] != null) ddCategory.SelectedValue = ViewState["category"].ToString();
        }
        filteredIssues();
    }

    protected void btnApplyFilter_Click(object sender, EventArgs e)
    {
        filteredIssues();
    }

    protected void filteredIssues()
    {
        SearchIssues obj = new SearchIssues();
        obj._reporter = ddReporters.SelectedValue;
        obj._matchType = ddMatchType.SelectedValue;
        obj._assignedTo = ddAssignedTo.SelectedValue;
        obj._monitoredBy = ddMonitoredBy.SelectedValue;
        obj._noteBy = ddNoteBy.SelectedValue;
        obj._priority = ddPriority.SelectedValue;
        obj._severity = ddSeverity.SelectedValue;
        obj._category = Convert.ToInt64(ddCategory.SelectedValue);
        obj._status = ddStatus.SelectedValue;
        obj._hideStatus = ddHideStatus.SelectedValue;
        obj.DateSubmit1 = txtSubmitDate1.Text;
        obj.DateSubmit2 = txtSubmitDate2.Text;
        obj.DateUpdate1 = txtLastUpdate1.Text;
        obj.DateUpdate2 = txtLastUpdate2.Text;
        obj._relation = ddRelationships.SelectedValue;
        obj._sortBy = ddSortBy.SelectedValue;
        obj._sortByOrder = ddSortOrder.SelectedValue;
        obj._userName = Session["userName"].ToString();
        obj._viewStatus = ddViewStatus.SelectedValue;

        string strTags = txtTags.Text;
        string[] separator = { ", ", " ,", "," };
        string[] tagsArray = strTags.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        string[] distinctTags = tagsArray.Distinct().ToArray();
        obj._tagsCount = distinctTags.Length;

        // Enclose each tag in single quotes
        string strDistinctTags = "";
        for (int i = 0; i < distinctTags.Length; i++)
        {
            strDistinctTags += "'" + distinctTags[i] + "'";


            // Add a comma if it's not the last element
            if (i < distinctTags.Length - 1)
            {
                strDistinctTags += ",";
            }
        }
        //strDistinctTags += ")";

        obj._tags = strDistinctTags;
        obj._searchBox = txtSearch.Text.Trim();


        if (Session["projectIDForDropDown"] != null) obj.ProjectID = Session["projectIDForDropDown"].ToString();
        else obj.ProjectID = "0";
        DataSet ds = obj.filteredIssues();
        gvIssues.DataSourceID = null;
        gvIssues.DataSource = ds;
        gvIssues.DataBind();
    }

    #region DropDowns
    protected void dropDowns_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ViewState["reporters"] != null) ViewState["reporters"] = ddReporters.SelectedValue;
        if (ViewState["assignedTo"] != null) ViewState["assignedTo"] = ddAssignedTo.SelectedValue;
        if (ViewState["monitoredBy"] != null) ViewState["monitoredBy"] = ddMonitoredBy.SelectedValue;
        if (ViewState["noteBy"] != null) ViewState["noteBy"] = ddNoteBy.SelectedValue;
        if (ViewState["category"] != null) ViewState["category"] = ddCategory.SelectedValue;
    }
    protected void dropDownsData()
    {
        SearchIssues obj = new SearchIssues();
        DataSet ds = obj.fiterDropDowns();

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddReporters.DataSource = ds.Tables[0];
            ddReporters.DataBind();
        }
        ListItem customItem0 = new ListItem("", "");
        ddReporters.Items.Insert(0, customItem0);

        if (ds.Tables[1].Rows.Count > 0)
        {
            ddAssignedTo.DataSource = ds.Tables[1];
            ddAssignedTo.DataBind();
        }
        ListItem customItem1 = new ListItem("", "");
        ddAssignedTo.Items.Insert(0, customItem1);

        if (ds.Tables[2].Rows.Count > 0)
        {
            ddMonitoredBy.DataSource = ds.Tables[2];
            ddMonitoredBy.DataBind();
        }
        ListItem customItem2 = new ListItem("", "");
        ddMonitoredBy.Items.Insert(0, customItem2);

        if (ds.Tables[3].Rows.Count > 0)
        {
            ddNoteBy.DataSource = ds.Tables[3];
            ddNoteBy.DataBind();
        }
        ListItem customItem3 = new ListItem("", "");
        ddNoteBy.Items.Insert(0, customItem3);

        if (ds.Tables[4].Rows.Count > 0)
        {
            ddCategory.DataSource = ds.Tables[4];
            ddCategory.DataBind();
        }
        ListItem customItem4 = new ListItem("", "0");
        ddCategory.Items.Insert(0, customItem4);
        if (ds.Tables[5].Rows.Count > 0)
        {
            ddExistingTags.DataSource = ds.Tables[5];
            ddExistingTags.DataBind();
        }
        ListItem customItem5 = new ListItem("[Existing Tags]", "0");
        ddExistingTags.Items.Insert(0, customItem5);
    }
    #endregion

    protected void dropDownss_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Check if the selected index is not 0 (not [Existing Tags])
        if (ddExistingTags.SelectedIndex != 0)
        {
            // Get the selected item's text
            string selectedTag = ddExistingTags.SelectedItem.Text;

            // Append the selected tag to the existing text in the txtTags TextBox
            if (string.IsNullOrWhiteSpace(txtTags.Text))
            {
                txtTags.Text = selectedTag;
            }
            else
            {
                txtTags.Text += ", " + selectedTag;
            }
        }
    }

    protected string GetLinkColor(string bugPriority)
    {
        return Color.priorityColor(bugPriority);
    }

}