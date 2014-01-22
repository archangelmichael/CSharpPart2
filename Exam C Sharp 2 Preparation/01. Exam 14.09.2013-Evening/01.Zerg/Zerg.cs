using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Zerg
{
    static int GetHexDigit(string s, int i)
    {
        if (s[i] >= 'A' && s[i] <= 'E') // For capital letters
        {
            return s[i] - 'A' + 10;
        }
        return s[i] - '0';
    }
    static long HexToDecimal(string hex, int systemBase = 15)
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
        string[] system = { "Rawr", "Rrrr", "Hsst", "Ssst", "Grrr", "Rarr", "Mrrr", "Psst", "Uaah", "Uaha", "Zzzz", "Bauu", "Djav", "Myau", "Gruh" };
        string input = Console.ReadLine();
        int index = 0;
        List<string> words = new List<string>(input.Length / 4);
        while (index <= input.Length - 3)
        {
            words.Add(input.Substring(index, 4));
            index += 4;
        }
        StringBuilder result = new StringBuilder(words.Count);
        foreach (var word in words)
        {
            for (int i = 0; i < system.Length; i++)
            {
                if (word == system[i])
                {
                    switch (i)
                    {
                        case 10: result.Append('A');
                            break;
                        case 11: result.Append('B');
                            break;
                        case 12: result.Append('C');
                            break;
                        case 13: result.Append('D');
                            break;
                        case 14: result.Append('E');
                            break;
                        default: result.Append(i);
                            break;
                    }
                }
            }
        }
        //Console.WriteLine(result.ToString());
        Console.WriteLine(HexToDecimal(result.ToString()));


        string text = Console.ReadLine();
        ulong thirteen = ConvertNumberFromBase(text, 15);
        Console.WriteLine(thirteen);
    }

    private static ulong ConvertNumberFromBase(string number, ulong numberBase)
    {
        Dictionary<string, int> system = new Dictionary<string, int>()
        {
            {"Rawr",0},    {"Rrrr",1},    {"Hsst",2},    {"Ssst",3},    {"Grrr",4},    {"Rarr",5},    {"Mrrr",6},    {"Psst",7},
            {"Uaah",8},    {"Uaha",9},    {"Zzzz",10},   {"Bauu",11},   {"Djav",12},   {"Myau",13},   {"Gruh",14},};
        ulong sum = 0;
        for (int i = 0; i < number.Length - 3; i = i + 4)
        {
            int digit = 0;
            string stringer = "" + number[i] + number[i + 1] + number[i + 2] + number[i + 3];
            digit = system[stringer];
            sum = sum * numberBase + (ulong)digit;
        }
        return sum;
    }
}


