using System;

/*   Write a program to convert hexadecimal numbers to binary numbers (directly).   */

class ConvertHexToBinary
{
    static int GetHexChar(string s, int i)
    {
        if (s[i] >= 'A' && s[i] <= 'F') // For capital letters
        {
            return s[i] - 'A' + 10;
        }
        else if (s[i] >= 'a' && s[i] <= 'f') // For small letters
        {
            return s[i] - 'a' + 10;
        }
        return s[i] - '0';
    }
    static string HexToBin(string hex)
    {
        string result = "";
        for (int i = hex.Length - 1; i >= 0; i--)
        {
            for (int j = 0, tempNumber = GetHexChar(hex, i); j < 4; j++, tempNumber /= 2)
            {
                result = tempNumber % 2 +  result;
            }
        }
        return result;
    }
    static void Main()
    {
        Console.WriteLine("Enter number in hex system: ");
        string hex = Console.ReadLine();
        Console.WriteLine(HexToBin(hex));
    }
}

