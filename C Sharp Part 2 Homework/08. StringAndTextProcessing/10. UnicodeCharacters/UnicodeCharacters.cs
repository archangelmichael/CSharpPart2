using System;
using System.Text;

/*  Write a program that converts a string 
 * to a sequence of C# Unicode character literals. 
 * Use format strings. 
 * Sample input:
 * Hi!
 * Expected output:
    \u0048\u0069\u0021  */

class UnicodeCharacters
{
    static string ConvertToUnicode(string convert)
    {
        StringBuilder coverted = new StringBuilder (convert.Length);

        for (int i = 0; i < convert.Length; i++)
        {
            coverted.AppendFormat("\\u{0:X4}", (int)convert[i]);
        }

        return coverted.ToString();
    }
    static void Main()
    {
        string input = Console.ReadLine();
        string result = ConvertToUnicode(input);
        Console.WriteLine(result);
    }
}

