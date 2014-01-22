using System;
using System.IO;
using System.Text;
/*  Write a program that reads a text file and inserts 
 * line numbers in front of each of its lines. 
 * The result should be written to another text file.*/
class InsertLineNumbers
{
    static void Main()
    {
        Encoding encoding = Encoding.GetEncoding("windows-1251");
        string file = @"..\..\InputText.txt";
        StreamWriter writer = new StreamWriter(@"..\..\OutputText.txt", false, encoding);
        using (writer)
        {
                StreamReader reader = new StreamReader(file, encoding);
                int lineNumber = 0;
                string line = reader.ReadLine();
                while (line != null)
                {
                    lineNumber++;
                    writer.WriteLine("Line " + lineNumber + ": " + line);
                    line = reader.ReadLine();
                }
        }

        // To Print Output File
        StreamReader printer = new StreamReader(@"..\..\OutputText.txt",encoding);
        using (printer)
        {
            string text = printer.ReadToEnd();
            Console.WriteLine(text);
        }
    }
}

