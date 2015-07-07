using System;
using System.Linq;

class BabaTinche
{
    public static void Main()
    {
        const int firstClassPrice = 7000;
        const int businessClassPrice = 3500;
        const int economyClassPrice = 1000;

        string[] input = Console.ReadLine().Split().ToArray();
        int firstClassfrequentFlyers = int.Parse(input[1]);
        int firstClassPurchaseMeal = int.Parse(input[2]);
        int passangersFirstClass = (int.Parse(input[0])) - (firstClassfrequentFlyers + firstClassPurchaseMeal); 

        input = Console.ReadLine().Split().ToArray();
        int businesClassfrequentFlyers = int.Parse(input[1]);
        int businesClassPurchaseMeal = int.Parse(input[2]);
        int passangersBusinesClass = (int.Parse(input[0])) - (businesClassfrequentFlyers + businesClassPurchaseMeal);

        input = Console.ReadLine().Split().ToArray();
        int EconomyClassfrequentFlyers = int.Parse(input[1]);
        int EconomyClassPurchaseMeal = int.Parse(input[2]);
        int passangersEconomyClass = (int.Parse(input[0])) - (EconomyClassPurchaseMeal + EconomyClassfrequentFlyers);

        double income = (passangersFirstClass * firstClassPrice) + (firstClassfrequentFlyers * 2100) +
            (passangersBusinesClass * businessClassPrice) + (businesClassfrequentFlyers * 1050) + (passangersEconomyClass * economyClassPrice)
            + (EconomyClassfrequentFlyers * 300);
        income += ((firstClassPurchaseMeal*firstClassPrice) + (businesClassPurchaseMeal*businessClassPrice) +         
                   (EconomyClassPurchaseMeal*economyClassPrice));                                                     
        income += (firstClassPurchaseMeal*(firstClassPrice*0.005)) +
                  (businesClassPurchaseMeal*(businessClassPrice*0.005)) +
                  (EconomyClassPurchaseMeal*(economyClassPrice*0.005));
        Console.WriteLine((int)income);
        double maxIncome = (12*7035) + (28*3517.5) + (50*1005);
        Console.WriteLine("{0}",(int)maxIncome-(int)income);
    }
}