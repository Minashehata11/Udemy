namespace Udemy.pl.Helper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Course, CourseDto>()
                .ForMember(dest => dest.CategoryName, src => src.MapFrom(c => c.Category.Name))
                .ForMember(dest => dest.TrainerName, src => src.MapFrom(c => c.AppUser.UserName))
                .ForMember(dest => dest.Post, src => src.MapFrom<CourseImageUrlResolver>());
                 ;
        }
    }
}
