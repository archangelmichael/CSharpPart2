using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

/*  Write a program that replaces all occurrences of the substring 
 * "start" with the substring "finish" in a text file. 
 * Ensure it will work with large files (e.g. 100 MB).  
 Modify the solution to replace only whole words (not substrings).*/

class WordReplace
{
    static string GenerateLargeFile()
    {
        string inputPath = @"../../Input.txt";
        Random generator = new Random();
        using (StreamWriter writer = new StreamWriter(inputPath, false))
        {
            string[] words = { "start", "starting", "start-up", "wake", "generate", "over", "more", "bystart" };
            long fileSize = 0;
            long maxSize = 1000;
            while (fileSize < maxSize)
            {
                string word = "";
                for (int i = 0; i < 6; i++)
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
    static void Main()
    {
        string input = GenerateLargeFile();
        string temp = @"..\..\Temp.txt";
        string search = @"\bstart\b";
        string replace = "finish";
        using (StreamReader read = new StreamReader(input))
        {
            using (StreamWriter write = new StreamWriter(temp))
            {
                string line = read.ReadLine();
                while (line != null)
                {
                    write.WriteLine(Regex.Replace(line,search,replace));
                    line = read.ReadLine();
                }
            }
        }
        File.Replace(temp, input, @"..\..\backup.txt");
        // if you want to delete backup file uncomment next row
        //File.Delete("../../backup.txt");
    }
}

