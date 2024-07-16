namespace GuideMeApp.Shared.Models
{
    public class Address : Microsoft.Azure.Management.EdgeGateway.Models.Address
    {
        public string PostalCodeCity
        {
            get => $"{PostalCode} {City}";
        }

        public string AddressString
        {
            get => $"{AddressLine1}, {PostalCodeCity}";
        }
    }
}
