using System;

namespace _09.Sum_of_n_Numbers
{
    class SumNNumbers
    {
        static void Main()
        {
            int numbers = int.Parse(Console.ReadLine());
            double[] massiveNumbers = new double[numbers];
            for (int i = 0; i < numbers; i++)
            {
                massiveNumbers[i] = double.Parse(Console.ReadLine());
            }
            double result = 0;
            foreach (var item in massiveNumbers)
            {
                result += item;
            }
            Console.Write("Sum: ");
            Console.WriteLine(result);
        }
    }
}
