using System;

namespace company_house_consume
{
    class Program
    {
        static void Main(string[] args)
        {
            var cs = CompanyHouseConsumer.Search("Hello Limited");
            var c = CompanyHouseConsumer.GetGivenCompany("11789276");
            
            Console.Out.WriteLine("done");
        }
    }
}