using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class webAdmin_addCategory : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        //fetchCategories();
    }
    protected void btnAddCat_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtCatName.Text.Trim()))
        {
            Response.Write("<script>alert('Please Enter a category' )</script>");
        }
        else
        {
            manageCat mgc = new manageCat();
            mgc._catName = txtCatName.Text.Trim();
            int res = mgc.addCategory();
            if (res > 0)
            {
                Response.Redirect("manage_category.aspx");
                txtCatName.Text = "";
            }
            else
            {
                Response.Write("<script>alert('Category already exist' )</script>");
            }
        }
    }
    /* protected void fetchCategories()
     {
         manageCat mgp = new manageCat();
         DataSet ds = mgp.fetchCategories();
         if (ds.Tables[0].Rows.Count > 0)
         {
             gridShowCategories.DataSource = ds;
             gridShowCategories.DataBind();
         }
     }*/

    protected void gridCatDetails_Row(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "update")
        {
            manageUsersByAdmin mgu = new manageUsersByAdmin();
            string usernameToUpdate = e.CommandArgument.ToString();
            Session["UsernameToUpdate"] = usernameToUpdate;
            Response.Redirect("manage_user_update.aspx");

        }
    }

    protected void gridCatDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // This event handler is left empty as it's not needed for your scenario
    }
}