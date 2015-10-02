using System;

class BitBuilder
{
    public static void Main()
    {
        long bit = long.Parse(Console.ReadLine());
        string position = Console.ReadLine();

        while (position != "quit")
        {
            if (position != "skip")
            {
                int pos = int.Parse(position);
                string command = Console.ReadLine();
                string mask;
                switch (command)
                {
                    case "flip":
                        bit ^= (1 << pos);
                        break;
                    case "remove":
                        mask = Convert.ToString((bit), 2);
                        if (pos <= mask.Length-1)
                        {
                            if (pos == 0)
                            {
                                bit = (bit >> 1);
                            }
                            else if (pos == mask.Length - 1)
                            {
                                bit ^= ((long)1 << pos);
                            }
                            else
                            {
                                string result = "";
                                pos = (mask.Length - 1) - pos;
                                for (int index = 0; index < mask.Length; index++)
                                {
                                    if (index != pos)
                                    {
                                        result = result + mask[index];
                                    }
                                }
                                bit = Convert.ToInt64(result, 2);
                            }
                        }
                        break;
                    case "insert":
                        mask = Convert.ToString((bit), 2);
                        if (mask.Length-1 < pos)
                        {
                            bit ^= ((long) 1 << pos);
                        }
                        else if (mask.Length-1 >= pos)
                        {
                            if (pos == 0)
                            {
                                bit = (bit << 1);
                                bit ^= 1;
                            }
                            else
                            {
                                string result = "";
                                pos = (mask.Length - 1) - pos;
                                for (int index = 0; index < mask.Length; index++)
                                {
                                    if (index != pos)
                                    {
                                        result = result + mask[index];
                                    }
                                    else
                                    {
                                        result = result + mask[index] + "1";
                                    }
                                }
                                bit = Convert.ToInt64(result, 2);
                            }
                        }
                        break;
                }
            }
            position = Console.ReadLine();
        }
        Console.WriteLine(bit);
    }
}