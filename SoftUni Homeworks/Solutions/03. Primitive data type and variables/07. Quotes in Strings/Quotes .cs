using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Quotes_in_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string quote = "The \"use\" of quotations causes difficulties.";
            Console.WriteLine(quote);
            quote = (@"The ""use"" of quotations causes difficulties.");
            Console.WriteLine(quote);
        }
    }
}
