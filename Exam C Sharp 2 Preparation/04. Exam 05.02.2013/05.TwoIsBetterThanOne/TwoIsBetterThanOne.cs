using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class TwoIsBetterThanOne
{
    
    static bool IsPalindrom(long number)
    {
        string str = number.ToString();
        for (int i = 0; i < str.Length / 2; i++)
        {
            if (str[i]!= str[str.Length - 1 - i])
            {
                return false;
            }
        }
        return true;
    }
    static int Lucky(long lower, long upper)
    {
        long max = upper; // 1000000000000000000;
        int left = 0;
        var numbers = new List<long> { 3, 5 };
        int count = 0;
        while (left < numbers.Count)
        {
            int right = numbers.Count;
            for (int i = left; i < right; i++)
            {
                if (numbers[i] < max)
                {
                    numbers.Add((numbers[i] * 10)+3);
                    numbers.Add((numbers[i] * 10) + 5);
                }
            }
            left = right;
        }
        foreach (var num in numbers)
        {
            if (num >= lower && num <= upper && IsPalindrom(num))
            {
                count++;
            }
        }
        return count;
    }

    static void Main(string[] args)
    {
        // Task 1
        string[] input = Console.ReadLine().Split(' ');
        long lowerBound = long.Parse(input[0]);
        long upperBound = long.Parse(input[1]);
        int sum = Lucky(lowerBound, upperBound);

        //Task 2
        input = Console.ReadLine().Split(',');
        int percent = int.Parse(Console.ReadLine());
        var tokens = new List<int>(input.Length);
        for (int i = 0; i < input.Length; i++)
        {
            tokens.Add(int.Parse(input[i]));
        }
        tokens.Sort();
        int? answer = null;

        for (int i = 0; i < tokens.Count; i++)
        {
            int smaller = 0;
            for (int j = 0; j < tokens.Count; j++)
            {
                if (tokens[i] >= tokens[j])
                {
                    smaller++;
                }
            }
            if (smaller >= tokens.Count * (percent/100.0))
            {
                answer = tokens[i];
                break;
            }
        }
        if (answer == null)
        {
            answer = tokens[tokens.Count - 1];
        }
        Console.WriteLine(sum);
        Console.WriteLine(answer);
    }
}

