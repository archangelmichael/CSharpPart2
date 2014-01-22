using System;
using System.IO;
/*  Write a program that reads a text file containing a square 
 * matrix of numbers and finds in the matrix an area of size 2 x 2
 * with a maximal sum of its elements. 
 * The first line in the input file contains the size of matrix N. 
 * Each of the next N lines contain N numbers separated by space. 
 * The output should be a single number in a separate text file.    */
class MaxiamalSumInMatrix
{
    static int[,] GetMatrix(string file)
    {
        using (StreamReader input = new StreamReader(file))
        {
            int n = int.Parse(input.ReadLine());
            int[,] matrix = new int[n, n];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string[] numbers = input.ReadLine().Split(' ');
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = int.Parse(numbers[j]);
                }
            }
            return matrix;
        }
    }
    static int GetMax(int[,] matrix,int platform)
    {
        int bestSum = int.MinValue;
        for (int row = 0; row < matrix.GetLength(0) - platform + 1; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - platform + 1; col++)
            {
                int sum = 0;
                for (int k = 0; k < platform; k++)
                {
                    for (int t = 0; t < platform; t++)
                    {
                        sum += matrix[row + k, col + t];
                    }
                }
                if (sum > bestSum)
                {
                    bestSum = sum;
                }
            }
        }
        return bestSum;
    }
    static void Main()
    {
        Console.WriteLine("Enter platform size: ");
        int platform = int.Parse(Console.ReadLine());
        string file = @"..\..\InputMatrix.txt";
        StreamWriter writer = new StreamWriter(@"..\..\OutputText.txt", false);
        using (writer)
        {
            int[,] matrix = GetMatrix(file);
            int best = GetMax(matrix,platform);
            writer.Write(best);
        }

        // To Print Output File
        using (StreamReader printer = new StreamReader(@"..\..\OutputText.txt"))
        {
            string text = printer.ReadToEnd();
            Console.WriteLine("The best sum with platform {0} x {0} is: {1}",platform,text);
        }
    }
}

