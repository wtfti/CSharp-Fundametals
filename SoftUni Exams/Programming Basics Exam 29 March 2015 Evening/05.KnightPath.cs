using System;
using System.Linq;

class KnightPath
{
    public static void Main()
    {
        int[] bits = new int[8];
        bits[0] = 1;
        string[] commands = Console.ReadLine().Split().ToArray();
        int row = 0;
        int col = 0;
        int rowCopy = 0;
        int colCopy = 0;
        bool setRow = true;
        bool result = false;
        bool outOfRange = false;
        while (commands[0] != "stop")
        {
            for (int index = 0; index < commands.Length; index++)
            {
                switch (commands[index])
                {
                    case "left":
                        if (setRow && !outOfRange)
                        {
                            col += 2;
                            if (col > 7)
                            {
                                col = colCopy;
                                row = rowCopy;
                                outOfRange = true;
                            }
                        }
                        else if (!outOfRange)
                        {
                            col++;
                            if (col > 7)
                            {
                                col = colCopy;
                                row = rowCopy;
                                outOfRange = true;
                            }
                        }
                        break;
                    case "down":
                        if (setRow && !outOfRange)
                        {
                            row += 2;
                            if (row > 7)
                            {
                                row = rowCopy;
                                col = colCopy;
                                outOfRange = true;
                            }
                        }
                        else if (!outOfRange)
                        {
                            row++;
                            if (row > 7)
                            {
                                row = rowCopy;
                                col = colCopy;
                                outOfRange = true;
                            }
                        }
                        break;
                    case "up":
                        if (setRow && !outOfRange)
                        {
                            row -= 2;
                            if (row < 0)
                            {
                                row = rowCopy;
                                col = colCopy;
                                outOfRange = true;
                            }
                        }
                        else if (!outOfRange)
                        {
                            row--;
                            if (row < 0)
                            {
                                row = rowCopy;
                                col = colCopy;
                                outOfRange = true;
                            }
                        }
                        break;
                    case "right":
                        if (setRow && !outOfRange)
                        {
                            col -= 2;
                            if (col < 0)
                            {
                                col = colCopy;
                                row = rowCopy;
                                outOfRange = true;
                            }
                        }
                        else if (!outOfRange)
                        {
                            col--;
                            if (col < 0)
                            {
                                col = colCopy;
                                row = rowCopy;
                                outOfRange = true;
                            }
                        }
                        break;
                }
                setRow = false;
            }

            if (!outOfRange)
            {
                rowCopy = row;
                colCopy = col;
                bits[row] ^= (1 << col);
            }
            outOfRange = false;
            setRow = true;
            commands = Console.ReadLine().Split().ToArray();
        }
        foreach (var bit in bits)
        {
            if (bit != 0)
            {
                Console.WriteLine(bit);
                result = true;
            }
        }
        if (!result)
        {
            Console.WriteLine("[Board is empty]");
        }
    }
}