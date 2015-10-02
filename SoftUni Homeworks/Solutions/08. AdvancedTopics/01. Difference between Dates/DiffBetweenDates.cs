using System;
using System.Globalization;

class DiffBetweenDates
{
    static void Main()
    {
        Console.Write("First date: ");
        DateTime firstDate = DateTime.ParseExact(Console.ReadLine(), "d.MM.yyyy", CultureInfo.InvariantCulture);
        Console.Write("Second date: ");
        DateTime secondDate = DateTime.ParseExact(Console.ReadLine(), "d.MM.yyyy",
        CultureInfo.InvariantCulture);
        Console.WriteLine("Days between: {0}", (secondDate - firstDate).Days);
    }
}