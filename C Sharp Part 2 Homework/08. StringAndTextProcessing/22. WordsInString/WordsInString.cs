using System;
using System.Collections;
using System.Collections.Generic;

/*  Write a program that reads a string from the console 
 * and lists all different words in the string along 
 * with information how many times each word is found. */
class WordsInString
{
    static void Main()
    {
        string[] words = Console.ReadLine().Split(new char[] { ' ', ',', '.', '!', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        IDictionary<string, int> dictionary = new SortedDictionary<string, int>();
        foreach (var word in words)  //with regular expression -> Match word in Regex.Matches(str, @"\w+")
        {
            if (dictionary.ContainsKey(word))
            {
                dictionary[word] = dictionary[word] + 1;
            }
            else //word is not contained
            {
                dictionary.Add(word, 1);
            }
        }
        foreach (var word in dictionary)
        {
            Console.WriteLine("{0,-15} - {1} times", word.Key, word.Value);
        }
    }
}

