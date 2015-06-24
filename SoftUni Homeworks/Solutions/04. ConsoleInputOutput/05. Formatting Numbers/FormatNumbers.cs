using System;

namespace _05.Formatting_Numbers
{
    class FormatNumbers
    {
        static void Main()
        {
            int firstNUmber = int.Parse(Console.ReadLine()); ;
            while (firstNUmber < 0 && firstNUmber > 500)
            {
                firstNUmber = int.Parse(Console.ReadLine());
            }
            float secondNUmber, thirdNumber;
            secondNUmber = float.Parse(Console.ReadLine());
            thirdNumber = float.Parse(Console.ReadLine());
            Console.WriteLine("|{0,-10:X}|{1}|{2,10:0.##}|{3,-10:0.000}|", firstNUmber, ToBin(firstNUmber,10), secondNUmber, thirdNumber);
        }

        public static string ToBin(int value, int len)
        {
            return (len > 1 ? ToBin(value >> 1, len - 1) : null) + "01"[value & 1];
        }
    }
}
