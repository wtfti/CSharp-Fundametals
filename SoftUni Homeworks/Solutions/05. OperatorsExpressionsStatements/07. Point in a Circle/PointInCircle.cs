using System;
class PointInCircle
{
    static void Main()
    {
        Console.Write("X: ");
        double x = double.Parse(Console.ReadLine());
        Console.Write("Y: ");
        double y = double.Parse(Console.ReadLine());
        bool isInside = Math.Pow((x - 0), 2) + Math.Pow((y - 0), 2) <= 4;
        Console.WriteLine("Inside: {0}",isInside);
    }
}
