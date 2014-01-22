using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _01.DurankulakNumbers
{
    class DurankulakNumbers
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int index = 0;
            long result = 0;
            char current;
            long addition = 0;
            while (index < input.Length)
            {
                result *= 168;
                current = input[index];
                if (current <= 'f' && current >= 'a' && index < input.Length -1)
                {
                    addition = (current - 'a' + 1) * 26;
                    index++;
                    current = input[index];
                    addition += current - 'A';
                }
                else
                {
                    addition = (current - 'A');
                }
                index++;
                result += addition;
            }
            Console.WriteLine(result);
        }
    }
}
