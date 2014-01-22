using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SpecialValue
{
    class Program
    {
        static int[][] ReadData(int[][] field)
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                string[] line = Console.ReadLine().Split(new char[] { ',', ' ' },StringSplitOptions.RemoveEmptyEntries);
                field[i] = new int[line.Length];
                for (int j = 0; j < line.Length; j++)
                {
                    field[i][j] = int.Parse(line[j]);
                }
            }
            return field;
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int [][] jaggerArr = new int[n][];
            ReadData(jaggerArr);

            int maxSum = 0;
            
            for (int i = 0; i < jaggerArr[0].Length; i++)
            {
                int currentLine = 0;
                int currentCol = i;
                int sum = 1;
                bool end = false;
                while (!end)
                {
                    if (jaggerArr[currentLine][currentCol] == -150)
                    {
                        end = true;
                    }
                    else if (jaggerArr[currentLine][currentCol] < 0)
                    {
                        sum -= jaggerArr[currentLine][currentCol];
                        end = true;
                    }
                    else
                    {
                        sum++;
                        int col = currentCol;
                        currentCol = jaggerArr[currentLine][currentCol];
                        jaggerArr[currentLine][col] = -150;
                        if (currentLine == jaggerArr.GetLength(0) - 1)
                        {
                            currentLine = 0;
                        }
                        else
                        {
                            currentLine++;
                        }
                    }
                }
                if (sum > maxSum)
                {
                    maxSum = sum;
                }
                
            }
            Console.WriteLine(maxSum);
        }
    }
}
