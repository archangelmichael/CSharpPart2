using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

/* Write a program that extracts from a given text 
 * all dates that match the format DD.MM.YYYY. 
 * Display them in the standard date format for Canada. */

class DatesExtraction
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(new char[] { ' ', '?', '!', ';', ',', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < input.Length; i++) // Check for '.' in the end
        {
            if (input[i].LastIndexOf('.') == input[i].Length - 1)
            {
                input[i] = input[i].Substring(0, input[i].Length - 1);
            }
        }
        foreach (var word in input)  // can be done with regular expression @"\b\d{2}.\d{2}.\d{4}\b"
        {
            DateTime date;
            if (DateTime.TryParseExact(word, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                string dateCanada = date.ToString(CultureInfo.GetCultureInfo("en-CA").DateTimeFormat.ShortDatePattern);
                Console.WriteLine(dateCanada);
            }
        }
    }
}

