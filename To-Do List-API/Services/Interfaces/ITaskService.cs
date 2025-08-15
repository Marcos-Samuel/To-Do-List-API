using To_Do_List_API.Dtos;
using To_Do_List_API.Entities;

namespace To_Do_List_API.Services.Interface
{
    public interface ITaskService
    {
        Task<TaskSummaryDto> GetAllTasksAsync(string? name = null, bool? isCompleted = null, CategoryTask? category = null);

        Task<IEnumerable<TaskItem>> GetLastTasksAsync();

        Task<TaskItem?> GetTaskByIdAsync(int id);

        Task<TaskItem> CreateTaskAsync(CreateTaskDto taskDto);

        Task<TaskItem?> UpdateTaskAsync(int id, TaskItem taskItem);

        Task<bool> DeleteTaskAsync(int id);
       
    }
}
