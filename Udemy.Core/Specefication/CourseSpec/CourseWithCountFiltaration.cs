using Udemy.Core.Entities;

namespace Udemy.Core.Specefication.CourseSpec
{
    public class CourseWithCountFiltaration:BaseSpecefication<Course>
    {
        public CourseWithCountFiltaration(CourseSpecParamter specParameter)
           : base(
                p =>
                (string.IsNullOrEmpty(specParameter.Search) || p.Name.ToLower().Trim().Contains(specParameter.Search))
                &&
                (!specParameter.CategoryId.HasValue || p.CategoryId == specParameter.CategoryId)
                &&
                (string.IsNullOrEmpty(specParameter.AppUserId) || p.AppUserId == specParameter.AppUserId)

            )
        {

        }
    }
}
