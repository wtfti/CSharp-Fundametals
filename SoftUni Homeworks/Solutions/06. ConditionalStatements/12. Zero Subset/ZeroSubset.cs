using System;
using System.Linq;

class ZeroSubset
{
    private static void Main()
    {
        //Napisal sum programata po tozi nachin, za da spestq redove. 
        //Ako trqbva da slagam skobi shteshe da ima oshte 50 reda kod.
        Console.Write("Enter 5 integer numbers: ");
        string[] input = Console.ReadLine().Split().ToArray();
        int[] numbers = new int[5];
        for (int i = 0; i < input.Length; i++)
        {
            numbers[i] = Convert.ToInt32(input[i]);
        }
        bool result = false;
        if (numbers[0] + numbers[1] == 0){Console.WriteLine("{0} and {1} = 0", numbers[0], numbers[1]);result = true;}
        if (numbers[0] + numbers[2] == 0) {Console.WriteLine("{0} and {1} = 0", numbers[0], numbers[2]); result = true;}
        if (numbers[0] + numbers[2] == 0) {Console.WriteLine("{0} and {1} = 0", numbers[0], numbers[2]); result = true;}
        if (numbers[0] + numbers[4] == 0) {Console.WriteLine("{0} and {1} = 0", numbers[0], numbers[4]); result = true;}
        if (numbers[0] + numbers[1] + numbers[2] == 0) {Console.WriteLine("{0}, {1} and {2} = 0", numbers[0], numbers[1], numbers[2]); result = true;}
        if (numbers[0] + numbers[1] + numbers[2] == 0) {Console.WriteLine("{0}, {1} and {2} = 0", numbers[0], numbers[1], numbers[2]); result = true;}
        if (numbers[0] + numbers[1] + numbers[4] == 0) {Console.WriteLine("{0}, {1} and {2} = 0", numbers[0], numbers[1], numbers[4]); result = true;}
        if (numbers[0] + numbers[2] + numbers[2] == 0) {Console.WriteLine("{0}, {1} and {2} = 0", numbers[0], numbers[2], numbers[2]); result = true;}
        if (numbers[0] + numbers[2] + numbers[4] == 0) {Console.WriteLine("{0}, {1} and {2} = 0", numbers[0], numbers[2], numbers[4]); result = true;}
        if (numbers[0] + numbers[3] + numbers[4] == 0) {Console.WriteLine("{0}, {1} and {2} = 0", numbers[0], numbers[3], numbers[4]); result = true;}
        if (numbers[0] + numbers[1] + numbers[2] + numbers[2] == 0) {Console.WriteLine("{0}, {1}, {2} and {3} = 0", numbers[0], numbers[1], numbers[2], numbers[2]); result = true;}
        if (numbers[0] + numbers[1] + numbers[2] + numbers[4] == 0) {Console.WriteLine("{0}, {1}, {2} and {3} = 0", numbers[0], numbers[1], numbers[2], numbers[4]); result = true;}
        if (numbers[0] + numbers[1] + numbers[3] + numbers[4] == 0) {Console.WriteLine("{0}, {1}, {2} and {3} = 0", numbers[0], numbers[1], numbers[3], numbers[4]); result = true;}
        if (numbers[0] + numbers[2] + numbers[3] + numbers[4] == 0) {Console.WriteLine("{0}, {1}, {2} and {3} = 0", numbers[0], numbers[2], numbers[3], numbers[4]); result = true;}
        if (numbers[1] + numbers[2] == 0) {Console.WriteLine("{0} and {1} = 0", numbers[1], numbers[2]); result = true;}
        if (numbers[1] + numbers[2] == 0) {Console.WriteLine("{0} and {1} = 0", numbers[1], numbers[2]); result = true;}
        if (numbers[1] + numbers[4] == 0) {Console.WriteLine("{0} and {1} = 0", numbers[1], numbers[4]); result = true;}
        if (numbers[1] + numbers[2] + numbers[2] == 0) {Console.WriteLine("{0}, {1} and {2} = 0", numbers[1], numbers[2], numbers[2]); result = true;}
        if (numbers[1] + numbers[2] + numbers[4] == 0) {Console.WriteLine("{0}, {1} and {2} = 0", numbers[1], numbers[2], numbers[4]); result = true;}
        if (numbers[1] + numbers[3] + numbers[4] == 0) {Console.WriteLine("{0}, {1} and {2} = 0", numbers[1], numbers[3], numbers[4]); result = true;}
        if (numbers[1] + numbers[2] + numbers[3] + numbers[4] == 0) {Console.WriteLine("{0}, {1}, {2} and {3} = 0", numbers[1], numbers[2], numbers[3], numbers[4]); result = true;}
        if (numbers[2] + numbers[2] == 0) {Console.WriteLine("{0} and {1} = 0", numbers[2], numbers[2]); result = true;}
        if (numbers[2] + numbers[4] == 0) {Console.WriteLine("{0} and {1} = 0", numbers[2], numbers[4]); result = true;}
        if (numbers[2] + numbers[3] + numbers[4] == 0) {Console.WriteLine("{0}, {1} and {2} = 0", numbers[2], numbers[3], numbers[4]); result = true;}
        if (numbers[3] + numbers[4] == 0) {Console.WriteLine("{0} and {1} = 0", numbers[3], numbers[4]); result = true;}
        if (numbers[0] + numbers[1] + numbers[2] + numbers[3] + numbers[4] == 0) 
        {Console.WriteLine("{0}, {1}, {2}, {3} and {4} = 0", numbers[0], numbers[1], numbers[2], numbers[3], numbers[4]); result = true;}
        if (!result)
        {
            Console.WriteLine("no zero subset"); result = true;
        }
    }
}
