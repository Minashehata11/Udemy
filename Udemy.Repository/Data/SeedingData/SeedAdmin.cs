using Microsoft.AspNetCore.Identity;
using Udemy.Core.Entities.Identity;

namespace Udemy.Repository.Data.SeedingData
{
    public static class SeedAdmin
    {
        public async static Task CreateUser(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                AppUser user = new AppUser()
                {
                    Email = "Mina@Gmail.com",
                    UserName = "Mayno",
                    PhoneNumber = "01225666903",
                };
               await userManager.CreateAsync(user,"P@ssW0rd");
                await userManager.AddToRoleAsync(user,Roles.Admin);
            }
        }
    }
}
