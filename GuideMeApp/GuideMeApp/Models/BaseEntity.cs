using System.ComponentModel.DataAnnotations;

namespace GuideMeApp.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
