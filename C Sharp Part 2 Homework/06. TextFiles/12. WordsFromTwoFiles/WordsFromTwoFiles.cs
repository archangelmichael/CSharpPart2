using System;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Security;

/*  Write a program that removes from a text file all words
 * listed in given another text file. 
 * Handle all possible exceptions in your methods. */

class WordsFromTwoFiles
{
    static string[] words = { "happy", "cool", "hot", "warm", "tea", "vase", "more", "best", "honey", "rain", "cliff", "box"};
    static string GenerateFile()
    {
        string inputPath = @"../../Input.txt";
        Random generator = new Random();
        using (StreamWriter writer = new StreamWriter(inputPath, false))
        {
            long fileSize = 0;
            long maxSize = 20;
            while (fileSize < maxSize)
            {
                string word = "";
                for (int i = 0; i < 10; i++)
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
    static string GenerateWords()
    {
        string inputPath = @"../../Words.txt";
        Random generator = new Random();
        using (StreamWriter writer = new StreamWriter(inputPath, false))
        {
            for (int i = 0; i < 4; i++)
            {
                writer.WriteLine(words[generator.Next(words.Length)]); // gets 5 random words
            }
        }
        return inputPath;
    }
    static void Main()
    {
        try
        {
            string input = GenerateFile();
            string output = @"..\..\Output.txt";

            string words = GenerateWords();
            string search = @"\b(" + String.Join("|", File.ReadAllLines(words)) + @")\b";
            string replace = "";
            using (StreamReader read = new StreamReader(input))
            {
                using (StreamWriter write = new StreamWriter(output))
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
        }        
        catch (IndexOutOfRangeException exc)   // When generating words
        {
            Console.WriteLine(exc.Message);
        }
        catch (ArgumentException exc)   // When generating files
        {
            Console.WriteLine(exc.Message);
        }
        catch (FileNotFoundException exc)
        {
            Console.WriteLine(exc.Message);
        }
        catch (DirectoryNotFoundException exc)
        {
            Console.WriteLine(exc.Message);
        }
        catch (IOException exc)
        {
            Console.WriteLine(exc.Message);
        }
        catch (SecurityException exc)
        {
            Console.WriteLine(exc.Message);
        }
        catch (UnauthorizedAccessException exc)
        {
            Console.WriteLine(exc.Message);
        }

        #region
        //// To see the result uncomment
        //try
        //{
        //    Process openFile = new Process();
        //    openFile.StartInfo.FileName = @"..\..\Input.txt";
        //    openFile.Start();
        //    openFile.StartInfo.FileName = @"..\..\Output.txt";
        //    openFile.Start();
        //    openFile.StartInfo.FileName = @"..\..\Words.txt";
        //    openFile.Start();
        //}
        //catch (ArgumentNullException excnull)
        //{
        //    Console.Error.WriteLine(excnull.Message);
        //}
        //catch (InvalidOperationException excoper)
        //{
        //    Console.Error.WriteLine(excoper.Message);
        //}
        //catch (ObjectDisposedException excdispose)
        //{
        //    Console.Error.WriteLine(excdispose.Message);
        //}
        #endregion
    }
}
