using System;
class CalcExpression
{
    static void Main()
    {
        Console.Write("n: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("x: ");
        int x = int.Parse(Console.ReadLine());
        double sum = 0;
        int counter = 0;
        int factorial = 1;

        for (int i = 0; i <= n; i++)
        {
            if (counter == 0)
            {
                sum++;
            }
            else
            {
                factorial *= counter;
                sum += factorial/Math.Pow(x, i);
            }
            counter++;
        }
        Console.WriteLine("{0:0.00000}",sum);
    }
}