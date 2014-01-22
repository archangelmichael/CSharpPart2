using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class SelectionSort
{
    static void Main()
    {
        /*  Sorting an array means to arrange its elements in increasing order. 
         * Write a program to sort an array. Use the "selection sort" algorithm: 
         * Find the smallest element, move it at the first position, 
         * find the smallest from the rest, move it at the second position, etc.   */
        // Declaring array
        Console.Write("Number of elements of array = ");
        int N = int.Parse(Console.ReadLine());
        int[] arr = new int[N];
        for (int i = 0; i < N; i++)
        {
            Console.Write("arr[{0}] = ", i);
            arr[i] = int.Parse(Console.ReadLine());
        }

        // Solution
        int swapValue = 0;
        int sorted = 0;
        while (sorted < N)
        {
            int lowest = int.MaxValue;
            int position = sorted;
            for (int j = sorted; j < N; j++)
            {
                if (arr[j] < lowest)
                {
                    lowest = arr[j];
                    position = j;
                }
            }
            swapValue = arr[sorted];
            arr[sorted] = arr[position];
            arr[position] = swapValue;
            sorted++;
        }
        // Output - SortedArray
        Console.WriteLine("{"+ string.Join(",",arr) +"}");
    }    
}

