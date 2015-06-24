using System;

class InsideTheBuilding
{
    public static void Main()
    {
        int height = int.Parse(Console.ReadLine());
        int[] points = new int[10];

        for (int takePoints = 0; takePoints < 10; takePoints++)
        {
            points[takePoints] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < points.Length; i+=2)
        {
            if (points[i] <= 3*height && points[i] >= 0 )
            {
                if (points[i + 1] >= 0 && points[i + 1] <= height * 4 && points[i] >= height && points[i] <= height * 2 || points[i+1] <= height && points[i+1] >= 0)
                {
                    Console.WriteLine("inside");
                    continue;
                }
            }
            Console.WriteLine("outside");
        }
    }
}
