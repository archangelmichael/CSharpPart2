using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*  Extend program 11 to support also subtraction and multiplication of polynomials. */
class SubstractAndMultiplyPolynoms
{
    static void PrintPolynomial(int[] arr)
    {
        for (int i = arr.Length - 1; i >= 0; i--)
        {
            Console.Write(arr[i] + "*x^" + i);
            if (i == 0)
            {
                Console.WriteLine();

            }
            else
            {
                Console.Write(" + ");
            }
        }
        return;
    }
    static int[] AddPolynomial(int[] arr1, int[] arr2)
    {
        if (arr1.Length < arr2.Length)
        {
            return AddPolynomial(arr2, arr1);
        }
        int[] result = new int[arr1.Length];
        int coeficient = 0;
        for (; coeficient < arr2.Length; coeficient++)
        {
            result[coeficient] = arr1[coeficient] + arr2[coeficient];
        }
        for (; coeficient < arr1.Length; coeficient++)
        {
            result[coeficient] = arr1[coeficient];
        }
        return result;
    }
    static int[] SubstractPolynomial(int[] arr1, int[] arr2, bool reverse = false)
    {
        if (arr1.Length < arr2.Length)
        {
            return SubstractPolynomial(arr2, arr1, true);
        }
        int[] result = new int[arr1.Length];
        int coeficient = 0;
        for (; coeficient < arr2.Length; coeficient++)
        {
            if (reverse)
            {
                result[coeficient] = arr2[coeficient] - arr1[coeficient];
            }
            else
            {
                result[coeficient] = arr1[coeficient] - arr2[coeficient];
            }
        }
        for (; coeficient < arr1.Length; coeficient++)
        {
            if (reverse)
            {
                result[coeficient] = -arr1[coeficient];
            }
            else
            {
                result[coeficient] = arr1[coeficient];
            }
        }
        return result;
    }
    static int [] MultiplyPolynomial(int[] arr1, int[] arr2)
    {
        int[] result = new int[arr1.Length + arr2.Length - 1];

        for (int i = 0; i < arr1.Length; i++)
        {
            for (int j = 0; j < arr2.Length; j++)
            {
                result[i + j] += arr1[i] * arr2[j];
            }
        }
        return result;
    }

    static void Main()
    {
        // Input
        Console.WriteLine("Enter coeficients for first polynomial:");
        string inputArray = Console.ReadLine();
        char[] delimiter = new char[] { ',', ' ', '[', ']', '{', '}', ';' };
        string[] input = inputArray.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
        int[] polynomialOne = new int[input.Length];
        for (int i = 0; i < polynomialOne.Length; i++)
        {
            polynomialOne[i] = int.Parse(input[i]);
        }
        Console.WriteLine("Enter coeficients for second polynomial:");
        inputArray = Console.ReadLine();
        input = inputArray.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
        int[] polynomialTwo = new int[input.Length];
        for (int i = 0; i < polynomialTwo.Length; i++)
        {
            polynomialTwo[i] = int.Parse(input[i]);
        }
        // Solution
        PrintPolynomial(polynomialOne);
        PrintPolynomial(polynomialTwo);
        // Add
        Console.WriteLine("Addition:");
        PrintPolynomial(AddPolynomial(polynomialOne, polynomialTwo));
        // Substract
        Console.WriteLine("Substraction:");
        PrintPolynomial(SubstractPolynomial(polynomialOne, polynomialTwo));
        // Multiply
        Console.WriteLine("Multiplication:");
        PrintPolynomial(MultiplyPolynomial(polynomialOne, polynomialTwo));
    }
}

