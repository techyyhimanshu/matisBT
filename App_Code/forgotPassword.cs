using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
/// <summary>
/// Summary description for forgotEmailSend
/// </summary>
public class forgotPassword
{
    public string _email { get; set; }
    public string _resetToken { get; set; }
    public string _password { get; set; }

    public forgotPassword()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int SendEmail(string to, string subject, string body)
    {
        int a = 0;
        try
        {
            string from = "fmail9899@gmail.com"; // Update with your from address

            using (MailMessage message = new MailMessage(from, to))
            {
                message.Subject = subject;
                message.Body = body;
                message.BodyEncoding = Encoding.UTF8;
                message.IsBodyHtml = true;

                using (SmtpClient client = new SmtpClient("smtp.gmail.com", 25))
                {
                    client.EnableSsl = true;

                    // Replace "yourmail@gmail.com" and "YourPassword" with your actual Gmail credentials
                    client.Credentials = new NetworkCredential("fmail9899@gmail.com", "cxubhkkfkjeryeyw");

                    client.Send(message);
                }

                Console.WriteLine("Email sent successfully!");
                a = 1;

            }

        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: {ex.Message}");

        }
        return a;
    }

    public DataSet fetchTokenExpirationTime()
    {
        SqlParameter[] Param = new SqlParameter[]
{
    new SqlParameter("@resetToken", SqlDbType.VarChar) { Value = _resetToken },
    new SqlParameter("@action", SqlDbType.VarChar) { Value = "fetchTokenExpireTime" }
};
        DataSet ds = SqlHelper.ExecuteDataset(Utility.strconn, CommandType.StoredProcedure, SProcedures.forgotPass, Param);
        return ds;
    }

    public int resetPassword()
    {
        SqlParameter[] Param = new SqlParameter[]
{
    new SqlParameter("@newPassword", SqlDbType.VarChar) { Value = _password },
     new SqlParameter("@resetToken", SqlDbType.VarChar) { Value = _resetToken },
    new SqlParameter("@action", SqlDbType.VarChar) { Value = "setNewPassword" }
};
        int res = SqlHelper.ExecuteNonQuery(Utility.strconn, CommandType.StoredProcedure, SProcedures.forgotPass, Param);
        return res;
    }

    public DataSet checkUserExistsOrNot()
    {
        SqlParameter[] Param = new SqlParameter[]
{
    new SqlParameter("@email", SqlDbType.VarChar) { Value = _email },
    new SqlParameter("@action", SqlDbType.VarChar) { Value = "userExistsOrNot" }
};
        DataSet ds = SqlHelper.ExecuteDataset(Utility.strconn, CommandType.StoredProcedure, SProcedures.forgotPass, Param);
        return ds;
    }

    public int updateResetAttempts(int count)
    {
        SqlParameter[] Param = new SqlParameter[]
{
    new SqlParameter("@email", SqlDbType.VarChar) { Value = _email },
     new SqlParameter("@attemptcount", SqlDbType.VarChar) { Value = count },
    new SqlParameter("@action", SqlDbType.VarChar) { Value = "updateResetAttemptCount" }
};
        int res = SqlHelper.ExecuteNonQuery(Utility.strconn, CommandType.StoredProcedure, SProcedures.forgotPass, Param);
        return res;
    }

    public DataSet fetchAttempts()
    {
        SqlParameter[] Param = new SqlParameter[]
{
    new SqlParameter("@email", SqlDbType.VarChar) { Value = _email },
    new SqlParameter("@action", SqlDbType.VarChar) { Value = "fetchAttempts" }
};
        DataSet ds = SqlHelper.ExecuteDataset(Utility.strconn, CommandType.StoredProcedure, SProcedures.forgotPass, Param);
        return ds;
    }

}