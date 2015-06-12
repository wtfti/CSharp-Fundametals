using System;

class Program
{
    static void Main()
    {
        long bit = long.Parse(Console.ReadLine()); ;
        Console.WriteLine(bit);
        int numberOfSieves = int.Parse(Console.ReadLine()); ;
        long[] sieves = new long[numberOfSieves+1];
        sieves[0] = bit;
        for (int i = 1; i < numberOfSieves; i++)
        {
            sieves[i] = long.Parse(Console.ReadLine());
        }
        long currentBit = 0;
        long currentSieve = 0;
        long mask = 0;
        long mask2 = 0;
        long result = 0;
        int count = 0;

        for (int i = 0; i < numberOfSieves; i++)
        {
            if (i == 0)
            {
                currentBit = sieves[i];
                currentSieve = sieves[i + 1];
            }
            else
            {
                currentBit = result;
                currentSieve = sieves[i + 1];
                result = 0;
            }
            for (int j = 0; j < 64; j++)
            {
                if (j == 0)
                {
                    mask = currentBit & 1;
                    mask2 = (currentSieve & 1);
                }
                else
                {
                    mask = (currentBit >> j) & 1;
                    mask2 = (currentSieve >> j) & 1;
                }
                if (mask == 1 && mask2 == 0)
                {
                    if (j == 0)
                    {
                        result |= 1;
                    }
                    else
                    {
                        result |= (1 << j);
                    }
                    if (i == numberOfSieves-1)
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(result);
        }
        Console.WriteLine(count);
    }
}