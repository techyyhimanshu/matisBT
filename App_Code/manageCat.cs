using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
/// <summary>
/// Summary description for manageCat
/// </summary>
public class manageCat
{
    public string _catName { get; set; }
    public long _catID { get; set; }
    public string _assignUser { get; set; }
    string connectionStr = ConfigurationManager.ConnectionStrings["MantisBtConString"].ToString();
	public manageCat()
	{
		
	}
    #region Add category
    public int addCategory()
    {
        int returnval = 0;
        SqlConnection con = new SqlConnection(connectionStr);
        string sqlQuery = @"insert into tbl_Category(catName) values('"+_catName+"')";
        SqlCommand sqlCmd = new SqlCommand(sqlQuery, con);
        con.Open();
        try
        {
            returnval = sqlCmd.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            return 0;
        }
        return returnval;
    }
    #endregion
    public DataSet fetchCategories()
    {
        SqlConnection con = new SqlConnection(connectionStr);
        string sqlQuery = @"select * from tbl_Category";
        SqlDataAdapter adp = new SqlDataAdapter(sqlQuery, con);
        con.Open();
        DataSet ds = new DataSet();
        adp.Fill(ds);
        con.Close();
        return ds;
    }

    #region fetch category name and users   for update
    public DataSet fetchCategoryNameForUpdate()
    {
        SqlConnection con = new SqlConnection(connectionStr);
        string sqlQuery = @"select CatName from tbl_Category where catID='"+_catID+"'";
        SqlDataAdapter adp = new SqlDataAdapter(sqlQuery, con);
        con.Open();
        DataSet ds = new DataSet();
        adp.Fill(ds);
        con.Close();
        return ds;
    }

    public DataSet fetchUsersForUpdate()
    {
        SqlConnection con = new SqlConnection(connectionStr);
        string sqlQuery = @"select userName from tbl_Users";
        SqlDataAdapter adp = new SqlDataAdapter(sqlQuery, con);
        con.Open();
        DataSet ds = new DataSet();
        adp.Fill(ds);
        con.Close();
        return ds;
    }
    #endregion

    #region Update category
    public int updateCategoryDetails()
    {
        SqlConnection con = new SqlConnection(connectionStr);
        string sqlQuery = @"update tbl_Category set CatName='" + _catName + "' where CatId='"+_catID+"'";
        SqlCommand sqlCmd = new SqlCommand(sqlQuery,con);
        con.Open();
        int response=sqlCmd.ExecuteNonQuery();
        return response;
    }
    #endregion
}