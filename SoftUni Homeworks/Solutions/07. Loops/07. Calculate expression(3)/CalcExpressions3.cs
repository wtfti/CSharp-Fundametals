using System;
using System.Numerics;

class CalcExpressions3
{
    static void Main()
    {
        Console.Write("n: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("K: ");
        int k = int.Parse(Console.ReadLine());
        BigInteger nFac = 1;
        BigInteger kFac = 1;
        BigInteger nkFac = 1;

        for (int nFactorial = 1; nFactorial <= n; nFactorial++)
        {
            nFac *= nFactorial;
            if ((n - k) >= nFactorial)
            {
                nkFac *= nFactorial;
            }
        }

        for (int kFactorial = 1; kFactorial <= k; kFactorial++)
        {
            kFac *= kFactorial;        
        }

        Console.WriteLine(nFac/(kFac*nkFac));
    }
}