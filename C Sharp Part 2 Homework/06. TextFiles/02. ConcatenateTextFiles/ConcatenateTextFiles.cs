using System;
using System.IO;

//Write a program that concatenates two text files into another text file.
class ConcatenateTextFiles
{
    static void Main()
    {
        string[] files ={@"..\..\FirstTexxtFile.txt" , @"..\..\SecondTextFile.txt"};
        StreamWriter writer = new StreamWriter(@"..\..\OutputText.txt");
        using (writer)
        {
            for (int i = 0; i < files.Length; i++)
            {
               StreamReader reader = new StreamReader(files[i]);
               int lineNumber = 0;
               string line = reader.ReadLine();
               while (line != null)
               {
                   lineNumber++;
                   writer.WriteLine(line);
                   line = reader.ReadLine();
               }
            }
        }

        // To Print Output File
        //StreamReader printer = new StreamReader(@"..\..\OutputText.txt");
        //using (printer)
        //{
        //    string text = printer.ReadToEnd();
        //    Console.WriteLine(text);
        //}
    }
}

