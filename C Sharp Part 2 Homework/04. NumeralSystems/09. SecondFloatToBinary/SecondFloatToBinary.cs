using System;

// Second Solution With Methods

class SecondFloatToBinary
{
    static string DecimalToBinInt(int num)
    {
        string str = "";       
        while (num != 0)
        {
            str = num % 2 + str;
            num = num / 2;
        }
        return str;
    }
    static string DecimalToBinFloat(float flo)
    {
        string str = "";
        flo *= 2;
        while (flo != 0) //until flo gets 0
        {
            str += (int)flo;
            flo -= (int)flo;
            flo *= 2;
        }
        return str;
    }
    static int GetSign(float number)   // Get the sign -> first bit
    {
        if (number < 0)
        {
            return 1;
        }
        return 0;
    }
    static string GetExponent(string integer, string fraction) // Get exponent -> next 8 bits
    {
        int exponent;
        if (integer.Length != 0)
        {
            exponent = integer.Length - 1;
        }
        else
        {
            exponent = -fraction.IndexOf('1') - 1;
        }
        return DecimalToBinInt(127 + exponent).PadLeft(8, '0');
    }
    static string GetMantissa(string integer, string fraction) // Mantissa -> last 23 bits
    {
        string mantissa;
        if (integer.Length != 0)
        {
            mantissa = integer.Substring(1) + fraction;
        }
        else
        {
            mantissa = fraction.Substring(fraction.IndexOf('1') + 1);
        }
        return mantissa.PadRight(23, '0'); // Left aligned
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Enter floating-point  number: ");
        float floatNumber = float.Parse(Console.ReadLine());
        // 32 bits = 1 + 8 + 23 with 24 bits of precision in mantissa

        int sign = GetSign(floatNumber);
        floatNumber = Math.Abs(floatNumber); // If the number is negative make it positive

        string integer = DecimalToBinInt((int)floatNumber); 
        string fraction = DecimalToBinFloat(floatNumber - (int)floatNumber);

        Console.WriteLine("Sign: " + sign);
        Console.WriteLine("Exponent: " + GetExponent(integer, fraction));
        Console.WriteLine("Mantissa: " + GetMantissa(integer, fraction));
    }
}

