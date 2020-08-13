using System.Collections.Generic;
using company_house_consume.Models;

namespace company_house_consume.ResponseModels
{
    public class SearchResponseModel
    {
        public IEnumerable<SearchResponseCompanyModel> Items { get; set; }
    }

    public class SearchResponseCompanyModel
    {
        public string Title { get; set; }
        public string Company_Number { get; set; }
        public Address Address { get; set; }
    }
}