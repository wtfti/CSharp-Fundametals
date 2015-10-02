using System;

internal class Program
{
    private static void Main()
    {
        string input = Console.ReadLine().ToLower().Replace(" ", string.Empty);
        int oddJump = Int32.Parse(Console.ReadLine());
        int evenJump = Int32.Parse(Console.ReadLine());
        long oddResult = 0;
        long evenResult = 0;
        int oddCounter = 0;
        int evenCounter = 0;

        for (int i = 0; i < input.Length; i++)
        {
            if (i % 2 == 0)
            {
                oddCounter++;
                if (oddCounter % oddJump == 0)
                {
                    oddResult *= input[i];
                }
                else
                {
                    oddResult += input[i];
                }
            }
        }

        string hex = oddResult.ToString("X");
        Console.WriteLine("Odd: {0}", hex);

        for (int i = 0; i < input.Length; i++)
        {
            if (i % 2 != 0)
            {
                evenCounter++;
                if (evenCounter % evenJump == 0)
                {
                    evenResult *= input[i];
                }
                else
                {
                    evenResult += input[i];
                }
            }
        }

        hex = evenResult.ToString("X");
        Console.WriteLine("Even: {0}", hex);
    }
}
