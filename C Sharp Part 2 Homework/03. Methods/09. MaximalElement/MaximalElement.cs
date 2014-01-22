using System;

class MaximalElement
{
    /*  Write a method that return the maximal element in a portion of 
     * array of integers starting at given index. Using it write another
     * method that sorts an array in ascending / descending order.  */
    static void PrintArray(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i]);
            if (i < arr.Length - 1)
            {
                Console.Write(" ");
            }
        }
        Console.WriteLine();
    }
    static void Swap (int [] arr, int i, int j)
    {
        int swapValue = arr[i];
        arr[i] = arr[j];
        arr[j] = swapValue;
    }
    static void SelectionSort(int[] arr, bool descending = false)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Swap(arr, i, GetBestIndex(arr, i, descending));
        }
    }
    static int GetBestIndex(int[] arr, int i, bool descending = false)
    {
        int best = i;
        for (i++; i < arr.Length; i++)
        {
            if (descending)
            {
                if (arr[i] < arr[best])
                {
                    best = i;
                }
            }
            else
            {
                if (arr[best] < arr[i])
                {
                    best = i;
                }
            }
        }
        return best;
    }
    static void Main()
    {
        // Input
        Console.WriteLine("Enter array of integers:");
        string inputArray = Console.ReadLine();
        char[] delimiter = new char[] { ',', ' ','[',']','{','}',';'};
        string[] input = inputArray.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
        int[] arr = new int[input.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = int.Parse(input[i]);
        }
        Console.WriteLine(" Enter index you want to start from:");
        int index = int.Parse(Console.ReadLine());
        // Solution
        Console.WriteLine(arr[GetBestIndex(arr,index)]);

        // Optional Array Sorting
        Console.WriteLine(" Choose order for sorting (1 - ascending; 2 - descending):");
        int wayToSort = int.Parse(Console.ReadLine());
        switch (wayToSort)
        {
            case 1:
                SelectionSort(arr, false);
                PrintArray(arr);
                break;
            case 2: 
                SelectionSort(arr, true);
                PrintArray(arr);
                break;
            default: Console.WriteLine(" You have entered invalid selection!");
                break;
        }
        
    }
}

