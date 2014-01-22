using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.KaspichanNumbers
{
    class KaspichanNumbers
    {
        static void Main(string[] args)
        {
            ulong number = ulong.Parse(Console.ReadLine());
            List<string> digits = new List<string>();

            for (char i = 'A'; i <= 'Z'; i++)
            {
                digits.Add(i.ToString());
            }

            for (char i = 'a'; i <= 'i'; i++)
            {
                for (char j = 'A'; j <= 'Z'; j++)
                {
                    digits.Add(i.ToString() + j.ToString());
                }
            }
            string result = string.Empty;

            if (number == 0)
            {
                Console.WriteLine('A');
            }
            while (number != 0)
            {
                result = digits[(int)(number % 256)] + result;
                number = number / 256;
            }
            Console.WriteLine(result);
        }
    }
}
