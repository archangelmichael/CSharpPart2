using System;
using System.Collections.Generic;

/*  Write a program to convert hexadecimal numbers to their decimal representation. */

class ConvertHexToDecimal
{
    static int GetHexDigit(string s, int i)
    {
        if (s[i] >= 'A' && s[i] <= 'F') // For capital letters
        {
            return s[i] - 'A' + 10;
        }
        else if (s[i] >= 'a' && s[i] <= 'f') // For small letters
        {
            return s[i] - 'a' + 10;
        }
        return s[i] - '0';
    }
    static long HexToDecimal(string hex, int systemBase = 16)
    {
        long number = 0;
        for (int i = hex.Length - 1, j = 1; i >= 0; i--, j *= systemBase)
        {
            number += GetHexDigit(hex, i) * j;
        }
        return number;
    }
    static void Main()
    {
        Console.WriteLine("Enter number in hex system: ");
        string hex = Console.ReadLine();
        Console.WriteLine(HexToDecimal(hex));
    }
}

