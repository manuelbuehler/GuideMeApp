#nullable disable

using System.ComponentModel.DataAnnotations;

namespace GuideMeApp.Models
{
    public class User : BaseEntity
    {
        [Required (ErrorMessage = "Ungültiger Vorname. Bitte geben Sie einen Vornamen an.")]
        public string FirstName { get; set; }

        [Required (ErrorMessage = "Ungültiger Vorname. Bitte geben Sie einen Vornamen an.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Ungültiges Geburtsdatum. Bitte geben Sie ein Geburtsdatum an.")]
        public DateTime BirthDate { get; set; }

        public UserGroups UserGroup { get; set; }

        public byte[] Image { get; set; }

        public Guid RoleId { get; set; }
        public Role Role { get; set; }

        public Guid UserSettingId { get; set; }
        public UserSetting UserSetting { get; set; }

        public Guid AddressId { get; set; } 
        public Address Address { get; set; }
    }
}
