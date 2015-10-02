using System;
using System.Numerics;

class TrailingZeroes
{
    static void Main()
    {
        Console.Write("n: ");
        int factorial = int.Parse(Console.ReadLine());
        BigInteger factorialBigInteger = 1;
        for (int nFac = 1; nFac <= factorial; nFac++)
        {
            factorialBigInteger *= nFac;
        }
        int lastChar = factorialBigInteger.ToString().Length - 1;
        string result = factorialBigInteger.ToString();
        while (result[lastChar] == '0')
        {
            lastChar--;
        }
        Console.WriteLine("trailing zeroes of n!: {0}",result.Length - lastChar - 1);
    }
}
