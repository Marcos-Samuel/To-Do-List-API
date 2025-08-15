using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using To_Do_List_API.Dtos;
using To_Do_List_API.Entities;
using To_Do_List_API.Services.Interface;

namespace To_Do_List_API.Controllers
{
   
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TaskItemController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskItemController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("last")]
        public async Task<IActionResult> GetLastTasks()
        {
            var tasks = await _taskService.GetLastTasksAsync();
            return Ok(tasks);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks([FromQuery] string? name, [FromQuery] bool? isCompleted, [FromQuery] CategoryTask? category)
        {
            var tasks = await _taskService.GetAllTasksAsync(name, isCompleted, category);
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskDto dto)
        {
            var task = await _taskService.CreateTaskAsync(dto);
            return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] TaskItem taskItem)
        {
            var updatedTask = await _taskService.UpdateTaskAsync(id, taskItem);
            if (updatedTask == null) return NotFound();
            return Ok(updatedTask);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var deleted = await _taskService.DeleteTaskAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
