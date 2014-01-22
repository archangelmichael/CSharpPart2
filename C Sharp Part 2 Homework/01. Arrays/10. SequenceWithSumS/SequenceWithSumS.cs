using System;
using System.Collections.Generic;

class SequenceWithSumS
{
    static void Main()
    {
        /*  Write a program that finds in given array of integers a sequence of given sum S (if present). 
         * Example:	 {4, 3, 1, 4, 2, 5, 8}, S=11  {4, 2, 5}    */
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
        List<int> subset = new List<int>();
        string result = "";
        for (int i = 0; i < arr.Length; i++)
        {
            subset.Clear();
            int currentSum = 0;
            for (int j = i; j < arr.Length; j++)
            {
                currentSum += arr[j];
                subset.Add(arr[j]);
                if (currentSum == sum)
                {
                    result = "{" + string.Join(",", subset) + "}";
                    Console.WriteLine(result);
                    break;
                }
            }
        }
        if (result == "")
        {
            Console.WriteLine("There isnt any set that has sum = {0}!",sum);
        }
    }
}

