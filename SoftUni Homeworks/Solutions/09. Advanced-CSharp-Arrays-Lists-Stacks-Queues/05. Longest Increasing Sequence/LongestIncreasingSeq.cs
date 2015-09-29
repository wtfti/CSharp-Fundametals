using System;
using System.Collections.Generic;
using System.Linq;

class LongestIncreasingSeq
{
    static void Main()
    {
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
        List<int> currentSeq = new List<int>();
        List<int> longestSeq = new List<int>();


        for (int count = 0; count < numbers.Length; count++)
        {
            currentSeq.Add(numbers[count]);
            for (int currentNumber = count + 1; currentNumber < numbers.Length; currentNumber++)
            {
                if (numbers[count] < numbers[currentNumber])
                {
                    currentSeq.Add(numbers[currentNumber]);
                    count++;
                }
                else
                {
                    break;
                }
            }
            if (currentSeq.Count > longestSeq.Count)
            {
                longestSeq.Clear();
                currentSeq.ForEach(p => longestSeq.Add(p));
            }
            Console.WriteLine(string.Join(" ", currentSeq));
            currentSeq.Clear();
        }
        Console.WriteLine("longest: {0}", string.Join(" ", longestSeq));
    }
}
