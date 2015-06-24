using System;
namespace _04.Number_Comparer
{
    class PrintGreaterNumber
    {
        static void Main()
        {
            while (true)
            {
                double firstNumber, secondNUmber;
                firstNumber = Double.Parse(Console.ReadLine());
                secondNUmber = double.Parse(Console.ReadLine());
                bool isGreater = firstNumber > secondNUmber;
                if (isGreater)
                {
                    Console.WriteLine(firstNumber);
                }
                else
                {
                    Console.WriteLine(secondNUmber);
                }
            }
        }
    }
}
