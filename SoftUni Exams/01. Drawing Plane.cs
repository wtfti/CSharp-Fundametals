                ..........*..........
                .........*.*.........
                ........*...*........
                .......*.....*.......
                ......*.......*......
                .....*.........*.....
                ...*.............*...
                .*.................*.
                *.....*.......*.....*
                *...*.*.......*.*...*
                *.*...*.......*...*.*
                ......*.......*......
                .....*.........*.....
                ....*...........*....
                ...*.............*...
                ..*...............*..
                .*.................*.
                *********************
                
                
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Plane
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int totalWidth = number * 3;
            int beforeDots = totalWidth / 2 - 1;
            int midDots = 1;

            Console.Write(new string('.', beforeDots + 1));
            Console.Write(new string('*', 1));
            Console.WriteLine(new string('.', beforeDots + 1));

            for (int i = 0; i < number; i++)
            {
                Console.Write(new string('.', beforeDots));
                Console.Write(new string('*', 1));
                Console.Write(new string('.', midDots));
                Console.Write(new string('*', 1));
                Console.WriteLine(new string('.', beforeDots));
                beforeDots--;
                midDots += 2;
                if (beforeDots < number - 2)
                {
                    beforeDots--;
                    midDots += 2;
                }
            }

            beforeDots = number - 2;
            midDots = 1;

            Console.Write(new string('*', 1));
            Console.Write(new string('.', beforeDots));
            Console.Write(new string('*', 1));
            Console.Write(new string('.', number));
            Console.Write(new string('*', 1));
            Console.Write(new string('.', beforeDots));
            Console.WriteLine(new string('*', 1));

            for (int i = 0; i < number / 2 - 1; i++)
            {
                beforeDots -= 2;
                Console.Write(new string('*', 1));
                Console.Write(new string('.', beforeDots));
                Console.Write(new string('*', 1));
                Console.Write(new string('.', midDots));
                Console.Write(new string('*', 1));
                Console.Write(new string('.', number));
                Console.Write(new string('*', 1));
                Console.Write(new string('.', midDots));
                Console.Write(new string('*', 1));
                Console.Write(new string('.', beforeDots));
                Console.WriteLine(new string('*', 1));
                midDots += 2;
            }

            beforeDots = number - 1;
            midDots = number;
            for (int i = 0; i < number - 1; i++)
            {
                Console.Write(new string('.', beforeDots));
                Console.Write(new string('*', 1));
                Console.Write(new string('.', midDots));
                Console.Write(new string('*', 1));
                Console.WriteLine(new string('.', beforeDots));
                beforeDots--;
                midDots += 2;
            }

            Console.WriteLine(new string('*', totalWidth));
        }
    }
}
