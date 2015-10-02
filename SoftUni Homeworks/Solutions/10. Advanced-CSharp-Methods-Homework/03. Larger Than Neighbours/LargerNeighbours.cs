using System;
using System.Linq;

class LargerNeighbours
{
    static void Main()
    {
        Console.Write("Numbers: ");
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.Write("Position: ");
        int position = int.Parse(Console.ReadLine());
        Console.WriteLine(IsLargerNeighbours(numbers, position));
    }

    private static string IsLargerNeighbours(int[] numbers, int position)
    {
        int currentNumber = numbers[position];
        int previousNumber;
        int nextNumber;

        if (numbers.Length > 1)
        {
            if (position == 0)
            {
                nextNumber = numbers[1];
                return GetMax(currentNumber, nextNumber).ToString();
            }
            else if (position == numbers.Length - 1)
            {
                previousNumber = numbers[position - 1];
                return GetMax(currentNumber, previousNumber).ToString();
            }
            else
            {
                previousNumber = numbers[position - 1];
                nextNumber = numbers[position + 1];
                return GetMax(numbers[position], nextNumber, previousNumber).ToString();
            }
        }
        return new ArgumentException ("Write more than 1 number").ToString();
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