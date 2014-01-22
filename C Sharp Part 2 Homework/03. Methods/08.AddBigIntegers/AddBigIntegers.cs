using System;
using System.Collections.Generic;

public class AddBigIntegers
{
    /*  Write a method that adds two positive integer numbers represented as arrays of digits 
     * (each array element arr[i] contains a digit; the last digit is kept in arr[0]). 
     * Each of the numbers that will be added could have up to 10 000 digits.   */
    public static void PrintNumber(int[] result)
    {
        for (int i = result.Length - 1; i >= 0; i--)
        {
            if (result[i] == 0 && i == result.Length-1)
            {
                continue;
            }
            Console.Write(result[i]);
        }
        Console.WriteLine();
        return;
    }
    public static int[] SumBigIntegers(int[] first, int[] second)
    {
        if (first.Length > second.Length)
        {
            return SumBigIntegers(second, first);
        }
        int[] result = new int[second.Length + 1];
        int i = 0;
        int rest = 0;

        // For each digit in both arrays
        for (; i < first.Length; i++)
        {
            result[i] = (byte)(first[i] + second[i] + rest);
            rest = result[i] / 10;
            result[i] %= 10;
        }
        // If there is still a carry: 1 + 999 - twice; 1 + 99 - once, but not with 1 + 9
        for (; i < second.Length && rest != 0; i++)
        {
            result[i] = (byte)(second[i] + rest);
            rest = result[i] / 10;
            result[i] %= 10;
        }
        // If the second array has digits left: 1 + 100 - twice; 1 + 10 once; but not with 1 + 9 or 1 + 99
        for (; i < second.Length; i++)
        {
            result[i] = second[i];
        }
        // If there is still a carry: 1 + 9; 1 + 99, but not 1 + 8999
        if (rest != 0)
        {
            result[i] = 1;
        }
        else
        {
            Array.Resize(ref result, result.Length - 1); // Last digit not needed, remove it from the array
        }
        return result;
    }

    static void Main()
    {
        // Input
        Console.WriteLine("Enter first BigInteger:");
        string input = Console.ReadLine();
        int[] arr1 = new int[input.Length];
        for (int i = 0; i < arr1.Length; i++)
        {
            arr1[i] = int.Parse(input[input.Length - 1 - i].ToString());
        }
        Console.WriteLine("Enter second BigInteger:");
        input = Console.ReadLine();
        int[] arr2 = new int[input.Length];
        for (int i = 0; i < arr2.Length; i++)
        {
            arr2[i] = int.Parse(input[input.Length - 1 - i].ToString());
        }
        // Solution
        PrintNumber(SumBigIntegers(arr1, arr2));  
     
        // Tests
        PrintNumber(SumBigIntegers(new int[] { 1 , 9 , 9 }, new int[] { 9 }));// first bigger
        Console.WriteLine();

        PrintNumber(SumBigIntegers(new int[] { 0, 1 }, new int[] { 1 })); // general test
        Console.WriteLine();

        PrintNumber(SumBigIntegers(new int[] { 1 }, new int[] { 9 })); // result with more digits than both
        Console.WriteLine();

        PrintNumber(SumBigIntegers(new int[] { 1 }, new int[] { 9, 9 })); // result with more digits
        Console.WriteLine();

        PrintNumber(SumBigIntegers(new int[] { 1 , 2 }, new int[] { 9, 7, 9 }));// second bigger
        Console.WriteLine();
    }
}

