using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Employee_Data
{
    class Data
    {
        static void Main(string[] args)
        {
            Console.Write("First Name:");
            string firstName = Console.ReadLine();
            Console.Write("Second Name:");
            string secondName = Console.ReadLine();
            Console.Write("Age:");
            byte age = byte.Parse(Console.ReadLine());
            while (age > 100)
            {
                Console.WriteLine("Invalid age number..... Age must be between 0 and 100");
                age = byte.Parse(Console.ReadLine());
            }
            Console.Write("Gender: m/f?");
            char gender = char.Parse(Console.ReadLine());
            while (gender != 'm' && gender != 'f')
            {
                Console.WriteLine("Invalid gender... m = male; f = Female");
                gender = char.Parse(Console.ReadLine());
            }
            Console.Write("ID:");
            ulong ID = ulong.Parse(Console.ReadLine());
            Console.Write("Employee Number:");
            uint employeeNumber = uint.Parse(Console.ReadLine());
            while (employeeNumber < 27560000 || employeeNumber > 27569999)
            {
                Console.WriteLine("Employee Number must be between 27560000 and 27569999");
                employeeNumber = uint.Parse(Console.ReadLine());
            }
            Console.WriteLine(firstName);
            Console.WriteLine(secondName);
            Console.WriteLine(age);
            Console.WriteLine(gender);
            Console.WriteLine(ID);
            Console.WriteLine(employeeNumber);
        }
    }
}
