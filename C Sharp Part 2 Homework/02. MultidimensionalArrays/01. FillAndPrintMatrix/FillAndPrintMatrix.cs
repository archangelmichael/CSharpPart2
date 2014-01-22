using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class FillAndPrintMatrix
{
    /* Write a program that fills and prints a matrix of size (n, n) as shown below: (examples for n = 4) (in several ways) */
    static void MatrixFillDown(int[,] integerArr, int size)
    {
        int count = 1;
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                integerArr[j, i] = count;
                count++;
            }
        }
        return;
    }
    static void MatrixFillDownUp(int[,] integerArr, int size)
    {
        int count = 1;
        bool reverese = false;
        for (int i = 0; i < size; i++)
        {
            if (!reverese)
            {
                for (int j = 0; j < size; j++)
                {
                    integerArr[j, i] = count;
                    count++;
                }
                    reverese = true;
            }
            else
            {
                for (int j = size-1 ; j >= 0; j--)
                {
                    integerArr[j, i] = count;
                    count++;
                }
                    reverese = false;
            }
        }
        return;
    }
    static void MatrixFillDiagonally(int[,] integerArr, int size)
    {
        string direction = "up";
        int currentrow = size - 1;
        int currentcol = 0;
        for (int i = 1; i <= size * size; i++)
        {
            if (i == 1)
            {
                integerArr[currentrow, currentcol] = i;
                continue;
            }
            else if (direction == "up" && currentrow - 1 >= 0)
            {
                currentrow--;
                direction = "downright";
            }
            integerArr[currentrow, currentcol] = i;
            if (direction == "downright" && currentcol + 1 < size && currentrow + 1 < size)
            {
                currentrow++;
                currentcol++;
            }
            else
            {
                direction = "up";
                bool found = false;
                for (int j = 0; j < size && !found; j++)
                {
                    for (int k = size - 1; k >= 0; k--)
                    {
                        if (integerArr[k, j] == 0)
                        {
                            currentcol = j;
                            currentrow = k + 1;
                            found = true;
                            break;
                        }
                    }
                }
            }
        }
        return;
    }
    static void MatrixFillSpiral(int[,] spiral, int size)
    {
        string direction = "right";
        int currentrow = 0;
        int currentcol = 0;
        for (int i = 1; i <= size * size; i++)
        {
            if (direction == "right" && (currentcol >= size || spiral[currentrow, currentcol] != 0))
            {
                currentrow++;
                currentcol--;
                direction = "down";
            }
            if (direction == "down" && (currentrow >= size || spiral[currentrow, currentcol] != 0))
            {
                currentrow--;
                currentcol--;
                direction = "left";
            }
            if (direction == "left" && (currentcol < 0 || spiral[currentrow, currentcol] != 0))
            {
                currentrow--;
                currentcol++;
                direction = "up";
            }
            if (direction == "up" && (currentrow < 0 || spiral[currentrow, currentcol] != 0))
            {
                currentrow++;
                currentcol++;
                direction = "right";
            }

            spiral[currentrow, currentcol] = i;
            if (direction == "right")
            {
                currentcol++;
            }
            else if (direction == "down")
            {
                currentrow++;
            }
            else if (direction == "left")
            {
                currentcol--;
            }
            else if (direction == "up")
            {
                currentrow--;
            }
        }
        return;
    }
    static void MatrixFillReverseSpiral(int[,] reverseSpiral, int size)
    {
        string direction = "down";
        int currentrow = 0;
        int currentcol = 0;
        for (int i = 1; i <= size * size; i++)
        {
            if (direction == "down" && (currentrow >= size || reverseSpiral[currentrow, currentcol] != 0))
            {
                currentrow--;
                currentcol++;
                direction = "right";
            }
            if (direction == "right" && (currentcol >= size || reverseSpiral[currentrow, currentcol] != 0))
            {
                currentrow--;
                currentcol--;
                direction = "up";
            }
            if (direction == "up" && (currentrow < 0 || reverseSpiral[currentrow, currentcol] != 0))
            {
                currentrow++;
                currentcol--;
                direction = "left";
            }
            if (direction == "left" && (currentcol < 0 || reverseSpiral[currentrow, currentcol] != 0))
            {
                currentrow++;
                currentcol++;
                direction = "down";
            }
            reverseSpiral[currentrow, currentcol] = i;

            if (direction == "right")
            {
                currentcol++;
            }
            else if (direction == "down")
            {
                currentrow++;
            }
            else if (direction == "left")
            {
                currentcol--;
            }
            else if (direction == "up")
            {
                currentrow--;
            }
        }
        return;
    }
    static void Main()
    {
        Console.Write("Enter number of dimentions: ");
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];
        Console.WriteLine("Please select a way to fill the matrix:");
        Console.WriteLine("a) down  b) down-up c) diagonally  d) dpiral  e) reverse spiral ");
        char wayToFill = char.Parse(Console.ReadLine());
        

        // which way to fill the matrix
        switch (wayToFill)
        {
            case 'a': MatrixFillDown(matrix,n);
                break;
            case 'b': MatrixFillDownUp(matrix,n);
                break;
            case 'c': MatrixFillDiagonally(matrix,n);
                break;
            case 'd': MatrixFillSpiral(matrix,n);
                break;
            case 'e': MatrixFillReverseSpiral(matrix,n);
                break;
            default: Console.WriteLine(" You have entered invalid way!");
                Environment.Exit(0);
                break;
        }
        // print the matrix
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix [i,j] + "\t");
            }
            Console.WriteLine();
        }
    }
}

