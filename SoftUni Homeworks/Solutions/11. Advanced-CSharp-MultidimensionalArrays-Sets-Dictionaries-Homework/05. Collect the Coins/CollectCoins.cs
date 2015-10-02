using System;

class CollectCoins
{
    static string[] data = new string[4];
    static char[][] board = new char[4][];
    static int hitWalls = 0;
    static int coins = 0;
    static int[] position = new int[2];
    static void Main()
    {
        for (int currentString = 0; currentString < data.Length; currentString++)
        {
            string cell = Console.ReadLine();
            data[currentString] = cell;
            board[currentString] = new char[cell.Length]; // initiliazing the board
        }

        FillBoard();
        string moves = Console.ReadLine();
        int currentMove = 0;

        while (currentMove < moves.Length)
        {
            PlayerMoves(moves, currentMove);
            currentMove++;
        }

        Console.WriteLine("Coins collected: {0}\r\n\r\nWalls hit: {1}", coins, hitWalls);
    }

    private static void PlayerMoves(string moves,int currentMove)
    {
        switch (moves[currentMove])
        {
            case '>':
                position[1]++;
                if (!ValidateCordinates('>'))
                {
                    IsCoin(position[0], position[1]);
                }
                break;
            case '<':
                position[1]--;
                if (!ValidateCordinates('<'))
                {
                    IsCoin(position[0], position[1]);
                }
                break;
            case '^':
                position[0]--;
                if (!ValidateCordinates('^'))
                {
                    IsCoin(position[0], position[1]);
                }
                break;
            case 'V':
                position[0]++;
                if (!ValidateCordinates('V'))
                {
                    IsCoin(position[0], position[1]);
                }
                break;
        }
    }

    private static void IsCoin(int x, int y)
    {
        if (board[x][y] == '$')
        {
            coins++;
        }
    }

    private static bool ValidateCordinates(char movement)
    {
        if (position[0] > 3)
        {
            position[0]--;
        }
        switch (movement)
        {
            case '>':
                if (position[1] > board[position[0]].Length - 1)
                {
                    position[1]--;
                    hitWalls++;
                    return true;
                }
                break;
            case '<':
                if (position[1] < 0)
                {
                    position[1]++;
                    hitWalls++;
                    return true;
                }
                break;
            case '^':
                if (position[0] < 0)
                {
                    position[0]++;
                    hitWalls++;
                    return true;
                }
                else if (position[1] >= board[position[0]].Length)
                {
                    position[0]++;
                    hitWalls++;
                    return true;
                }
                break;
            case 'V':
                if (position[0] > 3)
                {
                    position[0]--;
                    hitWalls++;
                    return true;
                }
                else if (position[1] >= board[position[0]].Length)
                {
                    position[0]--;
                    hitWalls++;
                    return true;
                }
                break;
        }
        return false;
    }

    private static void FillBoard()
    {
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int currentCell = 0; currentCell < board[i].GetLength(0); currentCell++)
            {
                board[i][currentCell] = data[i][currentCell];
            }
        }
    }
}