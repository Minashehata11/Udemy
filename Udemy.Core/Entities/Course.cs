using Udemy.Core.Entities.Identity;

namespace Udemy.Core.Entities
{
    public class Course:BaseEntity
    {
        public DateTime CustomDate { get; set; }
        public string Description { get; set; }
        public Category? Category { get; set; }
        public int CategoryId { get; set; }
        public AppUser  AppUser { get; set; }
        public string AppUserId { get; set; }
        public string? Post { get; set; }
    }
}
