using System;

/* Write a program that reads a number and prints it as a 
 * decimal number, hexadecimal number, percentage and in scientific notation. 
 * Format the output aligned right in 15 symbols. */

class PrintNumber
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine("Decimal".PadRight(20, ' ') + " {0,15}", number);  
        Console.WriteLine("Hexadecimal".PadRight(20,' ') +" {0,15:X}", number);
        Console.WriteLine("Percentage".PadRight(20, ' ') + " {0,15:P}", number);
        Console.WriteLine("Scientific notation".PadRight(20, ' ') + " {0,15:E}", number); 
    }
}

