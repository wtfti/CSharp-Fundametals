using System;
class Rectangles
{
    static void Main()
    {
        Console.Write("Width: ");
        double width = double.Parse(Console.ReadLine());
        Console.Write("Height: ");
        double height = double.Parse(Console.ReadLine());
        double area = width*height;
        double p = (width + height)*2;
        Console.WriteLine("P: {0}\r\n Area: {1}", p,area);
    }
}