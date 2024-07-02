using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.Entities.Identity;
using Udemy.Core.Services;

namespace Udemy.Services
{
    public class TokenServices : ITokenServices
    {
        private readonly IConfiguration _configuration;

        public TokenServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> GenerateToken(AppUser user, UserManager<AppUser> userManager)
        {
            var authClaim = new List<Claim>()
            {
                new Claim(ClaimTypes.GivenName,user.UserName),
                new Claim(ClaimTypes.Email,user.Email)
            };
            var UserRoles = await userManager.GetRolesAsync(user);
            foreach (var role in UserRoles)
                authClaim.Add(new Claim(ClaimTypes.Role, role));
            var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWt:Key"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(double.Parse(_configuration["JWT:DurationInDays"])),
                claims: authClaim,
                signingCredentials: new SigningCredentials(authKey, SecurityAlgorithms.HmacSha256)

                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
