using System;

class CalculateFactorial
{
    /*  Write a program to calculate n! for each n in the range [1..100]. 
     * Hint: Implement first a method that multiplies a number represented 
     * as array of digits by given integer number. */
    // Using methods SumBigIntegers and PrintNumber from task 8 ( class AddBigIntegers
    static int[] MultiplyBigIntegers(int[] arr, int number)
    {
        int[] result = { 0 };
        for (int i = 0; i <= number; i++)
        {
            result = AddBigIntegers.SumBigIntegers(result, arr);
        }
        return result;
    }

    static void Main()
    {
        int[] factorial = {1};
        for (int i = 0; i < 100; i++)
        {
            factorial = MultiplyBigIntegers(factorial, i);
            AddBigIntegers.PrintNumber(factorial);
        }
    }
}

