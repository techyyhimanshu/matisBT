using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Represents a Monitor class responsible for monitoring bugs for a user.
/// </summary>
public class Monitor
{
    #region PROPERTIES
    public string _userName { get; set; } // User's name
    public long _bugID { get; set; }       // Bug ID
    #endregion

    /// <summary>
    /// Starts monitoring a bug for the user.
    /// </summary>
    /// <returns>The number of affected rows in the database.</returns>
    public int startMonitor()
    {
        SqlParameter[] pArr =
        {
            new SqlParameter("@action", SqlDbType.VarChar) {Value = "start"}, // Set the action to "start"
            new SqlParameter("@userName", SqlDbType.VarChar) {Value = _userName}, // Set the user's name
            new SqlParameter("@bugID", SqlDbType.BigInt) {Value = _bugID} // Set the bug ID
        };
        int i = SqlHelper.ExecuteNonQuery(Utility.strconn, CommandType.StoredProcedure, SProcedures.monitor, pArr);
        return i; // Return the number of affected rows
    }

    /// <summary>
    /// Ends monitoring for a bug for the user.
    /// </summary>
    /// <returns>The number of affected rows in the database.</returns>
    public int endMonitor()
    {
        SqlParameter[] pArr =
        {
            new SqlParameter("@action", SqlDbType.VarChar) {Value = "end"}, // Set the action to "end"
            new SqlParameter("@userName", SqlDbType.VarChar) {Value = _userName}, // Set the user's name
            new SqlParameter("@bugID", SqlDbType.BigInt) {Value = _bugID} // Set the bug ID
        };
        int i = SqlHelper.ExecuteNonQuery(Utility.strconn, CommandType.StoredProcedure, SProcedures.monitor, pArr);
        return i; // Return the number of affected rows
    }

    /// <summary>
    /// Checks the monitoring status of a bug for the user.
    /// </summary>
    /// <returns>A DataSet containing monitoring information for the bug.</returns>
    public DataSet checkMonitor()
    {
        SqlParameter[] pArr =
        {
            new SqlParameter("@action", SqlDbType.VarChar) {Value = "check"}, // Set the action to "check"
            new SqlParameter("@userName", SqlDbType.VarChar) {Value = _userName}, // Set the user's name
            new SqlParameter("@bugID", SqlDbType.BigInt) {Value = _bugID} // Set the bug ID
        };
        DataSet ds = SqlHelper.ExecuteDataset(Utility.strconn, CommandType.StoredProcedure, SProcedures.monitor, pArr);
        return ds; // Return the DataSet containing monitoring information
    }
}
