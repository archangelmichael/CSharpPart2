using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Brackets
{
    static bool isFirstSymbol = true;
    static bool printLine = false;
    static string tab;
    static StringBuilder result = new StringBuilder();
    static int tabCount = 0;
    static void HandleLine(string line = "")
    {
        for (int i = 0; i < line.Length; i++)
        {
            char current = line[i];
            if (printLine && char.IsWhiteSpace(current))
            {
                continue;
            }
            if (printLine)
            {
                result.AppendLine();
                printLine = false;
                isFirstSymbol = true;
            }
            if (current == '{')
            {
                if (!printLine)
                {
                    if (!isFirstSymbol)
                    {
                        if (result.Length > 0 && char.IsWhiteSpace(result[result.Length - 1]))
                        {
                            result.Remove(result.Length - 1, 1);
                        }
                        result.AppendLine();
                    }
                }

                AppendTabs();
                result.Append(current);
                tabCount++;
                printLine = true;
            }
            else if (current == '}')
            {
                tabCount--;
                if (!printLine)
                {
                    if (!isFirstSymbol)
                    {
                        if (result.Length > 0 && char.IsWhiteSpace(result[result.Length - 1]))
                        {
                            result.Remove(result.Length - 1, 1);
                        }
                        result.AppendLine();
                    }
                }
                AppendTabs();
                result.Append(current);
                printLine = true;
            }
            else
            {
                if (isFirstSymbol)
                {
                    AppendTabs();
                }
                if (!(isFirstSymbol && char.IsWhiteSpace(current)))
                {
                    if (!(i < line.Length - 1 && char.IsWhiteSpace(line[i]) && char.IsWhiteSpace(line[i+1])) )
                    {
                        result.Append(current);
                    }
                }
                isFirstSymbol = false;
            }
        }
        printLine = true;
        isFirstSymbol = true;
    }

    static void AppendTabs()
    {
        for (int i = 0; i < tabCount; i++)
        {
            result.Append(tab);
        }
    }


    static void Main(string[] args)
    {
        int lines = int.Parse(Console.ReadLine());
        tab = Console.ReadLine();
        for (int i = 0; i < lines; i++)
        {
            HandleLine(Console.ReadLine());
        }
        Console.WriteLine(result.ToString());
    }
}

