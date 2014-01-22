using System;
using System.Collections.Generic;

class SubsetKWithSumS
{
    /*  * Write a program that reads three integer numbers N, K and S and an array of N elements from the console. 
         * Find in the array a subset of K elements that have sum S or indicate about its absence.        */
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
        Console.Write("Enter how many numbers you need: ");
        int k = int.Parse(Console.ReadLine());
        Console.Write("Enter sum you are searching for: ");
        int sum = int.Parse(Console.ReadLine());

        // Solution
        int[] subsets = new int[arr.Length];
        Combination(arr, subsets, k-1, sum, 0, 0);
        if (!sumPossible)
        {
            Console.WriteLine("No such sum possible!");
        }
    }
}


        

