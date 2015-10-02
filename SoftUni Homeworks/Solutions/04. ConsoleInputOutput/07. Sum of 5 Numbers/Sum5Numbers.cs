using System;
using System.Linq;

namespace _07.Sum_of_5_Numbers
{
    class Sum5Numbers
    {
        static void Main()
        {
            string[] numbers = Console.ReadLine().Split().ToArray();
            double result = 0;

            foreach (var number in numbers)
            {
                result += Convert.ToDouble(number);
            }
            Console.WriteLine(result);
        }
    }
}
