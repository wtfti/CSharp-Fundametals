using System;

class PiggyBank
{
    public static void Main()
    {
        const int days = 30;
        const int months = 12;
        const int savesEveryDay = 2;
        const int spendMoneyOnPartyDay = 5;
        //input
        int priceOfTank = int.Parse(Console.ReadLine());
        int partyDays = int.Parse(Console.ReadLine());

        int normalDays = days - partyDays;
        int savesThisMonth = (normalDays*savesEveryDay)-(spendMoneyOnPartyDay*partyDays);
        if (savesThisMonth <= 0)
        {
            Console.WriteLine("never");
        }
        else
        {
            double neededMonths = (double) priceOfTank/savesThisMonth;
            int result = (int)Math.Ceiling(neededMonths);
            Console.WriteLine("{0} years, {1} months", result/months, result%12);
        }
    }


}