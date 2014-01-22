
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class DecodeAndDecrypt
{
    static string Decode(string encodedMessage)
    {
        var result = new StringBuilder();
        int count = 0;
        foreach (var symbol in encodedMessage)
        {
            if (char.IsDigit(symbol))
            {
                count *= 10;
                count += int.Parse(symbol.ToString());// symbol - '0'
            }
            else
            {
                if (count == 0)
                {
                    result.Append(symbol);
                }
                else
                {
                    result.Append(symbol, count);
                    count = 0;
                }
            }
        }
        return result.ToString();
    }
    static string Encrypt(string message, string cypher)
    {
        var result = new StringBuilder(message);

        var steps = Math.Max(message.Length, cypher.Length);
        for (int step = 0; step < steps; step++)
        {
            var messageIndex = step % message.Length;
            var cypherIndex = step % cypher.Length;
            result[messageIndex] = (char)(((result[messageIndex] - 'A') ^ (cypher[cypherIndex] - 'A')) + 'A');
        }
        return result.ToString();
    }
    static void Main()
    {
        string input = Console.ReadLine();

        var digits = new List<int>();
        for (int i = input.Length-1; i >= 0 ; i--)
        {
            if (char.IsDigit(input[i])) // input[i]>='0' && input[i] <= '9'
            {
                digits.Add(input[i] - '0');
            }
            else
            {
                break;
            }
        }
        digits.Reverse();
        //string result = string.Join(" ", digits);
        //Console.WriteLine(result);

        int lengthOfCrypter = 0;
        for (int i = 0; i < digits.Count; i++)
        {
            lengthOfCrypter *= 10;
            lengthOfCrypter += digits[i];
        }

        var encodedMessage = input.Substring(0, input.Length - digits.Count);
        var decodedMessage = Decode(encodedMessage);
        var encryptedMessage = decodedMessage.Substring(0, decodedMessage.Length - lengthOfCrypter); 
        var crypter = decodedMessage.Substring(decodedMessage.Length - lengthOfCrypter);

        string finish = Encrypt(encryptedMessage, crypter);
        Console.WriteLine(finish);
        // ABBAA6BA7 -> AAABB
    }
}
