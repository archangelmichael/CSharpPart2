using System;
using System.Linq;
using System.Collections.Generic;
/*  Write a program to convert decimal numbers to their binary representation. */

class ConvertDecimalToBinary
{
    static string DecimalToBinary(long number, int systemBase = 2)
    {
        string result = "";
        while (number > 0)
        {
            result = number % systemBase + result;
            number = number / systemBase;
        }
        return result;
    }
    static string NegativeDecimalToBinary(long num)
    {
        string result = "1";
        string tempResult = DecimalToBinary(num + long.MinValue);
        result = result + tempResult.Substring(0, tempResult.Length);
        return result;
    }
    static void Main()
    {
        Console.WriteLine(" Enter number in decimal system: ");
        long number = long.Parse(Console.ReadLine());
        Console.WriteLine(Convert.ToString(number, 2)); // The easy way
        if (number > 0)
        {
            Console.WriteLine(DecimalToBinary(number)); // Works only for positive long numbers
        }
        else
        {
            Console.WriteLine(NegativeDecimalToBinary(number)); // Works for negative long numbers
        }
    }
}

