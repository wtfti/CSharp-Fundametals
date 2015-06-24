using System;
class SpiralMatrirow
{
    static void Main()
    {
        Console.Write("n: ");
        int n = int.Parse(Console.ReadLine());
        int[,] spiralMatrix = new int[n,n];
        int currentCount = 1;
        int row = 0;
        int cols = 0;
        int size = n;

        while (size > 0)
        {
            for (int i = cols; i <= cols + size - 1; i++)
            {
                spiralMatrix[row, i] = currentCount++;
            }

            for (int j = row + 1; j <= row + size - 1; j++)
            {
                spiralMatrix[j, cols + size - 1] = currentCount++;
            }

            for (int i = cols + size - 2; i >= cols; i--)
            {
                spiralMatrix[row + size - 1, i] = currentCount++;
            }

            for (int i = row + size - 2; i >= row + 1; i--)
            {
                spiralMatrix[i, cols] = currentCount++;
            }

            row = row + 1;
            cols = cols + 1;
            size = size - 2;
        }

        for (int x = 0; x < n; x++)
        {
            for (int y = 0; y < n; y++)
            {
                Console.Write(spiralMatrix[x, y]);
                if (spiralMatrix[x, y] > 9)
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.Write("  ");
                }
            }
            Console.WriteLine();
        }
    }
}