using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* test
8 4 6
2MLM1MRM2MR2MLMLMR3MRM  
LMMR2M4MRMLMRMR1M2MRM
*/

namespace _3.Trails3D
{
    class Trails3D
    {
        static bool[,] field;
        static string ConvertCommands(string path)
        {
            StringBuilder result = new StringBuilder();
            path = path.Replace("M", " M ");
            path = path.Replace("L", " L ");
            path = path.Replace("R", " R ");
            string[] separatedPaths = path.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string lastNumber = null;
            for (int i = 0; i < separatedPaths.Length; i++)
            {
                if (separatedPaths[i] == "L" || separatedPaths[i] == "R")
                {
                    result.Append(separatedPaths[i]);
                }
                else if (separatedPaths[i] == "M")
                {
                    if (lastNumber == null)
                    {
                        result.Append("M");
                    }
                    else
                    {
                        int number = int.Parse(lastNumber);
                        result.Append(new string('M', number));
                        lastNumber = null;
                    }
                }
                else
                {
                    lastNumber = separatedPaths[i];
                }
            }
            result.Replace("LM", "L");
            result.Replace("RM", "R");
            return result.ToString(); ;
        }
        static void Main(string[] args)
        {
            string[] xyz = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int x = int.Parse(xyz[0]);
            int y = int.Parse(xyz[1]);
            int z = int.Parse(xyz[2]);
            string redMoves = ConvertCommands(Console.ReadLine());
            string blueMoves = ConvertCommands(Console.ReadLine());

            field = new bool [y + 1,2*(z+x)];

            int redrow = y / 2;
            int redcol = z + x / 2;
            string redDirection = "right";
            int bluerow = y / 2;
            int bluecol = 2 * z + x + x / 2;
            string blueDirection = "left";

            bool redOver = false;
            bool blueOver = false;

            field[redrow, redcol] = true;
            field[bluerow, bluecol] = true;

            for (int i = 0; i < redMoves.Length; i++)
            {
                #region red
                char currentRedMove = redMoves[i];
                if (currentRedMove == 'L' || currentRedMove == 'R')
                {
                    redDirection = ChangeDirection(redDirection, currentRedMove);
                }
                Move(ref redrow, ref redcol, redDirection);


                // check forbidden walls
                if (redrow < 0)
                {
                    redrow = 0;
                    redOver = true;
                }
                if (redrow == field.GetLength(0))
                {
                    redrow = field.GetLength(0)-1;
                    redOver = true;
                }

                if (field[redrow,redcol])
                {
                    redOver = true;
                }
                #endregion
                #region blue
                char currentBlueMove = blueMoves[i];
                if (currentBlueMove == 'L' || currentBlueMove == 'R')
                {
                    blueDirection = ChangeDirection(blueDirection, currentBlueMove);
                }
                Move(ref bluerow, ref bluecol, blueDirection);


                // check forbidden walls
                if (bluerow < 0)
                {
                    bluerow = 0;
                    blueOver = true;
                }
                if (bluerow == field.GetLength(0))
                {
                    bluerow = field.GetLength(0) - 1;
                    blueOver = true;
                }

                if (field[bluerow, bluecol])
                {
                    blueOver = true;
                }
                #endregion 

                if (redrow == bluerow && redcol == bluecol)
                {
                    redOver = true;
                    blueOver = true;
                }

                if (redOver && !blueOver)
                {
                    Console.WriteLine("BLUE");
                    break;
                }
                if (!redOver && blueOver)
                {
                    Console.WriteLine("RED");
                    break;
                }
                if (redOver && blueOver )
                {
                    Console.WriteLine("DRAW");
                    break;
                }

                field[redrow, redcol] = true;
                field[bluerow, bluecol] = true;
            }
            int distanceY = Math.Abs(redrow - y / 2);
            int distanceX = Math.Abs(redcol - (z + x / 2));
            if (distanceX > field.GetLength(1) / 2)
            {
                distanceX = field.GetLength(1) - distanceX;
            }
            Console.WriteLine(distanceX + distanceY);
        }

        private static void Move(ref int row, ref int col, string direction)
        {
            switch (direction)
            {
                case "up":
                    row--;
                    break;
                case "down":
                    row++;
                    break;
                case "left":
                    col--;
                    break;
                case "right":
                    col++;
                    break;
                default:
                    throw new ArgumentException("direction", "Invalid");
            }
            if (col < 0 )
            {
                col = field.GetLength(1) - 1;
            }
            if (col == field.GetLength(1))
            {
                col = 0;
            }
        }
        static string ChangeDirection(string direction, char move)
        {
            switch (direction)
            {
                case "up":
                    if (move == 'L') return "left";
                    if (move == 'R') return "right";
                    break;
                case "down":
                    if (move == 'L') return "right";
                    if (move == 'R') return "left";
                    break;
                case "left":
                    if (move == 'L') return "down";
                    if (move == 'R') return "up";
                    break;
                case "right":
                    if (move == 'L') return "up";
                    if (move == 'R') return "down";
                    break;
                default:
                    throw new ArgumentException("direction", "Invalid");
            }
            throw new ArgumentException("direction", "Invalid");
        }
    }
}
