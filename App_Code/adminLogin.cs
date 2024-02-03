using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

/// <summary>
/// Summary description for clsLogin
/// </summary>
public class adminLogin
{
    public string _username { get; set; }
    public string _pass { get; set; }
	public adminLogin()
	{

    }

    #region authenticate login
    /// <summary>
    /// authenticate User
    /// </summary>
    /// <returns>string</returns>
    public DataSet authenticateUser()
    {
       
        SqlParameter[] Param = new SqlParameter[2];
        Param[0] = new SqlParameter("@username", SqlDbType.VarChar);
        Param[0].Value = _username;

        Param[1] = new SqlParameter("@password", SqlDbType.VarChar);
        Param[1].Value = _pass;
        DataSet ds =SqlHelper.ExecuteDataset(Utility.strconn, CommandType.StoredProcedure, clsSP.adminLogin, Param);
        return ds;
    
        
    }
    #endregion

    //#region fetch user data 
    //public DataSet fetchUserData()
    //{
    //    SqlParameter[] userParam = new SqlParameter[1];
    //    userParam[0] = new SqlParameter("@username", SqlDbType.VarChar);
    //    userParam[0].Value = _username;

    //    DataSet ds = SqlHelper.ExecuteDataset(Utility.strConn, CommandType.StoredProcedure, clsSP.adminLogin, userParam);
    //    return ds;
    //}
    //#endregion
}