using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Strings_and_Objects
{
    class StringObject
    {
        static void Main(string[] args)
        {
            string firstWord = "Hello";
            string secondWord = "World";
            object stringConcat = firstWord + " " + secondWord;
            string result = (string)stringConcat;
            Console.WriteLine(result);
        }
    }
}
