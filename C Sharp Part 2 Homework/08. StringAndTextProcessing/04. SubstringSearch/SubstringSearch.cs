using System;
using System.IO;
using System.Text;

/*  Write a program that finds how many times a substring is contained in a given text (perform case insensitive search). */

class SubstringSearch
{
    static int SearchSubstring(string input, string search)
    {
        int count = 0;
        int index = input.IndexOf(search, 0);
        while (index >= 0)
        {
            count++;
            index++;
            index = input.IndexOf(search, index);
        }
        return count;
    }
    static void Main()
    {
        Console.WriteLine("Enter string to search for:");
        string target = Console.ReadLine().ToLower();
        string text = File.ReadAllText(@"..\..\input.txt",Encoding.UTF8).ToLower();
        Console.WriteLine(SearchSubstring(text,target));
    }
}

