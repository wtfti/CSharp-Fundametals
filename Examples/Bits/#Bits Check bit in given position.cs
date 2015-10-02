using System;
class BitwiseExtractBit
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int mask = number >> position;
        int nuberGivenPosition = mask & 1;
        Console.WriteLine(nuberGivenPosition);
    }
}
