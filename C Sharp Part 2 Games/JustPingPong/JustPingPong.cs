using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JustPingPong
{
    class JustPingPong
    {
        #region Declare Global Variables
        static int ballX = 5;
        static int ballY = 5;
        static int firstPlayerPadSize = 10;
        static int secondPlayerPadSize = 20;

        static int firstPlayerPosition = 0;
        static int secondPlayerPosition = 0;

        static int resultP1 = 0;
        static int resultP2 = 0;

        static bool ballRight = true;
        static bool ballUp = true;

        static bool endOfGame = false;
        static bool resumeGame = false;

        static Random generate = new Random();
        #endregion
        static void RemoveScrollBars()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
        }
        static void SetConsoleSizes()
        {
            Console.WindowWidth = 80;
            Console.WindowHeight = 40;
        }
        static void SetInitialPositions()
        {
            if (firstPlayerPadSize >= Console.WindowHeight)
            {
                firstPlayerPosition = 0;
            }
            else
            {
                firstPlayerPosition = Console.WindowHeight/ 2 - firstPlayerPadSize / 2;
            }
            if (secondPlayerPadSize >= Console.WindowHeight)
            {
                secondPlayerPosition = 0;
            }
            else
            {
                secondPlayerPosition = Console.WindowHeight / 2 - secondPlayerPadSize / 2;
            }
            ballX = Console.WindowWidth / 2;
            ballY = Console.WindowHeight / 2;
            return;
        }
        
        static void PrintAtPosition(int x, int y,char symbol)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(symbol);
        }
        static void DrawFirstPlayer()
        {
            for (int y = firstPlayerPosition; y < firstPlayerPosition + firstPlayerPadSize && Console.BufferHeight - y > 0; y++)
            {
                PrintAtPosition(0,y,'|');
                PrintAtPosition(1, y, '|');
            }
        }
        static void DrawSecondPlayer()
        {
            for (int y = secondPlayerPosition; y < secondPlayerPosition + secondPlayerPadSize && Console.BufferHeight - y > 0; y++)
            {
                PrintAtPosition(Console.WindowWidth - 2, y, '|');
                PrintAtPosition(Console.WindowWidth - 1, y, '|');
            }
        }
        static void DrawBall()
        {
            PrintAtPosition(ballX, ballY,'0');
        }
        static void PrintResult()
        {
            Console.SetCursorPosition(Console.WindowWidth / 2, 0);
            Console.Write("{0}  -  {1} ",resultP1,resultP2);
        }

        static void MoveFirstPlayerUp()
        {
            if (firstPlayerPosition > 0)
            {
                firstPlayerPosition -= 1;
            }            
        }
        static void MoveFirstPlayerDown()
        {
            if (firstPlayerPosition < Console.WindowHeight - firstPlayerPadSize)
            {
                firstPlayerPosition += 1;
            }  
        }
        static void SecondPlayerAIMove()
        {
            int randomMove = generate.Next(1, 101);
            if (randomMove < 70)
            {
                if (ballUp)
                {
                    MoveSecondPlayerUp();
                }
                else
                {
                    MoveSecondPlayerDown();
                }
            }
            else
            {
                if (randomMove == 0)
                {
                    MoveSecondPlayerUp();
                }
                else if (randomMove == 1)
                {
                    MoveSecondPlayerDown();
                }
            }
        }
        static void MoveSecondPlayerUp()
        {
            if (secondPlayerPosition > 0)
            {
                secondPlayerPosition--;
            }  
        }
        static void MoveSecondPlayerDown()
        {
            if (secondPlayerPosition < Console.WindowHeight - secondPlayerPadSize)
            {
                secondPlayerPosition++;
            }  
        }
        static void MoveBall()
        {
            if (ballY == 0)
            {
                ballUp = false;
            }
            else if (ballY == Console.WindowHeight - 1)
            {
                ballUp = true;
            }

            if (ballX == Console.WindowWidth -1)
            {
                resultP1++;
                Console.SetCursorPosition(Console.WindowWidth / 2 - Console.WindowWidth * 6 / 100, Console.WindowHeight / 2 - 1);
                Console.WriteLine("First Player Scores!");
                ballRight = false;          
                NewGame();
            }
            if (ballX == 0)
            {
                resultP2++;
                Console.SetCursorPosition(Console.WindowWidth / 2 - Console.WindowWidth * 6 / 100, Console.WindowHeight / 2 - 1);
                Console.WriteLine("Second Player Scores!");
                ballRight = true;
                NewGame();
            }

            if (ballUp)
            {
                ballY -= 1;
            }
            else
            {
                ballY += 1;
            }

            if (ballRight)
            {
                if (ballX >= Console.WindowWidth - 3 &&  CheckPlayerPosition())
                {
                    ballRight = false;
                    ballX -= 1;
                }
                else
                {
                    ballX += 1;
                }
            }
            else
            {
                if (ballX <= 2 && CheckPlayerPosition(1))
                {
                    ballRight = true;
                    ballX += 1;
                }
                else
                {
                    ballX -= 1;
                }
            }
        }

        static bool CheckPlayerPosition(int player = 0)
        {
            if (player == 1)
            {
                if (firstPlayerPosition <= ballY && firstPlayerPosition + firstPlayerPadSize > ballY)
                {
                    return true;
                }
                return false;
            }
            else
            {
                if (secondPlayerPosition <= ballY && secondPlayerPosition + secondPlayerPadSize > ballY)
                {
                    return true;
                }
                return false;
            }
        }
        static void NewGame()
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - Console.WindowWidth * 6 / 100, Console.WindowHeight / 2);
            Console.Write("Do you want a new game (y / n): ");
            ConsoleKeyInfo pressed = Console.ReadKey();
            if (pressed.KeyChar == 'n')
            {
                endOfGame = true;
                return;
            }
            else if ((pressed.KeyChar == 'p' || pressed.Key == ConsoleKey.Escape) && resumeGame)
            {
                resumeGame = false;
                return;
            }
            else if (pressed.KeyChar == 'y')
            {
                SetInitialPositions();
            }
            else if ((pressed.KeyChar == 'p' || pressed.Key == ConsoleKey.Escape) && !resumeGame)
            {
                NewGame();
            }
            else
            {
                NewGame();
            }
            return;
        }

        static void Main()
        {
            SetConsoleSizes();
            RemoveScrollBars();
            SetInitialPositions();

            DrawFirstPlayer();
            DrawSecondPlayer();

            while (!endOfGame)
            {
                #region
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.UpArrow)
                    {
                        MoveFirstPlayerUp();
                    }
                    else if (key.Key == ConsoleKey.DownArrow)
                    {
                        MoveFirstPlayerDown();
                    }
                    else if (key.Key == ConsoleKey.W)
                    {
                        MoveSecondPlayerUp();
                    }
                    else if (key.Key == ConsoleKey.S)
                    {
                        MoveSecondPlayerDown();
                    }
                    else if (key.Key == ConsoleKey.Escape)
                    {
                        Console.SetCursorPosition(Console.WindowWidth / 2 - Console.WindowWidth * 6 / 100, Console.WindowHeight / 2 - 1);
                        Console.WriteLine("Game Paused. Press p to resume.");
                        resumeGame = true;
                        NewGame();
                    }
                }
                #endregion
                SecondPlayerAIMove();
                MoveBall();
                Console.Clear();
                DrawFirstPlayer();
                DrawSecondPlayer();
                DrawBall();
                PrintResult();
                
                Thread.Sleep(30);
            }
            #region End Of Game
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
            Console.WriteLine("Game Over");
            Console.SetCursorPosition(Console.WindowWidth / 2 - Console.WindowWidth * 6 / 100, Console.WindowHeight / 2 + 1);
            Console.WriteLine("Final Score: {0} to {1}!", resultP1, resultP2);
            Console.SetCursorPosition(Console.WindowWidth / 2 - Console.WindowWidth * 6 / 100, Console.WindowHeight / 2 + 2);
            if (resultP1 == resultP2)
            {
                Console.WriteLine("It is a Tie!");
            }
            else
            {
                Console.WriteLine("Player {0} Wins!", resultP1 >= resultP2 ? '1' : '2');
            }
            Console.SetCursorPosition(Console.WindowWidth / 2 - Console.WindowWidth * 6 / 100, Console.WindowHeight - 2);
            #endregion
        }
    }
}