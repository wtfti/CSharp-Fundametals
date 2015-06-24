using System;
class BitwiseExtractBit
{
    private const int position = 3;
    static void Main()
    {
        Console.Write("number: ");
        int number = int.Parse(Console.ReadLine());
        int mask = number >> position;
        int nuberGivenPosition = mask & 1;
        Console.WriteLine(nuberGivenPosition);
    }
}
