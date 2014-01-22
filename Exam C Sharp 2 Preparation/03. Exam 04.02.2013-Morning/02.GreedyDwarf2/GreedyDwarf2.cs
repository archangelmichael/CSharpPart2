using System;
    class GreedyDwarf2
    {
        static long ProcessPattern(int[] vally)
        {
            string[] rawNumbers = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] pattern = new int[rawNumbers.Length];
            for (int i = 0; i < pattern.Length; i++)
            {
                pattern[i] = int.Parse(rawNumbers[i]); 
            }
            bool[] visited = new bool[vally.Length];
            long coinSum = 0;
            coinSum += vally[0];
            visited[0] = true;
            int current = 0;
            while (true)
            {
                for (int i = 0; i < pattern.Length; i++)
                {
                    int nextMove = current + pattern[i];
                    if (nextMove >= 0 && nextMove < vally.Length && !visited[nextMove])
                    {
                        coinSum += vally[nextMove];
                        visited[nextMove] = true;
                        current = nextMove;
                    }
                    else
                    {
                        return coinSum;
                    }
                }
            }
        }
        static void Main(string[] args)
        {

            string[] rawNumbers = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] vally = new int [rawNumbers.Length ];
            for (int i = 0; i < rawNumbers.Length; i++)
            {
                vally[i] = int.Parse(rawNumbers[i]);
            }


            // input patterns
            int patterns = int.Parse(Console.ReadLine());
            long max = long.MinValue;
            for (int i = 0; i < patterns; i++)
            {
                long sum = ProcessPattern(vally);
                if ( sum > max)
                {
                    max = sum;
                }
            }
            Console.WriteLine(max);
        }
    }

