using System;

class ChangeEvenBits
{
    public static void Main()
    {
        int countNumbers = int.Parse(Console.ReadLine());
        int[] numbers = new int[countNumbers];
        int countChanges = 0;
        for (int bit = 0; bit < countNumbers; bit++)
        {
            numbers[bit] = int.Parse(Console.ReadLine());
        }
        ulong processNumber = ulong.Parse(Console.ReadLine());

        foreach (var num in numbers)
        {
            string lenghtBit = Convert.ToString(num, 2); // X even positions
            for (int eachBit = 0; eachBit < lenghtBit.Length*2; eachBit++) 
            {
                ulong mask = (processNumber >> eachBit) & 1;
                if (eachBit % 2 == 0 && mask == 0)
                {
                    countChanges++;
                    processNumber |= ((ulong) 1 << eachBit);
                }
            }
        }
        Console.WriteLine("{0}\r\n{1}",processNumber,countChanges);
    }
}