using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ProjectMembers
/// </summary>
public class ProjectMembers
{
    #region
    public long _projectID { get; set; }
    public string _userName { get; set; }
    public string _userAccessLevel { get; set; }
    #endregion

    public int addUserToProject()
    {
        SqlParameter[] pArr =
        {
            new SqlParameter("@projectID",SqlDbType.BigInt) {Value = _projectID},
            new SqlParameter("@userName",SqlDbType.VarChar) {Value = _userName},
            new SqlParameter("@userAccessLevel",SqlDbType.VarChar) {Value = _userAccessLevel},
            new SqlParameter("@action",SqlDbType.VarChar) {Value = "add"}
        };

        int rowAffected = SqlHelper.ExecuteNonQuery(Utility.strconn, CommandType.StoredProcedure, SProcedures.team, pArr);
        return rowAffected;


    }

    public DataSet usersToAdd()
    {
        SqlParameter[] pArr = 
        {
            new SqlParameter("@projectID",SqlDbType.BigInt) {Value = _projectID},
            new SqlParameter("@action",SqlDbType.VarChar) {Value = "usersToAdd"}
        };
        DataSet ds = SqlHelper.ExecuteDataset(Utility.strconn, CommandType.StoredProcedure, SProcedures.team, pArr);
        return ds;
    }

    public DataSet showMembers()
    {
        SqlParameter[] pArr = 
        {
            new SqlParameter("@projectID",SqlDbType.BigInt) {Value = _projectID},
            new SqlParameter("@action",SqlDbType.VarChar) {Value = "showMembers"}
        };
        DataSet ds = SqlHelper.ExecuteDataset(Utility.strconn, CommandType.StoredProcedure, SProcedures.team, pArr);
        return ds;
    }

    public int updateMember()
    {
        SqlParameter[] pArr = 
        {
            new SqlParameter("@projectID",SqlDbType.BigInt) {Value = _projectID},
            new SqlParameter("@action",SqlDbType.VarChar) {Value = "updateMember"},
            new SqlParameter("@userName",SqlDbType.VarChar) {Value = _userName},
            new SqlParameter("@userAccessLevel",SqlDbType.VarChar) {Value = _userAccessLevel}
        };
        int rowAffected = SqlHelper.ExecuteNonQuery(Utility.strconn, CommandType.StoredProcedure, SProcedures.team, pArr);
        return rowAffected;
    }

    public int removeMember()
    {
        SqlParameter[] pArr = 
        {
            new SqlParameter("@projectID",SqlDbType.BigInt) {Value = _projectID},
            new SqlParameter("@action",SqlDbType.VarChar) {Value = "removeMember"},
            new SqlParameter("@userName",SqlDbType.VarChar) {Value = _userName}
        };
        int rowAffected = SqlHelper.ExecuteNonQuery(Utility.strconn, CommandType.StoredProcedure, SProcedures.team, pArr);
        return rowAffected;
    }



}