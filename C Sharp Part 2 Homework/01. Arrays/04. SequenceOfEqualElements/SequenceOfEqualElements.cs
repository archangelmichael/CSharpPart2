using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SequenceOfEqualElements
{
    static void Main()
    {
        /*  Write a program that finds the maximal sequence of equal elements in an array.
		Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1}  {2, 2, 2}.    */

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
        int bestLength = 0;
        
        for (int i = 0; i < arr.Length; i++)
        {
            int start = i;
            int len = 0;
            for (int j = i; j < arr.Length; j++)
            {
                if (arr[i] == arr[j])
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
        for (int i = bestStart; i < bestStart+bestLength; i++)
        {
            result += arr[i];
            if (i == bestStart+bestLength -1)
            {
                result += "}";
                break;
            }
            result += ",";
        }
        Console.WriteLine(result);
    }
}

