using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Exchange_Variable_Values
{
    class ExchangeValues
    {
        static void Main(string[] args)
        {
            int firstNumber = 5;
            int secondNumber = 10;
            Console.WriteLine(firstNumber);
            Console.WriteLine(secondNumber);
            Console.WriteLine("Changing");
            firstNumber = firstNumber + secondNumber;
            Console.WriteLine('.');
            secondNumber = firstNumber - secondNumber;
            Console.WriteLine('.');
            firstNumber -= secondNumber;
            Console.WriteLine('.');
            Console.WriteLine(firstNumber);
            Console.WriteLine(secondNumber);
        }
    }
}
