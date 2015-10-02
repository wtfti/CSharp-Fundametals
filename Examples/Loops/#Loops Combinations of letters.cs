using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Weird_Combinations
{
    class Combinations
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToArray();
            int sequenceNumber = int.Parse(Console.ReadLine());
            string currentSequence = "";
            int counter = 0;
            bool hasResult = false;

            foreach (char c in input)
            {
                foreach (char c1 in input)
                {
                    foreach (char c2 in input)
                    {
                        foreach (char c3 in input)
                        {
                            foreach (char c4 in input)
                            {
                                if (counter == sequenceNumber)
                                {
                                    string result =
                                        c + "" +
                                        c1 + "" +
                                        c2 + "" +
                                        c3 + "" +
                                        c4;
                                    Console.WriteLine(result);
                                    hasResult = true;
                                }

                                counter++;
                            }
                        }
                    }
                }
            }
        }
    }
}
