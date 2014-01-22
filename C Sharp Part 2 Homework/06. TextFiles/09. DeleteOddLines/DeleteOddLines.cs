using System;
using System.IO;
using System.Text;

/* Write a program that deletes from given text file all odd lines. 
The result should be in the same file. */

class DeleteOddLines
{
    static string GenerateLargeFile()
    {
        string inputPath = @"../../Input.txt";
        Random generator = new Random();
        using (StreamWriter writer = new StreamWriter(inputPath, false))
        {
            string[] words = { "last", "first", "start-up","big", "wake", "generate", "over", "more", "bystart" };
            long fileSize = 0;
            long maxSize = 1000;
            while (fileSize < maxSize)
            {
                string word = "";
                for (int i = 0; i < 9; i++)
                {
                    word += words[generator.Next(words.Length)] + " ";
                }
                writer.WriteLine(word);
                FileInfo file = new FileInfo(@"..\..\input.txt");
                fileSize = file.Length;
            }
        }
        return inputPath;
    }
    static void Main(string[] args)
    {
        string input = GenerateLargeFile();
        string temp = @"..\..\Temp.txt";
        using (StreamReader read = new StreamReader(input))
        {
            using (StreamWriter write = new StreamWriter(temp))
            {
                int lineNumber = 1;
                string line = read.ReadLine();
                while (line != null)
                {
                    if (lineNumber % 2 == 0)
                    {
                        write.WriteLine(line);
                    }
                    line = read.ReadLine();
                    lineNumber++;
                }
            }
        }
        File.Replace(temp, input, @"..\..\backup.txt");
        // if you want to delete backup file uncomment next row
        //File.Delete("../../backup.txt");
    }
}

