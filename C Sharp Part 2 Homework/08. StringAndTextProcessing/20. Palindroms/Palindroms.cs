using System;

/*  Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".
 */
class Palindroms
{
    static void Main()
    {
        // to test " Nice blue sky. No exe flying in the sky. ABBA will not come in Bulgaria. I don`t know what is lamal, maybe I will find some day. mouseesuom";
        string[] words = Console.ReadLine().Split(new char[] { ' ', ',', '.', '!', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string word in words)
        {
            bool isPalindrome = true;
            for (int i = 0; i < (word.Length / 2); i++)
            {
                if (word[i] != word[word.Length - 1 - i])
                {
                    isPalindrome = false;
                    break;
                }
            }
            if (isPalindrome && word.Length > 1)
            {
                Console.WriteLine(word);
            }
        }
    }
}

