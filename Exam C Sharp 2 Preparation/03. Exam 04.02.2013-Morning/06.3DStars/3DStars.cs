using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class _3DStars
{
    
    private static int width, height, depth, starCount;
    private static char[,,] cube;
    private static Dictionary<char, int> starType = new Dictionary<char, int>();
    static void Main(string[] args)
    {
        if (File.Exists("../../tests.txt"))
        {
            Console.SetIn(new StreamReader("../../tests.txt"));
        }
        ReadInput();
        FindStarts();
        PrintMessage();
    }

    private static void ReadInput()
    {
        string[] rawNumbers = Console.ReadLine().Split(' ');
        width = int.Parse(rawNumbers[0]);
        height = int.Parse(rawNumbers[1]);
        depth = int.Parse(rawNumbers[2]);
        cube = new char[width, height, depth];
        for (int h = 0; h < height; h++)
        {
            string[] line = Console.ReadLine().Split(' ');

            for (int d = 0; d < depth; d++)
            {
                string cubeContent = line[d];
                for (int w = 0; w < width; w++)
                {
                    cube[w, h, d] = cubeContent[w];
                }
            }
        }
    }

    private static void FindStarts()
    {
        for (int w = 1; w < width - 1; w++)
        {
            for (int h = 1; h < height - 1; h++)
            {
                for (int d = 1; d < depth - 1; d++)
                {
                    FindSingleStar(w,h,d);
                }
            }
        }
    }

    private static void FindSingleStar(int we, int he, int de)
    {
        char current = cube[we, he, de];
        bool isStar =
            current == cube[we - 1, he, de] &&
            current == cube[we + 1, he, de] &&
            current == cube[we, he - 1, de] &&
            current == cube[we, he + 1, de] &&
            current == cube[we, he, de - 1] &&
            current == cube[we, he, de + 1];
        if (isStar)
        {
            starCount++;
            if (starType.ContainsKey(current))
            {
                starType[current]++;
            }
            else
            {
                starType.Add(current, 1);
            }
        }
    }

    private static void PrintMessage()
    {
        var sorted = starType.OrderBy(x => x.Key);
        Console.WriteLine(starCount);
        foreach (var star in sorted)
        {
            Console.WriteLine("{0} {1}", star.Key, star.Value);
        }
    }
}

