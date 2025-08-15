using Microsoft.EntityFrameworkCore;
using To_Do_List_API.Context;
using To_Do_List_API.Dtos;
using To_Do_List_API.Entities;
using To_Do_List_API.Services.Interface;

namespace To_Do_List_API.Services
{
    public class TaskIService : ITaskService
    {
        private readonly AppDbContext _context;

        public TaskIService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TaskItem> CreateTaskAsync(CreateTaskDto taskDto)
        {
            var taskEntity = new TaskItem
            {
                Title = taskDto.Title,
                Description = taskDto.Description,
                Category = taskDto.Category,
                IsCompleted = taskDto.IsCompleted,
                UserId = taskDto.UserId,
                CreatedAt = DateTime.UtcNow
            };

            _context.Tasks.Add(taskEntity);
            await _context.SaveChangesAsync();

            return taskEntity;
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return false;

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<TaskSummaryDto> GetAllTasksAsync(string? name, bool? isCompleted, CategoryTask? category)
        {
            var query = _context.Tasks.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(t => t.Title.Contains(name));

            if (isCompleted.HasValue)
                query = query.Where(t => t.IsCompleted == isCompleted.Value);

            if (category.HasValue)
                query = query.Where(t => t.Category == category.Value);

            var tasks = await query.ToListAsync();

            var total = tasks.Count;
            var completed = tasks.Count(t => t.IsCompleted);
            var percentage = total > 0 ? (completed / (double)total) * 100 : 0;

            return new TaskSummaryDto
            {
                Tasks = tasks,
                CompletionPercentage = percentage
            };
        }

        public async Task<TaskItem?> GetTaskByIdAsync(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task<TaskItem?> UpdateTaskAsync(int id, TaskItem task)
        {
           
            var existingTask = await _context.Tasks.FindAsync(id);
            if (existingTask == null) return null;

            existingTask.Title = task.Title;
            existingTask.Description = task.Description;
            existingTask.IsCompleted = task.IsCompleted;
            existingTask.Category = task.Category;

            await _context.SaveChangesAsync();
            return existingTask;
        }

        public async Task<IEnumerable<TaskItem>> GetLastTasksAsync()
        {
            return await _context.Tasks
                .OrderByDescending(t => t.CreatedAt)
                .Take(2)
                .ToListAsync();
        }
    }
}
