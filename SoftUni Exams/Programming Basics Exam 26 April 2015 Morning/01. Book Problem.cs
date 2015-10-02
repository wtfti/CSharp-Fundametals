using System;

class BookProblem
{
    public static void Main()
    {
        int pagesOfBook = int.Parse(Console.ReadLine());
        int campingDays = int.Parse(Console.ReadLine());
        int readPagesEveryDay = int.Parse(Console.ReadLine());
        int normalDays = 30 - campingDays;
        int readPagesThisMonth = readPagesEveryDay * normalDays;
        if (readPagesThisMonth < 1)
        {
            Console.WriteLine("never");
            return;
        }
        double months;
        months = (double)pagesOfBook / readPagesThisMonth;
        Console.WriteLine("{0:0} years {1:0} months", months / 12, Math.Ceiling(months%12));
    }
}