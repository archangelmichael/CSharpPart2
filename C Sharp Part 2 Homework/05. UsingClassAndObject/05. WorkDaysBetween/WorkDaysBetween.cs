using System;
/*  Write a method that calculates the number of workdays 
 * between today and given date, passed as parameter. 
 * Consider that workdays are all days from Monday to Friday except 
 * a fixed list of public holidays specified preliminary as array.*/

class WorkDaysBetween
{
    static DateTime[] holidays = //I have chosen several random dates
    {
        new DateTime(2014,01,24),
        new DateTime(2014,02,14),
        new DateTime(2014,03,03),
        new DateTime(2014,04,14),
        new DateTime(2014,09,06),
        new DateTime(2014,12,24),
        new DateTime(2014,12,25)
    };
    static bool CheckHolidays(DateTime day)
    {
        foreach (DateTime holiday in holidays)
        {
            if (day == holiday)
            {
                return true;
            }
        }
        return false;
    }
    static void CountWorkingDays(DateTime start,DateTime end)
    {
        if (start > end)
        {
            CountWorkingDays(end, start);
        }
        else
        {
            int days = (int)(end - start).TotalDays - 1; // Exclude given dates (to include change to + 1;
            int count = 0;
            DateTime i = start.AddDays(1);
            for (int j = 0; j < days; j++)
            {
                if (i.DayOfWeek != DayOfWeek.Saturday && i.DayOfWeek != DayOfWeek.Sunday && !CheckHolidays(i))
                {
                    count++;
                }
                i = i.AddDays(1);
            }
            Console.WriteLine("There are {0} working days between {1:dd.MM.yyyy} and {2:dd.MM.yyyy} (excluded)!", count, start, end);
            return;
        }
    }
    static void Main()
    {
        DateTime today = DateTime.Today;
        Console.WriteLine("Enter date you want to check for(year,month,day): ");
        DateTime date = DateTime.Parse(Console.ReadLine()); 
        CountWorkingDays(today, date);
    }
}

