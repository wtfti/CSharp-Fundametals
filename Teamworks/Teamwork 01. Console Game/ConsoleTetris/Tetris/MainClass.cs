using System;
using System.Media;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Tetris
{
    internal class MainClass
    {
        #region Global Variables
        private static List<Tuple<string, int, string>> players = new List<Tuple<string, int, string>>();
        private static bool[,] GameBoard = new bool[TetrisHeight, TetrisWidth];
        private static bool isGameRunning = false;
        private static SoundPlayer player = new SoundPlayer();
        private static bool isMusicOn = true;
        private static int totalLinesRemoved = 0;
        private static int points;
        //private const int LevelPoints = 10;
        //private static int pointsToNextLevel = 50;
        private static int[] clearedLinesToChangeLevel = new int[] { 5, 10, 15, 20, 20 };
        private static int speed = 400;
        private static int level = 1;
        private static int remainingRotations = 10;
        private static int remainingRotationsCpy = remainingRotations;
        private const char BorderCharacter = '|';
        private const char FigureCharacter = 'o';
        private static Dictionary<int, Tuple<string, long, string>> standingsPlaceHolder = Standings();
        private const int TetrisWidth = 10;
        private const int TetrisHeight = 16;
        private const int InfoPanelWidth = 16;
        private const int GameWidth = TetrisWidth + InfoPanelWidth + 3;
        private const int GameHeight = TetrisHeight + 2;
        private static bool[,] currentFigure;
        private static int currentFigureRow = 0;
        private static int currentFigureCol = 5;
        private static int currentFigureNumber;
        private static Stopwatch timer = new Stopwatch();
        private static ConsoleColor currentFigureColor = ConsoleColor.White;
        private static Random randomGenerator = new Random();
        private static ConsoleColor[] figureColors = { ConsoleColor.Cyan, ConsoleColor.Green, ConsoleColor.Magenta, ConsoleColor.Yellow, ConsoleColor.Red };
        #region FigureArray
        private static bool[][,] Figures =
        {
            new [,]                                   // 0
            {                                         // 0
                {true, true, true, true}              // 0
            },                                        // 0
                                                      // 0
            new [,]                                   // 0
            {                                         // 0
                {true},                               // 0
                {true},                               // 0
                {true},                               // 0
                {true}                                // 0
            },          

            new [,]                                   // 1
            {                                         // 1
                {true, true, true},                   // 1
                {false, false, true}                  // 1
            },                                        // 1
                                                      // 1
            new [,]                                   // 1
            {                                         // 1
                {false, true},                        // 1
                {false, true},                        // 1
                {true, true},                         // 1
            },                                        // 1
                                                      // 1
            new [,]                                   // 1
            {                                         // 1
                {true, false, false},                 // 1
                {true, true, true}                    // 1
            },                                        // 1
                                                      // 1
            new [,]                                   // 1
            {                                         // 1
                {true, true},                         // 1
                {true, false},                        // 1
                {true, false},                        // 1
            },                                        // 1

            new [,]                                   // 2
            {                                         // 2
                {true, true, true},                   // 2
                {true, false, false}                  // 2
            },                                        // 2
                                                      // 2
            new [,]                                   // 2
            {                                         // 2
                {true, true},                         // 2
                {false, true},                        // 2
                {false, true},                        // 2
            },                                        // 2
                                                      // 2
            new [,]                                   // 2
            {                                         // 2
                {false, false, true},                 // 2
                {true, true, true}                    // 2
            },                                        // 2
                                                      // 2
            new [,]                                   // 2
            {                                         // 2
                {true, false},                        // 2
                {true, false},                        // 2
                {true, true},                         // 2
            },                                        // 2
            
            new [,]                                   // 3
            {                                         // 3
                {true, true},                         // 3
                {true, true}                          // 3
            },                                        // 3
            
            new [,]
            {                                         // 4
                {false, true, true},                  // 4
                {true, true, false}                   // 4
            },                                        // 4
                                                      // 4
            new [,]                                   // 4
            {                                         // 4
                {true, false},                        // 4
                {true, true},                         // 4
                {false, true}                         // 4
            },                                        // 4
            
            new [,]                                   // 5
            {                                         // 5
                {true, true, true},                   // 5
                {false, true, false}                  // 5
            },                                        // 5
                                                      // 5
            new [,]                                   // 5
            {                                         // 5
                {false, true},                        // 5
                {true, true},                         // 5
                {false, true}                         // 5
            },                                        // 5
                                                      // 5
            new [,]                                   // 5
            {                                         // 5
                {false, true, false},                 // 5
                {true, true, true}                    // 5
            },                                        // 5
                                                      // 5
            new [,]                                   // 5
            {                                         // 5
                {true, false},                        // 5
                {true, true},                         // 5
                {true, false}                         // 5
            },                                        // 5
            
            new [,]                                   // 6
            {                                         // 6
                {true, true, false},                  // 6
                {false, true, true}                   // 6
            },                                        // 6
                                                      // 6
            new [,]                                   // 6
            {                                         // 6
                {false, true},                        // 6
                {true, true},                         // 6
                {true, false}                         // 6
            },                                        // 6
        };
        #endregion
        #endregion
        public static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;
            Console.Title = "Tetris #Team brazerape [SoftUni]";
            PrintMenu();
        }

        private static void PlayGame()
        {
            Console.Clear();
            if (isMusicOn)
            {
                Task.Run(() => PlayMusic());
            }
            SetUpInitialGameSettings();
            GenerateFigure();
            PrintBorders();
            while (isGameRunning)
            {
                timer.Start();
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    while (Console.KeyAvailable) Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            if (currentFigureCol > 1)
                            {
                                MoveCurrentFigureHorizontally('-');
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (currentFigureCol + currentFigure.GetLength(1) - 1 < TetrisWidth)
                            {
                                MoveCurrentFigureHorizontally('+');
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            if (currentFigureRow + currentFigure.GetLength(0) - 1 < TetrisHeight)
                            {
                                MoveCurrentFigureDown(true);
                            }
                            break;
                        case ConsoleKey.Spacebar:

                            if (remainingRotations > 0)
                            {
                                RotateFigure();
                                remainingRotations--;
                            }
                            break;
                    }
                }
                try
                {
                    if (CheckForCollisions())
                    {
                        PrintCurrentFigure();
                        CheckForFullLines();
                        //if (points >= pointsToNextLevel)
                        //{
                        //    ChangeLevel();
                        //}
                        if (totalLinesRemoved >= clearedLinesToChangeLevel[level - 1])
                        {
                            ChangeLevel();
                        }
                        GenerateFigure();

                        remainingRotations = remainingRotationsCpy;
                        currentFigureRow = 1;
                        currentFigureCol = 5;
                    }
                    else if (!isGameRunning)
                    {
                        timer.Stop();
                        PrintGameOverMessage();
                        timer.Reset();
                        break;
                    }
                    else
                    {
                        currentFigureRow++;
                    }
                }
                catch (Exception e) { }
                PrintInfo();

                PrintGameField();

                PrintBorders();

                PrintFigure(currentFigure, currentFigureRow, currentFigureCol);
                Thread.Sleep(speed);
            }
        }

        #region RotateFigure
        private static void RotateFigure()
        {
            if (currentFigureNumber != 10)
            {
                switch (currentFigureNumber)
                {
                    case 0:
                        if ((currentFigureRow + 3) <= (TetrisHeight - 1) &&
                            !GameBoard[currentFigureRow + 3, currentFigureCol - 1])
                        {
                            currentFigureNumber = 1;
                        }
                        break;
                    case 1:
                        if ((currentFigureCol + 3) <= (TetrisWidth - 1) &&
                            !GameBoard[currentFigureRow, (currentFigureCol - 1) + 3])
                        {
                            currentFigureNumber = 0;
                        }
                        break;
                    case 2:
                        if ((currentFigureRow + 2) <= (TetrisHeight - 1) &&
                            !GameBoard[currentFigureRow + 2, currentFigureCol] &&
                            !GameBoard[currentFigureRow + 2, currentFigureCol + 1])
                        {
                            currentFigureNumber = 3;
                        }
                        break;
                    case 3:
                        if ((currentFigureCol + 1) <= (TetrisWidth - 1) && //
                            !GameBoard[currentFigureRow, currentFigureCol] &&
                            !GameBoard[currentFigureRow, currentFigureCol + 1])
                        {
                            currentFigureNumber = 4;
                        }
                        break;
                    case 4:
                        if ((currentFigureRow + 2) <= (TetrisHeight - 1) &&
                            !GameBoard[currentFigureRow, currentFigureCol])
                        {
                            currentFigureNumber = 5;
                        }
                        break;
                    case 5:
                        if ((currentFigureCol + 1) <= (TetrisWidth - 1) &&
                            !GameBoard[currentFigureRow, currentFigureCol + 1] &&
                            !GameBoard[currentFigureRow + 1, currentFigureCol + 1])
                        {
                            currentFigureNumber = 2;
                        }
                        break;
                    case 6:
                        if ((currentFigureCol + 1) <= (TetrisHeight - 1) &&
                            !GameBoard[currentFigureRow + 1, currentFigureCol + 1] &&
                            !GameBoard[currentFigureRow + 2, currentFigureCol + 1])
                        {
                            currentFigureNumber = 7;
                        }
                        break;
                    case 7:
                        if ((currentFigureCol - 2) >= 0 &&
                            !GameBoard[currentFigureRow, currentFigureCol - 2])
                        {
                            currentFigureNumber = 8;
                        }
                        break;
                    case 8:
                        if (!GameBoard[currentFigureRow, currentFigureCol - 1] &&
                            !GameBoard[currentFigureRow - 1, currentFigureCol - 1])
                        {
                            currentFigureNumber = 9;
                        }
                        break;
                    case 9:
                        if ((currentFigureCol + 1) <= (TetrisWidth - 1) &&
                            !GameBoard[currentFigureRow + 1, currentFigureCol + 1])
                        {
                            currentFigureNumber = 6;
                        }
                        break;
                    case 11:
                        if ((currentFigureCol + 2) <= (TetrisHeight - 1) &&
                            !GameBoard[currentFigureRow + 2, currentFigureCol + 2])
                        {
                            currentFigureNumber = 12;
                        }
                        break;
                    case 12:
                        if ((currentFigureCol + 1) <= (TetrisWidth - 1) &&
                            !GameBoard[currentFigureRow + 2, currentFigureCol - 1] &&
                            !GameBoard[currentFigureRow + 1, currentFigureCol + 1])
                        {
                            currentFigureNumber = 11;
                        }
                        break;
                    case 13:
                        if ((currentFigureRow + 2) <= (TetrisHeight - 1) &&
                            !GameBoard[currentFigureRow + 1, currentFigureCol - 1] &&
                            !GameBoard[currentFigureRow + 2, currentFigureCol])
                        {
                            currentFigureNumber = 14;
                        }
                        break;
                    case 14:
                        if ((currentFigureRow - 1) >= 0 &&
                            (currentFigureRow + 1) <= (TetrisWidth - 1) &&
                            !GameBoard[currentFigureRow, currentFigureCol - 1] &&
                            !GameBoard[currentFigureRow + 1, currentFigureCol + 1])
                        {
                            currentFigureNumber = 15;
                        }
                        break;
                    case 15:
                        if ((currentFigureRow + 2) <= (TetrisWidth - 1) &&
                            !GameBoard[currentFigureRow + 2, currentFigureCol] &&
                            !GameBoard[currentFigureRow + 1, currentFigureCol + 1])
                        {
                            currentFigureNumber = 16;
                        }
                        break;
                    case 16:
                        if ((currentFigureRow - 1) >= 0 &&
                            (currentFigureCol + 1) <= (TetrisWidth - 1) &&
                            !GameBoard[currentFigureRow + 1, currentFigureCol - 2] &&
                            !GameBoard[currentFigureRow + 2, currentFigureCol] &&
                            !GameBoard[currentFigureRow + 1, currentFigureCol + 1])
                        {
                            currentFigureNumber = 13;
                        }
                        break;
                    case 17:
                        if ((currentFigureRow + 2) <= (TetrisHeight - 1) &&
                            !GameBoard[currentFigureRow + 1, currentFigureCol - 1] &&
                            !GameBoard[currentFigureRow + 2, currentFigureCol - 1])
                        {
                            currentFigureNumber = 18;
                        }
                        break;
                    case 18:
                        if ((currentFigureCol + 1) <= (TetrisWidth - 1) &&
                            !GameBoard[currentFigureRow, currentFigureCol - 1] &&
                            !GameBoard[currentFigureRow + 1, currentFigureCol + 1])
                        {
                            currentFigureNumber = 17;
                        }
                        break;
                }
                currentFigure = Figures[currentFigureNumber];
            }
        }
        #endregion

        private static void MoveCurrentFigureHorizontally(char direction)
        {
            if (direction == '-')
            {
                for (int figureRow = 0; figureRow < currentFigure.GetLength(0); figureRow++)
                {
                    for (int figureCol = 0; figureCol < currentFigure.GetLength(1); figureCol++)
                    {
                        int row = (currentFigureRow - 1) + figureRow;
                        int col = (currentFigureCol - 2) + figureCol;

                        if (currentFigure[figureRow, figureCol] && GameBoard[row, col])
                        {
                            return;
                        }
                    }
                }
                currentFigureCol--;
            }
            else if (direction == '+')
            {
                for (int figureRow = 0; figureRow < currentFigure.GetLength(0); figureRow++)
                {
                    for (int figureCol = 0; figureCol < currentFigure.GetLength(1); figureCol++)
                    {
                        int row = (currentFigureRow - 1) + figureRow;
                        int col = (currentFigureCol) + figureCol;

                        if (currentFigure[figureRow, figureCol] && GameBoard[row, col])
                        {
                            return;
                        }
                    }
                }
                currentFigureCol++;
            }
        }

        private static void MoveCurrentFigureDown(bool isRowDown)
        {
            for (int figureRow = 0; figureRow < currentFigure.GetLength(0); figureRow++)
            {
                for (int figureCol = 0; figureCol < currentFigure.GetLength(1); figureCol++)
                {
                    int row = currentFigureRow + figureRow;
                    int col = (currentFigureCol - 1) + figureCol;

                    if (row > (TetrisHeight - 1) || (currentFigure[figureRow, figureCol] && GameBoard[row, col]))
                    {
                        return;
                    }
                }
            }
            currentFigureRow++;
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
                    totalLinesRemoved++;
                    linesRemoved++;
                }
            }

            //if (linesRemoved > 0)
            //{
            //    points += level * linesRemoved;
            //}
            switch (linesRemoved)
            {
                case 0: break;
                case 1: points += level * 10; break;
                case 2: points += level * 30; break;
                case 3: points += level * 50; break;
                case 4: points += level * 80; break;
                default: points += level * 80; break;
            }



        }

        private static void PrintCurrentFigure()
        {
            for (int figureRow = 0; figureRow < currentFigure.GetLength(0); figureRow++)
            {
                for (int figureCol = 0; figureCol < currentFigure.GetLength(1); figureCol++)
                {
                    int row = (currentFigureRow - 1) + figureRow;
                    int col = (currentFigureCol - 1) + figureCol;

                    if (currentFigure[figureRow, figureCol])
                    {
                        GameBoard[row, col] = true;
                    }
                }
            }
        }

        private static bool CheckForCollisions()
        {
            int currentFigureLowestRow = currentFigureRow + currentFigure.GetLength(0);

            if (currentFigureLowestRow > TetrisHeight)
            {
                return true;
            }
            if (currentFigureRow == 1 && GameBoard[currentFigureRow, currentFigureCol])
            {
                FinishGame(true);
                return false;
            }

            for (int figureRow = 0; figureRow < currentFigure.GetLength(0); figureRow++)
            {
                for (int figureCol = 0; figureCol < currentFigure.GetLength(1); figureCol++)
                {
                    var row = currentFigureRow + figureRow;
                    var col = (currentFigureCol - 1) + figureCol;

                    if (row < 0)
                    {
                        continue;
                    }

                    if (GameBoard[row, col] && currentFigure[figureRow, figureCol])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static void FinishGame(bool endGame = false)
        {
            if (endGame)
            {
                isGameRunning = false;
            }
        }

        private static void SetUpInitialGameSettings()
        {
            isGameRunning = true;
            GameBoard = new bool[TetrisHeight, TetrisWidth];
            currentFigureRow = 1;
            currentFigureCol = 5;
            points = 0;
            //pointsToNextLevel = 50;
            speed = 400;
            level = 1;
            remainingRotations = 10;
            remainingRotationsCpy = remainingRotations;
        }

        private static void GenerateFigure()
        {
            currentFigureNumber = randomGenerator.Next(0, Figures.Length);
            currentFigure = Figures[currentFigureNumber];
        }

        static void PrintInfo()
        {
            int pos = (InfoPanelWidth / 2) + 5;
            Print(1, pos, "Score: " + points);
            Print(3, pos, "Rotations: " + (remainingRotations == 10 ? "10" : remainingRotations % 10 + " "));
            Print(5, pos, "Level: " + level);
            Print(7, pos, string.Format("Time: {0:mm\\:ss} s", timer.Elapsed));

        }

        static void PrintBorders()
        {
            for (int col = 0; col < GameWidth; col++)
            {
                Print(0, col, '=');
                Print(GameHeight - 1, col, '=');
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
                        Print(row, col, FigureCharacter);
                    }
                    else
                    {
                        Print(row, col, ' ');
                    }
                }
            }
        }

        static void PrintFigure(bool[,] figure, int row, int col)
        {
            for (int x = 0; x < figure.GetLength(0); x++)
            {
                for (int y = 0; y < figure.GetLength(1); y++)
                {
                    if (figure[x, y])
                    {
                        SetCurrentBrickColor(figure);
                        Print(row + x, col + y, FigureCharacter, currentFigureColor);
                    }
                }
            }
        }
        static void SetCurrentBrickColor(bool[,] currentBrick)
        {
            for (int i = 0; i < Figures.GetLength(0); i++)
            {
                if (currentBrick == Figures[i])
                {
                    currentFigureColor = figureColors[i % figureColors.Length];
                    break;
                }
            }
        }
        static void PlayMusic()
        {
            player.SoundLocation = "tetris-tone.wav";
            player.PlayLooping();
        }

        public static bool[,] RotateBrick(bool[,] input, ConsoleColor color)
        {
            bool[,] result = new bool[input.GetLength(1), input.GetLength(0)];
            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    result[j, i] = input[i, j];
                }
            }

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1) / 2; j++)
                {
                    var tempLeft = result[i, j];
                    result[i, j] = result[i, result.GetLength(1) - 1 - j];
                    result[i, result.GetLength(1) - 1 - j] = tempLeft;
                }
            }

            return result;
        }

        static void ReadScoreFile()
        {
            using (StreamReader reader = new StreamReader( @"../../scores.txt"))
            {
                bool isFirstLine = true;
                string line;
                while (!string.IsNullOrEmpty(line = reader.ReadLine()))
                {
                    if (!isFirstLine)
                    {
                        try
                        {
                            string[] data = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            string name = data[0];
                            int score = int.Parse(data[1]);
                            string time = data[2];

                            players.Add(new Tuple<string, int, string>(name, score, time));
                        }
                        catch(Exception e) { }
                    }
                    isFirstLine = false;
                }
                }
            }
        

        static void ShowHighScores(int skip = -5)
        {

            Console.Clear();
            if (players.Count == 0)
            {
                ReadScoreFile();
            }
            var scores = standingsPlaceHolder
                   .Skip(skip + 5)
                   .Take(5)
                   .Select(player => player.Key + "." + player.Value.Item1 + " scored: " + player.Value.Item2 + " in " + player.Value.Item3);

            Console.WriteLine("Top 5 scores:\n");
            Console.WriteLine(string.Join("\n", scores));
            Console.WriteLine();
            Console.WriteLine("Press arrow down and up to scroll and any other key to go back");
            Console.WriteLine();

            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.DownArrow)
            {
                if (skip > standingsPlaceHolder.Count / 5)
                {
                    skip = standingsPlaceHolder.Count / 5;
                }
                ShowHighScores(skip + 5);

            }
            else if (key.Key == ConsoleKey.UpArrow)
            {

                if (skip < -5)
                {
                    skip = 0;
                }
                ShowHighScores(skip - 5);
            }
            else
            {
                Console.Clear(); PrintMenu();
            }
        }

        static void ShowLastPlayerScore()
        {
            if (players.Count == 0)
            {
                ReadScoreFile();
            }
            
            var higher = standingsPlaceHolder
                .Where(p => p.Value.Item2 > points)
                .OrderByDescending(player => player.Key)
                .Take(3)
                .Reverse()
                .Select(player => player.Key + "." + player.Value.Item1 + " scored: " + player.Value.Item2 + " in " + player.Value.Item3);
            Console.WriteLine(string.Join("\n", higher));
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("You scored " + points + " in " + timer.Elapsed.ToString().Substring(3, 5));
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
            var lower = standingsPlaceHolder
              .Where(p => p.Value.Item2 <= points)
              .OrderBy(player => player.Key)
              .Take(3)
              .Select(player => player.Key + "." + player.Value.Item1 + " scored: " + player.Value.Item2 + " in " + player.Value.Item3);
            Console.WriteLine(string.Join("\n", lower));


        }

        static Dictionary<int, Tuple<string, long, string>> Standings()
        {
            var dic = new Dictionary<int, Tuple<string, long, string>>();
            if(players.Count==0)
            {
                ReadScoreFile();
            }
            var result = players
                .OrderByDescending(p => p.Item2)
                .ThenBy(p => p.Item3)
                .Select(p => p.Item1 + " scored " + p.Item2 + " in " + p.Item3);

            for (int i = 1; i <= players.Count; i++)
            {
                var items = result.Skip(i - 1).Take(1).Select(p => p).ToArray();
                var split = items[0].Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                var name = split[0];
                var score = long.Parse(split[2]);
                var time = split.Last();
                dic.Add(i, new Tuple<string, long, string>(name, score, time));
            }

            return dic;

        }


        static void RecordPlayerScore()
        {
            Console.Clear();
            Console.WriteLine("\nWould you like to save your score?Yes/No");
            string option = Console.ReadLine().ToLower();
            if (option == "Yes".ToLower())
            {
                Console.WriteLine("Please enter your name");
                string playerName = Console.ReadLine();
                playerName = Regex.Replace(playerName, @"\s*", "_");
                timer.Stop();
                using (StreamWriter w = File.AppendText(@"../../scores.txt"))
                {
                    w.WriteLine(playerName + " " + points + " " + timer.Elapsed.ToString().Substring(3, 5));
                    players.Add(new Tuple<string, int, string>(playerName,points, timer.Elapsed.ToString().Substring(3, 5)));
                    standingsPlaceHolder = Standings();
                }
            }
            Console.Clear();
            PrintMenu();
        }

        private static void PrintMenu()
        {
            Console.SetWindowSize(38, TetrisHeight + 5);
            Console.BufferWidth = 38;
            Console.BufferHeight = TetrisHeight + 5;


            //Console.WindowWidth = 37;
            Print(0, 0, @"
  ____         __ _   _   _       _ 
 / ___|  ___  / _| |_| | | |_ __ (_)
 \___ \ / _ \| |_| __| | | | '_ \| |
  ___) | (_) |  _| |_| |_| | | | | |
 |____/ \___/|_|  \__|\___/|_| |_|_|
                                    ", ConsoleColor.Blue);
            Print(7, 12, @"Team: 
            wtflolwut 
            ValentinKolev 
            Orhan 
            DigitalParanoid
", ConsoleColor.Cyan);
            Print(14, 12, "MENU", ConsoleColor.White);
            Print(15, 12, "[1] New Game", ConsoleColor.White);
            Print(16, 12, "[2] High scores", ConsoleColor.White);
            Print(17, 12, "[3] Controls", ConsoleColor.White);
            Print(18, 12, "[4] Music is " + (isMusicOn ? "ON" : "OFF"), ConsoleColor.White);
            Print(19, 12, "[5] Exit", ConsoleColor.White);
            Print(20, 12, "Choose number: ", ConsoleColor.White);
            int option;
            if (int.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine();
                switch (option)
                {
                    case 1:
                        Console.WindowWidth = GameWidth + 1;
                        Console.BufferWidth = GameWidth + 1;
                        Console.WindowHeight = GameHeight + 1;
                        Console.BufferHeight = GameHeight + 1;
                        PlayGame();
                        break;
                    case 2:
                        ShowHighScores();
                        break;
                    case 3:
                        PrintControlsInfo();
                        break;
                    case 4:
                        isMusicOn = !isMusicOn;
                        if (!isMusicOn)
                        {
                            player.Stop();
                        }
                        Console.Clear();
                        PrintMenu();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                }
            }
        }
        static void PrintControlsInfo()
        {
            Console.Clear();
            Console.Write(@"
Controls:

[→] Move Block Right
[←] Move Block Left
[space] Rotate Block
[↓] Push block down

Press anykey to go back

");
            Console.ReadKey(true);
            Console.Clear();
            Main();
        }

        private static void ChangeLevel()
        {
            if (level == 5)
            {
                FinishGame();
                Console.WindowHeight = GameHeight + 10;
                Console.BufferHeight = GameHeight + 10;
                Console.Clear();
                Console.Write(String.Format(@"
   _____                      
  / ____|                     
 | |  __  __ _ _ __ ___   ___ 
 | | |_ |/ _` | '_ ` _ \ / _ \
 | |__| | (_| | | | | | |  __/
  \_____|\__,_|_| |_| |_|\___|
Completed 100%, congragulations!!!
You made {0} lines. You scored {1} in {2}

Press any key to continue...", totalLinesRemoved, points, timer.Elapsed.ToString().Substring(3, 5)), ConsoleColor.Red);
                Console.ReadKey();
                RecordPlayerScore();
                
            }
            else
            {
                GameBoard = new bool[TetrisHeight, TetrisWidth];
                level++;
                //pointsToNextLevel = points + pointsToNextLevel * 2;
                remainingRotations -= level;
                remainingRotationsCpy = remainingRotations;
                if (speed > 100)
                {
                    speed -= 100;
                }
                else
                {
                    speed -= 50;
                }
            }
        }

        private static void PrintGameOverMessage()
        {
            Console.WindowHeight = GameHeight + 10;
            Console.BufferHeight = GameHeight + 10;
            Console.Clear();
            Console.Write(String.Format(@"
   _____                      
  / ____|                     
 | |  __  __ _ _ __ ___   ___ 
 | | |_ |/ _` | '_ ` _ \ / _ \
 | |__| | (_| | | | | | |  __/
  \_____|\__,_|_| |_| |_|\___|
  / __ \                      
 | |  | |_   _____ _ __       
 | |  | \ \ / / _ \ '__|      
 | |__| |\ V /  __/ |         
  \____/  \_/ \___|_|            


You made {0} lines.
You scored {1} in {2}
", totalLinesRemoved, points, timer.Elapsed.ToString().Substring(3, 5)), ConsoleColor.Red);
            Console.WriteLine("Press any key to continue..");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key != null)
            {
                Console.Clear();
                ShowLastPlayerScore();
               key = Console.ReadKey();
                if (key != null)
                {
                      Console.Clear();
                    RecordPlayerScore();
                }
            }
            Console.ResetColor();
            Console.CursorVisible = true;
        }
    }
}
