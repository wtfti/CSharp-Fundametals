using System;
using System.Text;

class BitsKiller
{
    static void Main()
    {
        int numberOfBits = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());
        int[] bits = new int[numberOfBits];
        for (int i = 0; i < bits.Length; i++)
        {
            bits[i] = int.Parse(Console.ReadLine());
        }
        bool killedFirstBit = false;
        int countAllBits = 0;
        StringBuilder resultOfBits = new StringBuilder();
        for (int bitsCount = 0; bitsCount < bits.Length; bitsCount++)
        {
            for (int eachBit = 7; eachBit >= 0; eachBit--)
            {
                if (!killedFirstBit)
                {
                    countAllBits = step-1;
                    killedFirstBit = true;
                }
                if (countAllBits == step)
                {
                    countAllBits = 0;
                }
                else
                {
                    int mask = (bits[bitsCount] >> eachBit) & 1;
                    resultOfBits.Append(mask);
                }
                countAllBits++;
                if (resultOfBits.Length == 8)
                {
                    Console.WriteLine(Convert.ToInt32(resultOfBits.ToString(), 2));
                    resultOfBits.Clear();
                }
            }
        }
        if (resultOfBits.Length > 0)
        {
            while (resultOfBits.Length < 8)
            {
                resultOfBits.Append(0);
            }
            Console.WriteLine(Convert.ToInt32(resultOfBits.ToString(), 2));
        }
    }
}