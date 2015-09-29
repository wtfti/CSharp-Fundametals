using System;
using System.Collections.Generic;
using System.Linq;

class MinMaxAvgNums
{
    static void Main()
    {
        double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();
        List<int> roundNumbers = new List<int>();
        List<double> floatNumbers = new List<double>();

        foreach (var number in numbers)
        {
            if (number % 1 != 0)
            {
                floatNumbers.Add(number);
            }
            else
            {
                roundNumbers.Add((int)number);
            }
        }

        Console.WriteLine("[{0}] -> min: {1}, max: {2}, sum: {3}, avg: {4:f2}\r\n[{5}] -> min: {6}, max: {7}, sum: {8}, avg: {9:f2}",
            string.Join(", ", floatNumbers), floatNumbers.Min(), floatNumbers.Max(), floatNumbers.Sum(), floatNumbers.Average(),
            string.Join(", ", roundNumbers), roundNumbers.Min(), roundNumbers.Max(), roundNumbers.Sum(), roundNumbers.Average());
    }
}
