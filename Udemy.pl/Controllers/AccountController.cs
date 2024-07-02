using Microsoft.AspNetCore.Identity;
using Udemy.Core.Entities.Identity;
using Udemy.Core.Services;
using Udemy.Repository.Data;

namespace Udemy.pl.Controllers
{
    public class AccountController : BaseController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly ITokenServices _tokenServices;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AccountController> _loggerFactory;

        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager,IMapper mapper,ITokenServices tokenServices,IUnitOfWork unitOfWork,ILogger<AccountController> loggerFactory)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _tokenServices = tokenServices;
            _unitOfWork = unitOfWork;
            _loggerFactory = loggerFactory;
        }
        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> Register([FromForm ]LoginAndRegisterDto input)
        {
            if(!ModelState.IsValid)
                return BadRequest(new ErrorApiResponse(400,"Please Fill All Required"));
            AppUser user = new AppUser()
            {
                Email = input.Email,
                UserName = input.Email.Split('@')[0],

            };
            var result = await _userManager.CreateAsync(user,input.Password);
            if (!result.Succeeded)
                return BadRequest(new ErrorApiResponse(400,"ERROR Pass Or Duplicate UserName"));
             await  _userManager.AddToRoleAsync(user,Roles.Trainee);
             
            trainee trainee = new trainee()
            {
                AppUser = user,
                IsActive = true,
                Name=user.UserName,
                
            };
            try
            {
              _unitOfWork.Repository<trainee>().Add(trainee);   
             await _unitOfWork.CompleteAsync(); 

            }
            catch (Exception ex)
            {
                _loggerFactory.LogError(ex.Message);
                return BadRequest(new ErrorApiResponse(400,ex.Message));
            }
            var useRoles = await _userManager.GetRolesAsync(user);

            return Ok(new UserDto
            {
                Email = user.Email,
                Name = user.UserName,
                Token = await _tokenServices.GenerateToken(user, _userManager),
                Roles= useRoles

            }) ;
        }
        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login([FromForm]LoginAndRegisterDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user is null)
                return Unauthorized(new ErrorApiResponse(401, "Not Found Email Create One"));
            var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);
            if (!result.Succeeded)
                return Unauthorized(new ErrorApiResponse(401));
            var useRoles = await _userManager.GetRolesAsync(user);

            return Ok(new UserDto
            {
                Email = dto.Email,
                Name = user.UserName,
                Token = await _tokenServices.GenerateToken(user, _userManager),
                Roles= useRoles

            });


        }
    }
}
