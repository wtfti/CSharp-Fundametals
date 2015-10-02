using System;

namespace Numbers_from_1_to_n
{
    class From1ToN
    {
        static void Main(string[] args)
        {
            int startNumber = int.Parse(Console.ReadLine());
            for (int i = 1; i <= startNumber; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
