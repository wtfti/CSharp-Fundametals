using System;

namespace Tetris
{
    class Tetris
    {
        /// <summary>
        /// Game Over Event Delegate
        /// </summary>
        public delegate void GameOverHandler();
        /// <summary>
        /// Block was Fixed Event Handler
        /// </summary>
        public delegate void BlockFixedHandler();
        /// <summary>
        /// The Player was awesome enough to make some Lines 8or at least one) Handler
        /// </summary>
        /// <param name="Lines">Number of Lines the Player did</param>
        public delegate void LinesDoneHandler(int Lines);

        /// <summary>
        /// Game is over Buddy!
        /// </summary>
        public event GameOverHandler GameOver;
        /// <summary>
        /// Block fixed.
        /// </summary>
        public event BlockFixedHandler BlockFixed;
        /// <summary>
        /// YOU made lines?
        /// </summary>
        public event LinesDoneHandler LinesDone;

        /// <summary>
        /// Available Tetris Keys
        /// </summary>
        public enum Key
        {
            Left,
            Right,
            Up,
            Down,
            rRight,
            rLeft
        }

        /// <summary>
        /// The Playfield
        /// </summary>
        private int[,] Container;
        /// <summary>
        /// X Coord of Block
        /// </summary>
        private int posX;
        /// <summary>
        /// Y Coord of Block
        /// </summary>
        private int posY;
        /// <summary>
        /// Current moving Block
        /// </summary>
        private int[,] currBlock = null;
        /// <summary>
        /// next Block
        /// </summary>
        private int[,] nextBlock = null;
        /// <summary>
        /// Block generator and Manager
        /// </summary>
        private Blocks bGen = new Blocks();
        /// <summary>
        /// True as long as the Game is running
        /// (well if you play this is not so long in "true" state)
        /// </summary>
        private bool inGame;
        /// <summary>
        /// Draw shadow Block [y/n]?
        /// </summary>
        private bool shadow;

        /// <summary>
        /// initializes a new Tetris Game
        /// </summary>
        /// <param name="Width">Width of Container (without Border) >=10</param>
        /// <param name="Height">Height of Container (without Border) >=20</param>
        public Tetris(int Width, int Height)
        {
            shadow = true;
            if (Width >= 10 && Height >= 20)
            {
                Container = new int[Height, Width];
            }
            else
            {
                throw new Exception("Baker must be at least 10x20");
            }

        }

        /// <summary>
        /// Starts a Game or gets the next Block
        /// </summary>
        public void start()
        {
            inGame = true;
            posY = 0;
            posX = Container.GetUpperBound(1) / 2;
            currBlock = nextBlock != null ? nextBlock : bGen.getRandomBlock();
            nextBlock = bGen.getRandomBlock();
            if (!canPosAt(currBlock, posX, posY))
            {
                gameOver();
            }
        }

        /// <summary>
        /// Game is over
        /// </summary>
        public void gameOver()
        {
            inGame = false;
            if (GameOver != null)
            {
                GameOver();
            }
        }

        /// <summary>
        /// Advances the Game by one step
        /// </summary>
        public void step()
        {
            if (inGame)
            {
                if (canPosAt(currBlock, posX, posY + 1))
                {
                    posY++;
                }
                else
                {
                    Container = fixBlock(currBlock, Container, posX, posY);

                    start();
                }
                int Lines = checkLines();
                if (LinesDone != null)
                {
                    LinesDone(Lines);
                }
            }
        }

