using System;
using System.IO;
using System.Collections.Generic;

/*  Write a program that reads a text file containing a list of strings, 
 * sorts them and saves them to another text file. */
class SortNamesFromFile
{
    static List<string> GetNames(string file)
    {
        List<string> listOfNames = new List<string>();
        using (StreamReader reader = new StreamReader(file))
        {
            string line = reader.ReadLine();
            while (line != null)
            {
                listOfNames.Add(line);
                line = reader.ReadLine();
            }
            return listOfNames;
        }
    }

    static void Main()
    {
        string file = @"..\..\InputNames.txt";
        using (StreamWriter writer = new StreamWriter(@"..\..\SortedNames.txt", false))
        {
            List<string> names = GetNames(file);
            names.Sort();
            for (int i = 0; i < names.Count; i++)
            {
                writer.WriteLine(names[i]);
            }
        }

        // To Print Output File
        using (StreamReader printer = new StreamReader(@"..\..\SortedNames.txt"))
        {
            string text = printer.ReadToEnd();
            while (text != null)
            {
                Console.WriteLine(text);
                text = printer.ReadLine();
            }
        }
    }
}