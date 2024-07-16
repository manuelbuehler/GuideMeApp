using System.ComponentModel.DataAnnotations;

namespace GuideMeApp.Shared.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
