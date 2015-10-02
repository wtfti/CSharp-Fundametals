using System;
using System.Linq;

class Program
{
    public static void Main()
    {
        const double consumeLampsWatts = 100.53;
        const double consumeComputersWatts = 125.90;

        int floors = int.Parse(Console.ReadLine());
        int flats = int.Parse(Console.ReadLine());
        string[] time = Console.ReadLine().Split(':').ToArray();
        int hours = int.Parse(time[0]);
        int totalFlats = floors*flats;
        double totalWatts = 0;

        if (hours >= 14 && hours <= 18) // 2 lamps 2 PCs
        {
            totalWatts = ((2 * consumeLampsWatts) + (2 * consumeComputersWatts)) * totalFlats;
        }
        else if (hours >= 19 && hours <= 23) // 7 lamps 6 PCs
        {
            totalWatts = ((7 * consumeLampsWatts) + (6 * consumeComputersWatts)) * totalFlats;
        }
        else if (hours >= 0 && hours <= 8) // 1 lamp 8 PCs
        {
            totalWatts = ((1 * consumeLampsWatts) + (8 * consumeComputersWatts)) * totalFlats;
        }
        Console.WriteLine((int)totalWatts+" Watts");
    }
}