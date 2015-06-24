using System;
class NotDivisible3And7
{
    static void Main()
    {
        Console.Write("n: ");
        int number = int.Parse(Console.ReadLine());
        for (int startNumber = 1; startNumber <= number; startNumber++)
        {
            if (startNumber % 3 != 0 && startNumber % 7 != 0)
            {
                Console.Write(startNumber + " ");
            }
        }
        Console.WriteLine();
    }
}
