# nullable disable

using System.ComponentModel.DataAnnotations.Schema;

namespace GuideMeApp.Models
{
    [Table ("Address")]
    public class Address : BaseEntity
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }

        public string PostalCodeCity { get => $"{PostalCode} {City}";}
    }
}
