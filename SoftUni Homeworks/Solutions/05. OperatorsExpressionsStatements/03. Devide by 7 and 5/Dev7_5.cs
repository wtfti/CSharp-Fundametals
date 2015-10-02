using System;
class Program
{
    static void Main()
    {
        Console.Write("Number:");
        int number = int.Parse(Console.ReadLine());
        bool isDivided = number%7 == 0 && number%5 == 0;
        Console.WriteLine("Divided by 7 and 5? {0}", isDivided);
    }
}
