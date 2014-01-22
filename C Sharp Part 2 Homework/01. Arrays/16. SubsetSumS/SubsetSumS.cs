using System;
using System.Collections.Generic;

class SubsetSumS
{
    /*  * We are given an array of integers and a number S. 
         * Write a program to find if there exists a subset of the elements of the array that has a sum S. 
         * Example: arr={2, 1, 2, 4, 3, 5, 2, 6}, S=14  yes (1+2+5+6) */
    static bool sumPossible = false;
    static void Check(int[] arr, int[] subsets, int k, int sum)
    {
        int currentSum = 0;
        for (int i = 0; i <= k; i++)
        {
            currentSum += arr[subsets[i]];
        }
        if (currentSum == sum)
        {
            sumPossible = true;
            for (int i = 0; i <= k; i++)
            {
                Console.Write(arr[subsets[i]]);
                if (i == k)
	            {
		            Console.WriteLine();
	            }
                else
                {
                    Console.Write(" + ");
                }
            }
        }
    }

    static void Combination(int[] arr, int[] subsets, int k, int sum, int i, int next)
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
                Check(arr, subsets, k, sum);
            }
            Combination(arr, subsets, k, sum, i + 1, j + 1);
        }
    }

    static void Main()
    {
        //Input
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
        Console.Write("Enter sum you are searching for: ");
        int sum = int.Parse(Console.ReadLine());

        // Solution

        int[] subsets = new int[arr.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            Combination(arr, subsets, i, sum, 0, 0);
        }
        if (!sumPossible)
        {
            Console.WriteLine("No such sum possible!");
        }
    }
}

