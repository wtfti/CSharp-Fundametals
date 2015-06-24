using System;
using System.Linq;

class TheBiggestOf3Numbers
{
    static void Main()
    {
        double[] numbers = new double[3];
        Console.Write("a: ");
        numbers[0] = double.Parse(Console.ReadLine());
        Console.Write("b: ");
        numbers[1] = double.Parse(Console.ReadLine());
        Console.Write("c: ");
        numbers[2] = double.Parse(Console.ReadLine());
        Console.WriteLine("biggest: {0}", numbers.Max());
    }
}
