using System.Collections.Generic;
using System.Linq;
using company_house_consume.Models;

namespace company_house_consume.Services
{
    public static class CompanyHouseConsumerService
    {
        public static IEnumerable<Company> Search(string companyName)
        {
            return ApiHelper.GetCompaniesByName(companyName).Items
                .Select(c => new Company(c))
                .ToList();
        }

        public static Company GetGivenCompany(string companyNumber) => 
            new Company(ApiHelper.GetCompanyByCompanyNumber(companyNumber));

        public static IDictionary<string, Change> GetChanges(Company company) => ChangeService.GetChangesToCompany(company);
    }
}