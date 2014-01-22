using System;

class ReverseDigitsOfNumber
{
    /*  Write a method that reverses the digits of given decimal number. Example: 256  652 */
    // In this solution i suggest that by decimal number they refer to a number in decimal system (base 10)
    static void ReverseDigits(long number)
    {
        if (number < 10)
        {
            Console.Write(number);
            Console.WriteLine();
            return;
        }
        else
        {
            Console.Write(number % 10);
            ReverseDigits(number / 10);
            return;
        }
    }
    static void Main()
    {
        Console.WriteLine("Enter a number to be reversed:");
        long entered = long.Parse(Console.ReadLine());
        if (entered < 0)
        {
            Console.Write("-");
            ReverseDigits(-entered);
        }
        else
        {
            ReverseDigits(entered);
        }
    }
}

