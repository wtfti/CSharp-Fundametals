using System;
class ExtractBitFromInteger
{
    static void Main()
    {
        Console.Write("number: ");
        int number = int.Parse(Console.ReadLine());
        Console.Write("position: ");
        int position = int.Parse(Console.ReadLine());
        int mask = number >> position;
        int numberGivenPosition = mask & 1;
        Console.WriteLine(numberGivenPosition);
    }
}
