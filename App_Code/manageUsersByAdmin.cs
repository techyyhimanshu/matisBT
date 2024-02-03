using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
/// <summary>
/// Summary description for manageUsersByAdmin
/// </summary>
public class manageUsersByAdmin
{
    #region properties
    public string _username { get; set; }
    public string _picPath { get; set; }
    public string _usernameForUpdate { get; set; }
    public string _realName { get; set; }
    public string _pass { get; set; }
    public string _email { get; set; }
    public string _userAccesLevel { get; set; }
    public long _projectID { get; set; }
    public string _isEnabled { get; set; }
    public string _isProtected { get; set; }
    #endregion
    string connectionStr = ConfigurationManager.ConnectionStrings["MantisBtConString"].ToString();
    public manageUsersByAdmin()
    {

    }
    #region Fetching All User details
    public DataSet fetchUserDetails()
    {
        SqlParameter[] Param = new SqlParameter[1];
        Param[0] = new SqlParameter("@action", SqlDbType.VarChar);
        Param[0].Value = "fetchAllUserDetails";
        DataSet ds = SqlHelper.ExecuteDataset(Utility.strconn, CommandType.StoredProcedure, clsSP.manageUserByAdmin, Param);
        return ds;
    }
    #endregion

    #region Add new user
    public int addNewUser()
    {
        SqlParameter[] parameters = new SqlParameter[]
        {
            new SqlParameter("@userName", SqlDbType.VarChar) { Value = _username },
            new SqlParameter("@userRealName", SqlDbType.VarChar) { Value = _realName },
            new SqlParameter("@userEmail", SqlDbType.VarChar) { Value = _email },
            new SqlParameter("@userPassword", SqlDbType.VarChar) { Value = "kk" }, // You should use a proper password hashing mechanism here.
            new SqlParameter("@userAccessLevel", SqlDbType.VarChar) { Value = _userAccesLevel },
            new SqlParameter("@isEnabled", SqlDbType.VarChar) { Value = _isEnabled },
            new SqlParameter("@isProtected", SqlDbType.VarChar) { Value = _isProtected },
            new SqlParameter("@action", SqlDbType.VarChar) { Value = "addNewUser" }
        };
        int returnval = SqlHelper.ExecuteNonQuery(Utility.strconn, CommandType.StoredProcedure, clsSP.manageUserByAdmin, parameters);

        return returnval;
    }
    #endregion

    #region Fetch User Details for Update
    public DataSet fetchUserDetailsForUpdate()
    {
        SqlParameter[] parameters = new SqlParameter[]
    {
        new SqlParameter("@userName", SqlDbType.VarChar) { Value = _username },
        new SqlParameter("@userNameForUpdate", SqlDbType.VarChar) { Value = _usernameForUpdate },
        new SqlParameter("@action", SqlDbType.VarChar) { Value = "fetchUserDetailsForUpdate" }
    };

        DataSet ds = SqlHelper.ExecuteDataset(Utility.strconn, CommandType.StoredProcedure, clsSP.manageUserByAdmin, parameters);

        return ds;
    }
    #endregion

    #region Delete User
    public int deleteUser()
    {
        SqlParameter[] parameters = new SqlParameter[]
    {
        new SqlParameter("@userName", SqlDbType.VarChar) { Value = _username },
        new SqlParameter("@action", SqlDbType.VarChar) { Value = "deleteUser" },
    };

        int returnval = SqlHelper.ExecuteNonQuery(Utility.strconn, CommandType.StoredProcedure, clsSP.manageUserByAdmin, parameters);

        return returnval;
    }
    #endregion

    #region Update User
    public int updateUser()
    {
        SqlParameter[] parameters = new SqlParameter[]
    {
        new SqlParameter("@userName", SqlDbType.VarChar) { Value = _username },
         new SqlParameter("@userPicPath", SqlDbType.VarChar) { Value = _picPath },
        new SqlParameter("@userRealName", SqlDbType.VarChar) { Value = _realName },
        new SqlParameter("@userEmail", SqlDbType.VarChar) { Value = _email },
        new SqlParameter("@userAccessLevel", SqlDbType.VarChar) { Value = _userAccesLevel },
        new SqlParameter("@isEnabled", SqlDbType.VarChar) { Value = _isEnabled },
        new SqlParameter("@isProtected", SqlDbType.VarChar) { Value = _isProtected },
        new SqlParameter("@userNameForUpdate", SqlDbType.VarChar) { Value = _usernameForUpdate },
         new SqlParameter("@userPassword", SqlDbType.VarChar) { Value = _pass },
         new SqlParameter("@action", SqlDbType.VarChar) { Value = "updateUser" },
    };

        int returnval = SqlHelper.ExecuteNonQuery(Utility.strconn, CommandType.StoredProcedure, clsSP.manageUserByAdmin, parameters);

        return returnval;
    }
    #endregion

