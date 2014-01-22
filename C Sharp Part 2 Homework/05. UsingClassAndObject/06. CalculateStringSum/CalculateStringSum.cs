using System;
/*  You are given a sequence of positive integer values written into a string, separated by spaces.
 * Write a function that reads these values from given string and calculates their sum. 
 * Example:		string = "43 68 9 23 318"  result = 461 */

class CalculateStringSum
{
    static void Main()
    {
        char [] separators = {' ',',','.',':',';','{','}','(',')','-'};
        Console.WriteLine("Enter string of numbers: ");
        string[] inputs = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
        int sum = 0;
        foreach (string input in inputs)
        {
            sum += int.Parse(input);
        }
        Console.WriteLine(sum);
    }
}

