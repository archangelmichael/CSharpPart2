using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.EncodeAndEncrypt
{
    class EncodeAndEncrypt
    {
        static string Encrypt(string input, string cypher)
        {
            string result = string.Empty;
            if (input.Length > cypher.Length)
            {
                result = EncryptLongerMessage(input, cypher);
            }
            else
            {
                result = EncryptshorterMessage(input, cypher);
            }
            return result;
        }

        static string EncryptshorterMessage(string input, string cypher)
        {
            StringBuilder result = new StringBuilder(input);
            int messageIndex = 0;
            for (int i = 0; i < cypher.Length; i++)
            {
                char take = result[messageIndex];
                char make = cypher[i];
                char encryptedSymbol = EncryptSymbol(take, make);
                result[messageIndex] = encryptedSymbol;
                messageIndex++;
                if (messageIndex == input.Length) //cypherIndex = i % cypher.Length;
                {
                    messageIndex = 0;
                }
            }
            return result.ToString();
        }

        static string EncryptLongerMessage(string input, string cypher)
        {
            StringBuilder result = new StringBuilder();
            int cypherIndex = 0;
            for (int i = 0; i < input.Length; i++)
            {
                char take = input[i];
                char make = cypher[cypherIndex];
                char encryptedSymbol = EncryptSymbol(take,make);
                result.Append(encryptedSymbol);
                cypherIndex++;
                if (cypherIndex == cypher.Length) //cypherIndex = i % cypher.Length;
                {
                    cypherIndex = 0;
                }
            }
            return result.ToString();
        }

        static char EncryptSymbol(char take, char make)
        {
            int get = take - 'A';
            int mad = make - 'A';
            int xor = get ^ mad ;
            return (char)(xor + 'A');
        }

        static string Encode(string input)
        {
            StringBuilder compressed = new StringBuilder();
            char previous = input[0];
            int counter = 1;

            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == previous )
                {
                    counter++;
                }
                else
                {
                    AppendCompressed(counter, compressed, previous);
                    counter = 1;
                }
                previous = input[i];
            }
            AppendCompressed(counter, compressed, previous);
            return compressed.ToString();
        }

        static void AppendCompressed(int counter, StringBuilder result, char previous)
        {
            if (counter == 1)
            {
                result.Append(previous);
            }
            else if (counter == 2)
            {
                result.Append(new string(previous, counter));
            }
            else
            {
                result.Append(counter + previous.ToString());
            }
        }

        static void Main()
        {
            string message = Console.ReadLine();
            string cypher = Console.ReadLine();
            string cypherText = Encrypt(message, cypher);
            int lengthOfCypher = cypher.Length;
            string final = Encode(Encrypt(message, cypher) + cypher) + lengthOfCypher;
            Console.WriteLine(final);
        }
    }
}
