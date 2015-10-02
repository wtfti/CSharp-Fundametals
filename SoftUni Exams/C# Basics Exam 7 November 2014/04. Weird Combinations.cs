using System;
using System.Linq;

class WeirdCombinations
{
    public static void Main()
    {
        char[] input = Console.ReadLine().ToCharArray();
        char[] result = new char[5];
        foreach (var sym in result)
        {
            result[sym] = input[0];
        }
        int nElement = int.Parse(Console.ReadLine());
        int maxCombination = 3125;
        int counter = 0;
        bool foundResult = false;

        for (int symbol1 = 0; symbol1 < input.Length; symbol1++)
        {
            for (int symbol2 = 0; symbol2 < input.Length; symbol2++)
            {
                for (int symbol3 = 0; symbol3 < input.Length; symbol3++)
                {
                    for (int symbol4 = 0; symbol4 < input.Length; symbol4++)
                    {
                        for (int symbol5 = 0; symbol5 < input.Length; symbol5++)
                        {
                            counter++;
                            result[0] = input[symbol1];
                            result[1] = input[symbol2];
                            result[2] = input[symbol3];
                            result[3] = input[symbol4];
                            result[4] = input[symbol5];
                            if (counter - 1 == nElement)
                            {
                                Console.WriteLine("{0}{1}{2}{3}{4}", result[0], result[1], result[2], result[3], result[4]);
                                foundResult = true;
                                return;
                            }
                        }
                    }
                }
            }
        }
        if (!foundResult)
        {
            Console.WriteLine("No");
        }
    }
}