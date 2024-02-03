using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

public partial class webAdmin_manage_tags_edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string st = Convert.ToString(Session["UserName"]);
        if (st == "")
        {
            Response.Redirect("Default.aspx");
        }
        if (!IsPostBack)
        {
            fetchTagDetails();
        }
    }

    public long refineQueryString()
    {
        string tagIdFromQueryString = Request.QueryString["tag_id"];

        // Remove special symbols and non-numeric characters from tag_id
        string cleanedTagId = Regex.Replace(tagIdFromQueryString, "[^0-9]", "");
        long refinedTagID;
        long.TryParse(cleanedTagId, out refinedTagID);
        return refinedTagID;
    }
    protected void fetchTagDetails()
    {
            long tagId = refineQueryString();
            manageTags mgt = new manageTags();
            mgt._tagID = tagId;
            DataSet ds;
            mgt.fetchTagDetailsForUpdate(out ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtTagNameForUpdate.Text = ds.Tables[0].Rows[0]["tagName"].ToString();
                lblCreatedDate.Text = ds.Tables[0].Rows[0]["tagCreatedDate"].ToString();
                lblLastUpdated.Text = ds.Tables[0].Rows[0]["tagLastUpdated"].ToString();
            }
            else
            {
                Response.Redirect("manage_tags.aspx");
            }
        
       
    }

    protected void btnUpdateTag_Click(object sender, EventArgs e)
    {
            long tagIdForUpdate = refineQueryString();
            manageTags mgt = new manageTags();
            mgt._tagID = tagIdForUpdate;
            mgt._tagName = txtTagNameForUpdate.Text.Trim();

            int res = mgt.updateTagDetails();
            if (res != null)
            {
                Response.Redirect("manage_tags.aspx");
            }

       

    }
    protected void btnDeleteTag_Click(object sender, EventArgs e)
    {
        long tagIdForDeletion = refineQueryString();
            manageTags mgt = new manageTags();
            mgt._tagID = tagIdForDeletion;
            int res = mgt.deleteTag();
            if (res != null)
            {
                Response.Redirect("manage_tags.aspx");
            }

    }
}