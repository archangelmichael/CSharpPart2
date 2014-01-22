using System;
using System.IO;
using System.Text.RegularExpressions;

/*  Write a program that extracts from given 
 * HTML file its title (if available), 
 * and its body text without the HTML tags. */
class ExtractFromHTML
    {
        static void Main()
        {
            // Solution with regular expressions
            using (StreamReader reader = new StreamReader(@"..\..\input.html"))
            {
                string line = reader.ReadLine();
                MatchCollection titleAndBody;
                while (line != null)
                {
                    titleAndBody = Regex.Matches(line, @"(?<=^|>)[^><]+?(?=<|$)");
                    foreach (var match in titleAndBody)
                    {
                        if (match.ToString().Trim() != string.Empty)
                        {
                            string element = match.ToString().Trim();
                            Console.WriteLine(element);
                        }
                    }
                    line = reader.ReadLine();
                }
            }
        }
    }

