# nullable disable

using System.ComponentModel.DataAnnotations.Schema;

namespace GuideMeApp.Models
{
    [Table ("Trip")]
    public class Trip : BaseEntity
    { 
        public string Title { get; set; }

        public string Description { get; set; } 

        public DateTime Date { get; set; }

        public byte[] Image { get; set; }

        public Guid GuideId { get; set; }
        //public User Guide { get; set; }

        public Guid AddressId { get; set; }
        //public Address Address { get; set; }
    }
}
