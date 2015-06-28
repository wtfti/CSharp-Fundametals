using System;
using System.Linq;

class Program
{
    public static void Main()
    {
        string numbers = Console.ReadLine();
        int[] bits = numbers.Split(' ').Select(int.Parse).ToArray();
        string[] commands = Console.ReadLine().Split(' ').ToArray();
        while (commands[0] != "end")
        {
            if (commands[0] == "check")
            {
                int countBits = 0;
                int col = int.Parse(commands[1]);

                foreach (var row in bits)
                {
                    countBits += (row >> col) & 1;
                }
                Console.WriteLine(countBits);
            }
            else if (commands[0] != "end")
            {
                int rowBit = bits[int.Parse(commands[0])];
                string direction = commands[1];
                int rotations = int.Parse(commands[2]);

                if (direction == "right")
                {
                    for (int rotation = 0; rotation < rotations; rotation++)
                    {
                        int firstBit = rowBit & 1;
                        rowBit >>= 1;
                        if (firstBit == 1)
                        {
                            rowBit |= (1 << 11);
                        }
                    }
                }
                else if(direction == "left")
                {
                    for (int rotation = 0; rotation < rotations; rotation++)
                    {
                        int lastBit = (rowBit >> 11) & 1;
                        rowBit <<= 1;
                        if (lastBit == 1 )
                        {
                            rowBit ^= (1 << 12);
                            rowBit |= 1;
                        }
                    }
                }
                bits[Convert.ToInt32(commands[0])] = rowBit;
            }
            commands = Console.ReadLine().Split();
        }
        foreach (var bit in bits)
        {
            Console.Write(bit + " ");
        }
    }
}