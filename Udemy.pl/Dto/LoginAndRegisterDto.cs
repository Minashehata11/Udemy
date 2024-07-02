using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Udemy.pl.Dto
{
    public class LoginAndRegisterDto
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
