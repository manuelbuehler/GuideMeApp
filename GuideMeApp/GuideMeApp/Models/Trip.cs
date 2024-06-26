# nullable disable

namespace GuideMeApp.Models
{
    public class Trip : BaseEntity
    { 
        public string Title { get; set; }

        public string Description { get; set; } 

        public byte[] Image { get; set; }

        public Guid GuideId { get; set; }
        public User Guide { get; set; }
    }
}
