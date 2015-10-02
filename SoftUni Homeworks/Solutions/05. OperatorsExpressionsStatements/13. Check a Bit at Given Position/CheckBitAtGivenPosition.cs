using System;

class CheckBitAtGivenPosition
{
    static void Main()
    {
        Console.Write("number: ");
        int number = int.Parse(Console.ReadLine());
        Console.Write("position: ");
        int position = int.Parse(Console.ReadLine());
        int mask = number >> position;
        int numberGivenPosition = mask & 1;
        var bit = Convert.ToBoolean(Convert.ToInt32(numberGivenPosition));
        Console.WriteLine(bit);
    }
}
