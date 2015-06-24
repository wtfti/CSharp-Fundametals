using System;
class CalcGCD
{
    static void Main()
    {
        Console.Write("a: ");
        int a = Math.Abs(int.Parse(Console.ReadLine()));
        Console.Write("b: ");
        int b = Math.Abs(int.Parse(Console.ReadLine()));
        while (a != 0 && b != 0)
        {
            if (a > b)
            {
                a -= b;
            }
            else
            {
                b -= a;
            }
        }
        Console.WriteLine(Math.Max(a, b));
    }
}
