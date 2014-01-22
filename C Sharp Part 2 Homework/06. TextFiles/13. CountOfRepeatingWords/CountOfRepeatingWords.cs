using System;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Security;

/*  Write a program that reads a list of words from a file words.txt and 
 * finds how many times each of the words is contained in another file test.txt. 
 * The result should be written in the file result.txt and the words should be 
 * sorted by the number of their occurrences in descending order. 
 * Handle all possible exceptions in your methods.      */

class CountOfRepeatingWords
{
    static string[] words = { "happy", "cool", "hot", "warm", "tea", "vase", "more", "best", "honey", "rain", "cliff", "box" };
    static string GenerateFile()
    {
        string inputPath = @"../../Tests.txt";
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
                FileInfo file = new FileInfo(@"..\..\Tests.txt");
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
            for (int i = 0; i < 3; i++)
            {
                writer.WriteLine(words[generator.Next(words.Length)]); // gets 3 random words (some can be the same)
            }
        }
        return inputPath;
    }
    static void Main()
    {
        try
        {
            string input = GenerateFile();
            string output = @"..\..\Result.txt";

            string words = GenerateWords();
            string[] search = File.ReadAllLines(words);
            int[] values = new int [search.Length];

            using (StreamReader read = new StreamReader(input))
            {
                using (StreamWriter write = new StreamWriter(output))
                {
                    string line = read.ReadLine();
                    while (line != null)
                    {
                        for (int i = 0; i < search.Length; i++)
                        {
                            values[i] += Regex.Matches(line, @"\b" + search[i] + @"\b").Count;
                        }
                        line = read.ReadLine();
                    }
                    Array.Sort(values, search);
                    for (int i = search.Length - 1; i >= 0; i--)
                    {
                        write.WriteLine("{0} times: {1}", values[i], search[i]);
                    }
                }
            }
        }
        catch (IndexOutOfRangeException exc)   // when generating words
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
    }
}

