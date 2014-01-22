using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Slides
{
    class Ball
    {
        public Ball(int ballWidth, int ballHeight, int ballDepth)
        {
            this.BallWidth = ballWidth;
            this.BallHeight = ballHeight;
            this.BallDepth = ballDepth;
        }
        public Ball(Ball ball)
        {
            this.BallWidth = ball.BallWidth;
            this.BallHeight = ball.BallHeight;
            this.BallDepth = ball.BallDepth;
        }
        public int BallWidth { get; set; }
        public int BallHeight { get; set; }
        public int BallDepth { get; set; }
    }
    class Slides
    {
        private static int width, depth, height;
        private static string[, ,] cube;
        private static Ball cubeBall;
        static void Main()
        {
            if (File.Exists("../../test.txt"))
            {
                Console.SetIn(new StreamReader("../../test.txt"));
            }
            ReadInput();
            ProcessBallCommands();
        }
        private static void ProcessBallSlides(string command)
        {
            Ball newCubeBall = new Ball(cubeBall);
            switch (command)
            {
                case "R":
                    newCubeBall.BallHeight++;
                    newCubeBall.BallWidth++;
                    break;
                case "L":
                    newCubeBall.BallWidth--;
                    newCubeBall.BallHeight++;
                    break;
                case "F":
                    newCubeBall.BallDepth--;
                    newCubeBall.BallHeight++;
                    break;
                case "B":
                    newCubeBall.BallDepth++;
                    newCubeBall.BallHeight++;
                    break;
                case "FL":
                    newCubeBall.BallDepth--;
                    newCubeBall.BallWidth--;
                    newCubeBall.BallHeight++;
                    break;
                case "FR":
                    newCubeBall.BallDepth--;
                    newCubeBall.BallWidth++;
                    newCubeBall.BallHeight++;
                    break;
                case "BL":
                    newCubeBall.BallDepth++;
                    newCubeBall.BallWidth--;
                    newCubeBall.BallHeight++;
                    break;
                case "BR":
                    newCubeBall.BallDepth++;
                    newCubeBall.BallWidth++;
                    newCubeBall.BallHeight++;
                    break;
                default: throw new ArgumentException("Invalid Command!");
                    break;
            }
            if (IsPassable(newCubeBall))
            {
                cubeBall = new Ball(newCubeBall);
            }
            else
            {
                PrintMessage();
                Environment.Exit(0);
            }
        }
        private static void PrintMessage()
        {
            string currentCell  = cube[cubeBall.BallWidth, cubeBall.BallHeight, cubeBall.BallDepth];
            if (currentCell == "B" || cubeBall.BallHeight != height - 1)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine("Yes");
            }
            Console.WriteLine("{0} {1} {2}",cubeBall.BallWidth, cubeBall.BallHeight, cubeBall.BallDepth);
        }
        private static bool IsPassable(Ball ball)
        {
            if (ball.BallWidth >= 0 && ball.BallHeight >= 0 && ball.BallDepth >= 0 && 
                ball.BallWidth < width && ball.BallHeight < height && ball.BallDepth < depth)
            {
                return true;
            }
            return false;
        }
        private static void ProcessBallCommands()
        {
            while (true)
            {
                string currentCell = cube[cubeBall.BallWidth, cubeBall.BallHeight, cubeBall.BallDepth];
                string[] splittedCell = currentCell.Split();
                string command = splittedCell[0];
                switch (command)
                {
                    case "S": 
                        ProcessBallSlides(splittedCell[1]);
                        break;
                    case "T":
                        cubeBall.BallWidth = int.Parse(splittedCell[1]);
                        cubeBall.BallDepth = int.Parse(splittedCell[2]);
                        break;
                    case "B":
                        PrintMessage();
                        return;
                    case "E":
                        if (cubeBall.BallHeight == height -1)
                        {
                            PrintMessage();
                            return;
                        }
                        else
                        {
                            cubeBall.BallHeight++;
                        }
                        break;
                    default: throw new ArgumentException("Invalid Command!");
                        break;
                }
            }
        }
        private static void ReadInput()
        {
            string[] raw = Console.ReadLine().Split(' ');
            width = int.Parse(raw[0]);
            height = int.Parse(raw[1]);
            depth = int.Parse(raw[2]);
            cube = new string[width, height, depth];

            for (int h = 0; h < height; h++)
            {
                string[] line = Console.ReadLine().Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
                for (int d = 0; d < depth; d++)
                {
                    string[] cubeContent = line[d].Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int w = 0; w < width; w++)
                    {
                        cube[w, h, d] = cubeContent[w];
                    }
                }
            }
            raw = Console.ReadLine().Split(' ');
            int ballWidth = int.Parse(raw[0]);
            int ballDepth = int.Parse(raw[1]);
            cubeBall = new Ball(ballWidth, 0, ballDepth);
        }
    }
}
