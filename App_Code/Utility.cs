using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Utility
/// </summary>
public static class Utility
{
	public static string strconn
	{
        get
        {
            return ConfigurationManager.ConnectionStrings["MantisBtConString"].ToString();
        }
	}  
}