using System;

internal class Program
{
    private static void Main()
    {
        int ax = int.Parse(Console.ReadLine());
        int ay = int.Parse(Console.ReadLine());
        int bx = int.Parse(Console.ReadLine());
        int by = int.Parse(Console.ReadLine());
        int cx = int.Parse(Console.ReadLine());
        int cy = int.Parse(Console.ReadLine());
        double valueA = Math.Sqrt(Math.Pow((cx - bx), 2) + Math.Pow((cy - by), 2));
        double valueB = Math.Sqrt(Math.Pow((ax - cx), 2) + Math.Pow((ay - cy), 2));
        double valueC = Math.Sqrt(Math.Pow((ax - bx), 2) + Math.Pow((ay - by), 2));
        bool formTri = valueA + valueB > valueC && 
            valueB + valueC > valueA && valueA + valueC > valueB;
        if (!formTri)
        {
            Console.WriteLine("No\r\n{0:f2}",valueA+valueB);
        }
        else
        {
            double p = (valueA + valueC + valueB) / 2;
            double areaHeron = Math.Sqrt((p * ((p - valueA) * (p - valueB) * (p - valueC))));
            Console.WriteLine("Yes\r\n{0:f2}", areaHeron);
        }
    }
}
