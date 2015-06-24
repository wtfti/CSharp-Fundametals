using System;

namespace _03.Circle_Perimeter_and_Area
{
    class CirclePerimeterArea
    {
        static void Main()
        {
            double r = double.Parse(Console.ReadLine());
            double perimeter, area;
            perimeter = 2*Math.PI*r;
            area = Math.PI*Math.Pow(r, 2);
            Console.WriteLine("Perimeter: {0:0.00} \r\nArea: {1:0.00}", perimeter, area);
        }
    }
}
