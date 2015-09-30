using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tetris
{
    internal class MainClass
    {
        static bool[,] Game = new bool[TetrisHeight, TetrisWidth];
        private static int Points = 0;
        private const int LevelPoints = 10;
        const char BorderCharacter = (char)219;
        const int TetrisWidth = 10;
        const int TetrisHeight = 16;
        const int InfoPanelWidth = 10;
        const int GameWidth = TetrisWidth + InfoPanelWidth + 3;
        const int GameHeight = TetrisHeight + 2;
        static bool[,] currentFigure;
        static int currentFigureRow = 0;
        static int currentFigureCol = 4;
        static Random random = new Random();
        public static void Main()
        {
            //Console.OutputEncoding = Encoding.GetEncoding(1252);
            Console.Beep(600, 500);
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
[↑]   Rotat Block
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
                    switch (key.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            if (currentFigureCol > 1)
                            {
                                currentFigureCol--;
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (currentFigureCol + currentFigure.GetLength(1) - 1 < TetrisWidth)
                            {
                                currentFigureCol++;
                            }
                            break;
                        case ConsoleKey.DownArrow:
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
                    currentFigureRow++;
                }

                PrintScore();

                PrintGameField();

                PrintBorders();

                PrintFigure(currentFigure, currentFigureRow, currentFigureCol);

                Thread.Sleep(50);
            }
        }

        private static void CheckForFullLines()
        {
            int linesRemoved = 0;

            for (int row = 0; row < Game.GetLength(0); row++)
            {
                bool isFullLine = true;
                for (int col = 0; col < Game.GetLength(1); col++)
                {
                    if (Game[row, col] == false)
                    {
                        isFullLine = false;
                        break;
                    }
                }

                if (isFullLine)
                {
                    for (int nextLine = row - 1; nextLine >= 0; nextLine--)
                    {
                        if (row < 0)
                        {
                            continue;
                        }

                        for (int colFromNextLine = 0; colFromNextLine < Game.GetLength(1); colFromNextLine++)
                        {
                            Game[nextLine + 1, colFromNextLine] =
                                Game[nextLine, colFromNextLine];
                        }
                    }

                    for (int colLastLine = 0; colLastLine < Game.GetLength(1); colLastLine++)
                    {
                        Game[0, colLastLine] = false;
                    }

                    linesRemoved++;
                }
            }

            if (linesRemoved > 0)
            {
                Points += LevelPoints;
            }
            currentFigureRow = 1;
            currentFigureCol = 4;
        }

        private static void PrintCurrentFigure()
        {
            for (int figRow = 0; figRow < currentFigure.GetLength(0); figRow++)
            {
                for (int figCol = 0; figCol < currentFigure.GetLength(1); figCol++)
                {
                    var row = currentFigureRow - 1 + figRow;
                    var col = currentFigureCol - 1 + figCol;

                    if (currentFigure[figRow, figCol])
                    {
                        Game[row, col] = true;
                    }
                }
            }
        }

        private static bool FigureStatus()
        {
            var currentFigureLowestRow = currentFigureRow +currentFigure.GetLength(0);

            if (currentFigureLowestRow > TetrisHeight)
            {
                return true;
            }

            for (int figRow = 0; figRow < currentFigure.GetLength(0); figRow++)
            {
                for (int figCol = 0; figCol < currentFigure.GetLength(1); figCol++)
                {
                    var row = currentFigureRow + figRow;
                    var col = currentFigureCol - 1 + figCol;

                    if (row < 0)
                    {
                        continue;
                    }

                    if (Game[row, col] && currentFigure[figRow, figCol])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static void StartGame()
        {
            currentFigure = Figures[random.Next(0, Figures.Length)];
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

        private static void Print(int row, int col, object ch)
        {
            Console.SetCursorPosition(col, row);
            Console.Write(ch);
        }

        static void PrintGameField()
        {
            for (int row = 1; row <= TetrisHeight; row++)
            {
                for (int col = 1; col <= TetrisWidth; col++)
                {
                    if (Game[row - 1, col - 1])
                    {
                        Print(row, col, '=');
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
                        Print(row + x, col + y, '=');
                    }
                }
            }
        }

        private static bool[][,] Figures = new bool[8][,]
        {
            new [,] // ----
            {
                {true, true, true, true}
            },
            new bool[,] // I
            {
                {true},
                {true},
                {true},
                {true}
            },
            new [,] // J
            {
                {true, true, true},
                {false, false, true}
            },
            new [,] // L
            {
                {true, true, true},
                {true, false, false}
            },
            new [,] // O
            {
                {true, true},
                {true, true}
            },
            new [,] // S
            {
                {false, true, true},
                {true, true, false}
            },
            new [,] // T
            {
                {true, true, true},
                {false, true, false}
            },
            new [,] // Z
            {
                {true, true, false},
                {false, true, true}
            },
        };
    }


}
