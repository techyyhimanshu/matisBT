using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for counters
/// </summary>
public class counters
{
    public static int _countForLogin { get; set; }
    public static int _countForNewIssue { get; set; }
    public static int _countForNewProject { get; set; }
    public static int _countForNewUser { get; set; }
    public static int _countForUserDeleted { get; set; }
    public static int _countForChangePass { get; set; }
    public static int _countForUserProtectedOrNot { get; set; }
    public static string _newUserCreatedUserName { get; set; }

	public counters()
	{
        _countForLogin = 0;
        _countForNewIssue = 0;
        _countForNewProject = 0;
        _countForNewUser = 0;
        _countForUserDeleted = 0;
        _countForUserProtectedOrNot = 0;
        _countForChangePass = 0;
		//
		// TODO: Add constructor logic here
		//
	}
}