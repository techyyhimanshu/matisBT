using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TimeLine
/// </summary>
public static class TimeLine
{


    public static int addedIssue(string userName, long bugID)
    {
        SqlParameter[] pArr = 
        {
            new SqlParameter("@userName",SqlDbType.VarChar) {Value = userName},
            new SqlParameter("@action",SqlDbType.VarChar) {Value = "addIssue"},
            new SqlParameter("@object",SqlDbType.VarChar) {Value = bugID}
        };
        int rowAffected = SqlHelper.ExecuteNonQuery(Utility.strconn, CommandType.StoredProcedure, SProcedures.timeLine, pArr);
        return rowAffected;
    }

    public static int updateIssue(string userName, long bugID)
    {
        SqlParameter[] pArr = 
        {
            new SqlParameter("@userName",SqlDbType.VarChar) {Value = userName},
            new SqlParameter("@action",SqlDbType.VarChar) {Value = "updateIssue"},
            new SqlParameter("@object",SqlDbType.VarChar) {Value = bugID}
        };
        int rowAffected = SqlHelper.ExecuteNonQuery(Utility.strconn, CommandType.StoredProcedure, SProcedures.timeLine, pArr);
        return rowAffected;
    }

    public static int cloneIssue(string userName, long bugID)
    {
        SqlParameter[] pArr = 
        { 
            new SqlParameter("@userName",SqlDbType.VarChar) {Value = userName},
            new SqlParameter("@action",SqlDbType.VarChar) {Value = "cloneIssue"},
            new SqlParameter("@object",SqlDbType.VarChar) {Value = bugID}
        };
        int rowAffected = SqlHelper.ExecuteNonQuery(Utility.strconn, CommandType.StoredProcedure, SProcedures.timeLine, pArr);
        return rowAffected;
    }

    public static int addedNote(string userName, long bugID)
    {
        SqlParameter[] pArr = 
        {
            new SqlParameter("@userName",SqlDbType.VarChar) {Value = userName},
            new SqlParameter("@action",SqlDbType.VarChar) {Value = "addNote"},
            new SqlParameter("@object",SqlDbType.VarChar) {Value = bugID}
        };
        int rowAffected = SqlHelper.ExecuteNonQuery(Utility.strconn, CommandType.StoredProcedure, SProcedures.timeLine, pArr);
        return rowAffected;
    }

    public static int changeStatus(string userName, long bugID, string change)
    {
        SqlParameter[] pArr = 
        {
            new SqlParameter("@userName",SqlDbType.VarChar) {Value = userName},
            new SqlParameter("@object",SqlDbType.VarChar) {Value = bugID},
            new SqlParameter("@action",SqlDbType.VarChar) {Value = change}
        };
        int rowAffected = SqlHelper.ExecuteNonQuery(Utility.strconn, CommandType.StoredProcedure, SProcedures.timeLine, pArr);
        return rowAffected;
    }

    public static int assignIssue(string userName, long bugID)
    {
        SqlParameter[] pArr = 
        {
            new SqlParameter("@action",SqlDbType.VarChar) {Value = "assignedTo"},
            new SqlParameter("@userName",SqlDbType.VarChar) {Value = userName},
            new SqlParameter("@object",SqlDbType.VarChar) {Value = bugID}
        };
        int rowAffected = SqlHelper.ExecuteNonQuery(Utility.strconn, CommandType.StoredProcedure, SProcedures.timeLine, pArr);
        return rowAffected;
    }

    public static int unassignIssue(string userName, long bugID)
    {
        SqlParameter[] pArr = 
        {
            new SqlParameter("@action",SqlDbType.VarChar) {Value = "unassigned"},
            new SqlParameter("@userName",SqlDbType.VarChar) {Value = userName},
            new SqlParameter("@object",SqlDbType.VarChar) {Value = bugID}
        };
        int rowAffected = SqlHelper.ExecuteNonQuery(Utility.strconn, CommandType.StoredProcedure, SProcedures.timeLine, pArr);
        return rowAffected;
    }
    
}