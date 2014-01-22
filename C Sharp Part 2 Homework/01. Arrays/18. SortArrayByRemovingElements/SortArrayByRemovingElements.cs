using System;
using System.Collections.Generic;

class SortArrayByRemovingElements
{
    /*  * Write a program that reads an array of integers and removes from it a minimal number of elements 
         * in such way that the remaining array is sorted in increasing order. 
         * Print the remaining sorted array. Example:
	     * {6, 1, 4, 3, 0, 3, 6, 4, 5}  {1, 3, 3, 4, 5}  */
    
    static void Check(int[] arr, int[] subsets, int k)
    {
        for (int i = 0; i < k; i++)
        {
            if (arr[subsets[i]] > arr[subsets[i + 1]])
            {
                return;
            }
        }
        for (int i = 0; i <= k; i++)
        {
            Console.Write(arr[subsets[i]]);
            if (i == k)
	        {
		        Console.WriteLine();
	        }
            else
            {
                Console.Write(" ");
            }
        }
        Environment.Exit(0);
    }

    static void Combination(int[] arr, int[] subsets, int k, int i, int next)
    {
        if (i > k)
        {
            return;
        }
        for (int j = next; j < arr.Length; j++)
        {
            subsets[i] = j;
            if (i == k)
            {
                Check(arr, subsets, k);
            }
            Combination(arr, subsets, k, i + 1, j + 1);
        }
    }

    static void Main()
    {
        Console.WriteLine("Enter numbers in the array: ");
        string inputArray = "";
        while (inputArray == "")
        {
            inputArray = Console.ReadLine();
        }
        char[] delimiter = new char[] { ',', ' ' };
        string[] input = inputArray.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
        int[] arr = new int[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            arr[i] = int.Parse(input[i]);
        }

        // Solution
        int[] subsets = new int[arr.Length];
        for (int i = arr.Length - 1; i >= 0; i--)
        {
            Combination(arr, subsets, i, 0, 0);
        }
    }
}

