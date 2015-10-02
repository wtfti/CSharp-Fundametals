using System;
using System.Linq;

class MaximalSum
{
    static void Main()
    {
        int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int x = sizes[0];
        int y = sizes[1];
        int[,] matrix = new int[x,y];
        int[,] bestSumMatrix = new int[3,3];

        InitializeMatrix(matrix, x, y);
        int bestSum = int.MinValue;
        for (int row = 0; row < x - 2; row++)
        {
            for (int col = 0; col < y - 2; col++)
            {
                int currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                      matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                      matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                CHeckSum(currentSum, ref bestSum, row, col, bestSumMatrix, matrix);
            }
        }
    }

    private static void CHeckSum(int currentSum, ref int bestSum, int firstMatrixRow, int firstMatrixCol,int[,] bestSumMatrix, int[,] currentMatrix)
    {
        if (currentSum > bestSum)
        {
            bestSum = currentSum;
            int matrixRow = firstMatrixRow;
            for (int rowBestSumMatrix = 0; rowBestSumMatrix < 3; rowBestSumMatrix++, matrixRow++)
            {
                for (int colBestSumMatrix = 0, matrixCol = firstMatrixCol; colBestSumMatrix < 3; colBestSumMatrix++, matrixCol++)
                {
                    bestSumMatrix[rowBestSumMatrix, colBestSumMatrix] = currentMatrix[matrixRow, matrixCol];
                }
            }
        }
    }

    private static void InitializeMatrix(int[,] matrix, int x, int y)
    {
        for (int row = 0; row < x; row++)
        {
            int[] currentRowNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int col = 0; col < y; col++)
            {
                matrix[row, col] = currentRowNumbers[col];
            }
        }
    }
}
