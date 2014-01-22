using System;
using System.Collections.Generic;

public class NumberAppearance
{
    /*   Write a method that counts how many times given number appears in given array. 
        * Write a test program to check if the method is working correctly.   */
    public static int Appearance(int[] integerArr, int number)
    {
        int times = 0;
        for (int i = 0; i < integerArr.Length; i++)
        {
            if (integerArr[i] == number)
            {
                times++;
            }
        }
        return times;
    }
    static void Main()
    {
        // Input
        Console.WriteLine("Enter array of integers:");
        string inputArray = Console.ReadLine();
        char[] delimiter = new char[] { ',', ' ' };
        string[] input = inputArray.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
        int[] arr = new int[input.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = int.Parse(input[i]);
        }
        Console.WriteLine("Enter the value K you are searching for : ");
        int k = int.Parse(Console.ReadLine());

        // Solution
        Console.WriteLine("Your number appear {0} times in the array!", Appearance(arr,k));
    }
}

