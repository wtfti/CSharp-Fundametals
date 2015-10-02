using System;

namespace _01.Sum3Numbers
{
    class SumNumbers
    {
        static void Main()
        {
            double firstNumber, secondNumber, thirdNumber;
            firstNumber = double.Parse(Console.ReadLine());
            secondNumber = double.Parse(Console.ReadLine());
            thirdNumber = double.Parse(Console.ReadLine());
            double sum = firstNumber + secondNumber + thirdNumber;
            Console.WriteLine(sum);
        }
    }
}
