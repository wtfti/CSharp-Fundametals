﻿using System;

internal class RockLq
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("{0}{1}{0}", new string('.', n), new string('*', n));

        int dotsBefore = n;
        int dotsMiddle = n + 2;
        for (int i = 0; i < n / 2; i++)
        {
            dotsBefore -= 2;
            Console.WriteLine("{0}*{1}*{0}", new string('.', dotsBefore), new string('.', dotsMiddle));
            dotsMiddle += 4;
        }

        dotsBefore = n - 2;
        dotsMiddle = n;
        int dotsBetween = 1;
        Console.WriteLine("*{0}*{1}*{0}*", new string('.', dotsBefore), new string('.', dotsMiddle));
        for (int i = 0; i < (n / 2) - 1; i++)
        {
            dotsBefore -= 2;
            Console.WriteLine("*{0}*{2}*{1}*{2}*{0}*",
                new string('.', dotsBefore), new string('.', dotsMiddle), new string('.', dotsBetween));
            dotsBetween += 2;
        }

        dotsBefore = n - 2;
        dotsBefore++;
        for (int i = 0; i < n - 1; i++)
        {
            Console.WriteLine("{0}*{1}*{0}", new string('.', dotsBefore), new string('.', dotsMiddle));
            dotsBefore--;
            dotsMiddle += 2;
        }

        Console.WriteLine(new string('*', n * 3));
    }
}