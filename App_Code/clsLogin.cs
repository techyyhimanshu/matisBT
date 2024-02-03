using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// This class handles user authentication and fetching user data.
/// </summary>
public class clsLogin
{
    public string _username { get; set; }
    public string _pass { get; set; }

    #region AUTHENTICATE LOGIN
    /// <summary>
    /// Authenticates a user based on the provided username and password.
    /// </summary>
    /// <returns>The authentication result as a string.</returns>
    public DataSet authenticateUser()
    {
        // Create a new SQL connection using the connection string from the Utility class.
        SqlConnection con = new SqlConnection(Utility.strconn);

        // Create an array of SqlParameter objects to hold the stored procedure parameters.
        SqlParameter[] pArr = new SqlParameter[2];

        // Set the parameter values for the stored procedure.
        // Parameter 0: @userName (VarChar)
        pArr[0] = new SqlParameter("@userName", SqlDbType.VarChar);
        pArr[0].Value = _username;

        // Parameter 1: @password (VarChar)
        pArr[1] = new SqlParameter("@password", SqlDbType.VarChar);
        pArr[1].Value = _pass;

        // Execute the stored procedure and retrieve the result as an object.
       DataSet ds= SqlHelper.ExecuteDataset(Utility.strconn, CommandType.StoredProcedure, SProcedures.signIn, pArr);

        // Convert the result to a string for return.
       return ds;
    }
    #endregion

    #region FETCH USER DATA ON LOGIN
    /// <summary>
    /// Fetches user data for the authenticated user.
    /// </summary>
    /// <returns>A DataSet containing user data.</returns>
    public DataSet fetchUserData()
    {
        // Create a new SQL connection using the connection string from the Utility class.
        SqlConnection con = new SqlConnection(Utility.strconn);

        // Create an array of SqlParameter objects to hold the stored procedure parameters.
        SqlParameter[] pArr = new SqlParameter[1];

        // Set the parameter value for the stored procedure.
        // Parameter 0: @userName (VarChar)
        pArr[0] = new SqlParameter("@userName", SqlDbType.VarChar);
        pArr[0].Value = _username;

        // Execute the stored procedure and retrieve the result as a DataSet.
        DataSet ds = SqlHelper.ExecuteDataset(Utility.strconn, CommandType.StoredProcedure, SProcedures.signIn, pArr);

        // Return the DataSet containing user data.
        return ds;
    }
    #endregion
}
