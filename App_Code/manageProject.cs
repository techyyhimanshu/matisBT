using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
/// <summary>
/// Summary description for manageProject
/// </summary>
public class manageProject
{
    #region Properties
    int returnval = 0;
    public string _projName { get; set; }
    public string _inheritCat { get; set; }
    public string _projStatus { get; set; }
    public string _viewStatus { get; set; }
    public string _projDescripion { get; set; }
    public long _projID { get; set; }
    public long _parentProjectID { get; set; }
    public string _isEnabled { get; set; }
    public string _chkInheritParentCat { get; set; }
    public string _userName { get; set; }
    public string _userAccessLevel { get; set; }
    #endregion
    public manageProject()
    {

    }
    #region Add new project
    public int addNewProject()
    {
        SqlParameter[] Param = new SqlParameter[5];
        Param[0] = new SqlParameter("@projectName", SqlDbType.VarChar);
        Param[0].Value = _projName;

        Param[1] = new SqlParameter("@viewStatus", SqlDbType.VarChar);
        Param[1].Value = _viewStatus;

        Param[2] = new SqlParameter("@projectDescription", SqlDbType.VarChar);
        Param[2].Value = _projDescripion;


        Param[3] = new SqlParameter("@status", SqlDbType.VarChar);
        Param[3].Value = _projStatus;

        Param[4] = new SqlParameter("@action", SqlDbType.VarChar);
        Param[4].Value = "insert";

        returnval = SqlHelper.ExecuteNonQuery(Utility.strconn, CommandType.StoredProcedure, clsSP.manageProject, Param);

        //string sqlQuery = @"insert into tbl_Project_Details(projectName,createdDate,viewStatus,projectDescription,isInheritCategory,status) values('"+_projName+"',getdate(),'"+_viewStatus+"','"+_projDescripion+"','"+_inheritCat+"','"+_projStatus+"')";
        return returnval;

    }
    #endregion

    #region fetch project details from table
    /// <summary>
    /// Fetching all project details from table tbl_Project_Details
    /// </summary>
    /// <returns></returns>
    public DataSet fetchProjectDetails()
    {
        SqlParameter[] Param = new SqlParameter[3];
        Param[0] = new SqlParameter("@action", SqlDbType.VarChar);
        Param[0].Value = "select";
        Param[1] = new SqlParameter("@username", SqlDbType.VarChar);
        Param[1].Value = _userName;
        Param[2] = new SqlParameter("@userAccessLevel", SqlDbType.VarChar);
        Param[2].Value = _userAccessLevel;
        DataSet ds = SqlHelper.ExecuteDataset(Utility.strconn, CommandType.StoredProcedure, clsSP.manageProject, Param);
        return ds;
    }
    #endregion

    #region fetch project details for update
    public void fetchProjectDetailsForUpdate(out DataSet datasetForAllDetails, out DataSet datasetForOnlyProjectName, out DataSet datasetForFetchingSubprojects)
    {


        SqlParameter[] ParamForAllDetails = new SqlParameter[2];
        ParamForAllDetails[0] = new SqlParameter("@projectID", SqlDbType.BigInt);
        ParamForAllDetails[0].Value = _projID;
        ParamForAllDetails[1] = new SqlParameter("@action", SqlDbType.VarChar);
        ParamForAllDetails[1].Value = "fetchAllProjectDetails";

        SqlParameter[] ParamForOnlyProjectName = new SqlParameter[4];
        ParamForOnlyProjectName[0] = new SqlParameter("@projectID", SqlDbType.BigInt);
        ParamForOnlyProjectName[0].Value = _projID;

        ParamForOnlyProjectName[1] = new SqlParameter("@userAccessLevel", SqlDbType.VarChar);
        ParamForOnlyProjectName[1].Value = _userAccessLevel;

        ParamForOnlyProjectName[2] = new SqlParameter("@username", SqlDbType.VarChar);
        ParamForOnlyProjectName[2].Value = _userName;

        ParamForOnlyProjectName[3] = new SqlParameter("@action", SqlDbType.VarChar);
        ParamForOnlyProjectName[3].Value = "fetchOnlyProjectNames";

        SqlParameter[] ParamForFetchingSubprojects = new SqlParameter[2];
        ParamForFetchingSubprojects[0] = new SqlParameter("@projectID", SqlDbType.BigInt);
        ParamForFetchingSubprojects[0].Value = _projID;
        ParamForFetchingSubprojects[1] = new SqlParameter("@action", SqlDbType.VarChar);
        ParamForFetchingSubprojects[1].Value = "fetchingSubprojects";

        datasetForAllDetails = SqlHelper.ExecuteDataset(Utility.strconn, CommandType.StoredProcedure, clsSP.manageProject, ParamForAllDetails);
        datasetForOnlyProjectName = SqlHelper.ExecuteDataset(Utility.strconn, CommandType.StoredProcedure, clsSP.manageProject, ParamForOnlyProjectName);
        datasetForFetchingSubprojects = SqlHelper.ExecuteDataset(Utility.strconn, CommandType.StoredProcedure, clsSP.manageProject, ParamForFetchingSubprojects);

    }
    #endregion

