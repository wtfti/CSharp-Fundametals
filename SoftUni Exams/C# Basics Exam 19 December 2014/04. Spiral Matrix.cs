using System;

class SpiralMatrix
{
    public static void Main()
    {
        int sizeOfMatrix = int.Parse(Console.ReadLine());
        char[] keyword = Console.ReadLine().ToCharArray();
        char[,] matrix = new char[sizeOfMatrix,sizeOfMatrix];

        FillMatrix(ref matrix,sizeOfMatrix,keyword);

        int rowWeight = int.MinValue;
        int winningRow = 0;
        for (int row = 0; row < sizeOfMatrix; row++)
        {
            int currentSum = 0;
            for (int col = 0; col < sizeOfMatrix; col++)
            {
                if (matrix[row,col] >= 'A' && matrix[row,col] <= 'Z')
                {
                    currentSum += (matrix[row, col] - '@') * 10;
                }
                else if (matrix[row,col] >= 'a' && matrix[row,col] <= 'z')
                {
                    currentSum += (matrix[row, col] - '`') * 10;
                }
            }
            if (currentSum > rowWeight)
            {
                rowWeight = currentSum;
                winningRow = row;
            }
        }

        Console.WriteLine("{0} - {1}", winningRow,rowWeight);

    }

    private static void FillMatrix(ref char[,] matrix, int size, char[] message)
    {
        int x = 0;
        int y = 0;
        int currentSymbol = 0;
        while (size > 0)
        {
            for (int i = y; i <= y + size - 1; i++)
            {
                OverflowMessageLetter(ref message, ref currentSymbol);
                matrix[x, i] = message[currentSymbol++];
            }

            for (int j = x + 1; j <= x + size - 1; j++)
            {
                OverflowMessageLetter(ref message, ref currentSymbol);
                matrix[j, y + size - 1] = message[currentSymbol++];
            }

            for (int i = y + size - 2; i >= y; i--)
            {
                OverflowMessageLetter(ref message, ref currentSymbol);
                matrix[x + size - 1, i] = message[currentSymbol++];
            }

            for (int i = x + size - 2; i >= x + 1; i--)
            {
                OverflowMessageLetter(ref message, ref currentSymbol);
                matrix[i, y] = message[currentSymbol++];
            }
            x = x + 1;
            y = y + 1;
            size = size - 2;
        }
        
    }

    private static void OverflowMessageLetter(ref char[] message, ref int number)
    {
        if (number > message.Length - 1)
        {
            number = 0;
        }
    }
}