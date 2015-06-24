using System;
class DecimalToBinary
{
    static void Main()
    {
        Console.Write("number: ");
        long number = long.Parse(Console.ReadLine());
        string result = "";

        while (number > 0)
        {
            result = number % 2 + result;
            number /= 2;
        }
        Console.WriteLine(result);
    }
}
