using System;
using System.Text;
using System.Text.RegularExpressions;

/*  Write a program that reads a string from the console 
 * and replaces all series of consecutive identical letters 
 * with a single one. Example: "aaaaabbbbbcdddeeeedssaa"  "abcdedsa". */

    class IdenticalLetters
    {
        static void Main()
        {
            
            string input = Console.ReadLine();
            // Solution without regular expression 
            string result = RemoveConsecutiveLetters(input);
            Console.WriteLine(result);

            // Solution with regular expression 
            result = Regex.Replace(input, @"(\w)\1+", "$1");
            Console.WriteLine(result);
        }
        static string RemoveConsecutiveLetters(string text) // works for letters and digits
        {
            var solution = new StringBuilder();
            solution.Append(text[0]);
            for (int i = 1; i < text.Length; i++)
            {
                if (text[i] == solution[solution.Length - 1] && (char.IsLetter(text[i]) || (char.IsDigit(text[i]) ) ) )
                {
                    continue;
                }
                else
                {
                    solution.Append(text[i]);
                }
            }
            return solution.ToString();
        }
    }

