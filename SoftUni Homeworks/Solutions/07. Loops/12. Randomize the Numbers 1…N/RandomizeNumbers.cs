using System;
using System.Linq;

class RandomizeNumbers
{
    static void Main()
    {
        Console.Write("n: ");
        int n = int.Parse(Console.ReadLine());
        int[] numbers = new int[n];

        Random randomNumber = new Random();

        for (int i = 0; i < n; i++)
        {
            int currentRandomNumber = randomNumber.Next(1, n+1);
            while (numbers.Contains(currentRandomNumber))
            {
                currentRandomNumber = randomNumber.Next(1, n);
            }
            numbers[i] = currentRandomNumber;
        }
        foreach (var num in numbers)
        {
            Console.Write(num + " ");
        }
    }
}
