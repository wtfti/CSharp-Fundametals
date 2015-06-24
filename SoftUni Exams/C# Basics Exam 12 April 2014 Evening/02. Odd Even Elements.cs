using System;
using System.Collections.Generic;
using System.Linq;

class OddEvenElements
{
    public static void Main()
    {
        string[] input = Console.ReadLine().Split().ToArray();
        double[] numbers = new double[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            numbers[i] = Convert.ToDouble(input[i]);
        }
        List<double> evenNumbers = new List<double>();
        List<double> oddNumbers = new List<double>();

        for (int i = 0; i < numbers.Length; i++)
        {
            if (i % 2 != 0) //odd
            {
                evenNumbers.Add(numbers[i]);
            }
            else //even
            {
                oddNumbers.Add(numbers[i]);
            }
        }
        if (oddNumbers.Count == 0)
        {
            Console.WriteLine("OddSum=No, OddMin=No, OddMax=No, EvenSum={0:0.##}, EvenMin={1:0.##}, EvenMax={2:0.##}", evenNumbers.Sum(), evenNumbers.Min(), evenNumbers.Max());
        }
        else if (evenNumbers.Count == 0)
        {
            Console.WriteLine("OddSum={0:0.##}, OddMin={1:0.##}, OddMax={2:0.##}, EvenSum=No, EvenMin=No, EvenMax=No", oddNumbers.Sum(), oddNumbers.Min(), oddNumbers.Max());
        }
        else
        {
            Console.WriteLine("OddSum={0:0.##}, OddMin={1:0.##}, OddMax={2:0.##}, EvenSum={3:0.##}, EvenMin={4:0.##}, EvenMax={5:0.##}", oddNumbers.Sum(), oddNumbers.Min(), oddNumbers.Max(), evenNumbers.Sum(), evenNumbers.Min(), evenNumbers.Max());
        }
    }
}
