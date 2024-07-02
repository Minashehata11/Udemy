using Udemy.Core.Entities;

namespace Udemy.Core.Specefication.CourseSpec
{
    public class CourseWithCategorySpecfication:BaseSpecefication<Course>
    {
        public CourseWithCategorySpecfication(CourseSpecParamter specParameter)
            : base(
                 p =>
                 (string.IsNullOrEmpty(specParameter.Search) || p.Name.ToLower().Trim().Contains(specParameter.Search))
                 &&
                 (!specParameter.CategoryId.HasValue || p.CategoryId == specParameter.CategoryId)
                 &&
                 (string.IsNullOrEmpty(specParameter.AppUserId) || p.AppUserId == specParameter.AppUserId)

                 
             )
        {
            Includes.Add(p => p.Category);
            Includes.Add(p => p.AppUser);

            if (!string.IsNullOrEmpty(specParameter.Sort))
            {
                switch (specParameter.Sort)
                {
                    case "Name":
                        AddOrderBy(p => p.Name);
                        break;
                    case "NameDes":
                        AddOrderByDesc(p => p.Name);
                        break;
                  
                    default:
                        AddOrderBy(p => p.CustomDate);
                        break;
                }
            }
            AddPaginated(specParameter.PageSize * (specParameter.PageIndex - 1), specParameter.PageSize);
        }
        public CourseWithCategorySpecfication(int id) : base(p => p.Id == id)
        {
            Includes.Add(p => p.Category);
            Includes.Add(p => p.AppUser);


        }
    }
}
