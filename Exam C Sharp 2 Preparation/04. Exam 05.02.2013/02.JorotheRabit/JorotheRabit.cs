using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.JorotheRabit
{
    class JorotheRabit
    {
        static void Main(string[] args)
        {
            string[] field = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            int [] numbers = new int [field.Length];
            for (int i = 0; i < field.Length; i++)
			{
			    numbers[i]  = int.Parse(field[i]);
			}
            long maxVisited = 1;
            for (int i = 0; i < field.Length; i++)
            {
                for (int step = 1; step < field.Length; step++)
                {
                    int current = i;
                    int stepCounter = 1;
                    int next = 0;
                    int currentValue = numbers[i];
                    while (true)
                    {
                        if (step + current > numbers.Length  - 1 )
                        {
                            next = (step + current) - numbers.Length;
                        }
                        else
                        {
                            next = (step + current);
                        }
                        if (numbers[next] <= currentValue )
                        {
                            break;
                        }
                        else if(numbers[next] > currentValue)
                        {
                            stepCounter++;
                            current = next;
                            currentValue = numbers[next];
                        }
                    }
                    if (stepCounter > maxVisited)
                    {
                        maxVisited = stepCounter;
                    }
                }
            }
            Console.WriteLine(maxVisited);
        }
    }
}
