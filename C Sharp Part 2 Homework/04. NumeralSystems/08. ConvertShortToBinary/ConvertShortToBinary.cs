using System;
using System.Collections.Generic;

/*  Write a program that shows the binary representation of given 16-bit signed integer number (the C# type short). */

class ConvertShortToBinary
{
    static string ShortToBinary(short input)
    {
        string result = "";
        for (int i = 0; i < 16; i++)
        {
            // get the value from the binary representation at position i
            result = ((input >> i) & 1) + result; 
        }
        return  result.TrimStart('0'); // Clears all leading Zeros
    }
    static void Main()
    {
        try
        {
            Console.WriteLine("Enter short number to convert: ");
            short shortNumber = short.Parse(Console.ReadLine());
            Console.WriteLine(ShortToBinary(shortNumber));
        }
        catch (OverflowException exc)
        {
            Console.WriteLine(exc.Message);
        }
    }
}

