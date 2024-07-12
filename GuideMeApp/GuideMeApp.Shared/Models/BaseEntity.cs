using System.ComponentModel.DataAnnotations;

namespace GuideMeApp.Shared.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}
