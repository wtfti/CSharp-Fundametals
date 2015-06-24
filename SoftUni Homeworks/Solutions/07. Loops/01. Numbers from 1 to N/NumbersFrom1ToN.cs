using System;
class NumbersFrom1ToN
{
    static void Main()
    {
        Console.Write("n: ");
        int startNumber;
        int endNumber = int.Parse(Console.ReadLine());
        for (startNumber = 1; startNumber <= endNumber; startNumber++)
        {
            Console.Write(startNumber + " ");
        }
        Console.WriteLine();
    }
}