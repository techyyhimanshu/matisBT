using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for Issue
/// </summary>
public class Issue
{
    #region PROPERTIES
    // Properties to store information about a bug/issue
    public string _tagName { get; set; }
    public long _bugId { get; set; }
    public string _bugStatus { get; set; }
    public string _bugSeverity { get; set; }
    public string _bugPriority { get; set; }
    public string _image { get; set; }
    public long _projectID { get; set; }
    public string _bugSummary { get; set; }
    public string _bugTags { get; set; }
    public string _bugDescription { get; set; }
    public string _stepsToReproduce { get; set; }
    public string _bugReproducibility { get; set; }
    public string _bugreporter { get; set; }
    public string _bugviewStatus { get; set; }
    public string _username { get; set; }
    public long _category { get; set; }
    public string _additionalInfo { get; set; }
    private string _bugAssignedTo;
    public string BugAssignedTo
    {
        get { return _bugAssignedTo; }
        set
        {
            if (value == "") _bugAssignedTo = null;
            else _bugAssignedTo = value;
        }
    }
    public string _tag { get; set; }



    #endregion

    // Constructor for the Issue class

    // Method to fetch categories of issues
    public DataSet fetchCategories()
    {
        // Prepare the parameter array
        SqlParameter[] pArr = 
        {
            new SqlParameter("@Action", SqlDbType.VarChar){Value = "catDrop"}
        };

        // Execute a stored procedure to retrieve categories
        DataSet ds = SqlHelper.ExecuteDataset(Utility.strconn, CommandType.StoredProcedure, SProcedures.issues, pArr);

        // Return the dataset containing categories
        return ds;
    }

    public DataSet fetchTags()
    {
        // Prepare the parameter array
        SqlParameter[] pArr = 
        {
            new SqlParameter("@Action", SqlDbType.VarChar){Value = "tagDrop"}
        };

        // Execute a stored procedure to retrieve categories
        DataSet ds = SqlHelper.ExecuteDataset(Utility.strconn, CommandType.StoredProcedure, SProcedures.issues, pArr);

        // Return the dataset containing categories
        return ds;
    }
    public DataSet fetchTagsOfIssue()
    {
        // Prepare the parameter array
        SqlParameter[] pArr = 
        {
            new SqlParameter("@Action", SqlDbType.VarChar){Value = "tagsForIssue"},
             new SqlParameter("@BugId", SqlDbType.VarChar){Value = _bugId}
        };

        // Execute a stored procedure to retrieve categories
        DataSet ds = SqlHelper.ExecuteDataset(Utility.strconn, CommandType.StoredProcedure, SProcedures.issues, pArr);

        // Return the dataset containing categories
        return ds;
    }

    // Method to add a new issue
    public string addIssue()
    {
        // Prepare the parameter array with issue details
        SqlParameter[] pArr = 
        {
            new SqlParameter("@Action", SqlDbType.VarChar){Value = "add"},
            new SqlParameter("@BugSeverity", SqlDbType.VarChar){Value = _bugSeverity},
            new SqlParameter("@BugPriority", SqlDbType.VarChar){Value = _bugPriority},
            new SqlParameter("@Image", SqlDbType.VarChar){Value = _image},
            new SqlParameter("@ProjectID", SqlDbType.BigInt){Value = _projectID},
            new SqlParameter("@BugSummary", SqlDbType.VarChar){Value = _bugSummary},
            new SqlParameter("@BugDescription", SqlDbType.VarChar){Value = _bugDescription},
            new SqlParameter("@StepsToReproduce", SqlDbType.VarChar){Value = _stepsToReproduce},
            new SqlParameter("@BugReproducibility", SqlDbType.VarChar){Value = _bugReproducibility},
            new SqlParameter("@BugReporter", SqlDbType.VarChar){Value = _bugreporter},
            new SqlParameter("@BugViewStatus", SqlDbType.VarChar){Value = _bugviewStatus},
            new SqlParameter("@Category", SqlDbType.BigInt){Value = _category},
             new SqlParameter("@Tags", SqlDbType.VarChar){Value = _bugTags},
            new SqlParameter("@AdditionalInfo", SqlDbType.VarChar){Value = _additionalInfo}
        };

        // Execute a stored procedure to add the issue and return the number of affected rows
        object obj = SqlHelper.ExecuteScalar(Utility.strconn, CommandType.StoredProcedure, SProcedures.issues, pArr);
        string returnID = Convert.ToString(obj);
        return returnID;
    }

