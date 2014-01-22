using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

/* Write a program that reverses the words in given sentence.
	Example: "C# is not C++, not PHP and not Delphi!" 
 * "Delphi not and PHP, not C++ not is C#!". */

    class ReverseWordsInSentance
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char[] delimiters = new char[] { ',', ' ', '!', '?', '.'};
            string[] words = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            Array.Reverse(words);
            string[] array = Regex.Split(input, "[A-Za-z0-9#+]");
            List <string> separators = new List <string>();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != String.Empty)
                {
                    separators.Add(array[i]);
                }
            }
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < separators.Count; i++)
            {
                if (i < words.Length)
                {
                    result.Append(words[i]);
                }
                result.Append(separators[i]);
            }
            Console.WriteLine(result.ToString());
        }
    }

