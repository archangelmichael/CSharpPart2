using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/* A dictionary is stored as a sequence of 
 * text lines containing words and their explanations. 
 * Write a program that enters a word and 
 * translates it by using the dictionary. 
 * Sample dictionary:
 * .NET – platform for applications from Microsoft
 * CLR – managed execution environment for .NET
 * namespace – hierarchical organization of classes */
class Dictionary
{
    static void Main()
    {
        Console.WriteLine("Enter a word: ");
        string word = Console.ReadLine();
        Console.WriteLine("{0} - {1}", word, ExplainWord(word));
    }
    static string ExplainWord(string input)
    {
        input = input.Trim();
        var dictionary = new Dictionary<string, string>();
        dictionary.Add(".NET", "platform for applications from Microsoft");
        dictionary.Add("CLR", "managed execution environment for .NET");
        dictionary.Add("namespace", "hierarchical organization of classes");

        foreach (var word in dictionary)
        {
            if (word.Key.ToLowerInvariant() == input.ToLowerInvariant())
            {
                return word.Value;
            }
        }
        return "word not found";
    }
}

