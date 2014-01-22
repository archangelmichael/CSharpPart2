using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

/* Write a program that reads two dates in the format: 
 * day.month.year and calculates the number of days between them. 
 * Example:
 * Enter the first date: 27.02.2006
 * Enter the second date: 3.03.2004
 * Distance: 4 days     */

class DaysBetween
{
    static void Main()
    {
        string startDate = Console.ReadLine();
        string endDate = Console.ReadLine();
        int days = CalculateDays(startDate, endDate);
        if (days < 0)
        {
            Console.WriteLine(-days);
        }
        else
        {
            Console.WriteLine(days);
        }
    }
    static int CalculateDays(string start, string end)
    {
        if (ValidDate(start) && ValidDate(end))
        {
            return (int)((DateTime.Parse(end) - DateTime.Parse(start)).TotalDays);
        }
        else
        {
            Console.WriteLine("Please enter the dates in the specified format!");
            return 0;
        }
    }
    static bool ValidDate(string date)
    {
        if (Regex.IsMatch(date, "[0-9]{1,2}[.][0-9]{2}[.][0-9]{4}"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

