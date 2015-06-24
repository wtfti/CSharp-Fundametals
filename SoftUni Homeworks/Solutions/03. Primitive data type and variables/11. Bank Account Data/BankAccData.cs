using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Bank_Account_Data
{
    class BankAccData
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Acc holder name: First/Middle/Last Name");
            string firstName = Console.ReadLine();
            string middleName = Console.ReadLine();
            string lastName = Console.ReadLine();
            Console.Write("Money Balanse: ");
            decimal balance = decimal.Parse(Console.ReadLine());
            Console.Write("Bank name: ");
            string bankName = Console.ReadLine();
            Console.Write("IBAN: ");
            string IBAN = Console.ReadLine();
            Console.WriteLine("3 Credit card Numbers: ");
            ulong[] credit = new ulong[3];
            Console.Write("First credit card number: ");
            credit[0] = ulong.Parse(Console.ReadLine());
            Console.Write("Second credit card number: ");
            credit[1] = ulong.Parse(Console.ReadLine());
            Console.Write("Third credit card number: ");
            credit[2] = ulong.Parse(Console.ReadLine());
        }
    }
}
