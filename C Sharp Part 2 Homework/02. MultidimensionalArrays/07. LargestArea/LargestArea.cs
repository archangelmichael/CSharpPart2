using System;
using System.Collections.Generic;

class LargestArea
{
    /*  * Write a program that finds the largest area of equal neighbor 
     * elements in a rectangular matrix and prints its size.
     * Hint: you can use the algorithm "Depth-first search" or "Breadth-first search" (find them in Wikipedia).     */
    // test: matrix[5,6]  {1,3,2,2,2,4} {3,3,3,2,4,4} {4,3,1,2,3,3} {4,3,1,3,3,1} {4,3,3,3,1,1}  -> result 13

    // Solution using DFS
    static bool IsTraversable(int[,] matrix, int x, int y)
    {
        return x >= 0 && x < matrix.GetLength(0) && y >= 0 && y < matrix.GetLength(1);
    }
    static int currentSum = 0;
    static int[,] directions = new int[,] { { 1, 0 }, { 0, 1 }, { -1, 0 }, { 0, -1 } };
    static void DFS(int[,] matrix, int row, int col)
    {
        int value = matrix[row, col];
        matrix[row, col] = 0; // Mark visited
        currentSum++;

        // Check neighbours
        for (int direction = 0; direction < directions.GetLength(0); direction++)
        {
            int _row = row + directions[direction, 0];
            int _col = col + directions[direction, 1];

            if (IsTraversable(matrix, _row, _col) && matrix[_row, _col] == value) DFS(matrix, _row, _col);
        }
    }
    static void Main()
    {
        // Input matrix from console on one row
        int n, m;
        bool enterN, enterM;
        string[] input;
        do
        {
            Console.Write("Enter N number of rows: ");
            enterN = int.TryParse(Console.ReadLine(), out n);
            Console.Write("Enter M number of columns: ");
            enterM = int.TryParse(Console.ReadLine(), out m);
            Console.WriteLine(" Please enter all {0} elements:", n * m);
            string inputArray = Console.ReadLine();
            char[] delimiter = new char[] { ',', ' ', '{', '}' };
            input = inputArray.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
        } while (!enterN || !enterM || input.Length < (n*m));
        
        int[,] matrix = new int[n,m];
        int count = 0;
        for (int i = 0; i < n; i++)
        {
            if (count == n*m)
            {
                break;
            }
            for (int j = 0; j < m; j++)
            {
                matrix[i,j] = int.Parse(input[count]);
                count++;
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

        // Solution
        int maxSum = 0;
        int bestElement = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (matrix[i,j] != 0)
                {
                    currentSum = 0;
                    int currentElement = matrix[i, j];
                    DFS(matrix, i, j);
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        bestElement = currentElement;
                    }
                    //maxSum = Math.Max(currentSum, maxSum);
                }
            }
        }

        // Output
        Console.WriteLine(maxSum);        
        //or Console.WriteLine(maxSum + " times " + bestElement); if you want to see which is the number

    }
}

