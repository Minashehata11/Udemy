using Udemy.Repository.Data;

namespace Udemy.pl.Dto
{
    public class UserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
