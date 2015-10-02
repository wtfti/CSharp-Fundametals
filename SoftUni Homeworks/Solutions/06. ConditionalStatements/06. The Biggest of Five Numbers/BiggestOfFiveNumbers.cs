using System;
using System.Linq;

class BiggestOfFiveNumbers
{
    static void Main()
    {
        Console.Write("a: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("b: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("c: ");
        double c = double.Parse(Console.ReadLine());
        Console.Write("d: ");
        double d = double.Parse(Console.ReadLine());
        Console.Write("e: ");
        double e = double.Parse(Console.ReadLine());
        double biggest = a;
        if (biggest < b)
        {
            biggest = b;
        }
        if (biggest < c)
        {
            biggest = c;
        }
        if (biggest < d)
        {
            biggest = d;
        }
        if (biggest < e)
        {
            biggest = e;
        }
        Console.WriteLine("biggest: {0}",biggest);
    }
}
