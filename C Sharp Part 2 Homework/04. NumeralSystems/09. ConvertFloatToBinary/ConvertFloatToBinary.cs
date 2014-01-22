using System;

/*  * Write a program that shows the internal binary representation of 
 * given 32-bit signed floating-point number in IEEE 754 format (the C# type float). 
 * Example: -27,25  sign = 1, exponent = 10000011, mantissa = 10110100000000000000000. */

class ConvertFloatToBinary
{
    static void Main()
    {
        Console.WriteLine("Enter floating-point  number: ");
        float floatNumber = float.Parse(Console.ReadLine());
        long number = BitConverter.DoubleToInt64Bits(floatNumber); // Convert to 64 signed integer number
        string result = "";
        long mask = 1;
        long sign = (number >> 63) & mask;

        // Check sign
        if (sign == 1)
        {
            number = (number & (~(mask << 63)));
        }
        // Take all Bits
        while (number != 0)
        {
            result = (number & mask) + result;
            number = number >> 1;
        }

        // Output
        Console.WriteLine("Sign: " + sign);
        if (floatNumber > -2.0f && floatNumber < 2.0f)
        {
            Console.WriteLine("Exponent: " + "0" + result.Substring(3, 7));
            Console.WriteLine("Mantissa: " + result.Substring(10,23));
        }
        else
        {
            //don't take 3 positions because we used 64 bits number and this 3 digits are no necessary for 32 bits number
            Console.WriteLine("Exponent: " + result.Substring(0, 1) + result.Substring(4, 7));
            Console.WriteLine("Mantissa: " + result.Substring(11, 23));
        }
    }
}

