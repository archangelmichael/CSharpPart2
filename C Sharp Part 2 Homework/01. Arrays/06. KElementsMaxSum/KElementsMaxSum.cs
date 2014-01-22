using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class KElementsMaxSum
{
    static void Main()
    {
        /*  Write a program that reads two integer numbers N and K and an array of N elements from the console. 
         * Find in the array those K elements that have maximal sum.    */

        // Solution without sorting

        // Declaring array
        Console.Write("Number of elements of array = ");
        int N = int.Parse(Console.ReadLine());
        Console.Write("Number of elements to sum = ");
        int K = int.Parse(Console.ReadLine());
        int[] arr = new int[N];
        for (int i = 0; i < N; i++)
        {
            Console.Write("arr[{0}] = ", i);
            arr[i] = int.Parse(Console.ReadLine());
        }

        // Solution
        List<int> subset = new List<int>();

        if (K < N)
        {
            for (int i = 0; i < K; i++)
            {
                int bigger = int.MinValue;
                int position = 0;
                for (int j = 0; j < N; j++)
                {
                    if (arr[j] > bigger)
                    {
                        bigger = arr[j];
                        position = j;
                    }
                }
                arr[position] = int.MinValue;
                subset.Add(bigger);
            }
            
            // Output
            string result = "{" + string.Join(",",subset) + "}";
            Console.WriteLine(result);
        }

        else
        {
            Console.WriteLine(" Wrong Input! K<N");
        }
    }
}

