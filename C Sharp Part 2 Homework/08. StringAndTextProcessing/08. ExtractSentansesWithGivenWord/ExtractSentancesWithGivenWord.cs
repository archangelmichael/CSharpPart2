using System;
using System.Text;
using System.Text.RegularExpressions;

/*  Write a program that extracts from a given text all sentences containing given word.
*   Consider that the sentences are separated by "." and the words – by non-letter symbols. */

class EtractSentancesWithGivenWord
{
    static void ExtractSentances(string input, string phrase)
    {
        foreach (Match sentence in Regex.Matches(input, @"\s*([^\.]*\b" + phrase + @"\b.*?\.)"))
        {
            Console.WriteLine(sentence.Groups[1]);
        }
    }
    static void Main()
    {
        string text = Console.ReadLine();
        string search = Console.ReadLine();
        ExtractSentances(text, search);
    }
}

