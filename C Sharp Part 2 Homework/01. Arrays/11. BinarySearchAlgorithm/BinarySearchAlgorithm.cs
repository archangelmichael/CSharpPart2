using System;
using System.Linq;
using System.Collections.Generic;

class BinarySearchAlgorithm
{
    /*  Write a program that finds the index of given element in a sorted array of integers 
         * by using the binary search algorithm (find it in Wikipedia).*/

    static int FindIndex(int [] values, int target) 
    {
        return BinarySearch (values, target, 0, values.Length - 1);
    }

    static int BinarySearch(int[] values,int target,int start,int end) 
    {
        if (start > end) 
        {
            return -1; 
        } //does not exist
        int middle =  (int)Math.Floor ( (double)(start + end) / 2) ;
        int value = values[middle];
        if (value > target) 
        { 
            return BinarySearch (values, target, start, middle-1); 
        }
        if (value < target) 
        { 
            return BinarySearch (values, target, middle+1, end); 
        }
        return middle; //found!
    }

    static void SelectionSort(int[] list, int last) 
    { 
        int current, walker, smallest, tempData; 
        for (current = 0; current < last; current ++)
        { 
             smallest = current; 
             for (walker = current + 1; walker < last; walker++) 
             {
                 if(list[walker] < list[smallest]) 
                 smallest = walker; 
                 // Smallest selected; swap with current element 
                 tempData = list[current]; 
                 list[current] = list[smallest]; 
                 list[smallest] = tempData; 
             }
        } 
    } 

    static void Main()
    {
        Console.WriteLine("Enter array of integers:");
        string inputArray = Console.ReadLine();
        char[] delimiter = new char[] { ',', ' ' };
        string[] input = inputArray.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
        int[] arr = new int[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            arr[i] = int.Parse(input[i]);
        }
        
        // The array must be sorted before BinarySearch
        SelectionSort(arr , arr.Length);
        
        Console.Write("Enter the number you are searching for: ");
        int number = int.Parse(Console.ReadLine());
        int index = FindIndex (arr, number);
        Console.WriteLine(index);
    }
}

