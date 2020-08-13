using company_house_consume.Models;

namespace company_house_consume.ResponseModels
{
    public class CompanyByNumberResponseModel
    {
        public string Company_Name { get; set; }
        public string Company_Number { get; set; }
        public Address Registered_Office_Address { get; set; }
    }
}