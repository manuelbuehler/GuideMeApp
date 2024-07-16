#nullable disable

using AgeCalculator;
using AgeCalculator.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuideMeApp.Shared.Models
{
    public class User : BaseEntity
    {
        [Required(ErrorMessage = "Ungültiger Vorname. Bitte geben Sie einen Vornamen an.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Ungültiger Nachname. Bitte geben Sie einen Nachnamen an.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Ungültiges Geburtsdatum. Bitte geben Sie ein Geburtsdatum an.")]
        public DateTime BirthDate { get; set; }

        public UserGroups UserGroup { get; set; }

        public byte[] Image { get; set; }

        [Required]
        public int RoleId { get; set; }
        public Role Role { get; set; }

        [Required]
        public int UserSettingId { get; set; }
        public UserSetting UserSetting { get; set; }

        [Required]
        public Address Address { get; set; }


        [NotMapped]
        public string Fullname
        {
            get => $"{FirstName} {LastName}";
        }

        [NotMapped]
        public int Age
        {
            get => BirthDate.CalculateAge(DateTime.Now).Years;
        }
    }
}
