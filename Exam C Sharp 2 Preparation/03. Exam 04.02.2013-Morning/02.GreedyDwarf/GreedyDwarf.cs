using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.GreedyDwarf
{
    class GreedyDwarf
    {
        
        static void Main(string[] args)
        {
            // input valey
            string[] numbers = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            bool[] check = new bool[numbers.Length];

            // input patterns
            int m = int.Parse(Console.ReadLine());
            int[][] moves = new int[m][];
            for (int i = 0; i < m; i++)
            {
                string[] input = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                moves[i] = new int [input.Length];
                for (int j = 0; j < input.Length; j++)
                {
                    moves[i][j] = int.Parse(input[j]);
                }
            }

            // check every pattern
            long max = long.MinValue;
            for (int i = 0; i < m; i++)
            {
                int number = 0;
                long sum = 0;
                int index = 0;
                int[] pattern = moves[i];
                int move = 0;

                while (true)
                {
                    if (!CheckIndex(index,check))
                    {
                        break;
                    }
                    else
                    {
                        number = int.Parse(numbers[index]);
                        check[index] = true;
                        sum += number;
                        index += pattern[move];
                        if (move < pattern.Length - 1)
                        {
                            move++;
                        }
                        else
                        {
                            move = 0;
                        }
                    }
                }
                if (sum > max)
                {
                    max = sum;
                }
                Array.Clear(check, 0, check.Length);
            }
            Console.WriteLine(max);
        }
        static bool CheckIndex(int index, bool[] arr)
        {
            if (index >= arr.Length || index < 0)
            {
                return false;
            }
            if (arr[index] == true)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
