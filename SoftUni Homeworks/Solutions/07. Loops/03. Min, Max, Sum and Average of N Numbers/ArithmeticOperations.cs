using System;
using System.Linq;

class ArithmeticOperations
{
    static void Main()
    {
        Console.Write("input: ");
        int nNumbers = int.Parse(Console.ReadLine());
        double[] numbers = new double[nNumbers];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("min = {0:0.##}\n\rmax = {1:0.##}\n\rsum = {2:0.##}\r\navg = {3:0.##}", numbers.Min(), numbers.Max(), numbers.Sum(), numbers.Average());
    }
}