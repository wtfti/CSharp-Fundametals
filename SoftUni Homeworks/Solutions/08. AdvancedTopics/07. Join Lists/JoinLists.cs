using System;
using System.Collections.Generic;
using System.Linq;

class JoinLists
{
    static void Main()
    {
        int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
        List<int> firstList = new List<int>();
        foreach (var num in input)
        {
            firstList.Add(num);
        }
        input = Console.ReadLine().Split().Select(int.Parse).ToArray();
        List<int> secondList = new List<int>();
        foreach (var num in input)
        {
            secondList.Add(num);
        }

        List<int> result = firstList.ToList();
        result.AddRange(secondList);
        result = result.Distinct().ToList();
        result.Sort();
        foreach (var numList in result)
        {
            Console.Write(numList + " ");
        }
    }
}