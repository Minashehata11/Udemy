using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Talabate.PL.ErrorsHandle;
using Udemy.Core.Services;
using Udemy.Repository;
using Udemy.Services;

namespace Udemy.pl.Extention
{
    public static class ServiceApplication
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection Services,IConfiguration configuration)
        {
            Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            Services.AddScoped<IUnitOfWork, UnitOfWork>();
            Services.AddScoped<ITokenServices, TokenServices>();

            Services.AddAutoMapper(typeof(MapperProfile));
            Services.Configure<ApiBehaviorOptions>(option =>
            {
                option.InvalidModelStateResponseFactory = (actionContext) =>
                {
                    var errors = actionContext.ModelState.Where(p => p.Value.Errors.Count() > 0)
                                             .SelectMany(p => p.Value.Errors)
                                             .Select(e => e.ErrorMessage)
                                             .ToArray();
                    var validtionErrorResponse = new ApiValidtionErrorRespones()
                    {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(validtionErrorResponse);
                };
            }
            );
            Services.AddAuthentication(Option =>
            {
                Option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                Option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(Option =>
            {
                Option.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer =  configuration["JWT:ValidIssuer"],
                    ValidateAudience = true,
                    ValidAudience = configuration["JWT:ValidAudience"],
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWt:Key"]))
                };

            });
           Services.AddAuthorization();
            return Services;
        }
    }
}