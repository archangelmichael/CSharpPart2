using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class FindClosestNumber
    {
        /*  Write a program, that reads from the console an array of N integers and an integer K, 
         * sorts the array and using the method Array.BinSearch() 
         * finds the largest number in the array which is ≤ K.  */
        static int Partition(int[] integerArr, int left, int right)
        {
            int pivot = integerArr[left];
            int i = left;
            int j = right + 1;
            while (true)
            {
                while (integerArr[++i] < pivot)
                {
                    if (i >= right)
                    {
                        break;
                    }
                }
                while (integerArr[--j] > pivot)
                {
                    if (j <= left)
                    {
                        break;
                    }
                }
                if (i >= j)
                {
                    break;
                }
                else
                {
                    Swap(integerArr, i, j);
                }
            }
            if (j == left)
            {
                return j;
            }
            Swap(integerArr, left, j);
            return j;
        }
        static void QuickSortCast(int[] integerArr, int left, int right)
        {
            int q;
            if (right > left)
            {
                q = Partition(integerArr, left, right);
                QuickSortCast(integerArr, left, q - 1);
                QuickSortCast(integerArr, q + 1, right);
            }
        }
        static void Swap(int[] integerArr, int i, int j)
        {
            int temp = integerArr[i];
            integerArr[i] = integerArr[j];
            integerArr[j] = temp;
        }

        static void Main()
        {
            // Input
            Console.WriteLine(" Enter number of integers in array: ");
            int n = int.Parse(Console.ReadLine());

            string[] input;
            do
            {
                Console.WriteLine("Enter array of integers:");
                string inputArray = Console.ReadLine();
                char[] delimiter = new char[] { ',', ' ' };
                input = inputArray.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
            } while (n!= input.Length);

            Console.WriteLine("Enter the value K you are searching for : ");
            int k = int.Parse(Console.ReadLine());

            int[] arr = new int[input.Length];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(input[i]);
            }

            // Sorting the array
            Console.WriteLine(string.Join(", ", arr));
            QuickSortCast(arr, 0, arr.Length - 1);
            Console.WriteLine(string.Join(", ", arr));

            // Solution

            int elemIndex = Array.BinarySearch(arr, k);
            while (elemIndex < 0)
            {
                if (k < arr[0])
                {
                    break;
                }
                k--;
                elemIndex = Array.BinarySearch(arr, k);
            }
            if (elemIndex < 0)
            {
                Console.WriteLine("Element not found!");
            }
            else
            {
                Console.WriteLine("Element <= K found at index [{0}] = {1}", elemIndex, arr[elemIndex]);
            }
        }
    }

