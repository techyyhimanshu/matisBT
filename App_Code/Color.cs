using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Color
/// </summary>
public static class Color
{
    public static string priorityColor(string bugPriority)
    {
        if (bugPriority != null && bugPriority.ToString() == "low")
        {
            return "#00b359";
        }
        else if (bugPriority != null && bugPriority.ToString() == "normal")
        {
            return "#4d79ff";
        }
        else if (bugPriority != null && bugPriority.ToString() == "high")
        {
            return "orange";
        }
        else if (bugPriority != null && bugPriority.ToString() == "urgent")
        {
            return "#ff6666";
        }
        else if (bugPriority != null && bugPriority.ToString() == "immediate")
        {
            return "red";
        }
        else
        {
            return "#adad85";
        }
    }
}