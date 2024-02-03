using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// This class represents the dashboard functionality.
/// </summary>
public class Dashboard
{
    #region Properties

    /// <summary>
    /// Gets or sets the username for the dashboard.
    /// </summary>
    public string _userName { get; set; }
    //public long _projectId { get; set; }
    private string _projectID;

    public string ProjectID
    {
        get { return _projectID; }
        set
        {
            if (value == "0") _projectID = "%";
            else _projectID = value;
        }
    }
    #endregion

    /// <summary>
    /// Retrieves unassigned issues from the database.
    /// </summary>
    /// <returns>A DataSet containing unassigned issues.</returns>
    public DataSet unassignedIssues()
    {
        SqlParameter[] pArr =
        {
             new SqlParameter("@projectID", SqlDbType.VarChar) { Value = _projectID },
             new SqlParameter("@userName", SqlDbType.VarChar) { Value = _userName },
            new SqlParameter("@type", SqlDbType.VarChar) { Value = "unassigned" }
        };
        DataSet ds = SqlHelper.ExecuteDataset(Utility.strconn, CommandType.StoredProcedure, SProcedures.dashboard, pArr);
        return ds;
    }

    /// <summary>
    /// Retrieves issues reported by the current user.
    /// </summary>
    /// <returns>A DataSet containing issues reported by the current user.</returns>
    public DataSet reportedByMe()
    {
        SqlParameter[] pArr =
        {
            new SqlParameter("@projectID", SqlDbType.VarChar) { Value = _projectID },
            new SqlParameter("@userName", SqlDbType.VarChar) { Value = _userName },
            new SqlParameter("@type", SqlDbType.VarChar) { Value = "reported" }
        };
        DataSet ds = SqlHelper.ExecuteDataset(Utility.strconn, CommandType.StoredProcedure, SProcedures.dashboard, pArr);
        return ds;
    }

    /// <summary>
    /// Retrieves resolved issues from the database.
    /// </summary>
    /// <returns>A DataSet containing resolved issues.</returns>
    public DataSet resolvedIssues()
    {
        SqlParameter[] pArr =
        {
            new SqlParameter("@projectID", SqlDbType.VarChar) { Value = _projectID },
            new SqlParameter("@userName", SqlDbType.VarChar) { Value = _userName },
            new SqlParameter("@type", SqlDbType.VarChar) { Value = "resolved" }
        };
        DataSet ds = SqlHelper.ExecuteDataset(Utility.strconn, CommandType.StoredProcedure, SProcedures.dashboard, pArr);
        return ds;
    }

    /// <summary>
    /// Retrieves recently modified issues from the database.
    /// </summary>
    /// <returns>A DataSet containing recently modified issues.</returns>
    public DataSet recentlyModified()
    {
        SqlParameter[] pArr =
        {
            new SqlParameter("@projectID", SqlDbType.VarChar) { Value = _projectID },
            new SqlParameter("@userName", SqlDbType.VarChar) { Value = _userName },
            new SqlParameter("@type", SqlDbType.VarChar) { Value = "recent" }
        };
        DataSet ds = SqlHelper.ExecuteDataset(Utility.strconn, CommandType.StoredProcedure, SProcedures.dashboard, pArr);
        return ds;
    }

    /// <summary>
    /// Retrieves issues monitored by the current user.
    /// </summary>
    /// <returns>A DataSet containing issues monitored by the current user.</returns>
    public DataSet monitoredByMe()
    {
        SqlParameter[] pArr =
        {
            new SqlParameter("@projectID", SqlDbType.VarChar) { Value = _projectID },
            new SqlParameter("@userName", SqlDbType.VarChar) { Value = _userName },
            new SqlParameter("@type", SqlDbType.VarChar) { Value = "monitored" }
        };
        DataSet ds = SqlHelper.ExecuteDataset(Utility.strconn, CommandType.StoredProcedure, SProcedures.dashboard, pArr);
        return ds;
    }

    public DataSet assignedToMe()
    {
        SqlParameter[] pArr =
        {
            new SqlParameter("@projectID", SqlDbType.VarChar) { Value = _projectID },
            new SqlParameter("@userName", SqlDbType.VarChar) { Value = _userName },
            new SqlParameter("@type", SqlDbType.VarChar) { Value = "assignedToMe" }
        };
        DataSet ds = SqlHelper.ExecuteDataset(Utility.strconn, CommandType.StoredProcedure, SProcedures.dashboard, pArr);
        return ds;
    }

    public DataSet timeLine()
    {
        SqlParameter[] pArr =
        {
            new SqlParameter("@projectID", SqlDbType.VarChar) { Value = _projectID },
            new SqlParameter("@userName", SqlDbType.VarChar) { Value = _userName },
            new SqlParameter("@type",SqlDbType.VarChar) {Value = "timeLine"}
        };
        DataSet ds = SqlHelper.ExecuteDataset(Utility.strconn, CommandType.StoredProcedure, SProcedures.dashboard, pArr);
        return ds;
    }
}
