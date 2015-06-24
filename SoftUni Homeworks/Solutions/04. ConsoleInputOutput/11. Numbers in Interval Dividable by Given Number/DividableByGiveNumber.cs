using System;

namespace _11.Numbers_in_Interval_Dividable_by_Given_Number
{
    class DividableByGiveNumber
    {
        static void Main()
        {
            int startNumber, endNumber;
            startNumber = int.Parse(Console.ReadLine());
            endNumber = int.Parse(Console.ReadLine());
            int counter = 0;

            for (int i = startNumber; i <= endNumber; i++)
            {
                if (i % 5 == 0)
                {
                    if (counter != 0)
                    {
                        Console.Write(", ");
                    }
                    counter++;
                    Console.Write(i);
                }
            }
            Console.WriteLine();
            if (counter == 0)
            {
                Console.WriteLine("{0} Numbers", counter);
                Console.WriteLine("-");
            }
            else
            {

                Console.WriteLine("{0} Numbers", counter);
            }
        }
    }
}
