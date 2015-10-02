using System;

class TicTacToe
{
    public static void Main()
    {
        const int TicTacRows = 3;
        const int TicTacCols = 3;

        int x = int.Parse(Console.ReadLine());
        int y = int.Parse(Console.ReadLine());
        int startValue = int.Parse(Console.ReadLine());

        for (int row = 0, countPower = 1; row < TicTacRows; row++)
        {
            for (int cols = 0; cols < TicTacCols; cols++, countPower++, startValue++)
            {
                if (row == y && cols == x)
                {
                    long value = startValue;
                    for (int power = 1; power < countPower; power++)
                    {
                        value *= startValue;
                    }
                    Console.WriteLine(value);
                    return;
                }
            }
        }
    }
}