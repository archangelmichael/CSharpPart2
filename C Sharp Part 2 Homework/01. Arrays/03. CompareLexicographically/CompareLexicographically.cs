using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CompareLexicographically
{
    static void Main()
    {
        /*  Write a program that compares two char arrays lexicographically (letter by letter). */
        // Input
        // Declaring first array
        Console.Write("Number of elements of first array = ");
        int size1 = int.Parse(Console.ReadLine());
        char[] array1 = new char[size1];
        for (int i = 0; i < size1; i++)
        {
            Console.Write("arr1[{0}] = ", i);
            array1[i] = char.Parse(Console.ReadLine());
        }
        Console.WriteLine(new string('*', 50));

        // Declaring second array
        Console.Write("Number of elements of second array = ");
        int size2 = int.Parse(Console.ReadLine());
        char[] array2 = new char[size2];
        for (int i = 0; i < size2; i++)
        {
            Console.Write("arr2[{0}] = ", i);
            array2[i] = char.Parse(Console.ReadLine());
        }
        Console.WriteLine(new string('*', 50));


        //Solution
        int longerArray = 0;
        int size = array1.Length;
        if (size2 > size1)
        {
            longerArray = 2;
        }
        else if (size1 > size2)
        {
            longerArray = 1;
            size = array2.Length;
        }

        int first = 0;
        int second = 0;
        bool isEqual = true;
        for (int i = 0; i < size; i++)
        {
            if (array1[i] != array2[i])
            {
                if (array1[i] > array2[i])
                {
                    second = 1;
                    first = 2;
                }
                else if (array1[i] < array2[i])
                {
                    first = 1;
                    second = 2;
                }
                isEqual = false;
                break;
            }
            else if (array1[i] == array2[i] && i == size -1 && longerArray != 0 )
            {
                switch (longerArray)
                {
                    case 1: 
                        first = 2;
                        second = 1;
                        break;
                    case 2: 
                        second = 2;
                        first = 1;
                        break;
                }
                isEqual = false;
                break;
            }
        }

        // Output
        if (isEqual)
        {
            Console.WriteLine("Both arrays are lexicographically equal!");
        }
        else
        {
            Console.WriteLine("Array {0} lexicographically is before array {1}", first, second);
        }
    }
}


