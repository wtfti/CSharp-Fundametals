using System;
class Program
{
    static void Main()
    {
        Console.Write("Weight: ");
        double weight = double.Parse(Console.ReadLine());
        Console.WriteLine("Weight on the moong: {0}", weight * 0.17);
    }
}