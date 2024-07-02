using Microsoft.AspNetCore.Identity;

namespace Udemy.Core.Entities.Identity
{
    public class AppUser:IdentityUser
    {
        public DateTime  CreationDate { get; set; }=DateTime.Now;
       

    }
}
