using System;

namespace _02.Print_Company_Information
{
    class CompanyInfo
    {
        static void Main()
        {
            string[] companyInfo = new string[8];
            uint age;
            Console.Write("Company name: ");
            companyInfo[0] = Console.ReadLine();
            Console.Write("Company address: ");
            companyInfo[1] = Console.ReadLine();
            Console.Write("Phone number:");
            companyInfo[2] = Console.ReadLine();
            Console.Write("Fax number: ");
            companyInfo[3] = Console.ReadLine();
            Console.Write("Web site: ");
            companyInfo[4] = Console.ReadLine();
            Console.Write("Manager first name: ");
            companyInfo[5] = Console.ReadLine();
            Console.Write("Manager last name: ");
            companyInfo[6] = Console.ReadLine();
            Console.Write("Manager age: ");
            age = uint.Parse(Console.ReadLine());
            Console.Write("Manager phone: ");
            companyInfo[7] = Console.ReadLine();

            Console.WriteLine(companyInfo[0]);
            Console.WriteLine("Address: {0}",companyInfo[1]);
            Console.WriteLine("Tel: {0}",companyInfo[2]);
            Console.WriteLine("Fax: ", companyInfo[3]);
            Console.WriteLine("Web site: {0}", companyInfo[4]);
            Console.WriteLine("Manager: {0} {1} (age: {2}, tel. {3}",companyInfo[5],companyInfo[6],age,companyInfo[7]);
        }
    }
}
