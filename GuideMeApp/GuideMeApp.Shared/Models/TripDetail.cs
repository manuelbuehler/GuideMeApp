#nullable disable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuideMeApp.Shared.Models
{
    public class TripDetail : BaseEntity
    {
        [Required]
        public Guid UserId { get; set; }
        public User User { get; set; }


        [Range(0, 5)]
        public int Rating { get; set; }
    }
}
