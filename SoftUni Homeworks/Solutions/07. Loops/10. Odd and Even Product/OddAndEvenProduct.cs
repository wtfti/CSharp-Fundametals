using System;
using System.Linq;

class OddAndEvenProduct
{
    static void Main()
    {
        Console.Write("input: ");
        string[] input = Console.ReadLine().Split().ToArray();
        int odd = 1;
        int even = 1;

        for (int i = 0; i < input.Length; i++)
        {
            if (i % 2 == 0)
            {
                odd *= Convert.ToInt32(input[i]);
            }
            else
            {
                even *= Convert.ToInt32(input[i]);
            }
        }

        if (odd == even)
        {
            Console.WriteLine("Yes\r\nproduct={0}", even);
        }
        else
        {
            Console.WriteLine("No\r\nodd product = {0}\r\neven product = {1}", odd,even);
        }
        
    }
}
