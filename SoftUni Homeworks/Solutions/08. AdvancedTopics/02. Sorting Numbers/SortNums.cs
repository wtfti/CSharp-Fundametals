using System;
class SortNums
{
    static void Main()
    {
        Console.Write("input: ");
        int numberOfArray = int.Parse(Console.ReadLine());
        int[] numbers = new int[numberOfArray];
        for (int index = 0; index < numberOfArray; index++)
        {
            numbers[index] = int.Parse(Console.ReadLine());
        }
        Array.Sort(numbers);
        Console.WriteLine("output: ");
        foreach (var num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}