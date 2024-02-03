using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class webUsers_SignUp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        clsSignUp userObj = new clsSignUp();
        userObj._userName = txtUserName.Text.Trim();
        userObj._realName = txtRealName.Text.Trim();
        userObj._mail = txtMail.Text.Trim();
        userObj._pass = txtPass.Text.Trim();
        string strPth = "..\\webUsers\\userImg\\" + fuProfilePic.FileName;
        if (fuProfilePic.HasFile)
        {
            userObj._picPath = strPth;
            string strActPath = Server.MapPath(strPth);
            fuProfilePic.SaveAs(strActPath);
        }
        int rowAffected = userObj.signUp();
        if (rowAffected > 0)
        {
            Response.Write("<script>alert('Data Inserted')</script>");
            Response.Redirect("SignIn.aspx");
        }

        
        
    }
}