# nullable disable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuideMeApp.Shared.Models
{
    public class Trip : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public byte[] Image { get; set; }

        [Required]
        public int GuideId { get; set; }
        public User Guide { get; set; }

        [Required]
        public Address Address { get; set; }
    }
}
