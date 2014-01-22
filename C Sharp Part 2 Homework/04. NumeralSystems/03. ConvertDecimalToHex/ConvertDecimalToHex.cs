using System;
using System.Collections.Generic;

/*  Write a program to convert decimal numbers to their hexadecimal representation. */

class ConvertDecimalToHex
{
    static string DecimalToHex(long number, int systemBase = 16)
    {
        string result = "";
        while (number > 0)
        {
            if (number % systemBase >= 10)
            {
                result = (char)('A' + number % systemBase - 10) + result; // using capital letters
            }
            else
            {
                result = (char)('0' + number % systemBase) + result;
            }
            number = number / systemBase;
        }
        return result;
    }
    static string NegativeDecimalToHex(long num)
    {
        string result = "F";
        string tempResult = DecimalToHex(num + long.MinValue);
        result = result + tempResult.Substring(1, tempResult.Length-1);
        return result;
    }
    static void Main()
    {
        Console.WriteLine(" Enter number in decimal system: ");
        long number = long.Parse(Console.ReadLine());
        Console.WriteLine(Convert.ToString(number, 16)); // The easy way
        if (number > 0)
        {
            Console.WriteLine(DecimalToHex(number)); // Works for positive long numbers
        }
        else
        {
            Console.WriteLine(NegativeDecimalToHex(number)); // Works for negative long numbers
        }
    }
}

