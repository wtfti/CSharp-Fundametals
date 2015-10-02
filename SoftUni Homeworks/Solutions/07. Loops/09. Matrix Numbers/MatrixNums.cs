using System;
class MatrixNums
{
    static void Main()
    {
        Console.Write("n: ");
        int n = int.Parse(Console.ReadLine());
        int numbers = 1;

        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                Console.Write(numbers + " ");
                numbers++;
            }
            Console.WriteLine();
            numbers = row +2;
        }
    }
}