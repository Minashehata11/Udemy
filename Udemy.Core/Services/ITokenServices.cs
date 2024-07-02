using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.Entities.Identity;

namespace Udemy.Core.Services
{
    public interface ITokenServices
    {
        Task<string> GenerateToken(AppUser user, UserManager<AppUser> userManager);
    }
}
