using System.Net;
using company_house_consume.ResponseModels;
using Newtonsoft.Json;

namespace company_house_consume
{
    public static class ApiHelper
    {
        private const string ApiBaseUrl = "https://api.companieshouse.gov.uk";

        public static SearchResponseModel GetCompaniesByName(string name)
        {
            var response = SetupWebClient().DownloadString(ApiBaseUrl + "/search/companies?q=" + name);
            return JsonConvert.DeserializeObject<SearchResponseModel>(response);
        }

        public static CompanyByNumberResponseModel GetCompanyByCompanyNumber(string number)
        {
            var response = SetupWebClient().DownloadString(ApiBaseUrl + "/company/" + number);
            return JsonConvert.DeserializeObject<CompanyByNumberResponseModel>(response);
        }

        private static WebClient SetupWebClient()
        {
            var client = new WebClient();
            client.Headers.Add("Authorization",
                System.IO.File.ReadAllText("api-key.txt"));
            return client;
        }
    }
}