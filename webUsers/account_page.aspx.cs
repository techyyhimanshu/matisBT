using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;

public partial class webAdmin_account_page : System.Web.UI.Page
{
    void Page_PreInit(Object sender, EventArgs e)
    {
        if (Session["UserAccessLevel"] != null)
        {
            string session = Session["UserAccessLevel"].ToString();
            if (session != "Administrator")
            {
                this.MasterPageFile = "../webUsers/MasterPage.master";
            }
            else
            {
                this.MasterPageFile = "../webAdmin/MasterPage.master";
            }
        }
        else Response.Redirect("project_management.aspx");

    }
    string userPass = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string username = Convert.ToString(Session["UserName"]);
        if (username == "")
        {
            Response.Redirect("SignIn.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                fetchUserDetails();
            }
        }
    }

    protected void fetchUserDetails()
    {
        manageUsersByAdmin mgu = new manageUsersByAdmin();
        mgu._username = Convert.ToString(Session["UserName"].ToString());
        DataSet ds = mgu.fetchUserDetailsForUpdate();
        if (ds.Tables[0].Rows.Count > 0)
        {
            imgUser.ImageUrl = ds.Tables[0].Rows[0]["userPicPath"].ToString();
            lblUsername.Text = ds.Tables[0].Rows[0]["userName"].ToString();
            txtRealNameForUpdate.Text = ds.Tables[0].Rows[0]["userRealName"].ToString();
            txtEmailForUpdate.Text = ds.Tables[0].Rows[0]["userEmail"].ToString();
            lblAccessLevel.Text = ds.Tables[0].Rows[0]["userAccessLevel"].ToString();

        }
    }
    protected void btnUpdateUser_Click(object sender, EventArgs e)
    {
        manageUsersByAdmin mgu = new manageUsersByAdmin();
        mgu._username = Convert.ToString(Session["UserName"]);
        userPass = Convert.ToString(Session["UserPass"]);
        mgu._isEnabled = "True";
        mgu._userAccesLevel = lblAccessLevel.Text.Trim();
        mgu._realName = txtRealNameForUpdate.Text.Trim();
        mgu._email = txtEmailForUpdate.Text.Trim();
        mgu._pass = txtNewPass.Text.Trim();
        if (profileImageUpload.HasFile)
        {
            string virtaulPath = "..\\webUsers\\userImg\\" + profileImageUpload.FileName;
            mgu._picPath = virtaulPath;
            string actPath = Server.MapPath(virtaulPath);
            profileImageUpload.SaveAs(actPath);
        }
        else mgu._picPath = imgUser.ImageUrl.ToString();
        int res = mgu.updateUser();
        if (res > 0)
        {
            Response.Redirect("account_page.aspx");
        }


    }
    protected void btnChangePassVisible_Click(object sender, EventArgs e)
    {
        pnlChangePassword.Visible = true;
        pnlUpdateAccountInfo.Visible = false;

    }
    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        manageUsersByAdmin mgu = new manageUsersByAdmin();
        mgu._username = Convert.ToString(Session["UserName"]);
        
        userPass = Convert.ToString(Session["UserPass"]);
        if (txtCurrentPass.Text.Trim() == userPass)
        {
            if (txtNewPass.Text.Trim() == txtConfirmPass.Text.Trim())
            {
                mgu._pass = txtNewPass.Text.Trim();
                int resp = mgu.changePassword();
                if (resp > 0)
                {
                    Response.Redirect("SignIn.aspx");
                }
            }
            else
            {
                Response.Write("<script>alert('Password not matched')</script>");
                txtNewPass.Text = "";
                txtConfirmPass.Text = "";
                txtCurrentPass.Text = "";
            }
        }
        else
        {
            Response.Write("<script>alert('Current password is wrong')</script>");
            txtNewPass.Text = "";
            txtConfirmPass.Text = "";
            txtCurrentPass.Text = "";

        }
    }

}