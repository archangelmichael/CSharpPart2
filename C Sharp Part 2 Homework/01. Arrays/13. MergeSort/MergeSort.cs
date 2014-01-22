using System;
using System.Collections.Generic;

class MergeSort
{
    /* * Write a program that sorts an array of integers using the merge sort algorithm (find it in Wikipedia).  */

    static public void Merge(int[] numbers, int left, int mid, int right)
    {
        int[] temp = new int[25];
        int i, left_end, num_elements, tmp_pos;

        left_end = (mid - 1);
        tmp_pos = left;
        num_elements = (right - left + 1);

        while ((left <= left_end) && (mid <= right))
        {
            if (numbers[left] <= numbers[mid])
                temp[tmp_pos++] = numbers[left++];
            else
                temp[tmp_pos++] = numbers[mid++];
        }

        while (left <= left_end)
            temp[tmp_pos++] = numbers[left++];

        while (mid <= right)
            temp[tmp_pos++] = numbers[mid++];

        for (i = 0; i < num_elements; i++)
        {
            numbers[right] = temp[right];
            right--;
        }
    }

    static public void MergeSortRecursive(int[] numbers, int left, int right)
    {
        int mid;

        if (right > left)
        {
            mid = (right + left) / 2;
            MergeSortRecursive(numbers, left, mid);
            MergeSortRecursive(numbers, (mid + 1), right);

            Merge(numbers, left, (mid + 1), right);
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
        for (int i = 0; i < input.Length; i++)
        {
            arr[i] = int.Parse(input[i]);
        }

        // Solution
        MergeSortRecursive(arr, 0, arr.Length - 1);

        // Output
        Console.WriteLine("{" + string.Join(", ", arr) + "}");
        

    }
}

