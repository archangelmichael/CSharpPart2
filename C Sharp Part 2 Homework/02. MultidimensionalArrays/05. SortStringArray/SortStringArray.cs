using System;
using System.Collections.Generic;

    class SortStringArray
    {
        /*  You are given an array of strings. 
         * Write a method that sorts the array by the length of its elements 
         * (the number of characters composing them).   */
        static int LowestElement(int[] countsArr)
        {
            int lowest = 0;
            int lowValue = int.MaxValue;
            for (int j = 0; j < countsArr.Length; j++)
			{
                int current = countsArr[j];
                if (current < lowValue && current != 0)
	            {
                    lowValue = current;
		             lowest = j;
	            }
			}
            countsArr[lowest] = 0;
            return lowest;
        }
        static string[] SortByLength(string[] stringArr, int[] countsArr)
        {
            string [] copy = new string [stringArr.Length];
            for (int i = 0; i < stringArr.Length; i++)
            {
                copy[i] = stringArr[LowestElement(countsArr)];
            }
            return copy;
        }
        static void Main()
        {
            // Input
            Console.WriteLine("Enter array of strings:");
            string inputArray = Console.ReadLine();
            char[] delimiter = new char[] { ',', ' ' };
            string[] input = inputArray.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
            string[] arr = new string[input.Length];
            int[] counts = new int[arr.Length];
            for (int i = 0; i < input.Length; i++)
            {
                arr[i] = input[i];
                counts[i] = arr[i].Length;
            }
            // Solution
            string[] sorted = SortByLength(arr,counts);
            Console.WriteLine(string.Join(", ", sorted));
        }
    }

