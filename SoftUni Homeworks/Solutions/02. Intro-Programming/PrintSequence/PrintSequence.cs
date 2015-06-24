using System;

namespace PrintSequence
{
    class PrintSequence
    {
        static void Main()
        {
            int x = -3;
            int y = 2;

            for (int i = 0; i < 5; i++)
            {
                Console.Write("{0}, {1}, ",y,x);
                x -= 2;
                y += 2;
            }
        }
    }
}
