using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class CompareArrays
{
    static void Main( )
    {
        /*  Write a program that reads two arrays from the console and compares them element by element. */

        // Declaring first array
        Console.Write("Number of elements of first array = ");
        int size1 = int.Parse(Console.ReadLine());
        int[] array1 = new int[size1];
        for (int i = 0; i < size1; i++)
        {
            Console.Write("arr1[{0}] = ", i);
            array1[i] = int.Parse(Console.ReadLine());
        }
        // Declaring second array
        Console.Write("Number of elements of second array = ");
        int size2 = int.Parse(Console.ReadLine());
        int[] array2 = new int[size2];
        Console.WriteLine(new string('*', 50));
        for (int i = 0; i < size2; i++)
        {
            Console.Write("arr2[{0}] = ", i);
            array2[i] = int.Parse(Console.ReadLine());
        }
        if (size2> size1)
        {
            Console.WriteLine("Second array is longer than first array!");
        }
        else if (size1> size2)
        {
            Console.WriteLine("First array is longer than second array!");
        }
        else
        {
            bool isEqual = true;
            for (int i = 0; i < size1; i++)
            {
                if (array1[i] != array2[i])
                {
                    isEqual = false;
                    break;
                }
            }
            Console.WriteLine("Are both arrays equal? --> {0}", isEqual);      
        }
    }
}

