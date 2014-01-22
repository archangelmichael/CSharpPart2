using System;
/*  Write a method ReadNumber(int start, int end) that 
 * enters an integer number in given range [start…end]. 
 * If an invalid number or non-number text is entered, 
 * the method should throw an exception.
 * Using this method write a program that enters 10 numbers:
 * a1, a2, … a10, such that 1 < a1 < … < a10 < 100     */


// the program doesnt stop if there is a bad input, but only if range is closed (99,100)
// if you want it to stop in case of exception, comment recurrsions in all exceptions
class ReadNumbers
{
    static int counter = 0;
    static void ReadNumber(int start, int end) 
    {
        if (counter == 10)
        {
            Console.WriteLine("You have entered all 10 numbers!");
            return;
        }
        else if (start == end - 1)
        {
            Console.Clear();
            Console.WriteLine("You have entered {0} valid numbers!",counter);
            Console.WriteLine("No more numbers left in the range!");
            return;
        }

        int number;
        Console.WriteLine("Enter number in range [{0},{1}]:",start,end);
        try
        {
            number = int.Parse(Console.ReadLine());
            if (start > number || number > end)
            {
                throw new ArgumentOutOfRangeException();
            }
            counter++;
            start = number;
            ReadNumber(start, end);
        }
        catch (OverflowException)
        {
            Console.WriteLine("Your number is too big!",start,end);
            ReadNumber(start, end); // comment this row if you want the program to stop at this exception
            return;
        }
        catch (FormatException)
        {
            Console.WriteLine("Your number is not valid!");
            ReadNumber(start, end); // comment this row if you want the program to stop at this exception
            return;
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Your number is not in the range [{0},{1}]!",start,end);
            ReadNumber(start, end); // comment this row if you want the program to stop at this exception
            return;
        }
    }

    static void Main()
    {
        int min = 1, max = 100;
        ReadNumber(min, max);
    }
}

