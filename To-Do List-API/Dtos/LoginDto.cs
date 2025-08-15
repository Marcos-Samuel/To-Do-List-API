
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace To_Do_List_API.Dtos
{
    public record LoginDto
    {
       
        public required string Username { get; set; }
        public required string Password { get; set; }

    }
}
