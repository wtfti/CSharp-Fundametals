using System;
class BinToDecimal
{
    static void Main()
    {
        Console.Write("input: ");
        string input = Console.ReadLine();
        long sum = 0;

        for (int i = 0; i < input.Length; i++)
        {
            sum = sum*2 + Convert.ToInt16(input[i].ToString());
        }
        Console.WriteLine(sum);
    }
}