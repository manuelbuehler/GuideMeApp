# nullable disable

using System.ComponentModel.DataAnnotations.Schema;

namespace GuideMeApp.Models
{
    [Table ("Role")]
    public class Role : BaseEntity
    {
        public string Name { get; set; }
    }
}