    // Method to fetch a list of projects
    public DataSet projectsDrop()
    {
        // Prepare the parameter array
        SqlParameter[] pArr = 
        {
            new SqlParameter("@Action", SqlDbType.VarChar){Value = "projectDrop"},
            new SqlParameter("@username", SqlDbType.VarChar){Value = _username}
        };

        // Execute a stored procedure to retrieve projects
        DataSet ds = SqlHelper.ExecuteDataset(Utility.strconn, CommandType.StoredProcedure, SProcedures.issues, pArr);

        // Return the dataset containing projects
        return ds;
    }

    // Method to view an issue by its ID
    public DataSet viewIssue()
    {
        // Prepare the parameter array with the issue ID
        SqlParameter[] pArr = 
        {
            new SqlParameter("@Action", SqlDbType.VarChar){Value = "view"},
            new SqlParameter("@BugID", SqlDbType.BigInt){Value = _bugId}
        };

        // Execute a stored procedure to retrieve the issue details
        DataSet ds = SqlHelper.ExecuteDataset(Utility.strconn, CommandType.StoredProcedure, SProcedures.issues, pArr);

        // Return the dataset containing issue details
        return ds;
    }

    // Method to clone an issue
    public string cloneIssue()
    {
        // Prepare the parameter array with issue details
        SqlParameter[] pArr = 
        {
            new SqlParameter("@Action", SqlDbType.VarChar){Value = "clone"},
            new SqlParameter("@BugSeverity", SqlDbType.VarChar){Value = _bugSeverity},
            new SqlParameter("@BugPriority", SqlDbType.VarChar){Value = _bugPriority},
            new SqlParameter("@Image", SqlDbType.VarChar){Value = _image},
            new SqlParameter("@ProjectID", SqlDbType.BigInt){Value = _projectID},
            new SqlParameter("@BugSummary", SqlDbType.VarChar){Value = _bugSummary},
            new SqlParameter("@BugDescription", SqlDbType.VarChar){Value = _bugDescription},
            new SqlParameter("@StepsToReproduce", SqlDbType.VarChar){Value = _stepsToReproduce},
            new SqlParameter("@BugReproducibility", SqlDbType.VarChar){Value = _bugReproducibility},
            new SqlParameter("@BugReporter", SqlDbType.VarChar){Value = _bugreporter},
            new SqlParameter("@BugViewStatus", SqlDbType.VarChar){Value = _bugviewStatus},
            new SqlParameter("@Category", SqlDbType.BigInt){Value = _category},
            new SqlParameter("@AdditionalInfo", SqlDbType.VarChar){Value = _additionalInfo}
        };

        // Execute a stored procedure to clone the issue and return the cloned issue's ID
        object obj = SqlHelper.ExecuteScalar(Utility.strconn, CommandType.StoredProcedure, SProcedures.issues, pArr);

        // Convert the result to a string
        string cloneID = Convert.ToString(obj);

        // Return the ID of the cloned issue
        return cloneID;
    }

    // Method to fetch the parent issue of a given issue ID
    public DataSet parentIssue()
    {
        // Prepare the parameter array with the issue ID
        SqlParameter[] pArr = 
        {
            new SqlParameter("@Action", SqlDbType.VarChar){Value = "parent"},
            new SqlParameter("@BugID", SqlDbType.BigInt){Value = _bugId}
        };

        // Execute a stored procedure to retrieve the parent issue details
        DataSet ds = SqlHelper.ExecuteDataset(Utility.strconn, CommandType.StoredProcedure, SProcedures.issues, pArr);

        // Return the dataset containing parent issue details
        return ds;
    }

