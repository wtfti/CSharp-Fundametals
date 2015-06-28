using System;

class CheatSheet
{
    public static void Main()
    {
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());
        decimal VstartNumber = decimal.Parse(Console.ReadLine());
        decimal HstartNumber = decimal.Parse(Console.ReadLine());

        for (decimal row = 0; row < rows; row++)
        {
            for (decimal col = 0; col < cols; col++)
            {
                Console.Write(VstartNumber * HstartNumber);
                if (col != cols-1)
                {
                    Console.Write(" ");
                }
                HstartNumber++;
            }
            VstartNumber++;
            HstartNumber -= cols;
            Console.WriteLine();
        }
    }


}