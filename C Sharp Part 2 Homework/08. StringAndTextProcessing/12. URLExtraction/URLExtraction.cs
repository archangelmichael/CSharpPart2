using System;
using System.Text.RegularExpressions;

/* Write a program that parses an URL address given in the format:
 * [protocol]://[server]/[resource]
 * and extracts from it the [protocol], [server] and [resource] elements. 
 * For example from the URL http://www.devbg.org/forum/index.php 
 * the following information should be extracted:
 * [protocol] = "http" 
 * [server] = "www.devbg.org"
 * [resource] = "/forum/index.php" */

class URLExtraction
{
    static void GetURLElements(string input)
    {
        var elements = Regex.Match(input, "(.*)://(.*?)(/.*)").Groups;
        Console.WriteLine(elements[1]);
        Console.WriteLine(elements[2]);
        Console.WriteLine(elements[3]);
    }
    static void Main()
    {
        string url = Console.ReadLine();
        GetURLElements(url);
    }
}

