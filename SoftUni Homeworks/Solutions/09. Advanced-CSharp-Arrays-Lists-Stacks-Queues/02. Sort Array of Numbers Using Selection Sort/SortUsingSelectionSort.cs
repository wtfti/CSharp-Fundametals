using System;
using System.Linq;

class SortUsingSelectionSort
{
    static void Main()
    {
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        for (int count = 0, minNumber = int.MaxValue, indexNumber = 0; count < numbers.Length; count++,
            minNumber = int.MaxValue)
        {
            for (int currentNumber = count; currentNumber < numbers.Length; currentNumber++)
            {
                if (minNumber > numbers[currentNumber])
                {
                    minNumber = numbers[currentNumber];
                    indexNumber = currentNumber;
                }
            }
            numbers[indexNumber] = numbers[count];
            numbers[count] = minNumber;
        }

        Array.ForEach(numbers, n => Console.Write("{0} ", n));
    }
}