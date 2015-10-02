using System;
class Trapezoids
{
    static void Main()
    {
        double a, b, h;
        Console.Write("a: ");
        a = double.Parse(Console.ReadLine());
        Console.Write("b: ");
        b = double.Parse(Console.ReadLine());
        Console.Write("h: ");
        h = double.Parse(Console.ReadLine());
        Console.WriteLine("Area: {0}", ((a+b)*h)/2);
    }
}