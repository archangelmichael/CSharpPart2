using System;
using System.IO;
using System.Security;

/*  Write a program that enters file name along with its full file path
 * (e.g. C:\WINDOWS\win.ini), reads its contents and prints it on the console. 
 * Find in MSDN how to use System.IO.File.ReadAllText(…). 
 * Be sure to catch all possible exceptions and print user-friendly error messages. */

class GetAndPrintFile
{
    static string ReadFile(string filePath)
    {
        string file = File.ReadAllText(filePath);
        return file;
    }
    static void Main()
    {
        try
        {
            Console.Write("Enter the full path of the file you want to read: ");
            string filePath = Console.ReadLine();
            string text = ReadFile(filePath);
            Console.WriteLine("The content of the file is: ");
            Console.WriteLine(text);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found or does not exist!");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("The file path contains a directory that cannot be found!");
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("No file path is given!");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("The entered file path is not correct!");
        }
        catch (PathTooLongException)
        {
            Console.WriteLine("The entered file path is too long - 248 characters maximum!");
        }
        catch (UnauthorizedAccessException uoae)
        {
            Console.WriteLine(uoae.Message);
        }
        catch (SecurityException)
        {
            Console.WriteLine("You don't have permission to access this file!");
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("Invalid file path format!");
        }
        catch (IOException ioe)
        {
            Console.WriteLine(ioe.Message);
        }
    }

   
}



