using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Represents a class for managing relationships between objects.
/// </summary>
public class Relationships
{
    #region PROPERTIES

    // Property to store the clone ID.
    public long _cloneID { get; set; }

    // Property to store the relationship description.
    public string _relation { get; set; }

    // Property to store the original object's ID.
    public long _originalID { get; set; }

    // Private field to store the reverse relationship description.
    private string _relationReverse;

    // Property to get or set the reverse relationship description.
    public string reverseRelation
    {
        get
        {
            return _relationReverse;
        }
        set
        {
            // Swap relationship descriptions for bidirectional relationships.
            if (value == "parent of") value = "child of";
            else if (value == "child of") value = "parent of";
            else if (value == "duplicate of") value = "has duplicate";
            else if (value == "has duplicate") value = "duplicate of";
            _relationReverse = value;
        }
    }

    #endregion

    /// <summary>
    /// Adds a relationship between objects to the database.
    /// </summary>
    /// <returns>The number of rows affected.</returns>
    public int addRelation()
    {
        SqlParameter[] pArr =
        {
            new SqlParameter("@cloneID", SqlDbType.BigInt) { Value = _cloneID },
            new SqlParameter("@originalID", SqlDbType.BigInt) { Value = _originalID },
            new SqlParameter("@relation", SqlDbType.VarChar) { Value = _relation },
            new SqlParameter("@reverseRelation", SqlDbType.VarChar) { Value = _relationReverse }
        };
        int i = SqlHelper.ExecuteNonQuery(Utility.strconn, CommandType.StoredProcedure, SProcedures.relationship, pArr);
        return i;
    }

    /// <summary>
    /// Retrieves relationships related to a specific object from the database.
    /// </summary>
    /// <returns>A DataSet containing relationship data.</returns>
    public DataSet issueRelations()
    {
        SqlParameter[] pArr =
        {
            new SqlParameter("@cloneID", SqlDbType.BigInt) { Value = _cloneID },
        };
        DataSet ds = SqlHelper.ExecuteDataset(Utility.strconn, CommandType.StoredProcedure, SProcedures.relationship, pArr);
        return ds;
    }
}
