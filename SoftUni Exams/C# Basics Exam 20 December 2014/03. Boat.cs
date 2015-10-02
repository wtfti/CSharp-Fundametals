using System;

namespace Task4.Popeye
{
    public class Popeye
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            //draw sail
            int sailCurrentW = 1;
            bool middlePointReached = false;

            for (int i = 0; i < n; i++)
            {
                Console.Write(new string('.', n - sailCurrentW));
                Console.Write(new string('*', sailCurrentW));
                Console.WriteLine(new string('.', n));
                
                if (sailCurrentW >= n)
                {
                    middlePointReached = true;
                }

                if (middlePointReached)
                {
                    sailCurrentW -= 2;
                }
                else
                {
                    sailCurrentW += 2;
                }
            }

            //draw boat
            int boatHeight = n / 2;
            int boatWidth = n + n;
            int dots = 0;
            for (int i = 0; i < boatHeight; i++)
            {
                Console.Write(new string('.', dots));
                Console.Write(new string('*', boatWidth));
                Console.WriteLine(new string('.', dots));

                boatWidth -= 2;
                dots++;
            }
        }
    }
}
