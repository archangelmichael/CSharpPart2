using System;
using System.Collections.Generic;

class SequenceInMatrix
{
    /* We are given a matrix of strings of size N x M. 
     * Sequences in the matrix we define as sets of several neighbor elements located on the same line, column or diagonal. 
     * Write a program that finds the longest sequence of equal strings in the matrix. */
    static int maxLength = 0;
    static int bestRow = 0;
    static int bestCol = 0;
    static string direction = "";
    static string set = "";

    static void CheckHorizon(string[,] arr, int rows, int cols, int i, int j)
    {
        string line = arr[i,j];
        int count = 0;
        for (int k = j; k < cols; k++)
        {
            if (arr[i,k]== line)
            {
                count++;
            }
            else
            {
                break;
            }
        }
        if (count > maxLength)
        {
            maxLength = count;
            bestRow = i;
            bestCol = j;
            direction = "horizontal";
            set = line;
        }
        return;
    }
    static void CheckVertical(string[,] arr, int rows, int cols, int i, int j)
    {
        string line = arr[i, j];
        int count = 0;
        for (int k = i; k < rows; k++)
        {
            if (arr[k, j] == line)
            {
                count++;
            }
            else
            {
                break;
            }
        }
        if (count > maxLength)
        {
            maxLength = count;
            bestRow = i;
            bestCol = j;
            direction = "vertical";
            set = line;
        }
        return;
    }
    static void CheckDiagonal(string[,] arr, int rows, int cols, int i, int j)
    {
        string line = arr[i, j];
        int count = 0;
        int currentRow = i;
        int currentCol = j;
        while (currentRow < rows && currentCol < cols)
        {
            if (arr[currentRow, currentCol] == line)
            {
                count++; 
            }
            else
            {
                break;
            }
            currentCol++;
            currentRow++;
        }
        if (count > maxLength)
        {
            maxLength = count;
            bestRow = i;
            bestCol = j;
            direction = "diagonal";
            set = line;
        }
        return;
    }
    static void Main()
    {
        Console.Write("Enter N number of rows: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter M number of columns: ");
        int m = int.Parse(Console.ReadLine());

        // Enter matrix's elements
        string[,] matrix = new string[n, m];
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < m; col++)
            {
                Console.Write("matrix[{0},{1}] = ", row, col);
                matrix[row, col] = Console.ReadLine();
            }
        }

        // Solution
        for (int t = 0;t < n; t++)
        {
            for (int p = 0; p < m; p++)
            {
                CheckHorizon(matrix, n, m, t, p);
                CheckVertical(matrix, n, m, t, p);
                CheckDiagonal(matrix, n, m, t, p);
            }
        }

        // Print Matrix
        for (int t = 0; t < n; t++)
        {
            for (int p = 0; p < m; p++)
            {
                Console.Write(matrix[t,p] + "\t");
            }
            Console.WriteLine();
        }

        // Print Result
        List<string> result = new List<string>(maxLength);
        for (int i = 0; i < maxLength; i++)
        {
            result.Add(set);
        }
        Console.WriteLine(string.Join(",", result));
        Console.WriteLine();

        // Complete information on the longest set
        Console.WriteLine(" {0} is {1} times in {2} direction starting matrix[{3},{4}]!", set, maxLength, direction, bestRow, bestCol);
    }
}

