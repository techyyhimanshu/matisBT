using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// This class handles the notes for the issues.
/// </summary>
public class Activity
{
    #region PROPERTIES
    public long _noteID { get; set; }
    public string _noteVisibility { get; set; }
    public string _noteDiscription { get; set; }
    public string _noteImage { get; set; }
    public string _noteCreateDate { get; set; }
    public string _noteUpdateDate { get; set; }
    public string _userName { get; set; }
    public long _bugID { get; set; }
    public long _linkTo { get; set; }
    public long _cloneID { get; set; }
    #endregion

    #region ADD NOTE
    /// <summary>
    /// Add a new note for the issue.
    /// </summary>
    /// <returns>The number of rows affected.</returns>
    public int addNote()
    {
        // Create a new SQL connection using the connection string from the Utility class.
        SqlConnection sqlconn = new SqlConnection(Utility.strconn);

        // Create an array of SqlParameter objects to hold the stored procedure parameters.
        SqlParameter[] pArr = new SqlParameter[5];

        // Set the parameter values for the stored procedure.
        // Parameter 0: @noteVisibility (VarChar)
        pArr[0] = new SqlParameter("@noteVisibility", SqlDbType.VarChar);
        pArr[0].Value = _noteVisibility;

        // Parameter 1: @noteDiscription (VarChar)
        pArr[1] = new SqlParameter("@noteDiscription", SqlDbType.VarChar);
        pArr[1].Value = _noteDiscription;

        // Parameter 2: @noteImage (VarChar)
        pArr[2] = new SqlParameter("@noteImage", SqlDbType.VarChar);
        pArr[2].Value = _noteImage;

        // Parameter 3: @userName (VarChar)
        pArr[3] = new SqlParameter("@userName", SqlDbType.VarChar);
        pArr[3].Value = _userName;

        // Parameter 4: @bugId (BigInt)
        pArr[4] = new SqlParameter("@bugId", SqlDbType.BigInt);
        pArr[4].Value = _bugID;

        // Execute the stored procedure and store the number of rows affected in rowAffected.
        int rowAffected = SqlHelper.ExecuteNonQuery(Utility.strconn, CommandType.StoredProcedure, SProcedures.manageNotes, pArr);

        // Return the number of rows affected by the add note operation.
        return rowAffected;
    }
    #endregion

    #region VIEW NOTES
    /// <summary>
    /// Fetches all the notes for a single issue.
    /// </summary>
    /// <returns>A dataset containing the issue notes.</returns>
    public DataSet viewNotes()
    {
        // Create a new SQL connection using the connection string from the Utility class.
        SqlConnection sqlconn = new SqlConnection(Utility.strconn);

        // Create an array of SqlParameter objects to hold the stored procedure parameters.
        SqlParameter[] pArr = new SqlParameter[]{

        // Set the parameter value for the stored procedure.
        // Parameter 0: @bugId (BigInt)
        new SqlParameter("@bugId", SqlDbType.BigInt) {Value = _bugID},
        new SqlParameter("@userName",SqlDbType.VarChar) {Value = _userName},
        new SqlParameter("@View", SqlDbType.VarChar) {Value = "true"}
        };
        // Execute the stored procedure and retrieve the result as a DataSet.
        DataSet ds = SqlHelper.ExecuteDataset(Utility.strconn, CommandType.StoredProcedure, SProcedures.manageNotes, pArr);

        // Return the DataSet containing the issue notes.
        return ds;
    }
    #endregion

    #region COPY NOTES
    /// <summary>
    /// Copy the notes of the original issue to the clone issue.
    /// </summary>
    /// <returns>The number of rows affected by the copy operation.</returns>
    public int copyNotes()
    {
        // Create a new SQL connection using the connection string from the Utility class.
        SqlConnection sqlconn = new SqlConnection(Utility.strconn);

        // Create an array of SqlParameter objects to hold the stored procedure parameters.
        SqlParameter[] pArr = new SqlParameter[6];

        // Set the parameter values for the stored procedure.
        // Parameter 0: @noteVisibility (VarChar)
        pArr[0] = new SqlParameter("@noteVisibility", SqlDbType.VarChar);
        pArr[0].Value = _noteVisibility;

        // Parameter 1: @noteDiscription (VarChar)
        pArr[1] = new SqlParameter("@noteDiscription", SqlDbType.VarChar);
        pArr[1].Value = _noteDiscription;

        // Parameter 2: @noteImage (VarChar)
        pArr[2] = new SqlParameter("@noteImage", SqlDbType.VarChar);
        pArr[2].Value = _noteImage;

        // Parameter 3: @userName (VarChar)
        pArr[3] = new SqlParameter("@userName", SqlDbType.VarChar);
        pArr[3].Value = _userName;

        // Parameter 4: @bugId (BigInt)
        pArr[4] = new SqlParameter("@bugId", SqlDbType.BigInt);
        pArr[4].Value = _bugID;

        // Parameter 5: @cloneID (BigInt)
        pArr[5] = new SqlParameter("@cloneID", SqlDbType.BigInt);
        pArr[5].Value = _cloneID;

        // Execute the stored procedure and store the number of rows affected in rowAffected.
        int rowAffected = SqlHelper.ExecuteNonQuery(Utility.strconn, CommandType.StoredProcedure, SProcedures.manageNotes, pArr);

        // Return the number of rows affected by the copy operation.
        return rowAffected;
    }
    #endregion
}
