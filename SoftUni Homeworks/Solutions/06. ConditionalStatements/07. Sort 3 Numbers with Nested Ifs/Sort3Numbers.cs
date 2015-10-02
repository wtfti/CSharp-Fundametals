using System;
class Sort3Numbers
{
    static void Main()
    {
        Console.Write("a: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("b: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("c: ");
        double c = double.Parse(Console.ReadLine());
        double min = a;
        double max = c;
        if (min > b)
        {
            min = b;
        }
        if (max < a)
        {
            max = a;
        }
        if (max < b)
        {
            max = b;
        }
        if (min > c)
        {
            min = c;
        }
        Console.WriteLine("{0} {1} {2}", max, (a + b + c) - (min + max), min);
    }
}
