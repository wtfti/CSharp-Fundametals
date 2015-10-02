using System;

class Budget
{
    public static void Main()
    {
        const int spendsEveryWeekday = 10;
        const int spendsEveryWeekend = 20;
        const int rent = 150;

        int money = int.Parse(Console.ReadLine());
        int weekdaysGoesOut = int.Parse(Console.ReadLine());
        int weekendsSpendHometown = int.Parse(Console.ReadLine());
        int normalDays = 22 - weekdaysGoesOut;
        int normalWeeknds = 4 - weekendsSpendHometown;
        double normalDaysSpends = (normalDays * spendsEveryWeekday) + ((normalWeeknds * 2) * (spendsEveryWeekend));
        double goingOutSpends = weekdaysGoesOut * Math.Floor(money*0.03 + 10);
        double totalSpends = normalDaysSpends + goingOutSpends + rent;
        if (totalSpends == money)
        {
            Console.WriteLine("Exact Budget.");
        }
        else if (totalSpends > money)
        {
            Console.WriteLine("No, not enough {0}.",totalSpends-money);
        }
        else
        {
            Console.WriteLine("Yes, leftover {0}.", money - totalSpends);
        }
    }
}