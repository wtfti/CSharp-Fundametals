using System;
class CalcExpression2
{
    static void Main()
    {
        Console.Write("n: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("K: ");
        int k = int.Parse(Console.ReadLine());

        if (n > 1 && n > k && k < 100)
        {
            int kCounter = 1;
            int nFactorial = 1;
            int kFactorial = 1;
            for (int factorial = 1; factorial <= n; factorial++)
            {
                nFactorial *= factorial;
                if (kCounter <= k)
                {
                    kFactorial *= factorial;
                }
                kCounter++;
            }
            Console.WriteLine(nFactorial/kFactorial);
        }
    }
}