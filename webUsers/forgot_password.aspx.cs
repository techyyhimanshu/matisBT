using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class forgot_password : System.Web.UI.Page
{
    int count=0;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnResetPassword_Click(object sender, EventArgs e)
    {

        string resetEmail = txtEmail.Text.Trim();

        int response = checkEmailExistsOrNot(resetEmail);

        if (response == 1)
        {
            //int resetEmailAttempts = fetchAttempts(resetEmail);
            //if (resetEmailAttempts < 6)
            //{
                forgotPassword fes = new forgotPassword();
                string resetToken = Guid.NewGuid().ToString();
                string resetLink = "http://localhost:50406/MantisBT/webUsers/reset_password?token=" + resetToken;
                SqlConnection cn = new SqlConnection(Utility.strconn);
                // Example in C#
                DateTime tokenExpirationDate = DateTime.Now.AddMinutes(5); // Token expires in 2 minutes
                Session["TokenExpiration"] = tokenExpirationDate;
                string strQuery = "insert into tbl_Reset_Tokens(userEmail,resetToken,tokenExpirationDate) output inserted.userEmail values('" + txtEmail.Text.Trim() + "','" + resetToken + "','" + tokenExpirationDate + "')";
                cn.Open();
                SqlDataAdapter adp = new SqlDataAdapter(strQuery, cn);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                string sqlQuery3 = "if (select userEmail from ResetAttempts where userEmail='" + txtEmail.Text.Trim() + "') = '" + txtEmail.Text.Trim() + "'" +
                                    @"begin
                                       update ResetAttempts set attempts=((select attempts from ResetAttempts where userEmail='"+txtEmail.Text.Trim()+"')+1) where userEmail='" + txtEmail.Text.Trim() + "'" +
                                    @"end " +
                                    @"else
                                     begin
                                        insert into ResetAttempts(userEmail,attempts) values('" + txtEmail.Text.Trim() + "','" + count + 1 + "')"+
                                     @"end ";
                SqlCommand cmd = new SqlCommand(sqlQuery3,cn);
                int res=cmd.ExecuteNonQuery();
                //if (count== 0)
                //{
                //    string strQuery2 = "insert into ResetAttempts(userEmail,attempts) values('" + txtEmail.Text.Trim() + "','" + count + 1 + "')";
                //    SqlCommand cmd = new SqlCommand(strQuery2, cn);
                //    cmd.ExecuteNonQuery();
                //    count = count+1;
                //}
                //else
                //{
                //    updateResetAttempts(txtEmail.Text.Trim(), count);
                //}
                if (ds.Tables[0].Rows.Count > 0)
                {
                    int resp = fes.SendEmail(txtEmail.Text.Trim(), "reset password confirmation email ", resetLink);
                    if (resp > 0)
                    {
                    Response.Write("<script>alert('Email Send Sucessfully')</script>");
                    }

                }
            //}
            //else
            //{
            //    Response.Write("<script>alert('Too many attempts ')</script>");
            //}
        }
        else
        {
            Response.Write("<script>alert('User with this email does not exist')</script>");
            Response.Write("<script>setTimeout(function() { window.location.href = 'forgot_password.aspx'; }, 5);</script>");
        }
    }

    protected int checkEmailExistsOrNot(string resetEmail)
    {
        int res = 0;
        forgotPassword fp = new forgotPassword();
        fp._email = resetEmail;
        DataSet ds = fp.checkUserExistsOrNot();
        if (ds.Tables[0].Rows.Count > 0)
        {
            res = 1;
        }
        else
        {
            res = 0;
        }
        return res;
    }

    protected void updateResetAttempts(string resetEmail, int resetEmailCount)
    {
        forgotPassword fp = new forgotPassword();
        fp._email = resetEmail;
        int res = fp.updateResetAttempts(resetEmailCount + 1);
    }

    protected int fetchAttempts(string email)
    {
        forgotPassword fp = new forgotPassword();
        fp._email = email;
        DataSet ds = fp.fetchAttempts();
        int totalAttempts = Convert.ToInt32(ds.Tables[0].Rows[0]["attempts"]);
        return totalAttempts;
    }
}