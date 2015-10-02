using System;
using System.Linq;

class PaintBall
{
    public static void Main()
    {
        string[] shots = Console.ReadLine().Split().ToArray();
        int[] board = new int[10];
        for (int fillNum = 0; fillNum < board.Length; fillNum++)
        {
            board[fillNum] = 1023;
        }
        int maxShots = 25;

        int blackOrWhite = 0;

        while (maxShots > 0 && shots[0] != "End")
        {
            int row = int.Parse(shots[0]);
            int col = int.Parse(shots[1]);
            int radius = int.Parse(shots[2]);
            int startingRow = row - radius;
            int startingCol = col - radius;
            int endRowShot = row + radius;
            int endBitShotCol = col + radius;

            CheckForInvalidValues(ref startingRow, ref startingCol, ref endBitShotCol, ref endRowShot);
            Shooot(blackOrWhite, startingRow, startingCol, endRowShot, endBitShotCol, ref board);
            if (blackOrWhite == 0)
            {
                blackOrWhite = 1;
            }
            else
            {
                blackOrWhite = 0;
            }
            shots = Console.ReadLine().Split().ToArray();
        }
        Console.WriteLine(board.Sum());
    }

    private static void Shooot(int type, int startRow, int startCol, int endRow, int endCol, ref int[] board)
    {
        for (int startRowCopy = startRow; startRowCopy <= endRow; startRowCopy++)
        {
            for (int startColCopy = startCol; startColCopy <= endCol; startColCopy++)
            {
                if (type == 1)
                {
                    board[startRowCopy] |= (1 << startColCopy);
                }
                else
                {
                    int mask = (board[startRowCopy] >> startColCopy) & 1;
                    if (mask == 0)
                    {
                        continue;
                    }
                    board[startRowCopy] ^= (1 << startColCopy);
                }

            }
        }
    }

    private static void CheckForInvalidValues(ref int startingRow, ref int startingCol,ref int endBitShot, ref int endRowShot)
    {
        if (startingRow < 0)
        {
            startingRow = 0;
        }
        if (startingCol < 0 )
        {
            startingCol = 0;
        }
        if (endBitShot > 9)
        {
            endBitShot = 9;
        }
        if (endRowShot > 9)
        {
            endRowShot = 9;
        }
    }
}