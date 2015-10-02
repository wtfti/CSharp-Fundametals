using System;

namespace _10.Fibonacci
{
    class Fibonacci
    {
        public static int Fibo(int n)
        {
            int a = 0;
            int b = 1;
            // In N steps compute Fibonacci sequence iteratively.
            for (int i = 0; i < n; i++)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }
            return a;
        }

        static void Main(string[] args)
        {
            int endNumber = int.Parse(Console.ReadLine());
            if (endNumber == 0)
            {
                Console.Write("0");
            }
            for (int i = 0; i < endNumber; i++)
            {
                Console.Write(Fibo(i)+" ");
            }
        }
    }
}
