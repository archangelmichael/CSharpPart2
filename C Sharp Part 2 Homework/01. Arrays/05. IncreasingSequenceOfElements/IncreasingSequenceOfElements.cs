using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class IncreasingSequenceOfElements
{
    static void Main()
    {
        /*  Write a program that finds the maximal increasing sequence in an array. 
         * Example: {3, 2, 3, 4, 2, 2, 4}  {2, 3, 4}.    */

        // Declaring array
        string inputArrayOne = Console.ReadLine();
        char[] delimiter = new char[] { ',', ' ' };
        string[] inputOne = inputArrayOne.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
        int[] arr = new int[inputOne.Length];
        for (int i = 0; i < inputOne.Length; i++)
        {
            arr[i] = int.Parse(inputOne[i]);
        }

        // Solution
        int bestStart = 0;
        int bestLength = 1;

        for (int i = 0; i < arr.Length; i++)
        {
            int start = i;
            int len = 1;
            for (int j = i; j < arr.Length - 1; j++)
            {
                if (arr[j] < arr[j+1])
                {
                    len++;
                }
                else
                {
                    break;
                }
            }
            if (len > bestLength)
            {
                bestLength = len;
                bestStart = start;
            }
        }

        // Output
        string result = "{";
        for (int i = bestStart; i < bestStart + bestLength; i++)
        {
            result += arr[i];
            if (i == bestStart + bestLength - 1)
            {
                result += "}";
                break;
            }
            result += ",";
        }
        Console.WriteLine(result);
    }
}

