using System;
class ModifyBitAtGivenPos
{
    static void Main()
    {
        Console.Write("number: ");
        int number = int.Parse(Console.ReadLine());
        int numberAfterChange = number;
        Console.Write("position: ");
        int position = int.Parse(Console.ReadLine());
        Console.Write("value: ");
        int value = int.Parse(Console.ReadLine());
        int mask = number >> position;
        int bit = mask & 1;
        if (bit != value)
        {
            bit = 1 << position;
            numberAfterChange = number ^ bit;
        }
        Console.WriteLine(numberAfterChange);
    }
}
