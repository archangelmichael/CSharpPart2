using System;
using System.Collections.Generic;

class QuickSort
{
    static int Partition(string[] stringArr, int left, int right)
    {
        string pivot = stringArr[left];
        int i = left;
        int j = right + 1;
        while (true)
        {
            while (string.Compare(stringArr[++i], pivot) < 0  )
            {
                if (i >= right)
	            {
		            break;
	            }
            }
            while (string.Compare(stringArr[--j], pivot) > 0 )
	        {
                if (j <= left)
	            {
		             break;
	            }
	        }
            if (i>= j)
            {
                break;
            }
            else
            {
                Swap(stringArr,i,j);
            }
        }
        if (j == left)
        {
            return j;
        }
        Swap(stringArr,left,j);
        return j;
    }
    static void QuickSortCast(string[] stringArr, int left, int right)
    {
        int q;
        if (right > left)
        {
            q = Partition(stringArr, left, right);
            QuickSortCast(stringArr, left, q - 1);
            QuickSortCast(stringArr, q + 1, right);
        }
    }
    static void Swap(string[] stringArr, int i, int j)
    {
        string temp = stringArr[i];
        stringArr[i] = stringArr[j];
        stringArr[j] = temp;
    }

    static void Main()
    {
        /* Write a program that sorts an array of strings using the quick sort algorithm (find it in Wikipedia).*/
        Console.WriteLine("Enter array of strings:");
        string inputArray = Console.ReadLine();
        char[] delimiter = new char[] { ',', ' ' };
        string[] input = inputArray.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
        string[] arr = new string[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            arr[i] = input[i];
        }
        QuickSortCast (arr, 0, arr.Length - 1);
        Console.WriteLine(string.Join (", ", arr));
    }
}

