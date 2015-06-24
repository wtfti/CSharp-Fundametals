using System;
using System.Linq;

class Program
{
    static void Main()
    {
        while (true)
        {
            DateTime date = DateTime.Parse(Console.ReadLine());
            DateTime startBeerTime = DateTime.Parse("1:00:00 PM");
            DateTime endBeerTime = DateTime.Parse("3:00:00 AM");
            if (date.TimeOfDay > startBeerTime.TimeOfDay || date.TimeOfDay < endBeerTime.TimeOfDay)
            {
                Console.WriteLine("beer time");
            }
            else
            {
                Console.WriteLine("non-beer time");
            }
        }
    }
}
