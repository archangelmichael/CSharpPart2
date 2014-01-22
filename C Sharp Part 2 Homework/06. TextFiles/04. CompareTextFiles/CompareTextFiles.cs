using System;
using System.Text;
using System.IO;

/*  Write a program that compares two text files line by line 
 * and prints the number of lines that are the same and the 
 * number of lines that are different. 
 * Assume the files have equal number of lines. */

class CompareTextFiles
{
    static void Main()
    {
        StreamReader reader1 = new StreamReader (@"..\..\InputOne.txt");
        StreamReader reader2 = new StreamReader (@"..\..\InputTwo.txt");
        // Changed me with you for difference
        using (reader1)
        {
            using (reader2)
            {
                string lineOne = reader1.ReadLine();
                string lineTwo = reader2.ReadLine();
                int countSame = 0;
                int countDiffer = 0;
                while (lineOne != null)
                {
                    if (lineOne == lineTwo)
                    {
                        countSame++;
                    }
                    else
                    {
                        countDiffer++;
                    }
                    lineOne = reader1.ReadLine();
                    lineTwo = reader2.ReadLine();
                }
                Console.WriteLine("Equal lines: " + countSame);
                Console.WriteLine("Different lines: " + countDiffer);
            }
        }
    }
}

