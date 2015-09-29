using System;
using System.Threading;

namespace Tetris
{
    internal class MainClass
    {
            /// <summary>
            /// Tetris Game
            /// </summary>
        private static
            Tetris t;
                /// <summary>
                /// Mover Thread
                /// </summary>
            private static
            Thread mover;
                /// <summary>
                /// Lock of Drawing Function
                /// </summary>
            private static
            bool drawLock;
                /// <summary>
                /// Counts poins/Lines
                /// </summary>
            private static
            int points;

                /// <summary>
                /// Counter for the Worker thread
                /// </summary>
            static
            int threadCounter = 0;

                #region "Drawing" CONSTANTS

                //Shadowing: █▓▒
            private
            const string BLOCK = "█";
            private
            const string ACTIVE = "█";
            private
            const string BAKER = "█";
            private
            const string EMPTY = " ";
            private
            const string SHADOW = "▒";
                #endregion

                /// <summary>
                /// Steps for the stepper thread
                /// </summary>
            private
            const int STEP = 10;

                /// <summary>
                /// Show next block [y/n]?
                /// </summary>
            private static
            bool showNext;

                /// <summary>
                /// Field for the "Next" Block
                /// </summary>
            private static readonly
            int[,] clearBlock = new int[,]
            {
                {0, 0, 0, 0},
                {0, 0, 0, 0},
                {0, 0, 0, 0},
                {0, 0, 0, 0}
            };

