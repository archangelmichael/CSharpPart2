using System;
using System.Collections.Generic;

class MaximalSumSquare
{
    static void Main()
    {
        /* Write a program that reads a rectangular matrix of size N x M and 
         * finds in it the square 3 x 3 that has maximal sum of its elements.*/
        int platform = 3;
        int n,m;
        bool enterN, enterM;
        do
        {
            Console.Write("Enter N number of rows: ");
            enterN = int.TryParse(Console.ReadLine(), out n);
            Console.Write("Enter M number of columns: ");
            enterM = int.TryParse(Console.ReadLine(), out m);
        } while ( !enterN || !enterM || n < 3 || m < 3);

        // Enter matrix's elements
        int[,] matrix = new int[n, m];
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < m; col++)
            {
                Console.Write("matrix[{0},{1}] = ", row, col);
                int element = int.Parse(Console.ReadLine());
	            matrix[row, col] = element;
            }
        }

        // Print input matrix
        //for (int i = 0; i < n; i++)
        //{
        //    for (int t = 0; t < m; t++)
        //    {
        //        Console.Write(matrix[i, t] + "\t");
        //    }
        //    Console.WriteLine();
        //}

        // Find the maximal sum platform of size 3 x 3
        int bestSum = int.MinValue;
        int bestRow = 0;
        int bestCol = 0;
        for (int row = 0; row < n - platform + 1; row++)
        {
            for (int col = 0; col < m - platform + 1; col++)
            {
                int sum = 0;
                for (int k = 0; k < platform; k++)
			    {
                    for (int t = 0; t < platform; t++)
                    {
                        sum += matrix[row + k,col + t];
                    }
			    }
                if (sum > bestSum)
                {
                    bestSum = sum;
                    bestRow = row;
                    bestCol = col;
                }
            }
        }

        // Print the maximum platform
        Console.WriteLine("The best platform {0} x {0} is:", platform);
        for (int i = 0; i < platform; i++)
        {
            for (int t = 0; t < platform; t++)
            {
                Console.Write(matrix[bestRow + i, bestCol + t] + "\t"); 
            }
            Console.WriteLine();
        }
    }
}

