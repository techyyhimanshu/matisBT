using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SearchIssues
/// </summary>
public class SearchIssues
{
    #region PROPERTIES
    public string _reporter { get; set; }
    public string _assignedTo { get; set; }
    public string _monitoredBy { get; set; }
    public string _noteBy { get; set; }
    public string _priority { get; set; }
    public string _severity { get; set; }
    public string _viewStatus { get; set; }
    public string _showStickyIssues { get; set; }
    public long _category { get; set; }
    public string _hideStatus { get; set; }
    public string _status { get; set; }
    public string _resolution { get; set; }
    public string _relation { get; set; }
    public string _show { get; set; }
    public string _sortBy { get; set; }
    public string _sortByOrder { get; set; }
    public string _matchType { get; set; }
    public string _highlightChanged { get; set; }
    private string _dateSubmit1;
    public string DateSubmit1
    {
        get { return _dateSubmit1; }
        set 
        {
            if (value == "") _dateSubmit1 = "1753-01-01";
            else _dateSubmit1 = value;
        }
    }
    private string _dateSubmit2;
    public string DateSubmit2
    {
        get { return _dateSubmit2; }
        set
        {
            if (value == "") _dateSubmit2 = "9999-12-31";
            else _dateSubmit2 = value; 
        }
    }
    private string _dateUpdate1;
    public string DateUpdate1
    {
        get { return _dateUpdate1; }
        set 
        {
            if (value == "") _dateUpdate1 = "1753-01-01";
            else _dateUpdate1 = value; 
        }
    }
    private string _dateUpdate2;
    public string DateUpdate2
    {
        get { return _dateUpdate2; }
        set
        {
            if (value == "") _dateUpdate2 = "9999-12-31";
            else _dateUpdate2 = value;
        }
    }
    public string _userName { get; set; }
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
    public string _tags { get; set; }
    public int _tagsCount { get; set; }
    public string _searchBox { get; set; }
    
    
    #endregion

    public DataSet fiterDropDowns()
    {
        DataSet ds = SqlHelper.ExecuteDataset(Utility.strconn, CommandType.StoredProcedure, SProcedures.searchIssue);
        return ds;
    }

    public DataSet filteredIssues()
    {
        SqlParameter[] pArr = 
        {
            new SqlParameter("@reporter",SqlDbType.VarChar) {Value = _reporter},
            new SqlParameter("@matchType",SqlDbType.VarChar) {Value = _matchType},
            new SqlParameter("@assignedTo",SqlDbType.VarChar) {Value = _assignedTo},
            new SqlParameter("@monitoredBy",SqlDbType.VarChar) {Value = _monitoredBy},
            new SqlParameter("@noteBy",SqlDbType.VarChar) {Value = _noteBy},
            new SqlParameter("@priority",SqlDbType.VarChar) {Value = _priority},
            new SqlParameter("@severity",SqlDbType.VarChar) {Value = _severity},
            new SqlParameter("@category",SqlDbType.BigInt) {Value = _category},
            new SqlParameter("@status",SqlDbType.VarChar) {Value = _status},
            new SqlParameter("@hideStatus",SqlDbType.VarChar) {Value = _hideStatus},
            new SqlParameter("@dateSubmit1",SqlDbType.Date) {Value = _dateSubmit1},
            new SqlParameter("@dateSubmit2",SqlDbType.Date) {Value = _dateSubmit2},
            new SqlParameter("@dateUpdate1",SqlDbType.Date) {Value = _dateUpdate1},
            new SqlParameter("@dateUpdate2",SqlDbType.Date) {Value = _dateUpdate2},
            new SqlParameter("@relationship",SqlDbType.VarChar) {Value = _relation},
            new SqlParameter("@sortBy",SqlDbType.VarChar) {Value = _sortBy},
            new SqlParameter("@sortByOrder",SqlDbType.VarChar) {Value = _sortByOrder},
            new SqlParameter("@viewStatus",SqlDbType.VarChar) {Value = _viewStatus},
            new SqlParameter("@userName",SqlDbType.VarChar) {Value = _userName},
            new SqlParameter("@projectID",SqlDbType.VarChar) {Value = _projectID},
            new SqlParameter("@tags",SqlDbType.VarChar) {Value = _tags},
            new SqlParameter("@tagCount",SqlDbType.Int) {Value = _tagsCount},
            new SqlParameter("@searchBox",SqlDbType.VarChar) {Value = _searchBox}
        };
        DataSet ds = SqlHelper.ExecuteDataset(Utility.strconn, CommandType.StoredProcedure, SProcedures.searchIssue, pArr);
        return ds;
    }
}