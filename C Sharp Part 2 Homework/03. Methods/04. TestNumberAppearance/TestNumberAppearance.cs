using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TestNumberAppearance
{
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
        Console.WriteLine("Enter the value K you are searching for : ");
        int k = int.Parse(Console.ReadLine());

        int count = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == k)
            {
                count++;
            }
        }
        if (count == NumberAppearance.Appearance(arr,k))
        {
            Console.WriteLine("Method works correctly!");
        }
        else
        {
            Console.WriteLine("Method works incorrectly!");
        }
    }
}

