using System;

class TorrentPirate
{
    public static void Main()
    {
        const int mbPerHour = 7200;
        int size = int.Parse(Console.ReadLine());
        int costCinema = int.Parse(Console.ReadLine());
        int wifeSpendPerHor = int.Parse(Console.ReadLine());

        double cinemaPrice = ((double)size/1500)*costCinema;
        double downloadCost = wifeSpendPerHor*((double)size/mbPerHour);

        if (downloadCost <= cinemaPrice)
        {
            Console.WriteLine("mall -> {0:0.00}lv", downloadCost);
        }
        else
        {
            Console.WriteLine("cinema -> {0:0.00}lv", cinemaPrice);
        }
    }
}