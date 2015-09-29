using System;
class FillMatrix
{
    static void Main()
    {
        int sizeMatrix = int.Parse(Console.ReadLine());
        int[,] matrixA = new int[sizeMatrix,sizeMatrix];
        int[,] matrixB = new int[sizeMatrix,sizeMatrix];
        int number;
        bool check = false;
        Console.Write("Pattern A:\r\n");

        for (int row = 0; row < sizeMatrix; row++)
        {
            number = row + 1;
            for (int col = 0; col < sizeMatrix; col++)
            {
                matrixA[row, col] = number;
                number += sizeMatrix;
            }
        }
        PrintMatrix(matrixA, sizeMatrix);

        Console.Write("Pattern B:\r\n");

        for (int row = 0; row < sizeMatrix; row++)
        {
            number = row + 1;
            for (int col = 0; col < sizeMatrix; col++)
            {
                matrixB[row, col] = number;
                check = !check;
                if (check)
                {
                    number = (sizeMatrix*(col + 2)) - row;
                }
                else
                {
                    number = (sizeMatrix * (col + 1)) + (row + 1);
                }
            }
            check = false;
        }

        PrintMatrix(matrixB,sizeMatrix);
    }

    private static void PrintMatrix(int[,] matrix, int sizeMatrix)
    {
        for (int row = 0; row < sizeMatrix; row++)
        {
            for (int col = 0; col < sizeMatrix; col++)
            {
                Console.Write("{0,4} ", matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}