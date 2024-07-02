
using Microsoft.AspNetCore.Authorization;
namespace Udemy.pl.Controllers
{

    public class CourseController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CourseController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet("GetAllCourses")]
        [ProducesResponseType(typeof(CourseDto),200)]
        public async Task<ActionResult<IReadOnlyList<Pagination<CourseDto>>>> GetAllCourseWithSpec([FromQuery]CourseSpecParamter paramter)
        {
            var specs =  new CourseWithCategorySpecfication(paramter);
            var courses= await _unitOfWork.Repository<Course>().GetAllWithSpecAsync(specs);
            var mappedData= _mapper.Map<IReadOnlyList<CourseDto>>(courses);
            var count = await _unitOfWork.Repository<Course>().GetCountWithSpecsAsync(new CourseWithCountFiltaration(paramter));
            return Ok(new Pagination<CourseDto>(paramter.PageSize,paramter.PageIndex,mappedData,count));
        }
        [HttpGet("GetCourseById")]
        [ProducesResponseType(400)]

        public async Task<ActionResult<CourseDto>> GetById(int id)
        {
            var specs = new CourseWithCategorySpecfication(id);
            var course=await _unitOfWork.Repository<Course>().GetByIdWithSpecsAsync(specs);
            if (course == null)
                return NotFound(new ErrorApiResponse(404) );
            var mappedCourse = _mapper.Map<CourseDto>(course);
            return Ok(mappedCourse);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            var course = await _unitOfWork.Repository<Course>().GetByIdAsync(id);
            if (course == null)
                return NotFound(new ErrorApiResponse(404));
             _unitOfWork.Repository<Course>().Delete(course);
            await _unitOfWork.CompleteAsync();
            return Ok();
        }

    }
}
