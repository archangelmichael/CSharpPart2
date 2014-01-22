using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class OneTaskIsNotEnough
{
    static int Task1()
    {
        int countOff = int.Parse(Console.ReadLine());
        var turnedOn = new bool[countOff + 1];
        var lampsStillOff = new int[countOff + 1];
        int lastLamp = 0;

        for (int i = 1; i < countOff; i++)
        {
            lampsStillOff[i] = i;
        }
        int jump = 1;
        while (countOff > 0)
        {
            jump++;
            Array.Clear(turnedOn,1 , countOff);

            int turnOnNowCount = 0;
            
            for (int i = 1; i <= countOff; i+= jump)
            {
                turnedOn[i] = true;
            }

            int newCountOff = 0;
            for (int i = 1; i <= countOff; i++)
            {
                if (!turnedOn[i])
                {
                    newCountOff++;
                    lampsStillOff[newCountOff] = lampsStillOff[i];
                    lastLamp = lampsStillOff[i];
                }
            }
            countOff = newCountOff;
        }
        return lastLamp;
    }
    static void Main(string[] args)
    {
        string results = Task1() + Environment.NewLine + Task2() + Environment.NewLine + Task2();
        Console.WriteLine(results);
    }

    static string Task2()
    {
        string commands = Console.ReadLine();
        int[] dx = { 1, 0, -1, 0 };
        int[] dy = { 0, 1, 0, -1 };

        int x = 0;
        int y = 0;
        int way = 0;
        for (int i = 0; i < 4; i++)
        {
            foreach (var command in commands)
            {
                if (command == 'S')
                {
                    x += dx[way];
                    y += dy[way];
                }
                else if (command == 'L')
                {
                    way -= 1;
                    way += 4;
                    way %= 4;
                }
                else if (command == 'R')
                {
                    way += 1;
                    way %= 4;
                }
            }
        }
        if (x == 0 && y == 0)
        {
            return "bounded";
        }
        else
        {
            return "unbounded";
        }

    }
}

