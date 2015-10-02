using System;

class InsideCircleOutsideRectangle
{
    static void Main()
    {
        while (true)
        {
            Console.Write("X: ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("Y: ");
            double y = double.Parse(Console.ReadLine());
            bool isInsideCircle = Math.Pow((x - 1), 2) + Math.Pow((y - 1), 2) <= 1.5*1.5;
            bool outRect = x <= -1 || x >= 5 || y > 1 || y <= -1;
            bool inCircleAndOutOfRectangle = isInsideCircle && outRect;
            if (inCircleAndOutOfRectangle)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