    #region update project details
    public int updateProjectDetails()
    {

        SqlParameter[] ParamForUpdateProjecct = new SqlParameter[7];
        ParamForUpdateProjecct[0] = new SqlParameter("@projectName", SqlDbType.VarChar);
        ParamForUpdateProjecct[0].Value = _projName;
        ParamForUpdateProjecct[1] = new SqlParameter("@viewStatus", SqlDbType.VarChar);
        ParamForUpdateProjecct[1].Value = _viewStatus;

        ParamForUpdateProjecct[2] = new SqlParameter("@projectDescription", SqlDbType.VarChar);
        ParamForUpdateProjecct[2].Value = _projDescripion;


        ParamForUpdateProjecct[3] = new SqlParameter("@status", SqlDbType.VarChar);
        ParamForUpdateProjecct[3].Value = _projStatus;

        ParamForUpdateProjecct[4] = new SqlParameter("@isEnabled", SqlDbType.VarChar);
        ParamForUpdateProjecct[4].Value = _isEnabled;

        ParamForUpdateProjecct[5] = new SqlParameter("@projectID", SqlDbType.BigInt);
        ParamForUpdateProjecct[5].Value = _projID;

        ParamForUpdateProjecct[6] = new SqlParameter("@action", SqlDbType.VarChar);
        ParamForUpdateProjecct[6].Value = "updateProject";


        int returnval = SqlHelper.ExecuteNonQuery(Utility.strconn, CommandType.StoredProcedure, clsSP.manageProject, ParamForUpdateProjecct);
        return returnval;
    }
    #endregion

    #region delete project
    public int deleteProject()
    {
        SqlParameter[] Param = new SqlParameter[2];
        Param[0] = new SqlParameter("@projectID", SqlDbType.BigInt);
        Param[0].Value = _projID;
        Param[1] = new SqlParameter("@action", SqlDbType.VarChar);
        Param[1].Value = "deleteProject";
        returnval = SqlHelper.ExecuteNonQuery(Utility.strconn, CommandType.StoredProcedure, clsSP.manageProject, Param);
        return returnval;
    }
    #endregion

