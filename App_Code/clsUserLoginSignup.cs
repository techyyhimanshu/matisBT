using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


/// <summary>
/// Summary description for clsUserLoginSignup
/// </summary>
public class clsUserLoginSignup
{
    public string _username { get; set; }
    public string _pass { get; set; }
    public string _realName { get; set; }
    public string _mail { get; set; }
    public string _picPath { get; set; }
    string connectionStr = ConfigurationManager.ConnectionStrings["MantisBtConString"].ToString();

	public clsUserLoginSignup()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region authenticate login
    public string authenticateUser()
    {
        string returnval = "";
        SqlConnection con = new SqlConnection(connectionStr);
        string sqlQuery = @"select userName from tbl_Users where userName='" + _username + "' and userPassword='" + _pass + "'";
        SqlCommand sqlCmd = new SqlCommand(sqlQuery, con);
        con.Open();
        object obj = sqlCmd.ExecuteScalar();
        returnval = Convert.ToString(obj);
        return returnval;
    }
    #endregion

    public int signUp()
    {
        SqlConnection sqlconn = new SqlConnection(connectionStr);
        string strcmd = @"INSERT INTO [dbo].[tbl_Users] ([userName],[userRealName],[userEmail],[userPassword],[userPicPath]) VALUES('" + _username + "','" + _realName + "','" + _mail + "','" + _pass + "','" + _picPath + "')";
        SqlCommand sqlcmd = new SqlCommand(strcmd, sqlconn);
        sqlconn.Open();
        int i = sqlcmd.ExecuteNonQuery();
        sqlconn.Close();
        return i;
    }
}