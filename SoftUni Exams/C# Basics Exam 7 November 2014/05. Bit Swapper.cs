using System;
using System.Linq;

class BitSwapper
{
    public static void Main()
    {
        uint[] bits = new uint[4];
        bits[0] = uint.Parse(Console.ReadLine());
        bits[1] = uint.Parse(Console.ReadLine());
        bits[2] = uint.Parse(Console.ReadLine());
        bits[3] = uint.Parse(Console.ReadLine());
        string[] command = Console.ReadLine().Split().ToArray();
        bool oneOne;
        bool zeroZero;

        while (command[0] != "End")
        {
            int startRow = int.Parse(command[0]);
            int firstBitCol = int.Parse(command[1]) * 4;
            command = Console.ReadLine().Split().ToArray();
            int endRow = int.Parse(command[0]);
            int secondBitCol = int.Parse(command[1]) * 4;
            uint firstBitMask = 1;
            uint secondBitMask = 1;

            for (int repeat = 0; repeat < 4; repeat++)
            {
                firstBitMask = 1 & (bits[startRow] >> firstBitCol);
                secondBitMask = 1 & (bits[endRow] >> secondBitCol);
                oneOne = firstBitMask == 1 && secondBitMask == 1;
                zeroZero = firstBitMask == 0 && secondBitMask == 0;
                if (oneOne || zeroZero)
                {
                    firstBitCol++;
                    secondBitCol++;
                    continue;
                }
                bits[startRow] ^= ((uint)1 << firstBitCol);
                bits[endRow] ^= ((uint)1 << secondBitCol);
                firstBitCol++;
                secondBitCol++;
            }
            command = Console.ReadLine().Split().ToArray();
        }
        foreach (var eachBit in bits)
        {
            Console.WriteLine(eachBit);
        }
    }
}