    public DataSet searchUser()
    {
        SqlConnection con = new SqlConnection(connectionStr);
        string sqlQuery = @"select userName,userRealName,userEmail,userAccessLevel,createdDate,CASE WHEN isEnabled='True' THEN '~//Images//check-mark.jpg' ELSE 'False' END AS isEnabled,CASE WHEN isProtected='True' THEN '~//Images//lock.jpg' ELSE '' END AS isProtected from tbl_Users where userName='" + _username + "' and isEnabled='True'";

        SqlDataAdapter adp = new SqlDataAdapter(sqlQuery, con);

        con.Open();

        DataSet ds = new DataSet();

        adp.Fill(ds);

        con.Close();

        return ds;
    }

    public int assignProjectToUser()
    {
        int returnval = 0;
        SqlConnection con = new SqlConnection(connectionStr);
        string sqlQuery = @"insert into tbl_assigned_projects(userName,projectID) values('" + _username + "','" + _projectID + "')";
        SqlCommand sqlCmd = new SqlCommand(sqlQuery, con);
        con.Open();
        returnval = sqlCmd.ExecuteNonQuery();
        return returnval;
    }

    public int unassignProjectFromUser()
    {
        int returnval = 0;
        SqlConnection con = new SqlConnection(connectionStr);
        string sqlQuery = @"delete from tbl_assigned_projects where userName='" + _username + "' and projectID='" + _projectID + "'";
        SqlCommand sqlCmd = new SqlCommand(sqlQuery, con);
        con.Open();
        returnval = sqlCmd.ExecuteNonQuery();
        return returnval;
    }

    #region Fetch Disabled User
    public DataSet searchDisabledUser()
    {
        SqlParameter[] parameters = new SqlParameter[]
    {
        new SqlParameter("@userName", SqlDbType.VarChar) { Value = _username },
        new SqlParameter("@isEnabled", SqlDbType.VarChar) { Value = _isEnabled },
        new SqlParameter("@action", SqlDbType.VarChar) { Value = "fetchDisabledUsers" }
    };
        DataSet ds = SqlHelper.ExecuteDataset(Utility.strconn, CommandType.StoredProcedure, clsSP.manageUserByAdmin, parameters);

        return ds;
    }
    #endregion

    #region User Exists OR Not
    public DataSet isUserExists()
    {
        SqlParameter[] Param = new SqlParameter[2];
        Param[0] = new SqlParameter("@action", SqlDbType.VarChar);
        Param[0].Value = "isUserExists";
        Param[1] = new SqlParameter("@username", SqlDbType.VarChar);
        Param[1].Value = _username;
        DataSet ds = SqlHelper.ExecuteDataset(Utility.strconn, CommandType.StoredProcedure, clsSP.manageUserByAdmin, Param);
        return ds;
    }
    #endregion

    #region User Protected OR Not
    public DataSet isProtectedOrNot()
    {
        SqlParameter[] parameters = new SqlParameter[]
        {
            new SqlParameter("@userName", SqlDbType.VarChar) { Value = _username },
            new SqlParameter("@action", SqlDbType.VarChar) { Value = "isUserProtectedOrNot" }
        };
        DataSet returnval = SqlHelper.ExecuteDataset(Utility.strconn, CommandType.StoredProcedure, clsSP.manageUserByAdmin, parameters);

        return returnval;
    }
    #endregion

    #region Change Password
    public int changePassword()
    {
        SqlParameter[] parameters = new SqlParameter[]
    {
        new SqlParameter("@userName", SqlDbType.VarChar) { Value = _username },
         new SqlParameter("@userPassword", SqlDbType.VarChar) { Value = _pass },
         new SqlParameter("@action", SqlDbType.VarChar) { Value = "changePassword" },
    };

        int returnval = SqlHelper.ExecuteNonQuery(Utility.strconn, CommandType.StoredProcedure, clsSP.manageUserByAdmin, parameters);

        return returnval;
    }
    #endregion
}