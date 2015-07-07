using System;

class XBits
{
    public static void Main()
    {
        int[,] bits = new int[8,32];
        int counter = 0;
        for (int row = 0, col = 0; row < 8; row++)
        {
            string currentBit = Convert.ToString(int.Parse(Console.ReadLine()), 2).PadLeft(31, '0');
            foreach (var charr in currentBit)
            {
                bits[row, col] = Convert.ToInt32(charr.ToString());
                col++;
            }
            col = 0;
        }

        for (int col = 0; col <= 5; col++)
        {
            for (int row = 0; row <= 28; row++)
            {
                bool found101 = bits[col, row] == 1 && bits[col, row + 1] == 0 && bits[col, row + 2] == 1;
                bool found010 = bits[col + 1, row] == 0 && bits[col + 1, row + 1] == 1 && bits[col + 1, row + 2] == 0;
                bool found101x = bits[col + 2, row] == 1 && bits[col + 2, row + 1] == 0 && bits[col + 2, row + 2] == 1;
                if (found101 && found010 && found101x)
                {
                    counter++;
                }
            }
        }
        Console.WriteLine(counter);
    }
}