    #region Create a new subproject
    public int createNewSubproject()
    {
        int returnval, returnvalTwo = 0;
        SqlParameter[] Param = new SqlParameter[]
{
    new SqlParameter("@projectName", SqlDbType.VarChar) { Value = _projName },
    new SqlParameter("@viewStatus", SqlDbType.VarChar) { Value = _viewStatus },
    new SqlParameter("@projectDescription", SqlDbType.VarChar) { Value = _projDescripion },
    new SqlParameter("@isInheritCategory", SqlDbType.VarChar) { Value = _inheritCat },
    new SqlParameter("@status", SqlDbType.VarChar) { Value = _projStatus },
    new SqlParameter("@action", SqlDbType.VarChar) { Value = "crateNewSubproject" }
};
        returnval = Convert.ToInt32(SqlHelper.ExecuteScalar(Utility.strconn, CommandType.StoredProcedure, clsSP.manageProject, Param));

        SqlParameter[] ParamForSubprojectRelation = new SqlParameter[4];

        ParamForSubprojectRelation[0] = new SqlParameter("@childProjectID", SqlDbType.BigInt);
        ParamForSubprojectRelation[0].Value = returnval;
        ParamForSubprojectRelation[1] = new SqlParameter("@parentProjectId", SqlDbType.BigInt);
        ParamForSubprojectRelation[1].Value = _parentProjectID;
        ParamForSubprojectRelation[2] = new SqlParameter("@chkInheritParent", SqlDbType.VarChar);
        ParamForSubprojectRelation[2].Value = _chkInheritParentCat;
        ParamForSubprojectRelation[3] = new SqlParameter("@action", SqlDbType.VarChar);
        ParamForSubprojectRelation[3].Value = "insertIntoSubprojectRelation";

        returnvalTwo = Convert.ToInt32(SqlHelper.ExecuteScalar(Utility.strconn, CommandType.StoredProcedure, clsSP.manageProject, ParamForSubprojectRelation));
        return returnval;
    }
    #endregion

    #region Create new subproject by selecting project from drop down list
    public int addSubproject()
    {
        SqlParameter[] ParamForSubprojectRelation = new SqlParameter[4];

        ParamForSubprojectRelation[0] = new SqlParameter("@childProjectID", SqlDbType.BigInt);
        ParamForSubprojectRelation[0].Value = _projID;
        ParamForSubprojectRelation[1] = new SqlParameter("@parentProjectId", SqlDbType.BigInt);
        ParamForSubprojectRelation[1].Value = _parentProjectID;
        ParamForSubprojectRelation[2] = new SqlParameter("@chkInheritParent", SqlDbType.VarChar);
        ParamForSubprojectRelation[2].Value = _chkInheritParentCat;
        ParamForSubprojectRelation[3] = new SqlParameter("@action", SqlDbType.VarChar);
        ParamForSubprojectRelation[3].Value = "insertIntoSubprojectRelation";

        returnval = Convert.ToInt32(SqlHelper.ExecuteNonQuery(Utility.strconn, CommandType.StoredProcedure, clsSP.manageProject, ParamForSubprojectRelation));
        return returnval;
    }
    #endregion

    #region Unlink Subproject
    public int unlinkSubproject()
    {
        SqlParameter[] ParamForSubprojectUnlink = new SqlParameter[2];
        ParamForSubprojectUnlink[0] = new SqlParameter("@childProjectID", SqlDbType.BigInt);
        ParamForSubprojectUnlink[0].Value = _projID;
        ParamForSubprojectUnlink[1] = new SqlParameter("@action", SqlDbType.VarChar);
        ParamForSubprojectUnlink[1].Value = "unlinkSubproject";
        returnval = SqlHelper.ExecuteNonQuery(Utility.strconn, CommandType.StoredProcedure, clsSP.manageProject, ParamForSubprojectUnlink);
        return returnval;
    }
    #endregion

    #region Fetch project name for top bar
    public DataSet fetchProjectNames()
    {
        SqlParameter[] Param = new SqlParameter[3];
        Param[0] = new SqlParameter("@action", SqlDbType.VarChar);
        Param[0].Value = "selectProjectName";
        Param[1] = new SqlParameter("@userName", SqlDbType.VarChar);
        Param[1].Value = _userName;
        Param[2] = new SqlParameter("@userAccessLevel", SqlDbType.VarChar);
        Param[2].Value = _userAccessLevel;
        DataSet ds = SqlHelper.ExecuteDataset(Utility.strconn, CommandType.StoredProcedure, clsSP.manageProject, Param);
        return ds;
    }
    #endregion
}