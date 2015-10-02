using System;
using System.Linq;

class FiveSpecialLetters
{
    public static void Main()
    {
        int startNumber = int.Parse(Console.ReadLine());
        int endNumber = int.Parse(Console.ReadLine());
        char[] keys = new[] {'a', 'b', 'c', 'd', 'e'};
        bool foundResult = false;

        for (int a1 = 0; a1 < keys.Length; a1++)
        {
            for (int a2 = 0; a2 < keys.Length; a2++)
            {
                for (int a3 = 0; a3 < keys.Length; a3++)
                {
                    for (int a4 = 0; a4 < keys.Length; a4++)
                    {
                        for (int a5 = 0; a5 < keys.Length; a5++)
                        {
                                int[] currentChars = { a1, a2, a3, a4, a5 };
                                int currentWeight = CalcWeight(currentChars);
                                if (currentWeight >= startNumber && currentWeight <= endNumber)
                                {
                                    Console.Write(keys[a1].ToString() + keys[a2] + keys[a3] + keys[a4] + keys[a5] + " ");
                                    foundResult = true;
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

    private static int CalcWeight(int[] keys)
    {
        keys = keys.Distinct().ToArray();
        int sum = 0;
        int multiplier = 1;
        for (int i = 0; i < keys.Length; i++)
        {
            switch (keys[i])
            {
                case 0:
                    sum += (multiplier * 5);
                    break;
                case 1:
                    sum -= (multiplier * 12);
                    break;
                case 2:
                    sum += (multiplier * 47);
                    break;
                case 3:
                    sum += (multiplier * 7);
                    break;
                case 4:
                    sum -= (multiplier * 32);
                    break;
            }
            multiplier++;
        }
        return sum;
    }
}
