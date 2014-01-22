using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Matrix
{
    /*  * Write a class Matrix, to holds a matrix of integers. 
        * Overload the operators for adding, subtracting and multiplying of matrices, 
        * indexer for accessing the matrix content and ToString(). */
    public int Rows, Cols;
    private int[,] matrix;

    public Matrix(int x, int y)
    {
        matrix = new int[x, y];
        Rows = x;
        Cols = y;
    }

    public int this[int x, int y]
    {
        get
        {
            return matrix[x,y];
        }
        set
        {
            matrix[x, y] = value;
        }
    }

    // Overloading Addition Operator
    public static Matrix operator +(Matrix mat1, Matrix mat2)
    {
        Matrix mat = new Matrix(mat1.Rows, mat2.Cols);
        for (int i = 0; i < mat.Rows; i++)
        {
            for (int j = 0; j < mat.Cols; j++)
            {
                mat[i, j] = mat1[i, j] + mat2[i, j];
            }
        }
        return mat;
    }
    // Overloading Substraction Operator
    public static Matrix operator -(Matrix mat1, Matrix mat2)
    {
        Matrix mat = new Matrix(mat1.Rows, mat2.Cols);
        for (int i = 0; i < mat.Rows; i++)
        {
            for (int j = 0; j < mat.Cols; j++)
            {
                mat[i, j] = mat1[i, j] - mat2[i, j];
            }
        }
        return mat;
    }
    // Overloading Multiplication Operator
    public static Matrix operator *(Matrix mat1, Matrix mat2)
    {
        Matrix mat = new Matrix(mat1.Rows, mat2.Cols);
        for (int i = 0; i < mat.Rows; i++)
        {
            for (int j = 0; j < mat.Cols; j++)
            {
                for (int k = 0; k < mat1.Cols; k++)
                {
                    mat[i, j] = mat1[i, k] * mat2[k, j];
                }
            }
        }
        return mat;
    }
    // Override ToString()
    public override string ToString()
    {
        int max = this.matrix[0, 0];
        foreach (int element in this.matrix)
        {
            max = Math.Max(max, element);
        }
        int elementSize = Convert.ToString(max).Length;
        string stringResult = String.Empty;
        for (int i = 0; i < this.Rows; i++)
        {
            for (int j = 0; j < this.Cols; j++)
            {
                stringResult += Convert.ToString(this.matrix[i, j]).PadRight(elementSize, ' ');
                if (j != this.Cols - 1)
                {
                    stringResult += " ";
                }
                else
                {
                    stringResult += "\n";
                }
            }
            
        }
        return stringResult;
    }
}
class OverloadOperators
{
    static void Main()
    {
        Matrix mat1 = new Matrix(3, 3);
        Matrix mat2 = new Matrix(3, 3);

        // Fill with random numbers lower than 20
        Random randomGenerator = new Random();
        for (int i = 0; i < mat1.Rows; i++)
        {
            for (int j = 0; j < mat1.Cols; j++)
            {
                mat1[i, j] = randomGenerator.Next(20);
                mat2[i, j] = randomGenerator.Next(20);
            }
        }

        Console.WriteLine("Matrix 1");
        Console.WriteLine(mat1);

        Console.WriteLine("Matrix 2");
        Console.WriteLine(mat2);

        Console.WriteLine("Matrix 1 + Matrix 2");
        Console.WriteLine(mat1 + mat2);

        Console.WriteLine("Matrix 1 - Matrix 2");
        Console.WriteLine(mat1 - mat2);

        Console.WriteLine("Matrix 1 * Matrix 2");
        Console.WriteLine(mat1 * mat2);
    }
}
