using System;
using System.Collections.Generic;

class GeneratePermutations
{
    /*  * Write a program that reads a number N and generates and prints all the permutations of the numbers [1 … N]. 
         * Example: 	n = 3  {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2}, {3, 2, 1}  */
    static void Check(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i] + 1);
            if (i == arr.Length - 1)
            {
                Console.WriteLine();
            }
            else
            {
                Console.Write(" ");
            }
        }
    }
    static void Permutation(int[] arr, bool[] used, int i)
    {
        if (i == arr.Length)
        {
            Check(arr);
            return;
        }

        for (int j = 0; j < arr.Length; j++)
        {
            if (used[j]) continue;

            arr[i] = j;

            used[j] = true;
            Permutation(arr, used, i + 1);
            used[j] = false;
        }
    }
    static void Main()
    {
        int[] arr = new int[int.Parse(Console.ReadLine())];
        bool[] used = new bool[arr.Length];
        Permutation(arr, used, 0);
    }
}

