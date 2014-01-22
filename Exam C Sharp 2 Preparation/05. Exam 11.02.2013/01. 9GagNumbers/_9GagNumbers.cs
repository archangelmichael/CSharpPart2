
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01._9GagNumbers
{
    class _9GagNumbers
    {
        static char ReturnDigit(string str)
        {
            char digit = 'N';
            switch (str)
            {
                case "-!": digit = '0';
                    break;
                case "**": digit = '1';
                    break;
                case "!!!": digit = '2';
                    break;
                case "&&": digit = '3';
                    break;
                case "&-": digit = '4';
                    break;
                case "!-": digit = '5';
                    break;
                case "*!!!": digit = '6';
                    break;
                case "&*!": digit = '7';
                    break;
                case "!!**!-": digit = '8';
                    break;
            }
            return digit;
        }
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            decimal decimalResult = 0;
            int baseNumber = 9;
            string substring = "";
          
            StringBuilder getDigits = new StringBuilder();
            for (int index = 0; index < input.Length; index++)
            {
                substring += input[index];
                char digit = ReturnDigit(substring);
                if (char.IsDigit(digit))
                {
                    getDigits.Append(digit);
                    substring = string.Empty;
                }
            }
            string result = getDigits.ToString();
            for (int i = 0; i < result.Length; i++)
            {
                decimalResult += (decimal)((result[i] - '0') * PowerOfNine(result.Length - i - 1));
            }
            Console.WriteLine(decimalResult);
        }

        private static decimal PowerOfNine(int p)
        {
            decimal result = 1;
            for (int i = 0; i < p; i++)
            {
                result *= 9;
            }
            return result;
        }
    }
}
