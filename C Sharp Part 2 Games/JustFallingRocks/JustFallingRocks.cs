using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class JustFallingRocks
{
    #region Declare Global Variables
    const int SIDEBAR = 15;
    static char[] rocks = {'!','@','#','$','%','^','&','*'};
    static ConsoleColor[] colors =
    {
    ConsoleColor.Blue,
    ConsoleColor.Green,
    ConsoleColor.Cyan,
    ConsoleColor.Red,
    ConsoleColor.Gray,
    ConsoleColor.Yellow,
    ConsoleColor.White,
    };

    static int minRocksPerRow = 1;
    static int maxRocksPerRow = 5;
    static int dwarfX = 0;
    static int dwarfSize = 3;
    static ConsoleColor color = ConsoleColor.Magenta;
    static int score = 0;
    static int lives = 3;
    static bool gameOver = false;
    static bool resumeGame = false;

    static Random generator = new Random();
    #endregion
    static void SetConsoleSizes()
    {
        Console.WindowWidth = 80;
        Console.WindowHeight = 40;
    }
    static void RemoveScrollBars()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.BufferHeight = Console.WindowHeight;
        Console.BufferWidth = Console.WindowWidth;
    }
    static void SetInitialPosition()
    {        
        if (dwarfSize >= Console.WindowWidth)
        {
            dwarfX = 0;
        }
        else
        {
            dwarfX = Console.WindowWidth / 2 - dwarfSize / 2 - SIDEBAR;
        }
        return;
    }

    
    #region Dwarf
    static void DrawDwarf()
    {
        for (int y = dwarfX; y < dwarfX + dwarfSize && Console.WindowWidth - y - SIDEBAR > 0; y++)
        {
            PrintAtPosition(y, Console.WindowHeight - 1, '0', color);           
        }
    }
    static void MoveLeft()
    {
        if (dwarfX > 0)
        {
            dwarfX--;
        }
    }
    static void MoveRight()
    {
        if (dwarfX < Console.WindowWidth - dwarfSize - SIDEBAR)
        {
            dwarfX++;
        }
    }
    static void NewGame(int [,,] positions)
    {
        Console.SetCursorPosition(Console.WindowWidth / 2 - Console.WindowWidth * 6 / 100 - SIDEBAR, Console.WindowHeight / 2);
        Console.Write("Do you want a new game (y / n): ");
        ConsoleKeyInfo pressed = Console.ReadKey();
        if (pressed.KeyChar == 'n')
        {
            gameOver = true;
            return;
        }
        else if ((pressed.KeyChar == 'p' || pressed.Key == ConsoleKey.Escape) && resumeGame)
        {
            resumeGame = false;
            return;
        }
        else if (pressed.KeyChar == 'y')
        {
            lives = 3;
            score = 0;
            SetInitialPosition();
            ClearRocks(positions);
        }
        else if ((pressed.KeyChar == 'p' || pressed.Key == ConsoleKey.Escape) && !resumeGame)
        {
            NewGame(positions);
        }
        else
        {
            NewGame(positions);
        }
        return;
    }
    #endregion

    static void PrintAtPosition(int x, int y, char symbol, ConsoleColor color = ConsoleColor.Green)
    {
        Console.ForegroundColor = color;
        Console.SetCursorPosition(x, y);

        Console.Write(symbol);
        Console.ForegroundColor = ConsoleColor.Green;
    }
    #region Rocks
    static void ClearRocks(int[, ,] positions)
    {
        for (int cols = 0; cols < positions.GetLength(1); cols++)
        {
            positions[0, cols, 0] = 0;
        }
    }
    static void GenerateRocks(int[, ,] positions)
    {
        ClearRocks(positions);
        int count = generator.Next(minRocksPerRow, maxRocksPerRow);
        Console.WriteLine(count);
        for (int i = 0; i < count; i++)
        {
            int position = generator.Next(0, positions.GetLength(1));
            int symbol = generator.Next(0, rocks.Length);
            int color = generator.Next(0, colors.Length);
            Console.Write( (int) rocks[symbol]);

            positions[0, position, 0] = (int)rocks[symbol];
            positions[0, position, 1] = color;
        }
    }
    static void MoveRocks(int[, ,] positions)
    {
        for (int rows = positions.GetLength(0)-2; rows > 0; rows--)
        {
            for (int cols = 0; cols < positions.GetLength(1); cols++)
            {
                for (int values = 0; values < positions.GetLength(2); values++)
                {
                    positions[rows + 1, cols, values] = positions[rows, cols, values];
                }
            }
        }
        GenerateRocks(positions);
    }
   static void DrawRocks(int[, ,] positions)
    {
        for (int rows = positions.GetLength(0) - 2; rows > 0; rows--)
        {
            for (int cols = 0; cols < positions.GetLength(1) - 1; cols++)
            {
                if (positions[rows, cols, 0] != 0)
                {
                    Console.SetCursorPosition(rows, cols);
                    Console.Write((char)positions[rows, cols, 0]);
                    //PrintAtPosition(rows, cols, (char)positions[rows, cols, 0], colors[positions[rows, cols, 2]]);
                }
            }
        }
    }
    #endregion
    static void Main()
    {
        SetConsoleSizes();
        RemoveScrollBars();
        SetInitialPosition();
        //DrawDwarf();
        int[, ,] positions = new int[Console.WindowHeight-1, Console.WindowWidth - SIDEBAR-1, 2];
        
        while (!gameOver)
        {
            #region KeysInput
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.RightArrow)
                {
                    MoveRight();
                }
                else if (key.Key == ConsoleKey.LeftArrow)
                {
                    MoveLeft();
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - Console.WindowWidth * 6 / 100 - SIDEBAR, Console.WindowHeight / 2 - 1);
                    Console.WriteLine("Game Paused. Press p to resume.");
                    resumeGame = true;
                    NewGame(positions);
                }
            }
            #endregion
            MoveRocks(positions);
            ClearRocks(positions);
            Console.Clear();
            DrawDwarf();
            DrawRocks(positions);
            Thread.Sleep(150);

        }

        //Console.Clear();
        //Console.ForegroundColor = ConsoleColor.Red;
        //Console.SetCursorPosition(Console.WindowWidth / 2 - SIDEBAR, Console.WindowHeight / 2);
        //Console.WriteLine("Game Over");
        //Console.SetCursorPosition(Console.WindowWidth / 2 - Console.WindowWidth * 6 / 100 - SIDEBAR, Console.WindowHeight / 2 + 1);
        //Console.WriteLine("Final Score: {0} points!", score);

    }

    
}