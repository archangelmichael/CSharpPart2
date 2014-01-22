using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Laser
{
    static int[] GetNumbers()
    {
        string[] input = Console.ReadLine().Split(' ');
        return input.Select(s => int.Parse(s)).ToArray();
    }
    static int HowManyAreLimit(int [] pos, int [] size)
    {
        int count = 0;
        for (int i = 0; i < 3; i++)
        {
            if (pos[i] == 0 || pos[i] == size[i] - 1)
            {
                count++;
            }
        }
        return count;
    }
    static void Main()
    {
        int[] size = GetNumbers();
        bool[, ,] visit = new bool[size[0], size[1], size[2]];
        int[] pos = GetNumbers();
        pos[0] -= 1;
        pos[1] = size[1] - pos[1];
        pos[2] -= 1;
        int[] dir = GetNumbers();
        dir[1] *= -1;

        while (true)
        {
            visit[pos[0],pos[1],pos[2]] =  true;
            int[] newPos = new int [3];
            for (int i = 0; i < 3; i++)
            {
                newPos[i] = pos[i] + dir[i];
            }
            if (visit[newPos[0], newPos[1], newPos[2]] || HowManyAreLimit(newPos, size) >= 2)
            {
                Console.WriteLine("{0} {1} {2}", pos[0] + 1, size[1] - pos[1], pos[2] + 1);
                break;
            }
            if (HowManyAreLimit(newPos,size) == 1)
            {
                ReverseDirection(newPos, dir, size);
            }
            for (int i = 0; i < 3; i++)
            {
                pos[i] = newPos[i];
            }
        }
    }
    static void ReverseDirection(int[] newPos, int[] dir, int[] size)
    {
        for (int i = 0; i < 3; i++)
        {
            if (newPos[i] == 0 && dir[i] == -1)
            {
                dir[i] *= -1;
            }
            else if (newPos[i] ==  size[i] - 1 && dir[i] == 1)
            {
                dir[i] *= -1;
            }
        }
    }
}