    public int updateIssue()
    {
        SqlParameter[] pArr = 
        {
            new SqlParameter("@Action",SqlDbType.VarChar) {Value = "update"},
            new SqlParameter("@BugID", SqlDbType.BigInt) {Value = _bugId},
            new SqlParameter("@Category",SqlDbType.BigInt) {Value = _category},
            new SqlParameter("@BugReproducibility",SqlDbType.VarChar) {Value = _bugReproducibility},
            new SqlParameter("@BugSeverity",SqlDbType.VarChar) {Value = _bugSeverity},
            new SqlParameter("@BugViewStatus",SqlDbType.VarChar) {Value = _bugviewStatus},
            new SqlParameter("@BugPriority",SqlDbType.VarChar) {Value = _bugPriority},
            new SqlParameter("@BugSummary",SqlDbType.VarChar) {Value = _bugSummary},
            new SqlParameter("@BugDescription",SqlDbType.VarChar) {Value = _bugDescription},
            new SqlParameter("@StepsToReproduce",SqlDbType.VarChar) {Value = _stepsToReproduce},
            new SqlParameter("@AdditionalInfo",SqlDbType.VarChar) {Value = _additionalInfo},
            new SqlParameter("@BugAssignedTo",SqlDbType.VarChar) {Value = _bugAssignedTo},
            new SqlParameter("@Tags",SqlDbType.VarChar) {Value = _bugTags}
        };
        int rowAffected = SqlHelper.ExecuteNonQuery(Utility.strconn, CommandType.StoredProcedure, SProcedures.issues, pArr);
        return rowAffected;
    }

    public DataSet fetchUserToAssignBug()
    {
        SqlParameter[] pArr =
        {
            new SqlParameter("@Action",SqlDbType.VarChar) {Value = "ToBeAssingedTo"},
            new SqlParameter("@BugID",SqlDbType.BigInt) {Value = _bugId}
        };
        DataSet ds = SqlHelper.ExecuteDataset(Utility.strconn, CommandType.StoredProcedure, SProcedures.issues, pArr);
        return ds;
    }

    public int changeStatus()
    {
        SqlParameter[] pArr = 
        {
            new SqlParameter("@Action",SqlDbType.VarChar) {Value = "updateStatus"},
            new SqlParameter("@BugID",SqlDbType.BigInt) {Value = _bugId},
            new SqlParameter("@BugStatus",SqlDbType.VarChar) {Value = _bugStatus}
        };
        int rowAffected = SqlHelper.ExecuteNonQuery(Utility.strconn, CommandType.StoredProcedure, SProcedures.issues, pArr);
        return rowAffected;
    }

    public int assignIssue()
    {
        SqlParameter[] pArr = 
        {
            new SqlParameter("@Action",SqlDbType.VarChar) {Value = "assignIssue"},
            new SqlParameter("@BugID",SqlDbType.BigInt) {Value = _bugId},
            new SqlParameter("@BugAssignedTo",SqlDbType.VarChar) {Value = _bugAssignedTo}
        };
        int rowAffected = SqlHelper.ExecuteNonQuery(Utility.strconn, CommandType.StoredProcedure, SProcedures.issues, pArr);
        return rowAffected;
    }

    public int tagIssue()
    {
        SqlParameter[] pArr = 
        {
            new SqlParameter("@Action",SqlDbType.VarChar) {Value = "tagIssue"},
            new SqlParameter("@BugID",SqlDbType.BigInt) {Value = _bugId},
            new SqlParameter("@Tags",SqlDbType.VarChar) {Value = _tag}
        };
        int rowAffected = SqlHelper.ExecuteNonQuery(Utility.strconn, CommandType.StoredProcedure, SProcedures.issues, pArr);
        return rowAffected;
    }

    public int deleteTag()
    {
        SqlParameter[] pArr = 
        {
            new SqlParameter("@Action",SqlDbType.VarChar) {Value = "deleteTag"},
            new SqlParameter("@Tags",SqlDbType.VarChar) {Value = _tagName},
        };
        int rowAffected = SqlHelper.ExecuteNonQuery(Utility.strconn, CommandType.StoredProcedure, SProcedures.issues, pArr);
        return rowAffected;
    }

    public DataSet projectRole() 
    {
        SqlParameter[] pArr = 
        {
            new SqlParameter("@Action",SqlDbType.VarChar) {Value = "projectRole"},
            new SqlParameter("@userName",SqlDbType.VarChar) {Value = _username},
            new SqlParameter("@BugID",SqlDbType.VarChar) {Value = _bugId}
        };
        DataSet ds = SqlHelper.ExecuteDataset(Utility.strconn, CommandType.StoredProcedure, SProcedures.issues, pArr);
        return ds;
    }
}
