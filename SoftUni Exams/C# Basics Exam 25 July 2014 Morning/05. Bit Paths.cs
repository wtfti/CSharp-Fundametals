using System;
using System.Linq;

class BitsPaths
{
    public static void Main()
    {
        int nCommands = int.Parse(Console.ReadLine());
        int bit = 0;
        int[][] directions = new int[nCommands][];
        int sum = 0;
        int[] positions = new int[nCommands];
        for (int i = 0; i < nCommands; i++)
        {
            directions[i] = new int[7];
            directions[i] = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
            positions[i] =  3 - directions[i][0];
            bit ^= (1 << (3 - directions[i][0]));
        }

        sum += bit;

        for (int nDirections = 1; nDirections <= 7; nDirections++)
        {
            bit = 0;
            for (int currentDirection = 0, countPosition = 0; currentDirection < nCommands; currentDirection++, countPosition++)
            {
                positions[countPosition] = (positions[countPosition] - directions[currentDirection][nDirections]);
                bit ^= (1 << positions[countPosition]);
            }
            sum += bit; 
        }
        Console.WriteLine(Convert.ToString(sum,2));
        Console.WriteLine(sum.ToString("X"));
    }
}