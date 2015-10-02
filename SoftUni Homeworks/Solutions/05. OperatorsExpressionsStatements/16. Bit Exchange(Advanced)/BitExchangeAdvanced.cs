using System;
using System.Collections;

class BitExchange
{
    public static bool[] thirdToFifthPos = new bool[3];
    public static bool[] twentyFourthTotwentySixth = new bool[3];
    public static BitArray bits;
    static void Main()
    {
        Console.Write("number: ");
        uint number = uint.Parse(Console.ReadLine());
        Console.Write("p:");
        int p = int.Parse(Console.ReadLine());
        Console.Write("q:");
        int q = int.Parse(Console.ReadLine());
        Console.Write("n-Positions:");
        int nPositions = int.Parse(Console.ReadLine());
        //End user input
        string numberToBit = Convert.ToString(number, 2).PadLeft(32, '0');
        if (p > numberToBit.Length || p < numberToBit.Length || q > numberToBit.Length || q < numberToBit.Length || nPositions <= 0)
        {
            Console.WriteLine("out of range");
        }
        else if (p+nPositions > numberToBit.Length || q+nPositions > numberToBit.Length)
        {
            Console.WriteLine("Overlapping");
        }
        else //catch invalid input
        {
            bits = new BitArray(numberToBit.Length);
            FillBitArray(bits, numberToBit);
            GetSetBitBoolValue(p, p + nPositions, twentyFourthTotwentySixth, "Get");
            GetSetBitBoolValue(q, q + nPositions, thirdToFifthPos, "Get");
            GetSetBitBoolValue(q, q + nPositions, thirdToFifthPos, "Set");
            GetSetBitBoolValue(p, p + nPositions, twentyFourthTotwentySixth, "Set");
            Console.WriteLine("result: {0}", binaryToNumber(DisplayBitArray(bits)));
        }
    }

    private static void FillBitArray(BitArray userBitArray, string numberInBits)
    {
        for (int i = 0; i < numberInBits.Length; i++)
        {
            if (numberInBits[i] == '0')
            {
                userBitArray.Set(i, false);
            }
            else
            {
                userBitArray.Set(i, true);
            }
        }
    }

    private static void GetSetBitBoolValue(int a, int b, bool[] filledBool, string command)
    {
        if (command == "Get")
        {
            int count = 0;
            for (int i = a; i <= b; i++)
            {
                filledBool[count] = bits.Get(i);
                count++;
            }
        }
        else if (command == "Set")
        {
            int count = 0;
            for (int i = a; i <= b; i++)
            {
                bits.Set(i, filledBool[count]);
                count++;
            }
        }
    }

    public static string DisplayBitArray(BitArray bitArray)
    {
        string value = "";
        for (int i = 0; i < bitArray.Count; i++)
        {
            bool bit = bitArray.Get(i);
            value += Convert.ToString(bit ? 1 : 0);
        }
        return value;
    }

    public static uint binaryToNumber(string bit)
    {

        var s = bit;    // my binary "number" as a string
        uint dec = 0;
        for (int i = 0; i < s.Length; i++)
        {
            // we start with the least significant digit, and work our way to the left
            if (s[s.Length - i - 1] == '0') continue;
            dec += (uint)Math.Pow(2, i);
        }
        return (uint)dec;
    }
}
