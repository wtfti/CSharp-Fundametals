using System;
using System.Linq;

class FirstLargerrNeighbours
{
    static void Main()
    {
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(FIrstLargerNeighbours(numbers));
    }
    private static int FIrstLargerNeighbours(int[] numbers)
    {
        int previousNumber;
        int nextNumber;

        for (int currentPosition = 0; currentPosition < numbers.Length; currentPosition++)
        {
            if (currentPosition == 0)
            {
                nextNumber = numbers[1];
                if (GetMax(numbers[currentPosition], nextNumber))
                {
                    return currentPosition;
                }
            }
            else if (currentPosition == numbers.Length - 1)
            {
                previousNumber = numbers[currentPosition - 1];
                if (GetMax(numbers[currentPosition], previousNumber))
                {
                    return currentPosition;
                }
            }
            else
            {
                previousNumber = numbers[currentPosition - 1];
                nextNumber = numbers[currentPosition + 1];
                if (GetMax(numbers[currentPosition], nextNumber, previousNumber))
                {
                    return currentPosition;
                }
            }
        }
        return -1;
    }
    static bool GetMax(int currentNumber, int secondNumber)
    {
        if (currentNumber > secondNumber)
        {
            return true;
        }
        return false;
    }

    static bool GetMax(int currentNumber, int nextNumber, int previousNumber)
    {
        if (currentNumber > nextNumber && currentNumber > previousNumber)
        {
            return true;
        }
        return false;
    }
}
