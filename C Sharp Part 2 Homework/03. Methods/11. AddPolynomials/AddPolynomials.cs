using System;

/* Write a method that adds two polynomials. Represent them as arrays of their coefficients as in the example below:
    x2 + 5 = 1x2 + 0x + 5  5,0,1       */

class AddPolynomials
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
        PrintPolynomial(AddPolynomial( polynomialOne, polynomialTwo));
    }
}

