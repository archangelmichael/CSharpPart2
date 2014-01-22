using System;
using System.Collections.Generic;


class AlphabetArray
{
    static void Main()
    {
        /* Write a program that creates an array containing all letters from the alphabet (A-Z).
         * Read a word from the console and print the index of each of its letters in the array. */
        char[] letters = new char[26];
        for (int i = 0; i < 26; i++)
        {
            letters[i] = (char) (i + 65);
        }
        string word = Console.ReadLine();
        for (int i = 0; i < word.Length; i++)
        {
            for (int j = 0; j < letters.Length; j++)
            {
                if (word[i] == letters [j])
                {
                    Console.WriteLine(j);
                }
            }
        }
    }
}

