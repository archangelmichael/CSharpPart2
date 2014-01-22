using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

/*  You are given a text. 
 * Write a program that changes the text in all regions 
 * surrounded by the tags <upcase> and </upcase> to uppercase. 
 * The tags cannot be nested.   */

class InTagsToUpperCase
{

    static string GetUpperCase(string input, string start = "<upcase>", string end = "</upcase>")
    {
        input = Regex.Replace(input, start + "(.*?)" + end, change => change.Groups[1].Value.ToUpper());
        return input;
    }
    static void Main()
    {
        string input = @"..\..\input.txt";
        string text = File.ReadAllText(input, Encoding.UTF8);
        Console.WriteLine(GetUpperCase(text));
    }
}


