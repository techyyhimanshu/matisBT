using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


/// <summary>
/// Summary description for manageTags
/// </summary>
public class manageTags
{
    public long _tagID { get; set; }
    public string _tagName { get; set; }
    public string _creatorName { get; set; }
    public string _tagDescription { get; set; }
	public manageTags()
	{

    }
    #region Create new tag
    public int creatNewTag()
    {
        SqlParameter[] ParamsToCreatTag=new SqlParameter[4];
        ParamsToCreatTag[0] = new SqlParameter("@tagName", SqlDbType.VarChar);
        ParamsToCreatTag[0].Value = _tagName;

        ParamsToCreatTag[1] = new SqlParameter("@tagCreator", SqlDbType.VarChar);
        ParamsToCreatTag[1].Value = _creatorName;

        ParamsToCreatTag[2] = new SqlParameter("@tagDescription", SqlDbType.VarChar);
        ParamsToCreatTag[2].Value = _tagDescription;

        ParamsToCreatTag[3] = new SqlParameter("@action", SqlDbType.VarChar);
        ParamsToCreatTag[3].Value = "createNewTag";

        int returnval = SqlHelper.ExecuteNonQuery(Utility.strconn, CommandType.StoredProcedure,clsSP.manageTags, ParamsToCreatTag);

        //string sqlQuery = @"insert into tbl_Project_Details(projectName,createdDate,viewStatus,projectDescription,isInheritCategory,status) values('"+_projName+"',getdate(),'"+_viewStatus+"','"+_projDescripion+"','"+_inheritCat+"','"+_projStatus+"')";
        return returnval;
    }
    #endregion

    #region Fetch All tags
    public DataSet fetchAlltags()
    {
        SqlParameter[] ParamsToFetchTags=new SqlParameter[1];
        ParamsToFetchTags[0] = new SqlParameter("@action", SqlDbType.VarChar);
        ParamsToFetchTags[0].Value = "showAllTags";
        DataSet ds = SqlHelper.ExecuteDataset(Utility.strconn, CommandType.StoredProcedure, clsSP.manageTags, ParamsToFetchTags);
        return ds;
    }
    #endregion

    #region Fetch a single tag for update
    public void fetchTagDetailsForUpdate(out DataSet ds)
    {
        SqlParameter[] ParamsToUpdate = new SqlParameter[2];
        ParamsToUpdate[0] = new SqlParameter("@tagID", SqlDbType.VarChar);
        ParamsToUpdate[0].Value = _tagID;

        ParamsToUpdate[1] = new SqlParameter("@action", SqlDbType.VarChar);
        ParamsToUpdate[1].Value = "fetchTagDetailsForUpdate";
        ds = SqlHelper.ExecuteDataset(Utility.strconn, CommandType.StoredProcedure, clsSP.manageTags, ParamsToUpdate);


       
        
    }
    #endregion

    #region Update tag
    public int updateTagDetails()
    {
        SqlParameter[] ParamsToUpdate = new SqlParameter[5];
        ParamsToUpdate[0] = new SqlParameter("@tagID", SqlDbType.BigInt);
        ParamsToUpdate[0].Value = _tagID;

        ParamsToUpdate[1] = new SqlParameter("@tagName", SqlDbType.VarChar);
        ParamsToUpdate[1].Value = _tagName;

        ParamsToUpdate[2] = new SqlParameter("@tagDescription", SqlDbType.VarChar);
        ParamsToUpdate[2].Value = _tagDescription;

        ParamsToUpdate[4] = new SqlParameter("@action", SqlDbType.VarChar);
        ParamsToUpdate[4].Value = "updateTagDetails";

        int returnval = SqlHelper.ExecuteNonQuery(Utility.strconn, CommandType.StoredProcedure, clsSP.manageTags, ParamsToUpdate);
        return returnval;
    }
    #endregion

    #region Delete tag
    public int deleteTag()
    {
        SqlParameter[] ParamsToDelete = new SqlParameter[2];
        ParamsToDelete[0] = new SqlParameter("@tagID", SqlDbType.BigInt);
        ParamsToDelete[0].Value = _tagID;
        ParamsToDelete[1] = new SqlParameter("@action", SqlDbType.VarChar);
        ParamsToDelete[1].Value = "deleteTag";

        int returnval = SqlHelper.ExecuteNonQuery(Utility.strconn, CommandType.StoredProcedure, clsSP.manageTags, ParamsToDelete);
        return returnval;

    }
    #endregion
}