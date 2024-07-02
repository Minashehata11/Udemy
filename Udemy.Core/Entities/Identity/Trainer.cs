namespace Udemy.Core.Entities.Identity
{
    public class Trainer:BaseEntity
    {
        public string Description { get; set; }
        public string Website { get; set; }
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
        

    }
}
