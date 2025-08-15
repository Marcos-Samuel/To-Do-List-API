using System.ComponentModel.DataAnnotations;


namespace To_Do_List_API.Entities
{
    public class User
    {

        public int Id { get; init; }

        [Required(ErrorMessage = "O Username é obrigatório.")]
        public required string Username { get; set; }


        [Required(ErrorMessage = "A senha  é obrigatório.")]
        public required string Password { get; set; }


        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();


        public DateTime CreatedAt { get; set; }

    }
}
