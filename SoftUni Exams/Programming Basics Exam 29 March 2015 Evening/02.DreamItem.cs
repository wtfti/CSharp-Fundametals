using System;
using System.Linq;

class DreamItem
{
    public static void Main()
    {
        const int holidays = 10;
        string[] input = Console.ReadLine().Split('\\').ToArray();
        int month = 1;
        switch (input[0])
        {
            case "Jan":
                month = 1;
                break;
            case "Feb":
                month = 2;
                break;
            case "March":
                month = 3;
                break;
            case "Apr":
                month = 4;
                break;
            case "May":
                month = 5;
                break;
            case "June":
                month = 6;
                break;
            case "July":
                month = 7;
                break;
            case "Aug":
                month = 8;
                break;
            case "Sept":
                month = 9;
                break;
            case "Oct":
                month = 10;
                break;
            case "Nov":
                month = 11;
                break;
            case "Dec":
                month = 12;
                break;
        }
        double moneyPerHour = double.Parse(input[1]);
        int hoursPerDay = int.Parse(input[2]);
        decimal price = decimal.Parse(input[3]);
        int daysMonth = DateTime.DaysInMonth(2015, month);
        daysMonth -= holidays;
        decimal income = (decimal)(moneyPerHour * hoursPerDay) * daysMonth;
        if (income > 700)
        {
            income += (income * (decimal)0.1);
        }
        if (income >= price)
        {
            Console.WriteLine("Money left = {0:0.00} leva.", income - price);
        }
        else
        {
            Console.WriteLine("Not enough money. {0:0.00} leva needed.", price - income);
        }
    }
}