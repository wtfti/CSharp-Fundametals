using System;

class StudentCables
{
    public static void Main()
    {
        int numberOfCables = int.Parse(Console.ReadLine());
        int[] cableLenghts = new int[numberOfCables];
        string[] typeOfCables = new string[numberOfCables];

        for (int i = 0; i < numberOfCables; i++)
        {
            cableLenghts[i] = int.Parse(Console.ReadLine());
            typeOfCables[i] = Console.ReadLine();
            if (typeOfCables[i] == "meters")
            {
                cableLenghts[i] *= 100;
            }
        }
        int workingCable = numberOfCables;
        int cables = 0;
        int joints = 0;
        for (int i = 0; i < cableLenghts.Length; i++)
        {
            if (cableLenghts[i] < 20)
            {
                workingCable--;
            }
            else
            {
                joints++;
                cables += cableLenghts[i];
            }
        }
        cables -= 3*(joints - 1);
        int studentCables = cables/504;
        int remainder = cables%504;
        Console.WriteLine("{0}\r\n{1}",studentCables,remainder);
    }
}
