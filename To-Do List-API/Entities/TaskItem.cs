using System.ComponentModel.DataAnnotations;



namespace To_Do_List_API.Entities
{
    public class TaskItem
    {
        public int Id { get; init; }

        [Required(ErrorMessage = "O Title obrigatório.")]
        public required string Title { get; set; }


        public string? Description { get; set; }

        public CategoryTask Category { get; set; }

        [Required(ErrorMessage = "A Status da Tarefa precisa ser definido.")]
        public required bool IsCompleted { get; set; }


        [Required]
        public int UserId { get; set; }


        public User? User { get; set; }


        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
