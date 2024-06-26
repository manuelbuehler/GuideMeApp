#nullable disable

using System.ComponentModel.DataAnnotations;

namespace GuideMeApp.Models
{
    public class TripDetail : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }

        public DateTime Date { get; set; }

        [Range(0, 5)]
        public int Rating { get; set; }
    }
}
