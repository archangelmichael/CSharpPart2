using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ThreeInOne
{
    static void Main(string[] args)
    {
        if (File.Exists("../../foobar.txt"))
        {
            Console.SetIn(new StreamReader("../../foobar.txt"));
        }
        Task1();
        Tast2();
        Console.WriteLine(Tast3());
    }

    private static int Tast3()
    {
        int[] coins = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
        int[] current = coins.Take(3).ToArray();
        int[] target = coins.Skip(3).ToArray();
        int G1 = current[0];
        int S1 = current[1];
        int B1 = current[2];
        int G2 = target[0];
        int S2 = target[1];
        int B2 = target[2];
        int operations = 0;
        while (G2 > G1)
        {
            --G2;
            S2 += 11;
            operations++;
        }
        while (S2 > S1)
        {
            if (G1 > G2)
            {
                --G1;
                S1 += 9;
                operations++;
            }
            else
            {
                --S2;
                B2 += 11;
                operations++;
            }
        }
        while (B2 > B1)
        {
            if (S1 > S2)
            {
                --S1;
                B1 += 9;
                operations++;
            }
            else if (G1 > G2)
            {
                --G1;
                S1 += 9;
                operations++;
            }
            else
            {
                return -1;
            }
        }
        return operations; 
        
    }

    

    private static void Tast2()
    {

        int[] sizes = Console.ReadLine().Split(',').Select(s => int.Parse(s)).ToArray();
        int friends = int.Parse(Console.ReadLine());
        // sort
        Array.Sort(sizes, (a, b) => b - a); // Array.Sort => Array.Reverse
        int ate = 0;
        for (int i = 0; i < sizes.Length; i = i + friends + 1)
        {
            ate += sizes[i];
        }
        Console.WriteLine(ate);
    }

    private static void Task1()
    {
        int[] scores = Console.ReadLine().Split(',').Select(s => int.Parse(s)).ToArray();
        int? winner = null;
        for (int i = 0; i < scores.Length; i++)
        {
            int currentScore = scores[i];

            if (currentScore <= 21)
            {
                if (winner == null || currentScore > scores[winner.Value])
                {
                    winner = i;
                }
            }
        }
        if (winner == null)
        {
            Console.WriteLine(-1);
        }
        else
        {
            for (int i = 0; i < scores.Length; i++)
            {
                if (scores[i] == scores[winner.Value] && i != winner.Value)
                {
                    Console.WriteLine(-1);
                    return;
                }
            }
            Console.WriteLine(winner.Value);
        }
    }

}

