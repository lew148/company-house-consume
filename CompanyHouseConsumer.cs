using System.Collections.Generic;
using System.Linq;
using company_house_consume.Models;

namespace company_house_consume
{
    public static class CompanyHouseConsumer
    {
        public static List<Company> Search(string companyName)
        {
            return ApiHelper.GetCompaniesByName(companyName).Items
                .Select(c => new Company(c))
                .ToList();
        }
        
        public static Company GetGivenCompany(string companyNumber)
        {
            return new Company(ApiHelper.GetCompanyByCompanyNumber(companyNumber));
        }
    }
}