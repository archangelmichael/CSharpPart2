using System;
using System.IO;
using System.Text;

/*  Write a program that extracts from given XML file all the text without the tags.*/
class TextWithoutTags
{
    static void Main()
    {
        string input = @"..\..\Input.xml";
        using (StreamReader read = new StreamReader(input))
        {
            string text = read.ReadToEnd();
            int index = 0;

            while (index != text.Length -1 && index != -1)
            {
                int start = text.IndexOf(">", index); // search for next closing index >
                int end = text.IndexOf("<", start); // search for next opening index <
                if (end != start + 1)
                {
                    string extract = text.Substring(start + 1, end - start-1); // extract the text between > and <
                    extract.Trim();
                    Console.WriteLine(extract);
                }
                index = text.IndexOf(">", end + 1);
            }
        }
    }
}

