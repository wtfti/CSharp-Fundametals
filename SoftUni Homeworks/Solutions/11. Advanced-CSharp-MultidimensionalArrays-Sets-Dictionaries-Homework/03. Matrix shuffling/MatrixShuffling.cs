using System;
class MatrixShuffling
{
    static void Main()
    {
        int x = int.Parse(Console.ReadLine());
        int y = int.Parse(Console.ReadLine());
        object[,] matrix = new object[x,y];

        InitializeMatrix(matrix, x, y);
        string[] command;
        do
        {
            command = Console.ReadLine().Split();
            if (command[0] == "swap")
            {
                SwapNumbers(command, x, y, matrix);
            }
            else if (command[0] != "END")
            {
                Console.WriteLine("Invalid  Input");
            }
        } while (command[0] != "END");
    }

    private static void SwapNumbers(string[] command, int x, int y, object[,] matrix)
    {
        int firstIndexX = int.Parse(command[1]);
        int firstIndexY = int.Parse(command[2]);
        int secondIndexX = int.Parse(command[3]);
        int secondIndexY = int.Parse(command[4]);
        if (firstIndexX < x && secondIndexX < x && firstIndexX >= 0 &&
            firstIndexY < y && secondIndexY < y && secondIndexY >= 0) //validate
        {
            object firstObjectToSwap = matrix[firstIndexX, firstIndexY];
            matrix[firstIndexX, firstIndexY] = matrix[secondIndexX, secondIndexY];
            matrix[secondIndexX, secondIndexY] = firstObjectToSwap;
            PrintMatrix(matrix, x, y, firstObjectToSwap, matrix[firstIndexX,firstIndexY]);
        }
        else
        {
            Console.WriteLine("Invalid  Input");
        }
    }

    private static void InitializeMatrix(object[,] matrix, int x, int y)
    {
        for (int row = 0; row < x; row++)
        {
            for (int col = 0; col < y; col++)
            {
                object currentCell = Console.ReadLine();
                matrix[row, col] = currentCell;
            }
        }
    }

    private static void PrintMatrix(object[,] matrix, int x, int y, object firstSwapObject, object secondSwapObject)
    {
        Console.WriteLine("(after swapping {0} and {1})\r\n", firstSwapObject, secondSwapObject);
        for (int row = 0; row < x; row++)
        {
            for (int col = 0; col < y; col++)
            {
                Console.Write("{0,4} ", matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}