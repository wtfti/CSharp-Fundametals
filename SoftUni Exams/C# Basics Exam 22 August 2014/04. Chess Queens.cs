using System;

class ChessQueens
{
    public static void Main()
    {
        int sizeOfBoard = int.Parse(Console.ReadLine());
        string[,] board = new string[sizeOfBoard,sizeOfBoard];
        int distance = int.Parse(Console.ReadLine())+1;
        char letter = 'a';
        bool foundResult = false;

        for (int row = 0; row < sizeOfBoard; row++)
        {
            for (int col = 0; col < sizeOfBoard; col++)
            {
                board[row, col] = letter.ToString() + (col + 1);
            }
            letter++;
        }
        int maxX = sizeOfBoard - 1;
        int maxY = sizeOfBoard - 1;

        for (int row = 0; row < sizeOfBoard; row++)
        {
            int colPos;
            int rowPos;
            for (int col = 0; col < sizeOfBoard; col++)
            {
                rowPos = row;                                       //horizontal
                colPos = col + distance;                            //horizontal
                if (rowPos <= maxX && colPos <= maxY)
                {
                    Console.WriteLine("{0} - {1}", board[row, col], board[rowPos, colPos]);
                    foundResult = true;
                }

                rowPos = row;
                colPos = col - distance;
                if (rowPos >= 0 && colPos >= 0)
                {
                    Console.WriteLine("{0} - {1}", board[row, col], board[rowPos, colPos]);

                }

                rowPos = row + distance;                            //vertical
                colPos = col;                                       //vertical
                if (rowPos <= maxX && colPos <= maxY)
                {
                    Console.WriteLine("{0} - {1}", board[row, col], board[rowPos, colPos]);
                    foundResult = true;
                }

                rowPos = row - distance;
                colPos = col;
                if (rowPos >= 0 && colPos >= 0)
                {
                    Console.WriteLine("{0} - {1}", board[row, col], board[rowPos, colPos]);
                }

                rowPos = row + distance;                            //diagonal
                colPos = col + distance;                            //diagonal
                if (rowPos <= maxX && colPos <= maxY)
                {
                    Console.WriteLine("{0} - {1}", board[row, col], board[rowPos, colPos]);
                    foundResult = true;
                }

                rowPos = row - distance;
                colPos = col - distance;
                if (rowPos >= 0 && colPos >= 0)
                {
                    Console.WriteLine("{0} - {1}", board[row, col], board[rowPos, colPos]);
                }

                rowPos = row - distance;
                colPos = col + distance;
                if (rowPos >= 0 && colPos <= maxY)
                {
                    Console.WriteLine("{0} - {1}", board[row, col], board[rowPos, colPos]);
                }

                rowPos = row + distance;
                colPos = col - distance;
                if (rowPos <= maxX && colPos >= 0)
                {
                    Console.WriteLine("{0} - {1}", board[row, col], board[rowPos, colPos]);
                }
            }
        }
        if (!foundResult)
        {
            Console.WriteLine("No valid positions");
        }
    }
}