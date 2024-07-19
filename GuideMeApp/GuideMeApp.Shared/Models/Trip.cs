# nullable disable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuideMeApp.Shared.Models
{
    public class Trip : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        [Display(Prompt = "Titel")]
        public string Title { get; set; }

        [MaxLength(500)]
        [Display(Prompt = "Beschreibung")]
        public string Description { get; set; }

        [Required]
        [Display(Prompt = "Datum")]
        public DateTime Date { get; set; }

        [Required]
        public byte[] Image { get; set; }

        [Required]
        public int GuideId { get; set; }
        public User Guide { get; set; }

        [Required]
        [Display(Prompt = "Addresse")]
        public Address Address { get; set; }

        [NotMapped]
        public string DateTimeString => Date.ToString("dd.MM.yyyy | HH:mm"); 

        [NotMapped]
        public string DateString => Date.ToString("dd.MM.yyyy");
    }
}
