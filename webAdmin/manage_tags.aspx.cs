using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Data;
public partial class webAdmin_manage_tags : System.Web.UI.Page
{
    void Page_PreInit(Object sender, EventArgs e)
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
    protected void Page_Load(object sender, EventArgs e)
    {
        fetchAllTags();
    }
    #region Button event to create a new tag
    protected void btnCreateTag_Click(object sender, EventArgs e)
    {
        manageTags mgt = new manageTags();
        mgt._tagName = txtTagName.Text.Trim();
       
        if (Session["UserName"] != null)
        {
            mgt._creatorName = Session["UserName"].ToString();
        }
        int res = mgt.creatNewTag();
        if (res != null)
        {
            Response.Redirect("manage_tags.aspx");
        }
    }
    #endregion.

    #region To show all tags on gridview
    protected void fetchAllTags()
    {
        manageTags mgt = new manageTags();
        DataSet ds = mgt.fetchAlltags();
        if (ds.Tables[0].Rows.Count > 0)
        {
            gridShowAllTags.DataSource = ds;
            gridShowAllTags.DataBind();
        }
    }
    #endregion
}