using System;

class ReverseDecimalNumber
{
    /*  Write a method that reverses the digits of given decimal number. Example: 256  652 */
    // In this solution i suggest that by decimal number they refer to a number with type decimal
    static void ReverseDecimal(decimal number)
    {
        string reversed = number.ToString();
        char[] charArray = reversed.ToCharArray();
        Array.Reverse(charArray);
        new string(charArray);
        Console.WriteLine(charArray);
    }
    static void Main()
    {

        Console.WriteLine("Enter a decimal number to be reversed:");
        decimal entered = decimal.Parse(Console.ReadLine());
        if (entered < 0)
        {
            Console.Write("-");
            ReverseDecimal(-entered);
        }
        else
        {
            ReverseDecimal(entered);
        }
    }
}

