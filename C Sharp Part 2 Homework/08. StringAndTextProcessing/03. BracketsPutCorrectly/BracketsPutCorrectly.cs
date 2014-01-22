using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*  Write a program to check if in a given expression the brackets are put correctly.
 * Example of correct expression: ((a+b)/5-d).
 * Example of incorrect expression: )(a+b)).   */

class BracketsPutCorrectly
{
    static bool CheckBrackets(string input)
    {
        int counter = 0;
        if (input[0] == ')')
        {
            return false;
        }
        for (int i = 0; i < input.Length && counter >= 0; i++)
        {
            if (input[i] == '(')
            {
                counter++;
            }
            else if (input[i] == ')')
            {
                counter--;
            }
        }
        if (counter == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    static void Main()
    {
        string input = Console.ReadLine();
        bool bracketsOK = CheckBrackets(input);
        if (bracketsOK)
        {
            Console.WriteLine("Correct brackets!");
        }
        else
        {
            Console.WriteLine("Incorrect brackets!");
        }
    }
}


