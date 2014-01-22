using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
//using System.Diagnostics;

/*  Write a program that deletes from a text file all words 
 * that start with the prefix "test".
 * Words contain only the symbols 0...9, a...z, A…Z, _. */
class WordsWithPrefix
{
    static string GenerateLargeFile()
    {
        string inputPath = @"../../Input.txt";
        Random generator = new Random();
        using (StreamWriter writer = new StreamWriter(inputPath, false))
        {
            string[] words = { "test", "test23AA???ing", "test645FSAEup", "wake", "gener123ate", "over", "more", "test_9???", "test?<>::load","ptest992lity" };
            long fileSize = 0;
            long maxSize = 20;
            while (fileSize < maxSize)
            {
                string word = "";
                for (int i = 0; i < 7; i++)
                {
                    word += words[generator.Next(words.Length)] + " ";
                }
                writer.WriteLine(word);
                FileInfo file = new FileInfo(@"..\..\Input.txt");
                fileSize = file.Length;
            }
        }
        return inputPath;
    }
    static void Main()
    {
        string input =  GenerateLargeFile();
        string temp = @"..\..\Temp.txt";
        string search = @"(\b)test(\w*)(\b)";
        string replace = " ";
        using (StreamReader read = new StreamReader(input))
        {
            using (StreamWriter write = new StreamWriter(temp))
            {
                string line = read.ReadLine();
                while (line != null)
                {
                    line = Regex.Replace(line, search, replace);
                    write.WriteLine(Regex.Replace(line, @"\s{2,}", " "));
                    line = read.ReadLine();
                }
            }
        }
        
        File.Replace(temp, input, @"..\..\backup.txt");
        // if you want to delete backup file uncomment next row
        //File.Delete("../../backup.txt");


        ////If you want to use process to view results (uncomment using System.Diagnostics too)
        //Process openFile = new Process();
        //openFile.StartInfo.FileName = @"..\..\Input.txt";
        //openFile.Start();
        //openFile.StartInfo.FileName = @"..\..\Temp.txt";
        //openFile.Start();
    }
}

