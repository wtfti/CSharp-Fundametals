using System;
using System.Linq;

class SortArrayNums
{
    static void Main()
    {
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Array.Sort(numbers);
        Array.ForEach(numbers, n => Console.Write("{0} ", n));
    }
}