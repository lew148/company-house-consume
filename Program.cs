using System;
using System.Collections.Generic;
using company_house_consume.Models;
using company_house_consume.Services;

namespace company_house_consume
{
    class Program
    {
        private const string CompanyNameToSearch = "Hello Limited";
        private const string CompanyNumberToFind = "11789276";
        
        static void Main(string[] args)
        {
            var companies = CompanyHouseConsumerService.Search(CompanyNameToSearch);
            var company = CompanyHouseConsumerService.GetGivenCompany(CompanyNumberToFind);
            
            var company2 = CompanyHouseConsumerService.GetGivenCompany(CompanyNumberToFind);
            company2.Name = "changed name";
            company2.Address.Postal_Code = "changed postal address";
            var ch = CompanyHouseConsumerService.GetChanges(company2);
            
            Console.WriteLine();
            PrintCompanySearchToConsole(companies);
            Console.WriteLine();
            PrintCompanyToConsole(company);
            Console.WriteLine();
            PrintChangesToConsole(ch);
        }

        private static void PrintChangesToConsole(IDictionary<string, Change> ch)
        {
            Console.WriteLine("Changes:");
            foreach (var (key, value) in ch)
            {
                Console.WriteLine($"Key = {key}");
                Console.WriteLine("Value:");
                Console.WriteLine($"> Original Value: {value.OriginalValue}");
                Console.WriteLine($"> New Value: {value.NewValue}");
            }
        }

        private static void PrintCompanyToConsole(Company company)
        {
            Console.WriteLine($"Company found with company number \"{CompanyNumberToFind}\":");
            Console.WriteLine($"> Name: {company.Name}");
            Console.WriteLine($"> Company Number: {company.CompanyNumber}");
            Console.WriteLine("> Address:");
            Console.WriteLine($"> Address Line 1: {company.Address.Address_Line_1}");
            Console.WriteLine($"> Postal Code: {company.Address.Postal_Code}");
            Console.WriteLine($"> Locality: {company.Address.Locality}");
            Console.WriteLine($"> Premises: {company.Address.Premises}");
            Console.WriteLine($"> Country: {company.Address.Country}");
        }

        private static void PrintCompanySearchToConsole(IEnumerable<Company> companies)
        {
            Console.WriteLine($"Companies found with search \"{CompanyNameToSearch}\":");
            foreach (var c in companies)
            {
                Console.WriteLine($"> {c.Name}");
            }
        }
    }
}