using System;
using System.Linq;

class BitShooter
{
    public static void Main()
    {
        ulong bit = ulong.Parse(Console.ReadLine());
        string[] firstShoot = Console.ReadLine().Split().ToArray();
        string[] secondShoot = Console.ReadLine().Split().ToArray();
        string[] thirdShoot = Console.ReadLine().Split().ToArray();

        string bitString = Convert.ToString((long)bit, 2).PadLeft(64,'0');
        int firstCenter = (bitString.Length-1) - Convert.ToInt32(firstShoot[0]);
        int secondCenter = (bitString.Length - 1) - Convert.ToInt32(secondShoot[0]);
        int thirdCenter = (bitString.Length - 1) - Convert.ToInt32(thirdShoot[0]);
        int firstDamage = Convert.ToInt32(firstShoot[1])/2;
        int secondDamage = Convert.ToInt32(secondShoot[1])/2;
        int thirdDamage = Convert.ToInt32(thirdShoot[1])/2;
        string result = "";

        for (int i = 0; i < bitString.Length; i++)
        {
            bool x1 = i < thirdCenter - thirdDamage || i > thirdCenter + thirdDamage;
            bool x2 = i < firstCenter - firstDamage || i > firstCenter + firstDamage;
            bool x3 = i < secondCenter - secondDamage || i > secondCenter + secondDamage;
            if (x1 && x2 && x3)
            {
                result = result + bitString[i];
            }
            else
            {
                result = result + "0";
            }
        }
        int left = 0;
        int right = 0;
        for (int countAliveBits = 0; countAliveBits < result.Length; countAliveBits++)
        {
            if (countAliveBits < 32 && result[countAliveBits] == '1')
            {
                left++;
            }
            else if (countAliveBits >= 32 && result[countAliveBits] == '1')
            {
                right++;
            }
        }

        Console.WriteLine("left: {0}\r\nright: {1}",left,right);
    }
}
