using System;

class TravellerBob
{
    public static void Main()
    {
        const int contractTravels = 12;
        const int familyTravels = 4;

        string kindyear = Console.ReadLine();
        int contractMonths = int.Parse(Console.ReadLine());
        int familyMonths = int.Parse(Console.ReadLine());

        int normalMonths = 12 - (contractMonths + familyMonths);
        double normalTravels = (contractTravels*normalMonths)*0.6;
        double totaltravels = (contractMonths*contractTravels) + (familyMonths*familyTravels) + normalTravels;

        if (kindyear == "leap")
        {
            totaltravels = totaltravels + (totaltravels*0.05);
        }
        Console.WriteLine("{0}",(int)totaltravels);
    }
}