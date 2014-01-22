using System;
using System.Collections.Generic;

class GetMaxMethod
{
    /*  Write a method GetMax() with two parameters that returns the bigger of two integers. 
     * Write a program that reads 3 integers from the console and prints the biggest of them using the method GetMax().*/
    static int GetMax (int one,int two)
    {
        int bigger = one;
        if (two > one)
        {
            bigger= two;
        }
        return bigger;
    }
    static void Main()
    {
        Console.WriteLine("Enter first number: ");
        int first = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter second number: ");
        int second = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter third number: ");
        int third = int.Parse(Console.ReadLine());
        int maxNumber = GetMax( GetMax(first, second), third);
        Console.WriteLine(maxNumber);
    }
}

