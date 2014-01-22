﻿using System;

/*  Write a program that reads a string from the console and 
 * prints all different letters in the string along with 
 * information how many times each letter is found.  */
class LettersInString
{
    static void Main()
    {
        char[] symbols = new char[65536];
        string text = Console.ReadLine();
        for (int i = 0; i < text.Length; i++)
        {
            if ((text[i] >= 'a' &&  text[i] <= 'z')||(text[i] >= 'A' &&  text[i] <= 'Z'))
	        {
		         symbols[(int)text[i]]++;
	        }
        }
        for (int i = 0; i < symbols.Length; i++)
        {
            if (symbols[i] != 0 && ((i >= (int)'A' && i <= (int)'Z') || (i >= (int)'a' && i <= (int)'z')))
            {
                Console.WriteLine((char)i + " " + (int) symbols[i]);
            }
        }
    }
}

