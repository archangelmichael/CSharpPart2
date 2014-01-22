using System;
using System.Text.RegularExpressions;

/* We are given a string containing a list of 
 * forbidden words and a text containing some of these words. 
 * Write a program that replaces the forbidden words with asterisks. 
 * Example: Words: "PHP, CLR, Microsoft"
 * Microsoft announced its next generation PHP compiler today. 
 * It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR. */

class ForbiddenWords
{
    static void Main()
    {
        char[] delimiter = {' ',',','.',';','"'};
        string[] words = Console.ReadLine().Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
        string expression = string.Join("|", words);
        string text = Console.ReadLine();
        Console.WriteLine(Regex.Replace(text, expression, m => new String('*', m.Length)));
    }
}
		 