        /// <summary>
        /// handle pressed Tetris Key
        /// </summary>
        /// <param name="k">Tetris Key</param>
        public void keyPress(Key k)
        {
            if (inGame)
            {
                int[,] temp;
                switch (k)
                {
                    case Key.Down:
                        step();
                        break;
                    case Key.Left:
                        if (posX > 0 && canPosAt(currBlock, posX - 1, posY))
                        {
                            posX--;
                        }
                        break;
                    case Key.Right:
                        if (posX < Container.GetUpperBound(0) - currBlock.GetUpperBound(0) && canPosAt(currBlock, posX + 1, posY))
                        {
                            posX++;
                        }
                        break;
                    case Key.rLeft:
                        temp = Blocks.rotateL(currBlock);
                        if (canPosAt(temp, posX, posY))
                        {
                            currBlock = Blocks.rotateL(currBlock);
                        }
                        break;
                    case Key.rRight:
                        temp = Blocks.rotateR(currBlock);
                        if (canPosAt(temp, posX, posY))
                        {
                            currBlock = Blocks.rotateR(currBlock);
                        }
                        break;
                    case Key.Up:
                        while (canPosAt(currBlock, posX, posY + 1))
                        {
                            step();
                        }
                        step();
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Checks if a Block can be positioned at a specific Location
        /// </summary>
        /// <param name="Block">Block to check</param>
        /// <param name="x">X Pos (0 based)</param>
        /// <param name="y">Y Pos (0 based)</param>
        /// <returns>true, if positionable</returns>
        private bool canPosAt(int[,] Block, int x, int y)
        {
            int[,] copy = (int[,])Container.Clone();

            if (x + Block.GetUpperBound(1) <= copy.GetUpperBound(1) && y + Block.GetUpperBound(0) <= copy.GetUpperBound(0))
            {
                for (int i = 0; i <= Block.GetUpperBound(1); i++)
                {
                    for (int j = 0; j <= Block.GetUpperBound(0); j++)
                    {
                        //I=X Coord
                        //J=Y Coord
                        if (Block[j, i] != 0)
                        {
                            if (copy[y + j, x + i] != 0)
                            {
                                return false;
                            }
                        }
                    }
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Fixes a Block in the Field and returns the new field
        /// </summary>
        /// <param name="Block">Block to fix</param>
        /// <param name="field">Field to use</param>
        /// <param name="x">X Pos to fix (0 based)</param>
        /// <param name="y">Y Pos to fix (0 based)</param>
        /// <returns>New Field with fixed Block</returns>
        private int[,] fixBlock(int[,] Block, int[,] field, int x, int y)
        {
            if (x + Block.GetUpperBound(1) <= field.GetUpperBound(1) && y + Block.GetUpperBound(0) <= field.GetUpperBound(0))
            {
                for (int i = 0; i <= Block.GetUpperBound(1); i++)
                {
                    for (int j = 0; j <= Block.GetUpperBound(0); j++)
                    {
                        //I=Y Coord
                        //J=X Coord
                        if (Block[j, i] != 0)
                        {
                            field[y + j, x + i] = Block[j, i];
                        }
                    }
                }
            }
            if (BlockFixed != null)
            {
                BlockFixed();
            }
            return field;
        }

        /// <summary>
        /// Checks for complete Lines and returns the Number of Lines found (and removed)
        /// </summary>
        /// <returns></returns>
        private int checkLines()
        {
            for (int i = 0; i < Container.GetUpperBound(0) + 1; i++)
            {
                bool isFullLine = true;
                for (int j = 0; j < Container.GetUpperBound(1) + 1; j++)
                {
                    isFullLine = isFullLine && Container[i, j] != 0;
                }
                if (isFullLine)
                {
                    removeLine(i--);
                    return checkLines() + 1;
                }
            }
            return 0;
        }

        /// <summary>
        /// Removes a Line at the specific Index
        /// </summary>
        /// <param name="index">Y Pos (0 Based)</param>
        private void removeLine(int index)
        {
            //move lines one down
            for (int i = index; i > 0; i--)
            {
                for (int j = 0; j <= Container.GetUpperBound(1); j++)
                {
                    Container[i, j] = Container[i - 1, j];
                }
            }
            //empty top line
            for (int j = 0; j <= Container.GetUpperBound(1); j++)
            {
                Container[0, j] = 0;
            }
        }

        /// <summary>
        /// The Actual Game Field (readonly)
        /// </summary>
        public int[,] Level
        {
            get
            {
                int[,] Block = (int[,])currBlock.Clone();
                int[,] temp = (int[,])Container.Clone();
                int add = 0;


                for (int i = 0; i <= Block.GetUpperBound(0); i++)
                {
                    for (int j = 0; j <= Block.GetUpperBound(1); j++)
                    {
                        if (Block[i, j] != 0)
                        {
                            Block[i, j] = 7;
                        }
                    }
                }
                temp = fixBlock(Block, temp, posX, posY);

                if (shadow)
                {
                    for (int i = 0; i <= Block.GetUpperBound(0); i++)
                    {
                        for (int j = 0; j <= Block.GetUpperBound(1); j++)
                        {
                            if (Block[i, j] != 0)
                            {
                                Block[i, j] = 8;
                            }
                        }
                    }

                    while (canPosAt(Block, posX, posY + add))
                    {
                        add++;
                    }

                    if (posY + add - 1 > 0)
                    {
                        return (int[,])fixBlock(Block, temp, posX, posY + add - 1).Clone();
                    }
                }
                return temp;
            }
        }

        /// <summary>
        /// Game running State (readonly)
        /// </summary>
        public bool running
        {
            get
            {
                return inGame;
            }
        }

        /// <summary>
        /// The Next Block to be played (readonly)
        /// </summary>
        public int[,] Next
        {
            get
            {
                return nextBlock;
            }
        }

        /// <summary>
        /// Should the Level Property display a block,
        /// where the actual Block would land [y/n]?
        /// </summary>
        public bool shadowBlock
        {
            get
            {
                return shadow;
            }
            set
            {
                shadow = value;
            }
        }
    }
}
