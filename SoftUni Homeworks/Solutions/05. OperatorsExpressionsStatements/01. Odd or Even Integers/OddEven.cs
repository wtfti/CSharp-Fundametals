using System;
class Program
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        bool isOdd = number%2 != 0;
        Console.WriteLine("Odd? {0}",isOdd);
    }
}