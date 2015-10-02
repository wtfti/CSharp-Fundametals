using System;
using System.Linq;

class MatrixPalindromes
{
    static void Main()
    {
        int[] rowCol = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[,] matrix = new int[rowCol[0],rowCol[1]];
        char[] chars = new[] {'a', 'a', 'a'};

        for (int row = 0; row < rowCol[0]; row++)
        {
            chars[1] = chars[0];
            chars[2] = chars[1];
            for (int col = 0; col < rowCol[1]; col++)
            {
                Console.Write("{0}{1}{2} ", chars[0], chars[1], chars[2]);
                if (chars[1] < 'z')
                {
                    chars[1]++;
                }
                if (chars[1] == 'z')
                {
                    chars[2]++;
                }
            }
            Console.WriteLine();
            chars[0]++;
        }
    }
}
