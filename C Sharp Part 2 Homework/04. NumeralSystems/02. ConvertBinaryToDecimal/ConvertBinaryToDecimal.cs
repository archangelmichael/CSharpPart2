using System;
using System.Collections.Generic;
using System.Linq;

/*  Write a program to convert binary numbers to their decimal representation. */

class ConvertBinaryToDecimal
{
    static int GetBinDigit(string s, int i)
    {
        return s[i] - '0';
    }
    static long BinToDecimal(string bin, int systemBase = 2)
    {
        long number = 0;
        for (int i = bin.Length-1, j = 1; i >= 0 ; i--, j *= systemBase)
        {
            number += GetBinDigit(bin,i) * j;
        }
        return number;
    }
    static void Main()
    {
        Console.WriteLine("Enter number in binary system: ");
        string binary = Console.ReadLine();
        Console.WriteLine(BinToDecimal(binary));
    }
}

