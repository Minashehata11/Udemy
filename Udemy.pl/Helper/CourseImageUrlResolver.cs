namespace Udemy.pl.Helper
{
    public class CourseImageUrlResolver : IValueResolver<Course, CourseDto, string>
    {
        private readonly IConfiguration _configuration;

        public CourseImageUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(Course source, CourseDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.Post))
                return $"{_configuration["ApiBaseResolver"]}{"Files/Images/"}{source.Post}";
            else
                return string.Empty ;  
        }
    }
}
