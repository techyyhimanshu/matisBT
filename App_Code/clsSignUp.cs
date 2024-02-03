using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// This class represents the functionality for user sign-up.
/// </summary>
public class clsSignUp
{
    #region PROPERTIES

    // Properties to store user information
    public string _userName { get; set; }
    public string _realName { get; set; }
    public string _pass { get; set; }
    public string _mail { get; set; }
    public string _picPath { get; set; }

    #endregion

    #region METHODS

    /// <summary>
    /// Method to register a new user in the system.
    /// </summary>
    /// <returns>The number of rows affected in the database.</returns>
    public int signUp()
    {
        // Create an array of SQL parameters to pass to the stored procedure
        SqlParameter[] pArr =
        {
            new SqlParameter("@userName", SqlDbType.VarChar) { Value = _userName },
            new SqlParameter("@userRealName", SqlDbType.VarChar) { Value = _realName },
            new SqlParameter("@userPassword", SqlDbType.VarChar) { Value = _pass },
            new SqlParameter("@userEmail", SqlDbType.VarChar) { Value = _mail },
            new SqlParameter("@userPicPath", SqlDbType.VarChar) { Value = _picPath }
        };

        // Execute the stored procedure to sign up the user
        int rowAffected = SqlHelper.ExecuteNonQuery(Utility.strconn, CommandType.StoredProcedure, SProcedures.signUp, pArr);

        // Return the number of rows affected
        return rowAffected;
    }

    #endregion
}
