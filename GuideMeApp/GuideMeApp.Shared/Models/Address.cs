# nullable disable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuideMeApp.Shared.Models
{
    public class Address : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Street { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [StringLength(50)]
        public string State { get; set; }

        [Required]
        [StringLength(50)]
        public string Country { get; set; }

        [Required]
        [StringLength(20)]
        public string PostalCode { get; set; }

        [NotMapped]
        public string PostalCodeCity 
        { 
            get => $"{PostalCode} {City}";
        }

        [NotMapped]
        public string AddressString 
        {
            get => $"{Street}, {PostalCodeCity}";
        }
    }
}
