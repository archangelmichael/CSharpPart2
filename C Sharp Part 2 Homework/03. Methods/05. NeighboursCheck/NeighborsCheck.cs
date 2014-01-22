using System;
using System.Collections.Generic;

public class NeighborsCheck
{
    /*  Write a method that checks if the element at given position 
     * in given array of integers is bigger than its two neighbors (when such exist). */
    public static int Neighbors(int[] integerArr, int position)
    {
        if (position < 0 || position >= integerArr.Length)
        {
            Console.WriteLine("Entered position is invalid!");
            Environment.Exit(0);
            return -1;
        }
        else if (position == 0 || position == integerArr.Length-1)
        {
            return -1;
        }
        else
        {
            if (integerArr[position] > integerArr[position -1] && integerArr[position] > integerArr[position + 1] )
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
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

        Console.WriteLine("Enter the position you are testing for : ");
        int k = int.Parse(Console.ReadLine());

        // Solution
        int result = Neighbors(arr, k);
        // Output
        if (result == 1)
        {
            Console.WriteLine("The element at position {0} is bigger than his neighbors!", k);
        }
        else
        {
            Console.WriteLine("The element at position {0} is not bigger than his neighbors!", k);
        }
    }
}

