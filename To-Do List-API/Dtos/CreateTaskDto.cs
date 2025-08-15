using System.ComponentModel.DataAnnotations;
using To_Do_List_API.Entities;

namespace To_Do_List_API.Dtos
{
    public record CreateTaskDto
    {
        [Required,MinLength(3),MaxLength(20)]
        public required string Title { get; set; }


        [MaxLength(40)]
        public string? Description { get; set; }

        [Required]
        public bool IsCompleted { get; set; }

        [Required]
        public CategoryTask Category { get; set; }

        [Required]
        public required int UserId { get; set; }
}
}
