using To_Do_List_API.Entities;

namespace To_Do_List_API.Dtos
{
    public class TaskSummaryDto
    {
        public required IEnumerable<TaskItem> Tasks { get; set; }
        public double CompletionPercentage { get; set; }
    }
}
