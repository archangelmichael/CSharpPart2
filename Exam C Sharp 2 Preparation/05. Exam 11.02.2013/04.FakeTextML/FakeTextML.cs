using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class FakeTextML
{
    private const string REVOPEN = "<rev>";
    private const string UPOPEN = "<upper>";
    private const string LOWOPEN = "<lower>";
    private const string TOGGLEOPEN = "<toggle>";
    private const string DELOPEN = "<del>";

    private const string REVCLOSE = "</rev>";
    private const string UPCLOSE = "</upper>";
    private const string LOWCLOSE = "</lower>";
    private const string TOGGLECLOSE = "</toggle>";
    private const string DELCLOSE = "</del>";

    static int openedDelTags = 0;
    static StringBuilder output = new StringBuilder();
    static List<string> currentOpenedTags = new List<string> ();
    static List<int> revTagStarts = new List<int>();

    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());
        for (int i = 0; i < number; i++)
        {
            string line = Console.ReadLine();
            int currentSymbolIndex = 0;

            while (currentSymbolIndex < line.Length)
            {
                if (line[currentSymbolIndex] == '<')
                {
                    string tag = GetTag(line, currentSymbolIndex);
                    ProcessTag(tag);
                    currentSymbolIndex += tag.Length - 1;
                }
                else
                {
                    if (openedDelTags == 0)
                    {
                        char symbolToAdd = line[currentSymbolIndex];
                        for (int j = currentOpenedTags.Count - 1; j >= 0; j--)
                        {
                            symbolToAdd = ApplyEffects(symbolToAdd, currentOpenedTags[j]);
                        }
                        output.Append(symbolToAdd);
                    }
                }
                currentSymbolIndex++;
            }
            output.Append('\n');
        }
        Console.WriteLine(output.ToString().Trim());
    }

    static string GetTag(string line, int symbolIndex)
    {
        int tagsStart = symbolIndex;
        int tagEnd = line.IndexOf('>', tagsStart + 1);
        string tag = line.Substring( tagsStart, tagEnd - tagsStart + 1);
        return tag;
    }

    static char ApplyEffects(char symbolToAdd, string currentOpenedTag)
    {

        if (char.IsLetter(symbolToAdd))
        {
            if (currentOpenedTag == UPOPEN)
            {
                symbolToAdd = char.ToUpper(symbolToAdd);
            }
            else if (currentOpenedTag == LOWOPEN)
            {
                symbolToAdd = char.ToLower(symbolToAdd);
            }
            else if (currentOpenedTag == TOGGLEOPEN)
            {
                if (char.IsLower(symbolToAdd))
                {
                    symbolToAdd = char.ToUpper(symbolToAdd);
                }
                else
                {
                    symbolToAdd = char.ToLower(symbolToAdd);
                }
            }
        }
        return symbolToAdd;
    }

    static void ProcessTag(string tag)
    {
        if (tag == DELOPEN)
        {
            openedDelTags++;
        }
        else if (tag == DELCLOSE)
        {
            openedDelTags--;
        }
        else
        {
            if (openedDelTags== 0)
            {
                if (tag == REVOPEN)
                {
                    revTagStarts.Add(output.Length);
                }
                else if (tag == REVCLOSE)
                {
                    int currentRevStart = revTagStarts[revTagStarts.Count - 1];
                    int revEnd = output.Length - 1;
                    Reverse(currentRevStart, revEnd);
                    revTagStarts.RemoveAt(revTagStarts.Count - 1);
                }
                else if (tag[1] == '/' )
                {
                    currentOpenedTags.RemoveAt(currentOpenedTags.Count - 1);
                }
                else
                {
                    currentOpenedTags.Add(tag);
                }
            }
        }
    }

    static void Reverse(int currentRevStart, int revEnd)
    {
        int start = currentRevStart;
        int end = revEnd;
        while (start < end)
        {
            char buffer = output[start];
            output[start] = output[end];
            output[end] = buffer;
            end--;
            start++;
        }
    }
}

