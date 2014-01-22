using System;
using System.Numerics;
/*  Write methods to calculate minimum, maximum, average, sum 
 * and product of given set of integer numbers. Use variable number of arguments.   */

class CalculateWithVariableArguments
{
    static int FindMin(params int[] numbers)
    {
        int min = int.MaxValue;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] < min)
            {
                min = numbers[i];
            }
        }
        return min;
    }
    static int FindMax(params int[] numbers)
    {
        int max = int.MinValue;
        foreach (int num in numbers)
        {
            if (num > max)
            {
                max = num;
            }
        }
        return max;
    }
    static long CalculateSum(params int[] numbers)
    {
        int sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }
        return sum;
    }
    static double CalculateAverage(params int[] numbers)
    {
        return (double)CalculateSum(numbers) / numbers.Length;
    }
    static BigInteger CalculateProduct(params int[] numbers)
    {
        BigInteger product = 1;
        foreach (int num in numbers)
        {
            product *= num;
        }
        return product;
    }

    static void Main()
    {
        Console.WriteLine("Min: " + FindMin(4, 6, 9, 1, 4, -3, 532123));
        Console.WriteLine("Max: " + FindMax(11, 5, 103, 1003, 89, 999, -2314));
        Console.WriteLine("Sum: " + CalculateSum(45, 76, 98, 11, 9));
        Console.WriteLine("Average: " + CalculateAverage(5, 23333, -13222, 11, 9, 12));
        Console.WriteLine("Product: " + CalculateProduct(5, 1, 19, 123123, 54));
    }
}

