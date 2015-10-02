using System;

class DoubleDowns
{
    public static void Main()
    {
        int numbers = int.Parse(Console.ReadLine());
        int[,] bits = new int[numbers, 32];
        for (int row = 0, col = 0; row < numbers; row++)
        {
            string currentBit = Convert.ToString(int.Parse(Console.ReadLine()), 2).PadLeft(31, '0');
            foreach (var charr in currentBit)
            {
                bits[row, col] = Convert.ToInt32(charr.ToString());
                col++;
            }
            col = 0;
        }
        int rightDiagonal = 0;
        int leftDiagonal = 0;
        int vertical = 0;

        for (int row = 0; row < numbers - 1; row++)
        {
            for (int col = 0; col <= 31; col++)
            {
                if (bits[row, col] == 1 && bits[row + 1, col] == 1)
                {
                    vertical++;
                }
                if (col + 1 <= 31 && row + 1 <= numbers - 1 && bits[row, col] == 1 && bits[row + 1, col + 1] == 1)
                {
                    rightDiagonal++;
                }
                if (col - 1 >= 0 && row + 1 <= numbers - 1 && bits[row, col] == 1 && bits[row + 1, col - 1] == 1)
                {
                    leftDiagonal++;
                }
            }
        }
        Console.WriteLine("{0}\r\n{1}\r\n{2}", rightDiagonal, leftDiagonal, vertical);
    }
}