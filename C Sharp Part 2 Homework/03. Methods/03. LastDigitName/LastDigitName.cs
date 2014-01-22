using System;
using System.Collections.Generic;

class LastDigitName
{
    /* Write a method that returns the last digit of given integer as an English word. 
     * Examples: 512  "two", 1024  "four", 12309  "nine". */
    static int GetLastDigit(int number)
    {
        if (number < 0)
        {
            number *= -1;
        }
        return number % 10;
    }
    static void GetLastDigitName(int number)
    {
        int digit = GetLastDigit(number);
        string[] names = {"Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine"};
        Console.WriteLine(names[digit]);
        return;
    }
    static void Main()
    {
        Console.WriteLine("Enter number: ");
        int number = int.Parse(Console.ReadLine());
        GetLastDigitName(number);
    }
}

