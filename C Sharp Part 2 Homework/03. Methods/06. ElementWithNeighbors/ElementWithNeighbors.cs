using System;
using System.Collections.Generic;

class ElementWithNeighbors
{
    /*  Write a method that returns the index of the first element in array 
     * that is bigger than its neighbors, or -1, if there’s no such element. 
        Use the method from the previous exercise. */
    static void Main()
    {
        Console.WriteLine("Enter array of integers:");
        string inputArray = Console.ReadLine();
        char[] delimiter = new char[] { ',', ' ' };
        string[] input = inputArray.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
        int[] arr = new int[input.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = int.Parse(input[i]);
        }

        // Solution
        bool isBigger = false;
        for (int i = 0; i < arr.Length; i++)
        {
            // Use method Neighbours();  from previous task with reference as requested
            int result = NeighborsCheck.Neighbors(arr, i);
            if (result == 1)
            {
                Console.WriteLine("Element with index {0} is bigger than his neightbors!", i);
                isBigger = true;
                break;
            }
        }
        if (!isBigger)
        {
            Console.WriteLine(-1);
        } 
    }
}