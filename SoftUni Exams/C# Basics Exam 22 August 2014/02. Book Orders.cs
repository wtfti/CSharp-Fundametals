using System;

class BookOrders
{
    public static void Main()
    {
        int numOfOrders = int.Parse(Console.ReadLine());
        double[][] orders = new double[numOfOrders][];
        int totalBooks = 0;
        double cost = 0;
        for (int index = 0; index < numOfOrders; index++)
        {
            orders[index] = new double[3];
            orders[index][0] = int.Parse(Console.ReadLine()); // number of packets
            orders[index][1] = int.Parse(Console.ReadLine()); // books
            orders[index][2] = double.Parse(Console.ReadLine()); // book price
            CalcDiscount(orders[index][0], ref orders[index][2]);
            totalBooks += (int)(orders[index][0]*orders[index][1]);
            cost += (orders[index][0]*orders[index][1])*orders[index][2];
        }
        Console.WriteLine("{0}\r\n{1:0.00}",totalBooks,cost);
    }

    private static void CalcDiscount(double numberOfPackets, ref double price)
    {
        double discount = 0;
        if (numberOfPackets >= 10 && numberOfPackets <= 19)
        {
            discount = 0.05;
        }
        else if (numberOfPackets >= 20 && numberOfPackets <= 29)
        {
            discount = 0.06;
        }
        else if (numberOfPackets >= 30 && numberOfPackets <= 39)
        {
            discount = 0.07;
        }
        else if (numberOfPackets >= 40 && numberOfPackets <= 49)
        {
            discount = 0.08;
        }
        else if (numberOfPackets >= 50 && numberOfPackets <= 59)
        {
            discount = 0.09;
        }
        else if (numberOfPackets >= 60 && numberOfPackets <= 69)
        {
            discount = 0.10;
        }
        else if (numberOfPackets >= 70 && numberOfPackets <= 79)
        {
            discount = 0.11;
        }
        else if (numberOfPackets >= 80 && numberOfPackets <= 89)
        {
            discount = 0.12;
        }
        else if (numberOfPackets >= 90 && numberOfPackets <= 99)
        {
            discount = 0.13;
        }
        else if (numberOfPackets >= 100 && numberOfPackets <= 109)
        {
            discount = 0.14;
        }
        else if (numberOfPackets >= 109)
        {
            discount = 0.15;
        }
        price = price - (price*discount);
    }
}