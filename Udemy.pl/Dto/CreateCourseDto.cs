using Udemy.Core.Entities.Identity;

namespace Udemy.pl.Dto
{
    public class CreateCourseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public IFormFile PostImage { get; set; }
    }
}