                /// <summary>
                /// Main Application loop
                /// </summary>
                /// <param name="args">Stupid Args</param>
                /// <returns>0</returns>
            static
            int Main 
            (string[]
            args)
            {
                //preparing Console
                Console.Clear();
                Console.Beep(600, 500);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.CursorVisible = false;

                //Intro
                Console.Write(@"C# Console Tetris
=======================================

Controls:
[→]   Move Block Right
[←]   Move Block Left
[↑]   Smash Bloock down
[↓]   Push block down 1 Unit
[S]   Turn Clockwise
[A]   Turn Clockwise 3 Times ;-)
[G]   Turn ghost Block on and off (Default on)
[N]   Turn Next Block on and off
[ESC] Exit Game

Press a Key to start
");
                Console.ReadKey(true);
                Console.Clear();

                //Default Values and Game initialization
                showNext = true;

                points = 0;
                drawLock = false;
                t = new Tetris(20, 30);
                t.LinesDone += new Tetris.LinesDoneHandler(t_LinesDone);

                //Start Game and run "Mover" Thread
                t.start();
                mover = new Thread(new ThreadStart(stepper));
                mover.IsBackground = true;
                mover.Start();

                //Keyboard handler
                while (t.running)
                {
                    Thread.Sleep(10);
                    if (Console.KeyAvailable)
                    {
                        lock (t)
                        {
                            switch (Console.ReadKey(true).Key)
                            {
                                case ConsoleKey.LeftArrow:
                                    t.keyPress(Tetris.Key.Left);
                                    break;
                                case ConsoleKey.RightArrow:
                                    t.keyPress(Tetris.Key.Right);
                                    break;
                                case ConsoleKey.UpArrow:
                                    t.keyPress(Tetris.Key.Up);
                                    threadCounter = 0;
                                    break;
                                case ConsoleKey.DownArrow:
                                    t.keyPress(Tetris.Key.Down);
                                    threadCounter = 0;
                                    break;
                                case ConsoleKey.A:
                                    t.keyPress(Tetris.Key.rLeft);
                                    break;
                                case ConsoleKey.S:
                                    t.keyPress(Tetris.Key.rRight);
                                    break;
                                case ConsoleKey.N:
                                    showNext = !showNext;
                                    break;
                                case ConsoleKey.G:
                                    t.shadowBlock = !t.shadowBlock;
                                    break;
                                case ConsoleKey.Escape:
                                    t.gameOver();
                                    break;
                                default:
                                    break;
                            }
                            drawField();
                        }
                    }
                }
                //Wait for thread to end and then End the Game and close
                Thread.Sleep(1000);
                Console.Clear();
                writeCol(string.Format(@"
      ___           ___           ___           ___     
     /  /\         /  /\         /__/\         /  /\    
    /  /:/_       /  /::\       |  |::\       /  /:/_   
   /  /:/ /\     /  /:/\:\      |  |:|:\     /  /:/ /\  
  /  /:/_/::\   /  /:/~/::\   __|__|:|\:\   /  /:/ /:/_ 
 /__/:/__\/\:\ /__/:/ /:/\:\ /__/::::| \:\ /__/:/ /:/ /\
 \  \:\ /~~/:/ \  \:\/:/__\/ \  \:\~~\__\/ \  \:\/:/ /:/
  \  \:\  /:/   \  \::/       \  \:\        \  \::/ /:/ 
   \  \:\/:/     \  \:\        \  \:\        \  \:\/:/  
    \  \::/       \  \:\        \  \:\        \  \::/   
     \__\/         \__\/         \__\/         \__\/    
      ___                        ___           ___     
     /  /\          ___         /  /\         /  /\    
    /  /::\        /__/\       /  /:/_       /  /::\   
   /  /:/\:\       \  \:\     /  /:/ /\     /  /:/\:\  
  /  /:/  \:\       \  \:\   /  /:/ /:/_   /  /:/~/:/  
 /__/:/ \__\:\  ___  \__\:\ /__/:/ /:/ /\ /__/:/ /:/___
 \  \:\ /  /:/ /__/\ |  |:| \  \:\/:/ /:/ \  \:\/:::::/
  \  \:\  /:/  \  \:\|  |:|  \  \::/ /:/   \  \::/~~~~ 
   \  \:\/:/    \  \:\__|:|   \  \:\/:/     \  \:\     
    \  \::/      \__\::::/     \  \::/       \  \:\    
     \__\/           ~~~~       \__\/         \__\/    

You made {0} lines. Press Esc to exit", points), ConsoleColor.Red);
                while (Console.ReadKey(true).Key != ConsoleKey.Escape) ;
                Console.ResetColor();
                Console.CursorVisible = true;
                return 0;
            }

            /// <summary>
            /// Counts Lines
            /// </summary>
            /// <param name="Lines">Number of Lines made</param>
        static
            void t_LinesDone 
            (int
            Lines)
            {
                points += Lines;
            }

            /// <summary>
            /// Mover Thread, makes the Game to step forward
            /// </summary>
        static
            void stepper 
            ()
            {
                while (t.running)
                {
                    threadCounter = 0;
                    t.step();
                    drawField();
                    //Increase Speed when Lines are made
                    while (threadCounter < 1000 - (points*5) && t.running)
                    {
                        Thread.Sleep(STEP);
                        threadCounter += STEP;
                    }
                }
            }

            /// <summary>
            /// Draw Handler for the Field
            /// </summary>
        private static
            void drawField 
            ()
            {
                //locks the Field
                while (drawLock) ;
                drawLock = true;

                //Current Position
                int posX = Console.CursorLeft;
                int posY = Console.CursorTop;

                //Draw points
                Console.CursorLeft = 13;
                Console.CursorTop = 2;
                Console.WriteLine("Lines: {0}", points);

                //Draw Field
                Console.SetCursorPosition(posX, posY);
                writeArr(t.Level, true);

                //Draw next Block
                Console.CursorLeft = 13;
                Console.CursorTop = 3;
                writeArr(clearBlock, true);
                if (showNext)
                {
                    Console.CursorLeft = 14;
                    Console.CursorTop = 4;
                    writeArr(t.Next, false);
                }

                //Back to the Future, err... Beginning
                Console.SetCursorPosition(posX, posY);
                drawLock = false;
            }

            /// <summary>
            /// Writes a 2D Array to the Console
            /// </summary>
            /// <param name="qq">Array</param>
            /// <param name="writeBorder">Write Border around Array?</param>
        static
            void writeArr 
            (int[,] qq, bool writeBorder)
            {
                int x = Console.CursorLeft;
                for (int i = 0; i <= qq.GetUpperBound(0); i++)
                {
                    if (writeBorder)
                    {
                        Console.Write(BAKER);
                    }
                    for (int j = 0; j <= qq.GetUpperBound(1); j++)
                    {
                        //Change color according to the Number
                        switch (qq[i, j])
                        {
                            case 1:
                                writeCol(BLOCK, ConsoleColor.White);
                                break;
                            case 2:
                                writeCol(BLOCK, ConsoleColor.Magenta);
                                break;
                            case 3:
                                writeCol(BLOCK, ConsoleColor.Blue);
                                break;
                            case 4:
                                writeCol(BLOCK, ConsoleColor.Green);
                                break;
                            case 5:
                                writeCol(BLOCK, ConsoleColor.Yellow);
                                break;
                            case 6:
                                writeCol(BLOCK, ConsoleColor.Red);
                                break;
                            case 7:
                                Console.BackgroundColor = ConsoleColor.Red;
                                writeCol(ACTIVE, ConsoleColor.Cyan);
                                Console.BackgroundColor = ConsoleColor.Black;
                                break;
                            case 8:
                                Console.BackgroundColor = ConsoleColor.Gray;
                                writeCol(SHADOW, ConsoleColor.Gray);
                                Console.BackgroundColor = ConsoleColor.Black;
                                break;
                            default:
                                Console.Write(EMPTY);
                                break;
                        }
                    }
                    if (writeBorder)
                    {
                        Console.WriteLine(BAKER);
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                    Console.CursorLeft = x;
                }
                for (int q = 0; q <= qq.GetUpperBound(1) + 2; q++)
                {
                    if (writeBorder)
                    {
                        Console.Write(BAKER);
                    }
                }
            }

            /// <summary>
            /// Writes a String in the Specified foreground color,
            /// then switches the Color back
            /// </summary>
            /// <param name="a">String</param>
            /// <param name="b">Color</param>
        static
            void writeCol 
            (string a, ConsoleColor b)
            {
                ConsoleColor c = Console.ForegroundColor;
                Console.ForegroundColor = b;
                Console.Write(a);
                Console.ForegroundColor = c;
            }
        }
    }

