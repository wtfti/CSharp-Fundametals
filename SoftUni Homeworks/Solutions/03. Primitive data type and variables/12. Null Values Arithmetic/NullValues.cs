using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Null_Values_Arithmetic
{
    class NullValues
    {
        static void Main(string[] args)
        {
            int? number = null;
            double? doubleNumber = null;
            Console.WriteLine(number);
            Console.WriteLine(doubleNumber);
            Console.WriteLine("value or default");
            Console.WriteLine(number.GetValueOrDefault());
            Console.WriteLine(doubleNumber.GetValueOrDefault());
            Console.WriteLine("initializing");
            number = 5;
            doubleNumber = 1.337;
            Console.WriteLine(number);
            Console.WriteLine(doubleNumber);
        }
    }
}
