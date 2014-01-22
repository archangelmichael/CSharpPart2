using System;
using System.Collections.Generic;
class MostFrequentNumber
{
    static void Main()
    {
        /*  Write a program that finds the most frequent number in an array. Example:
	        {4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3}  4 (5 times)   */
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
        int index = 0;
        int times = 1;
        int currentTimes = 1;
        for (int i = 0; i < arr.Length-1; i++)
        {
            for (int j = 1; j < arr.Length; j++)
            {
                if (arr[i] == arr[j])
                {
                    currentTimes ++;
                }
            }
            if (currentTimes > times)
	        {
		        times = currentTimes;
                index = i;
	        }
            currentTimes = 0;
        }
        // Output
        Console.WriteLine("Most frequent number is {0} ({1} times)",arr[index], times);
    }
}

