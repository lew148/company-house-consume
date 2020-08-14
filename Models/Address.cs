namespace company_house_consume.Models
{
    public class Address
    {
        public string Address_Line_1 { get; set; }
        public string Postal_Code { get; set; }
        public string Locality { get; set; }
        public string Premises { get; set; }
        public string Country { get; set; }

        public bool Equals(Address comparingAddress)
        {
            return Address_Line_1 == comparingAddress.Address_Line_1
                   && Postal_Code == comparingAddress.Postal_Code
                   && Locality == comparingAddress.Locality
                   && Premises == comparingAddress.Premises
                   && Country == comparingAddress.Country;
        }
    }
}