using System;

/*  Write a program to convert binary numbers to hexadecimal numbers (directly).    */

    class ConvertBinaryToHex
    {
        static char GetHexChar(int num)
        {
            if (num >= 10) 
            {
                return (char)(num + 'A' - 10);
            }
            return (char)(num + '0');
        }
        static int GetBinDigit(string s, int i)
        {
            return s[i] - '0';
        }
        static string BinToHex(string bin)
        {
            string result = "";
            if (bin.Length % 4 != 0)
            {
                return BinToHex(new string('0', 4 - bin.Length % 4) + bin);
            }
            for (int i = bin.Length - 1; i >= 0; i -= 4)
            {
                int nibble = 0;
                for (int j = 0, rate = 1; j < 4; j++, rate *= 2)
                {
                    nibble += GetBinDigit(bin, i - j) * rate;
                }
                result = GetHexChar(nibble) + result;
            }
            return result;
        }
        static void Main()
        {
            Console.WriteLine("Enter number in binary system: ");
            string binary = Console.ReadLine();
            Console.WriteLine(BinToHex(binary));
        }
    }

