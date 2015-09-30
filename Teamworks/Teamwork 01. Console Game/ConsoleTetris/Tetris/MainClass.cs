using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tetris
{
    internal class MainClass
    {
        #region Global Variables
        static bool[,] GameBoard = new bool[TetrisHeight, TetrisWidth];
        private static int Points = 0;
        private const int LevelPoints = 10;
        const char BorderCharacter = (char)219;
        const char BrickCharacter = 'o';
        const int TetrisWidth = 10;
        const int TetrisHeight = 16;
        const int InfoPanelWidth = 10;
        const int GameWidth = TetrisWidth + InfoPanelWidth + 3;
        const int GameHeight = TetrisHeight + 2;
        static bool[,] currentBrick;
        static int currentBrickRow = 0;
        static int currentBrickCol = 4;
        static Random randomGenerator = new Random();
        private static bool[][,] Bricks = new bool[8][,]
        {
            new [,]
            {
                {true, true, true, true}
            },
            new bool[,]
            {
                {true},
                {true},
                {true},
                {true}
            },
            new [,]
            {
                {true, true, true},
                {false, false, true}
            },
            new [,]
            {
                {true, true, true},
                {true, false, false}
            },
            new [,]
            {
                {true, true},
                {true, true}
            },
            new [,]
            {
                {false, true, true},
                {true, true, false}
            },
            new [,]
            {
                {true, true, true},
                {false, true, false}
            },
            new [,]
            {
                {true, true, false},
                {false, true, true}
            },
        };
        #endregion
        public static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;
            Console.Title = "Tetris";
            Console.WindowWidth = GameWidth;
            Console.BufferWidth = GameWidth;
            Console.WindowHeight = GameHeight + 1;
            Console.BufferHeight = GameHeight + 1;
            Console.Write(@"C# Console Tetris
=======================================

Controls:

[→]   Move Block Right
[←]   Move Block Left
[space]   Rotate Block
[↓]   Push block down 1 Unit


Press a Key to start................
");
            Console.ReadKey(true);
            Console.Clear();

            StartGame();
            PrintBorders();

            GameEngine();
        }

        private static void GameEngine()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    while (Console.KeyAvailable) Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            if (currentBrickCol > 1)
                            {
                                currentBrickCol--;
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (currentBrickCol + currentBrick.GetLength(1) - 1 < TetrisWidth)
                            {
                                currentBrickCol++;
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            //TODO moving current brick faster down
                            break;
                        case ConsoleKey.Spacebar:
                            //TODO rotate brick
                            break;

                    }
                }

                if (FigureStatus())
                {
                    PrintCurrentFigure();
                    CheckForFullLines();
                }
                else
                {
                    currentBrickRow++;
                }

                PrintScore();

                PrintGameField();

                PrintBorders();

                PrintFigure(currentBrick, currentBrickRow, currentBrickCol);

                Thread.Sleep(400);
            }
        }

        private static void CheckForFullLines()
        {
            int linesRemoved = 0;

            for (int row = 0; row < GameBoard.GetLength(0); row++)
            {
                bool isLineFull = true;
                for (int col = 0; col < GameBoard.GetLength(1); col++)
                {
                    if (GameBoard[row, col] == false)
                    {
                        isLineFull = false;
                        break;
                    }
                }

                if (isLineFull)
                {
                    for (int nextLine = row - 1; nextLine >= 0; nextLine--)
                    {
                        if (row < 0)
                        {
                            continue;
                        }

                        for (int colFromNextLine = 0; colFromNextLine < GameBoard.GetLength(1); colFromNextLine++)
                        {
                            GameBoard[nextLine + 1, colFromNextLine] =
                                GameBoard[nextLine, colFromNextLine];
                        }
                    }

                    for (int colLastLine = 0; colLastLine < GameBoard.GetLength(1); colLastLine++)
                    {
                        GameBoard[0, colLastLine] = false;
                    }

                    linesRemoved++;
                }
            }

            if (linesRemoved > 0)
            {
                Points += LevelPoints;
            }
            currentBrickRow = 1;
            currentBrickCol = 4;
        }

        private static void PrintCurrentFigure()
        {
            for (int brickRow = 0; brickRow < currentBrick.GetLength(0); brickRow++)
            {
                for (int brickCol = 0; brickCol < currentBrick.GetLength(1); brickCol++)
                {
                    int row = currentBrickRow - 1 + brickRow;
                    int col = currentBrickCol - 1 + brickCol;

                    if (currentBrick[brickRow, brickCol])
                    {
                        GameBoard[row, col] = true;
                    }
                }
            }
        }

        private static bool FigureStatus()
        {
            var currentFigureLowestRow = currentBrickRow +currentBrick.GetLength(0);

            if (currentFigureLowestRow > TetrisHeight)
            {
                return true;
            }

            for (int figRow = 0; figRow < currentBrick.GetLength(0); figRow++)
            {
                for (int figCol = 0; figCol < currentBrick.GetLength(1); figCol++)
                {
                    var row = currentBrickRow + figRow;
                    var col = currentBrickCol - 1 + figCol;

                    if (row < 0)
                    {
                        continue;
                    }

                    if (GameBoard[row, col] && currentBrick[figRow, figCol])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static void StartGame()
        {
            currentBrick = Bricks[randomGenerator.Next(0, Bricks.Length)];
        }

        static void PrintScore()
        {
            Print(6, TetrisWidth + 4, "Score:");
            int scoreStartposition = InfoPanelWidth / 2 - (Points.ToString().Length - 1) / 2;
            scoreStartposition = scoreStartposition + TetrisWidth + 2;
            Print(7, scoreStartposition - 1, Points);
        }

        static void PrintBorders()
        {
            for (int col = 0; col < GameWidth; col++)
            {
                Print(0, col, BorderCharacter);
                Print(GameHeight - 1, col, BorderCharacter);
            }

            for (int row = 0; row < GameHeight; row++)
            {
                Print(row, 0, BorderCharacter);
                Print(row, TetrisWidth + 1, BorderCharacter);
                Print(row, TetrisWidth + 1 + InfoPanelWidth + 1, BorderCharacter);
            }
        }

        private static void Print(int row, int col, object ch, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(col, row);
            Console.Write(ch);
        }

        static void PrintGameField()
        {
            for (int row = 1; row <= TetrisHeight; row++)
            {
                for (int col = 1; col <= TetrisWidth; col++)
                {
                    if (GameBoard[row - 1, col - 1])
                    {
                        Print(row, col, BrickCharacter);
                    }
                    else
                    {
                        Print(row, col, ' ');
                    }
                }
            }
        }

        static void PrintFigure(bool[,] figure,int row, int col)
        {
            for (int x = 0; x < figure.GetLength(0); x++)
            {
                for (int y = 0; y < figure.GetLength(1); y++)
                {
                    if (figure[x, y])
                    {
                        Print(row + x, col + y, BrickCharacter);
                    }
                }
            }
        }

        
    }


}
