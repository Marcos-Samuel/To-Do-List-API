using System.ComponentModel.DataAnnotations;

namespace To_Do_List_API.Dtos
{
    public class RegisterUserDto
    {
        [Required, MinLength(3), MaxLength(20)]
        public required string Username { get; set; }

        [Required, MinLength(6)]
        public required string Password { get; set; }
    }
}
