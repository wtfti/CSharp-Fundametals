using System;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
namespace Tetris
{
    internal class MainClass
    {
        #region Global Variables
        static    List<Tuple<string, long, string>> players = new List<Tuple<string, long, string>>();
        static bool[,] GameBoard = new bool[TetrisHeight, TetrisWidth];
        private static long Points = 0;
        private const int LevelPoints = 10;
        private static int level = 1;
        private static long pointsToNewLevel = 10;
        private static int rotatesLeft = 10;
        private static int rotatesCpy = rotatesLeft;
        const char BorderCharacter = '|';
        const char BrickCharacter = 'o';
        const int TetrisWidth = 10;
        const int TetrisHeight = 16;
        const int InfoPanelWidth = 10;
        const int GameWidth = TetrisWidth + InfoPanelWidth + 3;
        const int GameHeight = TetrisHeight + 2;
        static bool[,] currentBrick;
        static bool[,] nextBrick;
        static int currentBrickRow = 0;
        static int currentBrickCol = 4;
        static Stopwatch timer = new Stopwatch();
        static ConsoleColor currentBrickColor = ConsoleColor.White;
        static Random randomGenerator = new Random();
        static ConsoleColor[] brickColors = new ConsoleColor[] {ConsoleColor.Cyan,ConsoleColor.Green,ConsoleColor.Magenta,ConsoleColor.Gray,ConsoleColor.White,ConsoleColor.Yellow,ConsoleColor.Red };
        #region BrickArray
        private static bool[][,] Bricks = new bool[7][,]
        {
            new [,]
            {
                {true, true, true, true}
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
        #endregion
        public static void Main()
        {

            //TODO add menu with options - new game, saved game?, high scores, exit
            //TODO color bricks different colors
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;
            Console.Title = "Tetris";
            Console.WindowWidth = GameWidth+20;
            Console.BufferWidth = GameWidth+20;
            Console.WindowHeight = GameHeight ;
            Console.BufferHeight = GameHeight + 1;
            PrintMenu();
        }

        private static void PlayGame()
        {
             timer.Start();
            Console.Clear();
            Task.Run(() => PlayMusic());
            StartGame();
            PrintBorders();
            while (true)
            {
                
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
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
                            if (currentBrickRow+currentBrick.GetLength(0)-1 < TetrisHeight)
                            { 
                                currentBrickRow++;
                             }
                            break;
                        case ConsoleKey.Spacebar:
                            if ( rotatesLeft > 0)
                            {                               
                                    currentBrick = RotateBrick(currentBrick, currentBrickColor);
                                    rotatesLeft--;                             
                            }
                            break;

                    }
                }
                if (isGameOver())
                {
                    timer.Stop();
                    GameBoard = new bool[TetrisHeight, TetrisWidth];
                    Print(10, TetrisWidth+2, "GAME OVER!"); 
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key != null)
                    {
                        Console.Clear();
                        Console.WriteLine("Would you like to save your score? Yes/No");
                        string choice = Console.ReadLine();
                        if (choice == "Yes")
                        {
                            Console.WriteLine("Enter player name");
                            string playerName = Console.ReadLine();
                            ShowMyScoreRange(playerName);
                            RecordPlayerScore(playerName, Points, timer.Elapsed.ToString().Substring(3,5));
                            Points = 0;
                            level = 1;
                            pointsToNewLevel = 10;
                            rotatesLeft = 10;
                            Console.WriteLine("Press any key to go back to menu.");
                             key = Console.ReadKey();
                            if (key!=null)
                            {
                                PrintMenu();
                            }
                        }
                        else
                        {
                            Console.Clear();
                            PrintMenu();
                        }
                    }

                    else
                    {

                        PrintMenu();
                    }
                    
                }
                try
                {
                   
                    if (CheckForCollisions())
                    {
                        PrintCurrentFigure();
                        CheckForFullLines();
                        if (Points >= pointsToNewLevel)
                        {
                            newLevel();
                        }
                        currentBrick = nextBrick;
                        nextBrick = Bricks[randomGenerator.Next(0, Bricks.Length)];
                        rotatesLeft = rotatesCpy;
                        currentBrickRow = 1;
                        currentBrickCol = 4;
                        rotatesLeft = rotatesCpy;
                    }
                    else
                    {
                        currentBrickRow++;
                    }
                }
                catch (Exception e) { }
                //TODO update score
                //TODO add levels
                //TODO print next brick
                //TODO print current level
                //TODO print highest score
                //TODO option to save score after game over
                //TODO implement lives?
                PrintScore();

                PrintGameField();

                PrintBorders();

                PrintFigure(currentBrick, currentBrickRow, currentBrickCol);

               
                Thread.Sleep(400);
            }
        }

        private static bool isGameOver()
        {
            for (int col = 0; col < GameBoard.GetLongLength(1); col++)
            {
                if (GameBoard[0, col])
                {
                    return true;
                }
            }

            return false;
        }

