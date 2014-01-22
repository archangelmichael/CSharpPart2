using System;

/*  Write a program that can solve these tasks:
Reverses the digits of a number
Calculates the average of a sequence of integers
Solves a linear equation a * x + b = 0
		Create appropriate methods.
		Provide a simple text-based menu for the user to choose which task to solve.
		Validate the input data:
The decimal number should be non-negative
The sequence should not be empty
a should not be equal to 0      */

class SolveTasks
{
    static long ReverseDigits(long number, long result = 0)
    {
        if (number == 0)
        {
            return result;
        }
        return ReverseDigits(number / 10, result * 10 + (number % 10));
    }
    static void CheckReverseNumber()
    {
        Console.WriteLine("Enter a number to reverse:");
        long number = long.Parse(Console.ReadLine());
        if (number < 0 )
        {
            Console.WriteLine("The number should be positive!");
            CheckReverseNumber();
            return;
        }
        else
        {
            Console.WriteLine(" Your reverse number is: " + ReverseDigits(number));
            return;
        }
    }

    static double GetAverage(int[] arr)
    {
        double sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }
        return sum / arr.Length;
    }
    static void CheckAverageNumbers()
    {
        Console.WriteLine("Enter array size and numbers:");
        int[] arr = new int[int.Parse(Console.ReadLine())];
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }
        if (arr.Length > 0)
        {
            Console.WriteLine("Your average sum is: " + GetAverage(arr));
            return;
        }
        else
        {
            Console.WriteLine("Array should have elements.");
            CheckAverageNumbers();
            return;
        }
    }

    static double SolveEquation(int a, int b)
    {
        return (double)-b / a;
    }
    static void CheckEquation()
    {
        Console.WriteLine("Please enter a and b of your equation:");
        int a = int.Parse(Console.ReadLine());
        if (a == 0)
        {
            Console.WriteLine("Coeficient \"a\" should not be 0!");
            CheckEquation();
            return;
        }
        else
        {
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("The solution of your equation is: " + SolveEquation(a, b));
            return;
        }
    }

    static void Main()
    {
        // Input
        Console.WriteLine("Press 0 to ReverseDigits, 1 to GetAverage or 2 to SolveEquation:");
        int selection = int.Parse(Console.ReadLine());

        // Solution
        switch (selection)
        {
            case 0:
                CheckReverseNumber();
                break;
            case 1:
                CheckAverageNumbers();
                break;
            case 2:
                CheckEquation();
                break;
            default:
                Console.WriteLine("Invalid selection!");
                break;
        }
    }
}

