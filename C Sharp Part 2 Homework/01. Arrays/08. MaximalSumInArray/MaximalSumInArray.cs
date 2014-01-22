using System;
using System.Collections.Generic;
class MaximalSumInArray
{
    static void Main()
    {
        /*  Write a program that finds the sequence of maximal sum in given array. Example:
	        {2, 3, -6, -1, 2, -1, 6, 4, -8, 8}  {2, -1, 6, 4}
	        Can you do it with only one loop (with single scan through the elements of the array)? */
        // Input
        string inputArray = Console.ReadLine();
        char[] delimiter = new char[] { ',', ' ' };
        string[] input = inputArray.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
        int[] arr = new int[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            arr[i] = int.Parse(input[i]);
        }
        List<int> subset = new List<int>();
        // Solution
        string result = "";
        int maxSum = 0;
        int currentSum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            subset.Add(arr[i]);
            currentSum += arr[i];
            if (currentSum > maxSum)
            {
                maxSum = currentSum;
            }
            else if (currentSum < 0)
            {
                currentSum = 0;
                subset.Clear();
            }
        }
        // Output
        result = "{" + string.Join(",", subset) + "}";
        Console.WriteLine(result);
        Console.WriteLine(maxSum);
    }
}
