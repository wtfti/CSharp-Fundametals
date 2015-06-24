using System;
class Program
{
    static void Main()
    {
        Console.Write("Prime number: ");
        int primeNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("Is Prime? {0}", CheckPrime(primeNumber));
    }

    public static bool CheckPrime(int number)
    {
        if (number <=2) return false;

        for (int i = 2; i <= Math.Floor(Math.Sqrt(number)); ++i)
        {
            if (number % i == 0) return false;
        }

        return true;   
    }
}
