using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.MovingLetters
{
    class MovingLetters
    {
        static void Main(string[] args)
        {

            string[] words = Console.ReadLine().Split();
            int max = 0;
            foreach (var word in words)
            {
                if (word.Length > max)
                {
                    max = word.Length;
                }
            }
            int counter = 0;
            int position = 0;

            StringBuilder result = new StringBuilder();
            while (true)
            {
                for (int i = 0; i < words.Length; i++)
                {
                    if (counter >= words[i].Length)
                    {
                        continue;
                    }
                    position = words[i].Length - counter - 1;
                    if (position >= 0)
                    {
                        result.Append(words[i][position]);
                    }

                }
                counter++;
                if (counter == max)
                {
                    break;
                }
            }
            
            int count = result.Length;
            for (int i = 0; i < result.Length; i++)
            {
                char currentChar = result[i];
                int move;
                if (currentChar >= 'A' && currentChar <='Z')
                {
                    move = (currentChar - 'A' + 1);
                }
                else
                {
                    move = (currentChar - 'a' + 1) ;
                }
                result.Remove(i,1);
                move += i;
                move = move % count;
                result.Insert(move, currentChar);
            }
            Console.WriteLine(result.ToString());
        }
    }
}
