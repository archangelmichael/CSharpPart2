using System;
using System.Linq;
public class PrintName
{
    /*  Write a method that asks the user for his name 
     * and prints “Hello, <name>” (for example, “Hello, Peter!”). 
     * Write a program to test this method. */
    public static string PrintHelloName(string userName)
    {
        bool result = userName.All(Char.IsLetter);
        if (result)
        {
            Console.WriteLine("Hello, {0}!", userName);
        }
        else
        {
            Console.WriteLine("Invalid input!");
        }
        return "Hello, " + userName + "!"; // i use return type to test the method with UnitTestPrintName
    }
    static void Main()
    {
        Console.WriteLine("What is your name?");
        string name = Console.ReadLine();
        PrintHelloName(name);
    }
}

