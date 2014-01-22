using System;
using System.Collections.Generic;

/*  * Modify your last program and try to make it work for any number type, 
 * not just integer (e.g. decimal, float, byte, etc.). Use generic method 
 * (read in Internet about generic methods in C#). */
class UseGenericMethods
{

    static T FindMin<T>(params T[] numbers) where T : IComparable<T>
    {
        dynamic min = int.MaxValue;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i].CompareTo(min) < 0)
            {
                min = numbers[i];
            }
        }
        return min;
    }
    static T FindMax<T>(params T[] numbers) where T : IComparable<T>
    {
        dynamic max = int.MinValue;
        foreach (dynamic num in numbers)
        {
            if (num.CompareTo(max) > 0)
            {
                max = num;
            }
        }
        return max;
    }
    static T CalculateSum<T>(params T[] numbers)
    {
        dynamic sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }
        return sum;
    }
    static double CalculateAverage <T>(params T[] numbers)
    {
        return Convert.ToDouble(CalculateSum(numbers)) / numbers.Length;
    }
    static T CalculateProduct<T>(params T[] numbers)
    {
        dynamic product = 1;
        foreach (dynamic num in numbers)
        {
            product *= num;
        }
        return product;
    }

    static void Main()
    {
        Console.WriteLine("Min: " + FindMin(4, 6, 9, 1, -32.389, 4, -3, 532123));
        Console.WriteLine("Max: " + FindMax(11, 5, 103, 1003, 2.389, 999, -2314));
        Console.WriteLine("Sum: " + CalculateSum(45, 76, 98, 11, 9));
        Console.WriteLine("Average: " + CalculateAverage(5, 23333, -13222, 11, 9, 12));
        Console.WriteLine("Product: " + CalculateProduct(5, 1, 19, 123123, 54));
    }
}

