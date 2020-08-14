using System.Collections.Generic;
using company_house_consume.Models;

namespace company_house_consume.Services
{
    public static class ChangeService
    {
        public static IDictionary<string, Change> GetChangesToCompany(Company company)
        {
            var apiCompany = new Company(ApiHelper.GetCompanyByCompanyNumber(company.CompanyNumber));
            
            return !company.Equals(apiCompany)
                ? CreateChangeDict(company, apiCompany)
                : null;
        }

        private static IDictionary<string, Change> CreateChangeDict(Company originalCompany, Company apiCompany)
        {
            var changeDict = new Dictionary<string, Change>();
            AddChangedPropertiesToDict(changeDict, originalCompany, apiCompany);
            return changeDict;
        }

        private static void AddChangedPropertiesToDict<T>(IDictionary<string, Change> dict, T original, T api)
        {
            var props = typeof(T).GetProperties();

            foreach (var prop in props)
            {
                var originalValue = prop.GetValue(original);
                var apiValue = prop.GetValue(api);

                switch (originalValue)
                {
                    case string originalString when !originalString.Equals(apiValue):
                        dict.Add(prop.Name, new Change
                        {
                            OriginalValue = originalString,
                            NewValue = (string) apiValue
                        });
                        break;
                    case Address originalAddress:
                        AddChangedAddressPropertiesToDict(dict, originalAddress, apiValue as Address);
                        break;
                }
            }
        }

        private static void AddChangedAddressPropertiesToDict(
            IDictionary<string, Change> dict,
            Address original,
            Address api) => AddChangedPropertiesToDict(dict, original, api);
        }
}