        private static void newLevel()
        {
            level++;
            pointsToNewLevel = Points + pointsToNewLevel * 2;
            rotatesLeft =  10 - level;
            rotatesCpy = rotatesLeft;

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

        private static bool CheckForCollisions()
        {
            //TODO fix bug when moving left and right you can pass thru stacked bricks
            //TODO check for reaching top of the gameboard
            int currentFigureLowestRow = currentBrickRow +currentBrick.GetLength(0);

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
            nextBrick = Bricks[randomGenerator.Next(0, Bricks.Length)];
        }

        static void PrintScore()
        {
            Print(6, TetrisWidth + 4, "Score: ");
            int scoreStartposition = InfoPanelWidth / 2 - (Points.ToString().Length - 1) / 2;
            scoreStartposition = scoreStartposition + TetrisWidth + 2;
            Print(7, scoreStartposition - 1, Points);
            Print(9, scoreStartposition - 3, "Level "+level);
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
                        SetCurrentBrickColor(figure);
                        Print(row + x, col + y, BrickCharacter, currentBrickColor);
                    }
                }
            }
        }
        static void SetCurrentBrickColor(bool[,] currentBrick)
        {
            for (int i = 0; i < Bricks.GetLength(0); i++)
            {
                if(currentBrick == Bricks[i])
                {
                    currentBrickColor = brickColors[i];
                    break;
                }
            }
        }
        static void PlayMusic()
        {
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = "../../tetris-tone.wav";
          //player.PlayLooping();
        }

        //TODO: add option to rotate left or right?
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

        static void ShowHighScores()
        {
            if (players.Count() == 0)
            {
                ReadDataFromFile();
            }
            var result = players.OrderByDescending(player=> player.Item2)
                .Take(5)
                .Select(player => player.Item1 + " scored: "+player.Item2 + " in "+player.Item3);
          
            Console.WriteLine("Top 5 scores:");
            Console.WriteLine(string.Join("\n",result));
            Console.WriteLine("Press any key to continue...");
            var key = Console.ReadKey();
            if (key != null)
            {
                Console.Clear();
                PrintMenu();
            }
            
        }

        static void ReadDataFromFile()
        {
            StreamReader reader = new StreamReader("scores.txt");
            string line;
            bool isFirstLine = true;
            while ((line = reader.ReadLine()) != null)
            {
                if (!isFirstLine)
                {
                    try
                    {
                        string[] data = line.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                        string name = data[0];
                        long score = long.Parse(data[1]);
                        string time = data[2];

                        players.Add(new Tuple<string, long, string>(name, score, time));
                    }
                    catch (Exception e) { }
                }
                isFirstLine = false;
            }
            reader.Close();
        }


        static void ShowMyScoreRange(string player)
        {
            if(players.Count()==0)
            {
                ReadDataFromFile();
            }

            var higher = players.Where(p => p.Item2 > Points)
                .OrderBy(p => p.Item2)
                .Take(2)
                .Select(p => p.Item1 + " " + p.Item2 + " "+p.Item3);
            Console.WriteLine(string.Join("\n", higher.Reverse()));
            Console.WriteLine(player + " " + Points + " "+ timer.Elapsed.ToString().Substring(3,5));
            var lower = players.Where(p => p.Item2 <= Points)
                .OrderByDescending(p => p.Item2)
                .Take(2)
                .Select(p => p.Item1 + " " + p.Item2 + " " + p.Item3);
          
            Console.WriteLine(string.Join("\n", lower));


        }

        static void RecordPlayerScore(string playerName, long score, string time)
        {           
            using (StreamWriter w = File.AppendText("scores.txt"))
            {
                w.WriteLine("\n"+playerName +" "+score+" "+time);
            }
        }

        static void PrintMenu()
        {
            Console.Clear();
            Print(3, 9, "MENU", ConsoleColor.White);
            Print(4, 4, "[1] New Game", ConsoleColor.White);
            Print(5, 4, "[2] High scores",ConsoleColor.White);
            Print(6, 4, "[3] Controls",ConsoleColor.White);
            Print(7, 4, "[4] Exit",ConsoleColor.White);
            Print(8, 4, "Choose number: ", ConsoleColor.White);
            int option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1: PlayGame(); break;
                case 2: ShowHighScores(); break;
                case 3: PrintControlsInfo(); break;
                case 4: Environment.Exit(0); break;
                default: Environment.Exit(0);break;
            }
        }
        static void PrintControlsInfo()
        {
            Console.Clear();
            Console.Write(@"C# Console Tetris
=======================

Controls:

[→] Move Block Right
[←] Move Block Left
[space] Rotate Block
[↓] Push block down

Press anykey to
go back
");
            Console.ReadKey(true);
            Console.Clear();
            Main();
        }
    }

    

}
