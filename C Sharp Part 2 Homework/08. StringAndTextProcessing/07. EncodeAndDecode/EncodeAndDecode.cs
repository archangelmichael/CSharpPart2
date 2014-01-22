using System;
using System.Text;

/*  Write a program that encodes and decodes a string using given encryption key (cipher). 
 * The key consists of a sequence of characters. 
 * The encoding/decoding is done by performing XOR (exclusive or) operation 
 * over the first letter of the string with the first of the key, the second – with the second, etc.
 * When the last key character is reached, the next is the first. */

    class EncodeAndDecode
    {
        static string EncodeMessage(string input, string key)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                result.Append((char)(input[i] ^ key[i % key.Length]));
            }
            return result.ToString();
        }
        static string DecodeMessage(string input, string key) // Same as EodeMessage. Wrote it just for educational purpose. 
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                result.Append((char)(input[i] ^ key[i%key.Length]));
            }
            return result.ToString();
        }
        static void Main()
        {
            string message = Console.ReadLine();
            string cipher = Console.ReadLine();
            string encodedMessage = EncodeMessage(message, cipher);
            string decodedMessage = DecodeMessage(encodedMessage, cipher);
            Console.WriteLine("Original message is:" + message);
            Console.WriteLine("Encoded message is:" + encodedMessage);
            Console.WriteLine("Decoded message is:" + decodedMessage);
        }
    }

