using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for variables
/// </summary>
public class variables
{
	public variables()
	{
	 
	}
    // Static variable to store the value
    private static long valueOfSelectedProjectName;

    public static void GlobalVariables(long value)
    {
        // Set the value
        valueOfSelectedProjectName = value;
    }

    // Public property to access the value from other classes
    public static long ValueOfSelectedProjectName
    {
        get { return valueOfSelectedProjectName; }
    }
}