using company_house_consume.ResponseModels;

namespace company_house_consume.Models
{
    public class Company
    {
        public string Name;
        public string CompanyNumber;
        public Address Address;

        public Company(SearchResponseCompanyModel src)
        {
            Name = src.Title;
            CompanyNumber = src.Company_Number;
            Address = src.Address;
        }

        public Company(CompanyByNumberResponseModel cbnr)
        {
            Name = cbnr.Company_Name;
            CompanyNumber = cbnr.Company_Number;
            Address = cbnr.Registered_Office_Address;
        }
    }
}