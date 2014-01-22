using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*  Write a program to calculate n! for each n in the range [1..100]. 
     * Hint: Implement first a method that multiplies a number represented 
     * as array of digits by given integer number. */
// Solution by overriding BigInteger operators for +,* and ToString()
namespace Factorial
{
    class BigInteger
    {
        // Using 10000000 as base
        const int Base = 10000000;
        List<int> digits = new List<int>();

        public BigInteger()
        {
        }
        public BigInteger(int x)
        {
            digits.Add(x);
        }
        public int NumberOfDigits
        {
            get
            {
                return digits.Count;
            }
        }
        public int this[int index]
        {
            get
            {
                if (index >= 0 && index < NumberOfDigits)
                {
                    return digits[index];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if (index >= 0 && index < NumberOfDigits)
                {
                    digits[index] = value;
                }
            }
        }
        public void AddDigit(int x)
        {
            digits.Add(x);
        }
        public static BigInteger operator *(int x, BigInteger y)
        {
            BigInteger result = new BigInteger();
            int rest = 0;

            for (int i = 0; i < y.NumberOfDigits; ++i)
            {
                rest += x * y[i];

                result.AddDigit(rest % Base);
                rest /= Base;
            }
            while (rest > 0)
            {
                result.AddDigit(rest % Base);
                rest /= Base;
            }
            return result;
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder("");
            if (NumberOfDigits > 0)
            {
                result.Append(digits[NumberOfDigits - 1].ToString());
                for (int i = NumberOfDigits - 2; i >= 0; --i)
                {
                    result.Append(String.Format("{0:D7}", digits[i]));
                }
            }
            return result.ToString();
        }
    }

    class OverrideFactorial
    {
        static BigInteger CalculateFactorial(int n)
        {
            BigInteger result = new BigInteger(1);
            for (int i = 2; i <= n; ++i)
            {
                result = i * result;
            }
            return result;
        }
        static void Main(string[] args)
        {
            // Input
            Console.WriteLine(" Enter number to calculate factorial:");
            int n = int.Parse(Console.ReadLine());
            // Solution
            BigInteger result = CalculateFactorial(n);
            // Output
            Console.WriteLine(result.ToString());
        }
    }
}
