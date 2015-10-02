using System;
class ExchangeGreater
{
    static void Main()
    {
        Console.Write("a:");
        double a = double.Parse(Console.ReadLine());
        Console.Write("b:");
        double b = double.Parse(Console.ReadLine());
        if (a > b)
        {
            b += a;
            a = b - a;
            b -= a;
        }
        Console.WriteLine("{0} {1}", a, b);
    }
}