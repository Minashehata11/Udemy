using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Udemy.Core.Entities.Identity;

namespace Udemy.pl.Controllers
{

    public class TrainerController : BaseController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;

        public TrainerController(UserManager<AppUser> userManager,IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }
        [HttpPost("AddCourse")]
        public async Task<ActionResult> AddNewCourse([FromForm]CreateCourseDto  dto)
        {
       
            var trainer= await  GetCurrentUser();
              
            Course course = new Course
            {
                CategoryId = dto.CategoryId,
                Description = dto.Description,
                Name = dto.Name,
                AppUserId = trainer.Id,
                Post=DocumentSetting.UplouadFile(dto.PostImage,"Images")
            };
             _unitOfWork.Repository<Course>().Add(course);
             await _unitOfWork.CompleteAsync();
            return Ok();
        }
        [Authorize(Roles ="Trainer")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var trainer= await  GetCurrentUser();
            var spec = new CourseWithCategorySpecfication(id);
           Course course= await _unitOfWork.Repository<Course>().GetByIdWithSpecsAsync(spec);
            if (course == null)
                return NotFound(new ErrorApiResponse(400));
            if(!(course.AppUserId== trainer.Id))
                return Unauthorized(new ErrorApiResponse(403,"Cant Delete This Course"));
            _unitOfWork.Repository<Course>().Delete(course);
            await _unitOfWork.CompleteAsync();
            return Ok();
        }

        private async Task<AppUser> GetCurrentUser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            return await _userManager.FindByEmailAsync(email);
        }
    }
}
