using System;
using System.Collections.Generic;

/* Write a program that reads a list of words, 
 * separated by spaces and prints the list in an alphabetical order. */

class SortWords
{
    static void Main()
    {
        string[] words = Console.ReadLine().Split(' ');
        Array.Sort(words);
        foreach (var word in words)
        {
            Console.WriteLine(word);
        }
        // if i havent understood right and i need to use List for solution
        //var sorted = new List<string>();
        //foreach (var word in words)
        //{
        //    sorted.Add(word);
        //}
        //sorted.Sort();
        //foreach (var word in sorted)
        //{
        //    Console.WriteLine(word);
        //}
    }
}

