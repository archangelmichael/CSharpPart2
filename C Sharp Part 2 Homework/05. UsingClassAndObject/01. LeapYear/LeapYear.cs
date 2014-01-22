using System;
//Write a program that reads a year from the console and checks whether it is a leap. Use DateTime.

class LeapYear
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Enter year to check: ");
            int year = int.Parse(Console.ReadLine());
            if (DateTime.IsLeapYear(year))
            {
                Console.WriteLine("The year {0} is leap!", year);
            }
            else
            {
                Console.WriteLine("The year {0} is not leap!", year);
            }
        }
        catch (ArgumentException exc)
        {
            Console.WriteLine(exc.Message);
        }
        catch (FormatException exc)
        {
            Console.WriteLine(exc.Message);
        }
        catch (OverflowException exc)
        {
            Console.WriteLine(exc.Message);
        }
    }
}

